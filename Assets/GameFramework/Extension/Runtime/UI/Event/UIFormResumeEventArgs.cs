using GameFramework;
using GameFramework.Event;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 界面暂停恢复事件。
    /// </summary>
    public class UIFormResumeEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UIFormResumeEventArgs).GetHashCode();
        public override int Id => EventId;

        public UIFormResumeEventArgs()
        {
        }

        public int FormHash { get; private set; }

        public int FormId { get; private set; }

        public object UserData { get; private set; }

        public static UIFormResumeEventArgs Create(int formHash, int formId, object userData)
        {
            UIFormResumeEventArgs uiFormResumeEventArgs = ReferencePool.Acquire<UIFormResumeEventArgs>();
            uiFormResumeEventArgs.FormHash = formHash;
            uiFormResumeEventArgs.FormId = formId;
            uiFormResumeEventArgs.UserData = userData;
            return uiFormResumeEventArgs;
        }

        public override void Clear()
        {
            FormHash = 0;
            FormId = 0;
            UserData = null;
        }
    }
}