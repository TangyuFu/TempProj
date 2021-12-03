using System;
using GameFramework.Network;

namespace UnityGameFramework.Runtime.Extension
{
    public class SCPacketHandler : PacketHandlerBase
    {
        public override int Id => 0;

        public override void Handle(object sender, Packet packet)
        {
            SCPacket packetImpl = (SCPacket) packet;
            Log.Info("Received packet, protocol id {0} protocol data: '{1}'.",
                packetImpl.ProtocolId,
                packetImpl.ProtocolData != null ? BitConverter.ToString(packetImpl.ProtocolData) : "");
        }
    }
}