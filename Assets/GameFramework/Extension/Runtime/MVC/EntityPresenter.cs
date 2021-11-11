using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// Entity 代表者。
    /// </summary>
    /// <typeparam name="TView">MVC 界面。</typeparam>
    /// <typeparam name="TProp">MVC 属性。。</typeparam>
    public abstract class EntityPresenter : IEntityPresenter
    {
        /// <summary>
        /// 获取实体唯一标识符。
        /// </summary>
        public int UniqueId { get; private set; }

        /// <summary>
        /// 获取实体 Id。
        /// </summary>
        public int EntityId { get; private set; }

        /// <summary>
        /// 获取实体类型 ID 。
        /// </summary>
        public int EntityTypeId { get; private set; }

        /// <summary>
        /// 获取实体代表者的根物体。
        /// </summary>
        public GameObject Root { get; private set; }

        public void OnInit(int uniqueId, int entityId, Entity entity, GameObject root,
            object userData)
        {
            UniqueId = uniqueId;
            EntityId = entityId;
            Root = root;
        }

        public virtual void OnDeinit()
        {
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