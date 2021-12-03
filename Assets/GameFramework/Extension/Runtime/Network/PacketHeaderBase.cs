using GameFramework;
using GameFramework.Network;

namespace UnityGameFramework.Runtime.Extension
{
    public abstract class PacketHeaderBase : IPacketHeader, IReference
    {
        public abstract PacketType PacketType { get; }

        /// <summary>
        /// 包长。
        /// </summary>
        public int PacketLength { get; set; }
        
        /// <summary>
        /// 协议号。
        /// </summary>
        public ushort ProtocolId { get; set; }

        public void Clear()
        {
            ProtocolId = 0;
            PacketLength = 0;
        }
    }
}