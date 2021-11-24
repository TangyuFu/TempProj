namespace UnityGameFramework.Runtime.Extension
{
    public class SCDefault : CSPacketBase
    {
        public SCDefault()
        {
        }

        public override int Id => 1;
        
        public byte[] Data { get; set; }

        public override void Clear()
        {
        }
    }
}