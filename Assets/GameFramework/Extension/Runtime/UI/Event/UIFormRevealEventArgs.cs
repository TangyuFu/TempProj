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

        public int UniqueId { get; private set; }

        public int FormId { get; private set; }

        public object UserData { get; private set; }

        public static UIFormRevealEventArgs Create(int uniqueId, int formId, object userData)
        {
            UIFormRevealEventArgs uiFormRevealEventArgs = ReferencePool.Acquire<UIFormRevealEventArgs>();
            uiFormRevealEventArgs.UniqueId = uniqueId;
            uiFormRevealEventArgs.FormId = formId;
            uiFormRevealEventArgs.UserData = userData;
            return uiFormRevealEventArgs;
        }

        public override void Clear()
        {
            FormId = 0;
            UniqueId = 0;
            UserData = null;
        }
    }
}