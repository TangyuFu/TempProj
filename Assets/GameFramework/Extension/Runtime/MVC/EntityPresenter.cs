using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// Entity 代表者。
    /// </summary>
    public abstract class EntityPresenter : IEntityPresenter
    {
        /// <summary>
        /// 获取实体唯一标识符。
        /// </summary>
        public int UniqueId => Logic.UniqueId; 

        /// <summary>
        /// 获取实体 Id。
        /// </summary>
        public int EntityId => Logic.EntityId;

        /// <summary>
        /// 获取实体类型 ID 。
        /// </summary>
        public int EntityTypeId => Logic.EntityTypeId;

        /// <summary>
        /// 获取实体代表者的根物体。
        /// </summary>
        public Transform Root => Logic.Root;

        /// <summary>
        /// 获取实体。
        /// </summary>
        public CustomEntityLogic Logic { get; private set; }

        public virtual void OnInit(CustomEntityLogic logic, Transform root, object userData)
        {
            Logic = logic;
        }

        public virtual void OnDeinit()
        {
        }

        public virtual void OnRecycle()
        {
        }

        public virtual void OnShow(object userData)
        {
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

        public virtual void Hide()
        {
            Entry.Entity.HideEntity(Logic);
        }
    }
}