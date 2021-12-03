using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using GameFramework;
using GameFramework.Event;
using GameFramework.Network;

namespace UnityGameFramework.Runtime.Extension
{
    public class NetworkChannelHelper : INetworkChannelHelper
    {
        private readonly Dictionary<int, Type> m_ServerToClientPacketTypes = new();
        private INetworkChannel m_NetworkChannel = null;

        private readonly MemoryStream m_SerializeStream = new(1024 * 8);
        private BinaryWriter m_SerializeWriter;

        private readonly MemoryStream m_DeserializeStream = new(1024 * 8);
        private BinaryReader m_DeserializeReader;

        private int m_PacketHeaderLength = 4;

        /// <summary>
        /// 获取消息包头长度，由 2 byte 包长度 2 byte 协议号组成。
        /// </summary>
        public int PacketHeaderLength => m_PacketHeaderLength;

        /// <summary>
        /// 初始化网络频道辅助器。
        /// </summary>
        /// <param name="networkChannel">网络频道。</param>
        public void Initialize(INetworkChannel networkChannel)
        {
            m_NetworkChannel = networkChannel;

            m_SerializeWriter = new(m_SerializeStream, Encoding.ASCII);
            m_DeserializeReader = new(m_DeserializeStream, Encoding.ASCII);

            // 反射注册包和包处理函数。
            Type packetBaseType = typeof(SCPacketBase);
            Type packetHandlerBaseType = typeof(PacketHandlerBase);
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (!types[i].IsClass || types[i].IsAbstract)
                {
                    continue;
                }

                if (types[i].BaseType == packetBaseType)
                {
                    PacketBase packetBase = (PacketBase) Activator.CreateInstance(types[i]);
                    Type packetType = GetServerToClientPacketType(packetBase.Id);
                    if (packetType != null)
                    {
                        Log.Warning("Already exist packet type '{0}', check '{1}' or '{2}'?.", packetBase.Id.ToString(),
                            packetType.Name, packetBase.GetType().Name);
                        continue;
                    }

                    m_ServerToClientPacketTypes.Add(packetBase.Id, types[i]);
                }
                else if (types[i].BaseType == packetHandlerBaseType)
                {
                    IPacketHandler packetHandler = (IPacketHandler) Activator.CreateInstance(types[i]);
                    m_NetworkChannel.RegisterHandler(packetHandler);
                }
            }

            Entry.Event.Subscribe(NetworkConnectedEventArgs.EventId, OnNetworkConnected);
            Entry.Event.Subscribe(NetworkClosedEventArgs.EventId, OnNetworkClosed);
            Entry.Event.Subscribe(NetworkMissHeartBeatEventArgs.EventId, OnNetworkMissHeartBeat);
            Entry.Event.Subscribe(NetworkErrorEventArgs.EventId, OnNetworkError);
            Entry.Event.Subscribe(NetworkCustomErrorEventArgs.EventId, OnNetworkCustomError);
        }

        /// <summary>
        /// 关闭并清理网络频道辅助器。
        /// </summary>
        public void Shutdown()
        {
            Entry.Event.Unsubscribe(NetworkConnectedEventArgs.EventId, OnNetworkConnected);
            Entry.Event.Unsubscribe(NetworkClosedEventArgs.EventId, OnNetworkClosed);
            Entry.Event.Unsubscribe(NetworkMissHeartBeatEventArgs.EventId, OnNetworkMissHeartBeat);
            Entry.Event.Unsubscribe(NetworkErrorEventArgs.EventId, OnNetworkError);
            Entry.Event.Unsubscribe(NetworkCustomErrorEventArgs.EventId, OnNetworkCustomError);

            m_NetworkChannel = null;
        }

        /// <summary>
        /// 准备进行连接。
        /// </summary>
        public void PrepareForConnecting()
        {
            m_NetworkChannel.Socket.ReceiveBufferSize = 1024 * 64;
            m_NetworkChannel.Socket.SendBufferSize = 1024 * 64;
        }

        /// <summary>
        /// 发送心跳消息包。
        /// </summary>
        /// <returns>是否发送心跳消息包成功。</returns>
        public bool SendHeartBeat()
        {
            CSPacket packet = ReferencePool.Acquire<CSPacket>();
            m_NetworkChannel.Send(packet);
            return true;
        }

        /// <summary>
        /// 序列化消息包。
        /// </summary>
        /// <typeparam name="T">消息包类型。</typeparam>
        /// <param name="packet">要序列化的消息包。</param>
        /// <param name="destination">要序列化的目标流。</param>
        /// <returns>是否序列化成功。</returns>
        public bool Serialize<T>(T packet, Stream destination) where T : Packet
        {
            CSPacket csPacket = packet as CSPacket;
            if (csPacket == null)
            {
                Log.Warning("Packet is invalid.");
                return false;
            }

            m_SerializeStream.Position = 0L;
            byte[] data = csPacket.ProtocolData;
            ushort packetLength = (ushort) (data?.Length ?? 0);
            ushort protocolId = csPacket.ProtocolId;
            // 写入长度 - 2 byte
            m_SerializeWriter.Write(packetLength);
            // 写入协议号 - 2 byte
            m_SerializeWriter.Write(protocolId);
            // 写入数据
            if (data != null)
            {
                m_SerializeWriter.Write(data);
            }

            Log.Debug("Sent: packet length {0}, protocol id {1}, protocol data {2}", packetLength, protocolId,
                BitConverter.ToString(m_SerializeStream.GetBuffer(), 0, (int) m_SerializeStream.Position));
            destination.Write(m_SerializeStream.GetBuffer(), 0, (int) m_SerializeStream.Position);
            return true;
        }

