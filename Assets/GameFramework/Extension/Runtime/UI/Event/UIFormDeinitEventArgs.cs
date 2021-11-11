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

        public int UniqueId { get; private set; }

        public int FormId { get; private set; }

        public object UserData { get; private set; }

        public static UIFormDeinitEventArgs Create(int uniqueId, int formId, object userData)
        {
            UIFormDeinitEventArgs uiFormDeinitEventArgs = ReferencePool.Acquire<UIFormDeinitEventArgs>();
            uiFormDeinitEventArgs.UniqueId = uniqueId;
            uiFormDeinitEventArgs.FormId = formId;
            uiFormDeinitEventArgs.UserData = userData;
            return uiFormDeinitEventArgs;
        }

        public override void Clear()
        {
            UniqueId = 0;
            FormId = 0;
            UserData = null;
        }
    }
}