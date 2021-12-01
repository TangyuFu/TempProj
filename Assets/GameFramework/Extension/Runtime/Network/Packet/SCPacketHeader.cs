namespace UnityGameFramework.Runtime.Extension
{
    public sealed class SCPacketHeader : PacketHeaderBase
    {
        public override PacketType PacketType => PacketType.ServerToClient;
    }
}