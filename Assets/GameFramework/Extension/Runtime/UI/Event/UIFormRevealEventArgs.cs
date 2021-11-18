using GameFramework;
using GameFramework.Event;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 面遮挡恢复事件。
    /// </summary>
    public class UIFormRevealEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UIFormRevealEventArgs).GetHashCode();
        public override int Id => EventId;

        public UIFormRevealEventArgs()
        {
        }

        public CustomUIFormLogic Logic { get; private set; }

        public object UserData { get; private set; }

        public static UIFormRevealEventArgs Create(CustomUIFormLogic logic, object userData)
        {
            UIFormRevealEventArgs eventArgs = ReferencePool.Acquire<UIFormRevealEventArgs>();
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