using GameFramework;
using GameFramework.Event;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 界面关闭事件。
    /// </summary>
    public class UIFormCloseEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UIFormCloseEventArgs).GetHashCode();
        public override int Id => EventId;

        public UIFormCloseEventArgs()
        {
        }

        public CustomUIFormLogic Logic { get; private set; }

        public bool IsShutdown { get; private set; }

        public object UserData { get; private set; }

        public static UIFormCloseEventArgs Create(CustomUIFormLogic logic, bool isShutdown, object userData)
        {
            UIFormCloseEventArgs eventArgs = ReferencePool.Acquire<UIFormCloseEventArgs>();
            eventArgs.Logic = logic;
            eventArgs.IsShutdown = isShutdown;
            eventArgs.UserData = userData;
            return eventArgs;
        }

        public override void Clear()
        {
            Logic = default;
            IsShutdown = default;
            UserData = default;
        }
    }
}