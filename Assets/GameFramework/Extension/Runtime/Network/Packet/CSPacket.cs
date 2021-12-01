namespace UnityGameFramework.Runtime.Extension
{
    public class CSPacket : CSPacketBase
    {
        public CSPacket()
        {
        }

        public override int Id => 0;

        private byte[] m_Data;

        public byte[] Data
        {
            get => m_Data;
            set => m_Data = value;
        }

        public override void Clear()
        {
            m_Data = null;
        }
    }
}