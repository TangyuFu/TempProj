using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// Unity 游戏框架 Time 组件。
    /// 提供时间相关功能。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Time")]
    public class TimeComponent : CustomGameFrameworkComponent
    {
        [SerializeField] private bool m_EnableFakeTime = false;

        [SerializeField] private bool m_LocalTime = false;

        [SerializeField] private string m_FakeTime = "2020-05-01 00:00:00";

        private DateTime m_Now = default;

        private int m_FrameCount = 0;

        private double m_RealTimeSinceStartup = 0d;

        protected override void Awake()
        {
            base.Awake();
        }

        IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();
            m_FrameCount = UnityEngine.Time.frameCount;
            m_RealTimeSinceStartup = UnityEngine.Time.realtimeSinceStartupAsDouble;

            if (m_EnableFakeTime)
            {
                if (!DateTime.TryParse(m_FakeTime, out m_Now))
                {
                    m_Now = DateTime.Now;
                }
            }
            else
            {
                m_Now = GetNetworkTime();
                if (m_LocalTime)
                {
                    m_Now = m_Now.ToLocalTime();
                }
            }
        }

        /// <summary>
        /// 是否开启伪造时间。
        /// </summary>
        public bool EnableFakeTime => m_EnableFakeTime;

        /// <summary>
        /// 是否使用本地时间，一般使用世界时。使用 DateTime.SpecifyKind 对时间类型进行改造。
        /// </summary>
        public bool LocalTime => m_LocalTime;

        /// <summary>
        /// 伪造时间。
        /// </summary>
        public string FakeTime => m_FakeTime;

        /// <summary>
        /// 当前日期。
        /// </summary>
        public DateTime Now
        {
            get
            {
                if (m_FrameCount != UnityEngine.Time.frameCount)
                {
                    m_FrameCount = UnityEngine.Time.frameCount;
                    double realtimeSinceStartup = UnityEngine.Time.realtimeSinceStartupAsDouble;
                    m_Now = m_Now.AddSeconds(realtimeSinceStartup - m_RealTimeSinceStartup);
                    m_RealTimeSinceStartup = realtimeSinceStartup;
                }

                return m_Now;
            }
        }

        /// <summary>
        /// 当前帧数。
        /// </summary>
        public float FrameCount => UnityEngine.Time.frameCount;

        /// <summary>
        /// 时间缩放。
        /// </summary>
        public float TimeScale => UnityEngine.Time.timeScale;

        /// <summary>
        /// 上一帧到当前帧间隔时间，受 Time.timeScale 影响，以秒为单位。
        /// </summary>
        public float DeltaTime => UnityEngine.Time.deltaTime;

        /// <summary>
        /// 上一帧到当前帧间隔时间，不受 Time.timeScale 影响，以秒为单位。
        /// </summary>
        public float UnscaledDeltaTime => UnityEngine.Time.unscaledDeltaTime;

        /// <summary>
        /// 游戏开始到现在的运行时间间隔，受 Time.timeScale 影响，以秒为单位。
        /// </summary>
        public float Time => UnityEngine.Time.time;

        /// <summary>
        /// 游戏开始到现在的运行时间间隔，不受 Time.timeScale 影响，以秒为单位。
        /// </summary>
        public float UnscaledTime => UnityEngine.Time.unscaledTime;

        /// <summary>
        /// 游戏开始到现在的真实时间间隔，以秒为单位。
        /// </summary>
        public float RealtimeSinceStartup => UnityEngine.Time.realtimeSinceStartup;

        /// <summary>
        /// 获取当前世界时网络时间。
        /// </summary>
        /// <returns>当前世界时。</returns>
        private DateTime GetNetworkTime()
        {
            //default Windows time server
            const string ntpServer = "time.windows.com";

            // NTP message size - 16 bytes of the digest (RFC 2030)
            byte[] ntpData = new byte[48];

            //Setting the Leap Indicator, Version Number and Mode values
            ntpData[0] = 0x1B; //LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)

            IPAddress[] addresses = Dns.GetHostEntry(ntpServer).AddressList;

            //The UDP port number assigned to NTP is 123
            IPEndPoint ipEndPoint = new IPEndPoint(addresses[0], 123);
            //NTP uses UDP

            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                socket.Connect(ipEndPoint);

                //Stops code hang if NTP is blocked
                socket.ReceiveTimeout = 3000;

                socket.Send(ntpData);
                socket.Receive(ntpData);
                socket.Close();
            }

            //Offset to get to the "Transmit Timestamp" field (time at which the reply 
            //departed the server for the client, in 64-bit timestamp format."
            const byte serverReplyTime = 40;

            //Get the seconds part
            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

            //Get the seconds fraction
            ulong fractionPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

            //Convert From big-endian to little-endian
            intPart = SwapEndianness(intPart);
            fractionPart = SwapEndianness(fractionPart);

            ulong milliseconds = intPart * 1000 + fractionPart * 1000 / 0x100000000L;

            //**UTC** time
            DateTime networkDateTime =
                new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds((long) milliseconds);

            return networkDateTime;
        }

        uint SwapEndianness(ulong x)
        {
            return (uint) (((x & 0x000000ff) << 24) +
                           ((x & 0x0000ff00) << 8) +
                           ((x & 0x00ff0000) >> 8) +
                           ((x & 0xff000000) >> 24));
        }

        internal override int Priority => ComponentPriority.Time;

        internal override void Poll(float elapseSeconds, float realElapseSeconds)
        {
        }

        internal override void Shutdown()
        {
        }
    }
}