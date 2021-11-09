using GameFramework;
using GameFramework.Event;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 游戏焦点状态改变事件。
    /// </summary>
    public sealed class GameFocusChangedEventArgs : GameEventArgs
    {
        /// <summary>
        /// 游戏焦点状态改变事件的编号。
        /// </summary>
        public static int EventId { get; } = typeof(GameFocusChangedEventArgs).GetHashCode();

        /// <summary>
        /// 获取游戏焦点状态改变事件的编号。
        /// </summary>
        public override int Id => EventId;

        /// <summary>
        /// 初始化游戏焦点状态改变事件的新实例。
        /// </summary>
        public GameFocusChangedEventArgs()
        {
        }

        /// <summary>
        /// 游戏是否拥有焦点。
        /// </summary>
        public bool HasFocus { get; private set; }

        /// <summary>
        /// 用户自定义数据。
        /// </summary>
        public object UserData { get; private set; }

        /// <summary>
        /// 创建游戏焦点状态改变事件，
        /// </summary>
        /// <param name="hasFocus">游戏是否拥有焦点</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>创建的游戏焦点状态改变事件。</returns>
        public static GameFocusChangedEventArgs Create(bool hasFocus, object userData)
        {
            GameFocusChangedEventArgs gameFocusChangedEventArgs =
                ReferencePool.Acquire<GameFocusChangedEventArgs>();
            gameFocusChangedEventArgs.HasFocus = hasFocus;
            gameFocusChangedEventArgs.UserData = userData;
            return gameFocusChangedEventArgs;
        }

        /// <summary>
        /// 清理游戏焦点状态改变事件。
        /// </summary>
        public override void Clear()
        {
            HasFocus = default;
            UserData = default;
        }
    }
}