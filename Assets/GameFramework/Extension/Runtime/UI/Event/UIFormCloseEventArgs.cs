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

        public int FormHash { get; private set; }

        public int FormId { get; private set; }

        public bool IsShutdown { get; private set; }

        public object UserData { get; private set; }

        public static UIFormCloseEventArgs Create(int formHash, int formId, bool isShutdown, object userData)
        {
            UIFormCloseEventArgs uiFormCloseEventArgs = ReferencePool.Acquire<UIFormCloseEventArgs>();
            uiFormCloseEventArgs.FormHash = formHash;
            uiFormCloseEventArgs.FormId = formId;
            uiFormCloseEventArgs.IsShutdown = isShutdown;
            uiFormCloseEventArgs.UserData = userData;
            return uiFormCloseEventArgs;
        }

        public override void Clear()
        {
            FormId = 0;
            FormHash = 0;
            IsShutdown = false;
            UserData = null;
        }
    }
}