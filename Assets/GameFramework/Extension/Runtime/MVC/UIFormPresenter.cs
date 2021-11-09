using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// UIForm 代表者泛型。
    /// </summary>
    /// <typeparam name="TView">MVC 界面。</typeparam>
    /// <typeparam name="TProp">MVC 属性。。</typeparam>
    public abstract class UIFormPresenter<TView, TProp> : IUIFormPresenter
        where TProp : MVCProp
        where TView : MVCView<TProp>, new()
    {
        protected TProp m_Prop;

        protected TView m_View;

        public virtual void OnInit(GameObject target, object userData)
        {
            m_Prop = target.GetComponent<TProp>();
            if (m_Prop == null)
            {
                Log.Error($"Failed to get MVCProp '{typeof(TProp)}' from MVCView '{typeof(TView)}'.");
                return;
            }

            m_View = new TView();
            m_View.Init(m_Prop);
        }

        public virtual void OnDeinit()
        {
            m_View.Deinit();
            m_View = null;
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