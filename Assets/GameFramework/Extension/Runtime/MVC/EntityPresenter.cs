using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// Entity 代表者泛型。
    /// </summary>
    /// <typeparam name="TView">MVC 界面。</typeparam>
    /// <typeparam name="TProp">MVC 属性。。</typeparam>
    public abstract class EntityPresenter<TView, TProp> : IEntityPresenter
        where TProp : MVCProp
        where TView : MVCView<TProp>, new()
    {
        public int EntityId { get; private set; }
        
        public GameObject Target { get; private set; }

        protected TProp m_Prop;

        protected TView m_View;

        public virtual void OnInit(GameObject target, object userData)
        {
            Target = target;
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

        public virtual void OnShow(int entityId, object userData)
        {
            EntityId = entityId;
        }

        public virtual void OnHide(bool isShutdown, object userData)
        {
        }

        public virtual void OnAttached(EntityLogic childEntity, Transform parentTransform, object userData)
        {
        }

        public virtual void OnDetached(EntityLogic childEntity, object userData)
        {
        }

        public virtual void OnAttachTo(EntityLogic parentEntity, Transform parentTransform, object userData)
        {
        }

        public virtual void OnDetachFrom(EntityLogic parentEntity, object userData)
        {
        }

        public virtual void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
        }
    }
}