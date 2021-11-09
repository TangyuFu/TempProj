using GameFramework;
using GameFramework.Event;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 界面暂停事件。
    /// </summary>
    public class UIFormPauseEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UIFormPauseEventArgs).GetHashCode();
        public override int Id => EventId;

        public UIFormPauseEventArgs()
        {
        }

        public int FormHash { get; private set; }

        public int FormId { get; private set; }

        public object UserData { get; private set; }


        public static UIFormPauseEventArgs Create(int formHash, int formId, object userData)
        {
            UIFormPauseEventArgs uiFormPauseEventArgs = ReferencePool.Acquire<UIFormPauseEventArgs>();
            uiFormPauseEventArgs.FormHash = formHash;
            uiFormPauseEventArgs.FormId = formId;
            uiFormPauseEventArgs.UserData = userData;
            return uiFormPauseEventArgs;
        }

        public override void Clear()
        {
            FormHash = 0;
            FormId = 0;
            UserData = null;
        }
    }
}