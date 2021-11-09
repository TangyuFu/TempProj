using GameFramework;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 帧率计数器。
    /// </summary>
    public class FpsCounter
    {
        private float m_UpdateInterval;
        private float m_UpdateLeftTime;
        private float m_TimeSinceLastUpdate;
        private float m_FrameSinceLastUpdate;
        private float m_Fps;

        public FpsCounter(float updateInterval = 0.5f)
        {
            if (updateInterval < 0)
            {
                throw new GameFrameworkException($"Fps update interval '{updateInterval}' must be greater than 0.");
            }

            m_UpdateInterval = updateInterval;
            Reset();
        }

        /// <summary>
        /// Fps 更新间隔。
        /// </summary>
        public float UpdateInterval
        {
            get => m_UpdateInterval;
            set
            {
                if (value < 0)
                {
                    throw new GameFrameworkException($"Fps update interval '{value}' must be greater than 0.");
                }

                m_UpdateInterval = value;
                Reset();
            }
        }

        /// <summary>
        /// 帧率。
        /// </summary>
        public float Fps => m_Fps;

        /// <summary>
        /// 更新帧率。
        /// </summary>
        /// <param name="elapsedTime">游戏逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapsedTime">游戏真实流逝时间，以秒为单位。</param>
        public void Update(float elapsedTime, float realElapsedTime)
        {
            m_FrameSinceLastUpdate++;
            m_TimeSinceLastUpdate += realElapsedTime;
            m_UpdateLeftTime -= realElapsedTime;

            if (m_UpdateLeftTime <= 0f)
            {
                m_Fps = m_FrameSinceLastUpdate / m_TimeSinceLastUpdate;

                Reset();
            }
        }

        /// <summary>
        /// 重置帧率计数器。
        /// </summary>
        private void Reset()
        {
            m_UpdateLeftTime = m_UpdateInterval;
            m_TimeSinceLastUpdate = 0f;
            m_FrameSinceLastUpdate = 0;
        }
    }
}