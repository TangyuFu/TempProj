using GameFramework;
using GameFramework.Event;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 界面初始化事件。
    /// </summary>
    public class UIFormInitEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UIFormInitEventArgs).GetHashCode();
        public override int Id => EventId;

        public UIFormInitEventArgs()
        {
        }

        public CustomUIFormLogic Logic { get; private set; }

        public object UserData { get; private set; }

        public static UIFormInitEventArgs Create(CustomUIFormLogic logic, object userData)
        {
            UIFormInitEventArgs eventArgs = ReferencePool.Acquire<UIFormInitEventArgs>();
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