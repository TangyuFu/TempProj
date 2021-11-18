using GameFramework;
using GameFramework.Event;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 界面更新事件。
    /// </summary>
    public class UIFormUpdateEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UIFormUpdateEventArgs).GetHashCode();
        public override int Id => EventId;

        public UIFormUpdateEventArgs()
        {
        }

        public CustomUIFormLogic Logic { get; private set; }

        public float ElapseSeconds { get; private set; }

        public float RealElapseSeconds { get; private set; }

        public object UserData { get; private set; }

        public static UIFormUpdateEventArgs Create(CustomUIFormLogic logic, float elapseSeconds,
            float realElapseSeconds,
            object userData)
        {
            UIFormUpdateEventArgs eventArgs = ReferencePool.Acquire<UIFormUpdateEventArgs>();
            eventArgs.Logic = logic;
            eventArgs.ElapseSeconds = elapseSeconds;
            eventArgs.RealElapseSeconds = realElapseSeconds;
            eventArgs.UserData = userData;
            return eventArgs;
        }

        public override void Clear()
        {
            Logic = default;
            ElapseSeconds = default;
            RealElapseSeconds = default;
            UserData = default;
        }
    }
}