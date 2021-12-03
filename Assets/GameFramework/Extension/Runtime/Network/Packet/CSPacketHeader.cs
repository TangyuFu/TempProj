namespace UnityGameFramework.Runtime.Extension
{
    public sealed class CSPacketHeader : PacketHeaderBase
    {
        public override PacketType PacketType => PacketType.ClientToServer;
    }
}