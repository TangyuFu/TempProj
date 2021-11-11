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

        public int UniqueId { get; private set; }

        public int FormId { get; private set; }

        public object UserData { get; private set; }

        public static UIFormCoverEventArgs Create(int uniqueId, int formId, object userData)
        {
            UIFormCoverEventArgs uiFormCoverEventArgs = ReferencePool.Acquire<UIFormCoverEventArgs>();
            uiFormCoverEventArgs.UniqueId = uniqueId;
            uiFormCoverEventArgs.FormId = formId;
            uiFormCoverEventArgs.UserData = userData;
            return uiFormCoverEventArgs;
        }

        public override void Clear()
        {
            UniqueId = 0;
            FormId = 0;
            UserData = null;
        }
    }
}