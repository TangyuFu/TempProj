namespace UnityGameFramework.Runtime.Extension
{
    public abstract class CSPacketBase : PacketBase
    {
        public override PacketType PacketType => PacketType.ClientToServer;
    }
}