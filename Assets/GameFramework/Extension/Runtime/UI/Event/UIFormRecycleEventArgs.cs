using GameFramework;
using GameFramework.Event;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 界面回收事件。
    /// </summary>
    public class UIFormRecycleEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UIFormRecycleEventArgs).GetHashCode();
        public override int Id => EventId;

        public UIFormRecycleEventArgs()
        {
        }

        public CustomUIFormLogic Logic { get; private set; }

        public object UserData { get; private set; }

        public static UIFormRecycleEventArgs Create(CustomUIFormLogic logic, object userData)
        {
            UIFormRecycleEventArgs eventArgs = ReferencePool.Acquire<UIFormRecycleEventArgs>();
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