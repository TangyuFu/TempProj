using GameFramework;
using GameFramework.Network;

namespace UnityGameFramework.Runtime.Extension
{
    public abstract class PacketHeaderBase : IPacketHeader, IReference
    {
        public abstract PacketType PacketType { get; }

        public int Id { get; set; }

        public int PacketLength { get; set; }

        public void Clear()
        {
            Id = 0;
            PacketLength = 0;
        }
    }
}