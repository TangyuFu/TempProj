namespace UnityGameFramework.Runtime.Extension
{
    public abstract class SCPacketBase : PacketBase
    {
        public override PacketType PacketType => PacketType.ServerToClient;
    }
}