using GameFramework;
using GameFramework.Event;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 面遮挡恢复事件。
    /// </summary>
    public class UIFormRevealEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UIFormRevealEventArgs).GetHashCode();
        public override int Id => EventId;

        public UIFormRevealEventArgs()
        {
        }

        public int FormHash { get; private set; }

        public int FormId { get; private set; }

        public object UserData { get; private set; }

        public static UIFormRevealEventArgs Create(int formHash, int formId, object userData)
        {
            UIFormRevealEventArgs uiFormRevealEventArgs = ReferencePool.Acquire<UIFormRevealEventArgs>();
            uiFormRevealEventArgs.FormHash = formHash;
            uiFormRevealEventArgs.FormId = formId;
            uiFormRevealEventArgs.UserData = userData;
            return uiFormRevealEventArgs;
        }

        public override void Clear()
        {
            FormId = 0;
            FormHash = 0;
            UserData = null;
        }
    }
}