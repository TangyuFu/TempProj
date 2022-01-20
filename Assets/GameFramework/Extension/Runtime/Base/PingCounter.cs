using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// Ping 计数器。
    /// </summary>
    public class PingCounter
    {
        private readonly string m_IpAddress;
        private int m_Ping;
        private Ping m_UnityPing;

        public PingCounter(string ipAddress)
        {
            if (string.IsNullOrEmpty(ipAddress))
            {
                Log.Error($"Invalid ipAddress '{ipAddress}'.");
                return;
            }

            m_IpAddress = ipAddress;
            m_UnityPing = new Ping(m_IpAddress);
            m_Ping = 0;
        }

        /// <summary>
        /// Ping。
        /// </summary>
        public int Ping => m_Ping;

        /// <summary>
        /// 更新 Ping 。
        /// </summary>
        public void Update()
        {
            if (m_UnityPing is {isDone: true})
            {
                m_Ping = m_UnityPing.time;
                m_UnityPing = new Ping(m_IpAddress);
            }
        }

        /// <summary>
        /// 重置 Ping 计数器。
        /// </summary>
        public void Reset()
        {
            m_Ping = 0;
        }
    }
}