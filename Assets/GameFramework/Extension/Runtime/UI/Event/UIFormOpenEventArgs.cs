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

        public CustomUIFormLogic Logic { get; private set; }

        public object UserData { get; private set; }

        public static UIFormOpenEventArgs Create(int uniqueId, int formId, CustomUIFormLogic logic, object userData)
        {
            UIFormOpenEventArgs eventArgs = ReferencePool.Acquire<UIFormOpenEventArgs>();
            eventArgs.Logic = logic;
            eventArgs.UserData = userData;
            return eventArgs;
        }

        public override void Clear()
        {
            Logic = default;
            UserData = default;
        }
    }
}