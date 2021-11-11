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

        public int UniqueId { get; private set; }

        public int FormId { get; private set; }

        public object UserData { get; private set; }


        public static UIFormPauseEventArgs Create(int uniqueId, int formId, object userData)
        {
            UIFormPauseEventArgs uiFormPauseEventArgs = ReferencePool.Acquire<UIFormPauseEventArgs>();
            uiFormPauseEventArgs.UniqueId = uniqueId;
            uiFormPauseEventArgs.FormId = formId;
            uiFormPauseEventArgs.UserData = userData;
            return uiFormPauseEventArgs;
        }

        public override void Clear()
        {
            UniqueId = 0;
            FormId = 0;
            UserData = null;
        }
    }
}