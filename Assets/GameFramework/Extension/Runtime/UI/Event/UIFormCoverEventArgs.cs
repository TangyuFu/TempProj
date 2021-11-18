using GameFramework;
using GameFramework.Event;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 界面遮挡事件。
    /// </summary>
    public class UIFormCoverEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UIFormCoverEventArgs).GetHashCode();
        public override int Id => EventId;

        public UIFormCoverEventArgs()
        {
        }

        public CustomUIFormLogic Logic { get; private set; }

        public object UserData { get; private set; }

        public static UIFormCoverEventArgs Create(CustomUIFormLogic logic, object userData)
        {
            UIFormCoverEventArgs eventArgs = ReferencePool.Acquire<UIFormCoverEventArgs>();
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