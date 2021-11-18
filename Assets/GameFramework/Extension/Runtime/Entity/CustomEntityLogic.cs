using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime.Extension.DataTable;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 自定义实体。
    /// </summary>
    public sealed class CustomEntityLogic : EntityLogic
    {
        private int m_UniqueId;

        private int m_EntityTypeId;

        private Transform m_OldParent;

        private Transform m_Root;

        /// <summary>
        /// 实体唯一标识符。
        /// </summary>
        public int UniqueId => m_UniqueId;

        /// <summary>
        /// 实体 ID 。
        /// </summary>
        public int EntityId => Entity.Id;

        /// <summary>
        /// 实体类型 ID 。
        /// </summary>
        public int EntityTypeId => m_EntityTypeId;

        /// <summary>
        /// 实体根物体。
        /// </summary>
        public Transform Root => m_Root;

        /// <summary>
        /// 实体初始化时调用
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            m_Root = transform;
            m_UniqueId = GetHashCode();

            if (userData is CustomEntityData entityData)
            {
                m_EntityTypeId = entityData.TypeId;
                DREntity drEntity = entityData.DrEntity;
                if (drEntity == null)
                {
                    Log.Error($"Invalid entity data '{null}'.");
                    return;
                }

                if (drEntity.From == 3)
                {
                    UIExtension.SetTransformFont(m_Root);
                }

                Entry.Event.FireNow(EntityInitEventArgs.EventId,
                    EntityInitEventArgs.Create(this, userData));
            }
            else
            {
                Log.Error($"Invalid entity data. Show entity with '{nameof(EntityExtension.ShowEntity)}'.");
            }
        }

        /// <summary>
        /// 实体反初始化时调用。
        /// </summary>
        public void OnDeinit()
        {
            Entry.Event.FireNow(EntityDeinitEventArgs.EventId, EntityDeinitEventArgs.Create(this, null));
        }

        /// <summary>
        /// 实体回收。
        /// </summary>
        protected override void OnRecycle()
        {
            base.OnRecycle();

            Entry.Event.FireNow(EntityRecycleEventArgs.EventId, EntityRecycleEventArgs.Create(this, null));
        }

        /// <summary>
        /// 实体显示。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            if (userData is CustomEntityData entityData)
            {
                Transform newParent = entityData.Parent;
                Transform oldParent = m_Root;
                if (newParent != null && oldParent != newParent)
                {
                    m_OldParent = oldParent;
                    m_Root.SetParent(newParent);
                    m_Root.localPosition = entityData.Position;
                    m_Root.localScale = entityData.Scale;
                    m_Root.rotation = entityData.Rotation;
                }

                Entry.Event.FireNow(EntityShowEventArgs.EventId, EntityShowEventArgs.Create(this, userData));

                ReferencePool.Release(entityData);
            }
            else
            {
                Log.Error($"Invalid entity data. Show entity with '{nameof(EntityExtension.ShowEntity)}'.");
            }
        }

        /// <summary>
        /// 实体隐藏。
        /// </summary>
        /// <param name="isShutdown">是否是关闭实体管理器时触发。</param>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);

            if (m_OldParent != null)
            {
                m_Root.SetParent(m_OldParent);
                m_OldParent = null;
            }

            Entry.Event.FireNow(EntityHideEventArgs.EventId, EntityHideEventArgs.Create(this, isShutdown, userData));
        }

        /// <summary>
        /// 实体附加子实体。
        /// </summary>
        /// <param name="childEntity">附加的子实体。</param>
        /// <param name="parentTransform">被附加父实体的位置。</param>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnAttached(EntityLogic childEntity, Transform parentTransform, object userData)
        {
            base.OnAttached(childEntity, parentTransform, userData);

            Entry.Event.FireNow(EntityAttachedEventArgs.EventId,
                EntityAttachedEventArgs.Create(this, childEntity as CustomEntityLogic, parentTransform,
                    userData));
        }

        /// <summary>
        /// 实体解除子实体。
        /// </summary>
        /// <param name="childEntity">解除的子实体。</param>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnDetached(EntityLogic childEntity, object userData)
        {
            base.OnDetached(childEntity, userData);

            Entry.Event.FireNow(EntityDetachedEventArgs.EventId,
                EntityDetachedEventArgs.Create(this, childEntity as CustomEntityLogic, userData));
        }

        /// <summary>
        /// 实体附加子实体。
        /// </summary>
        /// <param name="parentEntity">被附加的父实体。</param>
        /// <param name="parentTransform">被附加父实体的位置。</param>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnAttachTo(EntityLogic parentEntity, Transform parentTransform, object userData)
        {
            base.OnAttachTo(parentEntity, parentTransform, userData);

            Entry.Event.FireNow(EntityAttachToEventArgs.EventId,
                EntityAttachToEventArgs.Create(this, parentEntity as CustomEntityLogic,
                    parentTransform, userData));
        }

        /// <summary>
        /// 实体解除子实体。
        /// </summary>
        /// <param name="parentEntity">被解除的父实体。</param>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnDetachFrom(EntityLogic parentEntity, object userData)
        {
            base.OnDetachFrom(parentEntity, userData);

            Entry.Event.FireNow(EntityDetachFromEventArgs.EventId,
                EntityDetachFromEventArgs.Create(this, parentEntity as CustomEntityLogic, userData));
        }

        /// <summary>
        /// 实体轮询。
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            Entry.Event.FireNow(EntityUpdateEventArgs.EventId,
                EntityUpdateEventArgs.Create(this, elapseSeconds, realElapseSeconds, null));
        }
    }
}