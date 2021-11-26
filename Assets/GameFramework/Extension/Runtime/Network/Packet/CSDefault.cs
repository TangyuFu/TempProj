namespace UnityGameFramework.Runtime.Extension
{
    public class CSDefault : CSPacketBase
    {
        public CSDefault()
        {
        }

        public override int Id => 1;

        public byte[] Data { get; set; }
        

        public override void Clear()
        {
        }
    }
}