        /// <summary>
        /// 反序列化消息包头。
        /// </summary>
        /// <param name="source">要反序列化的来源流。</param>
        /// <param name="customErrorData">用户自定义错误数据。</param>
        /// <returns>反序列化后的消息包头。</returns>
        public IPacketHeader DeserializePacketHeader(Stream source, out object customErrorData)
        {
            // 注意：此函数并不在主线程调用！
            customErrorData = null;

            SCPacketHeader header = ReferencePool.Acquire<SCPacketHeader>();
            header.ProtocolId = 0;
            lock (m_DeserializeStream)
            {
                m_DeserializeStream.Position = 0L;
                byte[] buffer = m_DeserializeStream.GetBuffer();
                int offset = 0;
                int count;
                while ((count = source.Read(buffer, offset, m_PacketHeaderLength - offset)) != 0)
                {
                    offset += count;
                    if (offset == m_PacketHeaderLength)
                    {
                        break;
                    }
                }

                m_DeserializeStream.Position = 0L;
                header.PacketLength = m_DeserializeReader.ReadUInt16();
                header.ProtocolId = m_DeserializeReader.ReadUInt16();
                Log.Debug("Received header: packet length {0}, protocol id {1}, header {2}",
                    header.PacketLength, header.ProtocolId,
                    BitConverter.ToString(buffer, 0, m_PacketHeaderLength));
            }

            return header;
        }

        /// <summary>
        /// 反序列化消息包。
        /// </summary>
        /// <param name="packetHeader">消息包头。</param>
        /// <param name="source">要反序列化的来源流。</param>
        /// <param name="customErrorData">用户自定义错误数据。</param>
        /// <returns>反序列化后的消息包。</returns>
        public Packet DeserializePacket(IPacketHeader packetHeader, Stream source, out object customErrorData)
        {
            // 注意：此函数并不在主线程调用！
            customErrorData = null;

            if (!(packetHeader is SCPacketHeader scPacketHeader))
            {
                Log.Warning("Packet header is invalid.");
                return null;
            }

            SCPacket scPacket = ReferencePool.Acquire<SCPacket>();
            Type packetType = GetServerToClientPacketType(scPacketHeader.ProtocolId);
            if (packetType != null)
            {
                int packetLength = scPacketHeader.PacketLength;
                byte[] protocolData = new byte[packetLength];
                int offset = 0;
                int count;
                while ((count = source.Read(protocolData, offset, packetLength - offset)) != 0)
                {
                    offset += count;
                    if (offset == packetLength)
                    {
                        break;
                    }
                }

                scPacket.ProtocolId = scPacketHeader.ProtocolId;
                scPacket.ProtocolData = protocolData;
                Log.Debug("Received packet: protocol id {0}, protocol data {1}", scPacket.ProtocolId,
                    BitConverter.ToString(protocolData));
            }
            else
            {
                Log.Warning("Can not deserialize packet for packet id '{0}'.", scPacketHeader.ProtocolId.ToString());
            }

            ReferencePool.Release(scPacketHeader);
            return scPacket;
        }

        private Type GetServerToClientPacketType(int id)
        {
            return m_ServerToClientPacketTypes.TryGetValue(id, out var type) ? type : null;
        }

        private void OnNetworkConnected(object sender, GameEventArgs e)
        {
            NetworkConnectedEventArgs ne = (NetworkConnectedEventArgs) e;
            if (ne.NetworkChannel != m_NetworkChannel)
            {
                return;
            }

            Log.Info("Network channel '{0}' connected, local address '{1}', remote address '{2}'.",
                ne.NetworkChannel.Name, ne.NetworkChannel.Socket.LocalEndPoint.ToString(),
                ne.NetworkChannel.Socket.RemoteEndPoint.ToString());

            INetworkChannel networkChannel = ne.NetworkChannel;
            CSPacket csPacket = ReferencePool.Acquire<CSPacket>();
            csPacket.ProtocolData = new byte[] {1, 2, 3};
            networkChannel.Send(csPacket);
        }

        private void OnNetworkClosed(object sender, GameEventArgs e)
        {
            NetworkClosedEventArgs ne = (NetworkClosedEventArgs) e;
            if (ne.NetworkChannel != m_NetworkChannel)
            {
                return;
            }

            Log.Info("Network channel '{0}' closed.", ne.NetworkChannel.Name);
        }

        private void OnNetworkMissHeartBeat(object sender, GameEventArgs e)
        {
            NetworkMissHeartBeatEventArgs ne = (NetworkMissHeartBeatEventArgs) e;
            if (ne.NetworkChannel != m_NetworkChannel)
            {
                return;
            }

            Log.Info("Network channel '{0}' miss heart beat '{1}' times.", ne.NetworkChannel.Name,
                ne.MissCount.ToString());

            // Close network channel when miss count is two.
            if (ne.MissCount > 1)
            {
                ne.NetworkChannel.Close();
            }
        }

        private void OnNetworkError(object sender, GameEventArgs e)
        {
            NetworkErrorEventArgs ne = (NetworkErrorEventArgs) e;
            if (ne.NetworkChannel != m_NetworkChannel)
            {
                return;
            }

            Log.Info("Network channel '{0}' error, error code is '{1}', error message is '{2}'.",
                ne.NetworkChannel.Name, ne.ErrorCode.ToString(), ne.ErrorMessage);

            ne.NetworkChannel.Close();
        }

        private void OnNetworkCustomError(object sender, GameEventArgs e)
        {
            NetworkCustomErrorEventArgs ne = (NetworkCustomErrorEventArgs) e;
            if (ne.NetworkChannel != m_NetworkChannel)
            {
                return;
            }

            Log.Info("Network channel '{0}' custom error, custom error data is '{1}'.", ne.NetworkChannel.Name,
                ne.CustomErrorData.ToString());
        }
    }
}