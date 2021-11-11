using GameFramework;
using GameFramework.Event;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 界面打开事件。
    /// </summary>
    public class UIFormOpenEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UIFormOpenEventArgs).GetHashCode();
        public override int Id => EventId;

        public UIFormOpenEventArgs()
        {
        }

        public int UniqueId { get; private set; }

        public int FormId { get; private set; }

        public object UserData { get; private set; }

        public static UIFormOpenEventArgs Create(int uniqueId, int formId, object userData)
        {
            UIFormOpenEventArgs uiFormOpenEventArgs = ReferencePool.Acquire<UIFormOpenEventArgs>();
            uiFormOpenEventArgs.UniqueId = uniqueId;
            uiFormOpenEventArgs.FormId = formId;
            uiFormOpenEventArgs.UserData = userData;
            return uiFormOpenEventArgs;
        }

        public override void Clear()
        {
            UniqueId = 0;
            FormId = 0;
            UserData = null;
        }
    }
}