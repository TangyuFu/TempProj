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

        public int UniqueId { get; private set; }

        public int FormId { get; private set; }

        public object UserData { get; private set; }

        public static UIFormRefocusEventArgs Create(int uniqueId, int formId, object userData)
        {
            UIFormRefocusEventArgs uiFormRefocusEventArgs = ReferencePool.Acquire<UIFormRefocusEventArgs>();
            uiFormRefocusEventArgs.UniqueId = uniqueId;
            uiFormRefocusEventArgs.FormId = formId;
            uiFormRefocusEventArgs.UserData = userData;
            return uiFormRefocusEventArgs;
        }

        public override void Clear()
        {
            UniqueId = 0;
            FormId = 0;
            UserData = null;
        }
    }
}