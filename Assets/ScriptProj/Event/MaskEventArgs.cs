using GameFramework;
using GameFramework.Event;

namespace TempProj
{
    /// <summary>
    /// 遮罩事件。
    /// </summary>
    public class MaskEventArgs : GameEventArgs
    {
        public static int EventId { get; } = typeof(MaskEventArgs).GetHashCode();

        public override int Id => EventId;

        public MaskEventArgs()
        {
            Show = false;
        }

        /// <summary>
        /// 是否是显示遮罩。
        /// </summary>
        public bool Show { get; private set; }

        /// <summary>
        /// 创建遮罩事件。
        /// </summary>
        /// <param name="show">为真，显示遮罩；为假，隐藏遮罩。</param>
        /// <returns>创建的遮罩事件。</returns>
        public static MaskEventArgs Create(bool show)
        {
            MaskEventArgs maskEventArgs = ReferencePool.Acquire<MaskEventArgs>();
            maskEventArgs.Show = show;
            return maskEventArgs;
        }

        public override void Clear()
        {
            Show = false;
        }
    }
}