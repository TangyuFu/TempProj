using GameFramework;
using GameFramework.Event;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 界面更新事件。
    /// </summary>
    public class UIFormUpdateEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UIFormUpdateEventArgs).GetHashCode();
        public override int Id => EventId;

        public UIFormUpdateEventArgs()
        {
        }

        public int FormHash { get; private set; }

        public int FormId { get; private set; }

        public float ElapseSeconds { get; private set; }

        public float RealElapseSeconds { get; private set; }

        public object UserData { get; private set; }

        public static UIFormUpdateEventArgs Create(int formHash, int formId, float elapseSeconds,
            float realElapseSeconds,
            object userData)
        {
            UIFormUpdateEventArgs uiFormUpdateEventArgs = ReferencePool.Acquire<UIFormUpdateEventArgs>();
            uiFormUpdateEventArgs.FormHash = formHash;
            uiFormUpdateEventArgs.FormId = formId;
            uiFormUpdateEventArgs.ElapseSeconds = elapseSeconds;
            uiFormUpdateEventArgs.RealElapseSeconds = realElapseSeconds;
            uiFormUpdateEventArgs.UserData = userData;
            return uiFormUpdateEventArgs;
        }

        public override void Clear()
        {
            FormHash = 0;
            FormId = 0;
            ElapseSeconds = 0f;
            RealElapseSeconds = 0f;
            UserData = null;
        }
    }
}