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

        public int FormHash { get; private set; }

        public int FormId { get; private set; }

        public object UserData { get; private set; }

        public static UIFormOpenEventArgs Create(int formHash, int formId, object userData)
        {
            UIFormOpenEventArgs uiFormOpenEventArgs = ReferencePool.Acquire<UIFormOpenEventArgs>();
            uiFormOpenEventArgs.FormHash = formHash;
            uiFormOpenEventArgs.FormId = formId;
            uiFormOpenEventArgs.UserData = userData;
            return uiFormOpenEventArgs;
        }

        public override void Clear()
        {
            FormHash = 0;
            FormId = 0;
            UserData = null;
        }
    }
}