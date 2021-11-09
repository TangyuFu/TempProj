using GameFramework;
using GameFramework.Event;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 游戏退出事件。
    /// </summary>
    public sealed class GameQuitEventArgs : GameEventArgs
    {
        /// <summary>
        /// 游戏退出事件的编号。
        /// </summary>
        public static int EventId { get; } = typeof(GameQuitEventArgs).GetHashCode();

        /// <summary>
        /// 获取游戏退出事件的编号。
        /// </summary>
        public override int Id => EventId;

        /// <summary>
        /// 初始化游戏退出事件的新实例。
        /// </summary>
        public GameQuitEventArgs()
        {
        }

        /// <summary>
        /// 创建游戏退出事件，
        /// </summary>
        /// <returns>创建的游戏退出事件。</returns>
        public static GameQuitEventArgs Create()
        {
            GameQuitEventArgs gameQuitEventArgs = ReferencePool.Acquire<GameQuitEventArgs>();
            return gameQuitEventArgs;
        }

        /// <summary>
        /// 清理游戏退出事件，
        /// </summary>
        public override void Clear()
        {
        }
    }
}