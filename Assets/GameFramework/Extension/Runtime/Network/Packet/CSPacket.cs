namespace UnityGameFramework.Runtime.Extension
{
    public class CSPacket : CSPacketBase
    {
        public CSPacket()
        {
        }

        public override int Id => 0;

        private ushort m_ProtocolId;

        /// <summary>
        /// 获取或设置协议号。
        /// </summary>
        public ushort ProtocolId
        {
            get => m_ProtocolId;
            set => m_ProtocolId = value;
        }
        
        private byte[] m_ProtocolData;

        /// <summary>
        /// 获取或设置协议数据。
        /// </summary>
        public byte[] ProtocolData
        {
            get => m_ProtocolData;
            set => m_ProtocolData = value;
        }

        public override void Clear()
        {
            m_ProtocolId = 0;
            m_ProtocolData = null;
        }
    }
}