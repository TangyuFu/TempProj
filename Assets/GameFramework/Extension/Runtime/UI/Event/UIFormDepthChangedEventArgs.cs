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

        public int FormHash { get; private set; }

        public int FormId { get; private set; }

        public int UIGroupDepth { get; private set; }

        public int DepthInUIGroup { get; private set; }

        public object UserData { get; private set; }

        public static UIFormDepthChangedEventArgs Create(int formHash, int formId, int uiGroupDepth,
            int depthInUIGroup,
            object userData)
        {
            UIFormDepthChangedEventArgs uiFormDepthChangedEventArgs =
                ReferencePool.Acquire<UIFormDepthChangedEventArgs>();
            uiFormDepthChangedEventArgs.FormHash = formHash;
            uiFormDepthChangedEventArgs.FormId = formId;
            uiFormDepthChangedEventArgs.UIGroupDepth = uiGroupDepth;
            uiFormDepthChangedEventArgs.DepthInUIGroup = depthInUIGroup;
            uiFormDepthChangedEventArgs.UserData = userData;
            return uiFormDepthChangedEventArgs;
        }

        public override void Clear()
        {
            FormHash = 0;
            FormId = 0;
            UIGroupDepth = 0;
            DepthInUIGroup = 0;
            UserData = null;
        }
    }
}