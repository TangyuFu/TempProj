using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// Unity 游戏框架视频组件。
    /// 提供视频播放、暂停等管理功能。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Video")]
    public sealed class VideoComponent : CustomGameFrameworkComponent
    {
        /// <summary>
        /// 初始化视频组件。
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
        }

        /// <summary>
        /// 视频组件优先级。
        /// </summary>
        internal override int Priority => ComponentPriority.Video;

        /// <summary>
        /// 视频组件轮询。
        /// </summary>
        /// <param name="elapseSeconds">游戏逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">游戏真实流逝时间，以秒为单位。</param>
        internal override void Poll(float elapseSeconds, float realElapseSeconds)
        {
        }

        /// <summary>
        /// 关闭并清理视频组件。
        /// </summary>
        internal override void Shutdown()
        {
        }
    }
}