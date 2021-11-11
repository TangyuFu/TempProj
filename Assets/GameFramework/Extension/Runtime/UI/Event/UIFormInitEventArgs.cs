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

        public int UniqueId { get; private set; }

        public int FormId { get; private set; }

        public GameObject Root { get; private set; }

        public UIForm UIForm { get; private set; }

        public object UserData { get; private set; }

        public static UIFormInitEventArgs Create(int uniqueId, int formId, UIForm uiForm, GameObject formGO,
            object userData)
        {
            UIFormInitEventArgs uiFormInitEventArgs = ReferencePool.Acquire<UIFormInitEventArgs>();
            uiFormInitEventArgs.UniqueId = uniqueId;
            uiFormInitEventArgs.FormId = formId;
            uiFormInitEventArgs.Root = formGO;
            uiFormInitEventArgs.UIForm = uiForm;
            uiFormInitEventArgs.UserData = userData;
            return uiFormInitEventArgs;
        }

        public override void Clear()
        {
            UniqueId = 0;
            FormId = 0;
            Root = null;
            UIForm = null;
            UserData = null;
        }
    }
}