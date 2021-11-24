using GameFramework.Network;

namespace UnityGameFramework.Runtime.Extension
{
    public abstract class PacketBase : Packet
    {
        protected PacketBase()
        {
        }

        public abstract PacketType PacketType { get; }
    }
}