using GameFramework;
using GameFramework.Event;

namespace TempProj
{
    /// <summary>
    /// 提示事件。fu't
    /// </summary>
    public class TipEventArgs : GameEventArgs
    {
        public static int EventId { get; } =typeof(TipEventArgs).GetHashCode();

        public override int Id => EventId;

        public TipEventArgs()
        {
            Content = null;
        }

        /// <summary>
        /// 提示内容。
        /// </summary>
        public string Content { get; private set; }
        
        /// <summary>
        /// 创建提示事件。
        /// </summary>
        /// <param name="content">提示内容。</param>
        /// <returns>创建的提示事件。</returns>
        public static TipEventArgs Create(string content)
        {
            TipEventArgs tipEventArgs = ReferencePool.Acquire<TipEventArgs>();
            tipEventArgs.Content = content;
            return tipEventArgs;
        }

        public override void Clear()
        {
            Content = null;
        }
    }
}