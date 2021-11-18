using GameFramework;
using GameFramework.Event;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 界面深度改变事件。
    /// </summary>
    public class UIFormDepthChangedEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UIFormDepthChangedEventArgs).GetHashCode();
        public override int Id => EventId;

        public UIFormDepthChangedEventArgs()
        {
        }

        public CustomUIFormLogic Logic { get; private set; }

        public int UIGroupDepth { get; private set; }

        public int DepthInUIGroup { get; private set; }

        public object UserData { get; private set; }

        public static UIFormDepthChangedEventArgs Create(CustomUIFormLogic logic, int uiGroupDepth, int depthInUIGroup,
            object userData)
        {
            UIFormDepthChangedEventArgs eventArgs = ReferencePool.Acquire<UIFormDepthChangedEventArgs>();
            eventArgs.Logic = logic;
            eventArgs.UIGroupDepth = uiGroupDepth;
            eventArgs.DepthInUIGroup = depthInUIGroup;
            eventArgs.UserData = userData;
            return eventArgs;
        }

        public override void Clear()
        {
            Logic = default;
            UIGroupDepth = default;
            DepthInUIGroup = default;
            UserData = default;
        }
    }
}