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

        public int FormHash { get; private set; }

        public int FormId { get; private set; }

        public object UserData { get; private set; }

        public static UIFormRecycleEventArgs Create(int formHash, int formId, object userData)
        {
            UIFormRecycleEventArgs uiFormRecycleEventArgs = ReferencePool.Acquire<UIFormRecycleEventArgs>();
            uiFormRecycleEventArgs.FormHash = formHash;
            uiFormRecycleEventArgs.FormId = formId;
            uiFormRecycleEventArgs.UserData = userData;
            return uiFormRecycleEventArgs;
        }

        public override void Clear()
        {
            FormHash = 0;
            FormId = 0;
            UserData = null;
        }
    }
}