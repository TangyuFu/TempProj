using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// UIForm 代表者。
    /// </summary>
    public abstract class UIFormPresenter : IUIFormPresenter
    {
        /// <summary>
        /// 界面唯一标识符。
        /// </summary>
        public int UniqueId { get; private set; }

        /// <summary>
        /// 界面 ID 。
        /// </summary>
        public int FormId { get; private set; }

        /// <summary>
        /// 界面根物体。
        /// </summary>
        public GameObject Root { get; private set; }

        public virtual void OnInit(int uniqueId, int formId, UIForm uiForm, GameObject root,
            object userData)
        {
            UniqueId = uniqueId;
            FormId = formId;
            Root = root;
        }

        public virtual void OnDeinit()
        {
        }

        public virtual void OnRecycle()
        {
        }

        public virtual void OnOpen(object userData)
        {
        }

        public virtual void OnClose(bool isShutdown, object userData)
        {
        }

        public virtual void OnPause()
        {
        }

        public virtual void OnResume()
        {
        }

        public virtual void OnCover()
        {
        }

        public virtual void OnReveal()
        {
        }

        public virtual void OnRefocus(object userData)
        {
        }

        public virtual void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
        }

        public virtual void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
        {
        }
    }
}