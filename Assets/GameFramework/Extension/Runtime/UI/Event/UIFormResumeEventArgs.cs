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

        public CustomUIFormLogic Logic { get; private set; }

        public object UserData { get; private set; }

        public static UIFormResumeEventArgs Create(CustomUIFormLogic logic, object userData)
        {
            UIFormResumeEventArgs eventArgs = ReferencePool.Acquire<UIFormResumeEventArgs>();
            eventArgs.Logic = logic;
            eventArgs.UserData = userData;
            return eventArgs;
        }

        public override void Clear()
        {
            Logic = default;
            UserData = default;
        }
    }
}