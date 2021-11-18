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

        public CustomUIFormLogic Logic { get; private set; }

        public object UserData { get; private set; }

        public static UIFormPauseEventArgs Create(CustomUIFormLogic logic, object userData)
        {
            UIFormPauseEventArgs eventArgs = ReferencePool.Acquire<UIFormPauseEventArgs>();
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