using GameFramework;
using GameFramework.Event;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 界面激活事件。
    /// </summary>
    public class UIFormRefocusEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UIFormRefocusEventArgs).GetHashCode();
        public override int Id => EventId;

        public UIFormRefocusEventArgs()
        {
        }
        
        public CustomUIFormLogic Logic { get; private set; }

        public object UserData { get; private set; }

        public static UIFormRefocusEventArgs Create(CustomUIFormLogic logic, object userData)
        {
            UIFormRefocusEventArgs eventArgs = ReferencePool.Acquire<UIFormRefocusEventArgs>();
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