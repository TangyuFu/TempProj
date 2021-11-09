using GameFramework;
using GameFramework.Event;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 游戏暂停状态改变事件。
    /// </summary>
    public sealed class GamePauseChangedEventArgs : GameEventArgs
    {
        /// <summary>
        /// 游戏暂停状态改变事件的编号。
        /// </summary>
        public static int EventId { get; } = typeof(GamePauseChangedEventArgs).GetHashCode();

        /// <summary>
        /// 获取游戏暂停状态改变事件的编号。
        /// </summary>
        public override int Id => EventId;

        /// <summary>
        /// 初始化游戏暂停状态改变事件的新实例。
        /// </summary>
        public GamePauseChangedEventArgs()
        {
        }

        /// <summary>
        /// 游戏是否暂停。
        /// </summary>
        public bool PauseStatus { get; private set; }

        /// <summary>
        /// 用户自定义数据。
        /// </summary>
        public object UserData { get; private set; }

        /// <summary>
        /// 创建游戏暂停状态改变事件，
        /// </summary>
        /// <param name="pauseStatus">游戏是否暂停。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>创建的游戏暂停状态改变事件。</returns>
        public static GamePauseChangedEventArgs Create(bool pauseStatus, object userData)
        {
            GamePauseChangedEventArgs gamePauseChangedEventArgs =
                ReferencePool.Acquire<GamePauseChangedEventArgs>();
            gamePauseChangedEventArgs.PauseStatus = pauseStatus;
            gamePauseChangedEventArgs.UserData = userData;
            return gamePauseChangedEventArgs;
        }

        /// <summary>
        /// 清理游戏暂停状态改变事件。
        /// </summary>
        public override void Clear()
        {
            PauseStatus = default;
            UserData = default;
        }
    }
}