namespace UnityGameFramework.Runtime.Extension
{
    public class SCPacket : SCPacketBase
    {
        public SCPacket()
        {
        }

        public override int Id => 0;
        
        public byte[] Data { get; set; }

        public override void Clear()
        {
        }
    }
}