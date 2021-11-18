using GameFramework;
using GameFramework.Event;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 界面反初始化事件。
    /// </summary>
    public class UIFormDeinitEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UIFormDeinitEventArgs).GetHashCode();
        public override int Id => EventId;

        public UIFormDeinitEventArgs()
        {
        }

        public CustomUIFormLogic Logic { get; private set; }

        public object UserData { get; private set; }

        public static UIFormDeinitEventArgs Create(CustomUIFormLogic logic, object userData)
        {
            UIFormDeinitEventArgs eventArgs = ReferencePool.Acquire<UIFormDeinitEventArgs>();
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