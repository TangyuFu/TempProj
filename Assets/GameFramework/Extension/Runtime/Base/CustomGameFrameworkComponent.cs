using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 自定义游戏框架组件。
    /// </summary>
    public abstract class CustomGameFrameworkComponent : MonoBehaviour
    {
        protected virtual void Awake()
        {
            CustomGameFrameworkEntry.RegisterComponent(this);
        }

        /// <summary>
        /// 获取游戏框架组件优先级。
        /// </summary>
        /// <remarks>优先级较高的模块会优先轮询，并且关闭操作会后进行。</remarks>
        internal virtual int Priority => ComponentPriority.Default;

        /// <summary>
        /// 自定义游戏框架组件轮询。
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        internal abstract void Poll(float elapseSeconds, float realElapseSeconds);

        /// <summary>
        /// 关闭并清理自定义游戏框架组件。
        /// </summary>
        internal abstract void Shutdown();
        
        protected static class ComponentPriority
        {
            public const int Default = 0;
            public const int BuiltinData = 0;
            public const int Camera = 0;
            public const int PlayerData = 0;
            public const int Script = 0;
            public const int Video = 0;
            public const int R = 0;
            public const int Time = 0;
        }
    }
}