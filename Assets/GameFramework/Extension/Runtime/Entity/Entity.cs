using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime.Extension.DataTable;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 自定义实体。
    /// </summary>
    public sealed class Entity : EntityLogic
    {
        private int m_EntityHash;
        private int m_EntityTypeId;
        private Transform m_OldParent;
        private Transform m_Transform;

        /// <summary>
        /// 实体初始化时调用
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            m_Transform = transform;
            m_EntityHash = GetHashCode();

            if (userData is EntityData entityData)
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
                    UIExtension.SetTransformFont(m_Transform);
                }

                Entry.Event.FireNow(EntityInitEventArgs.EventId,
                    EntityInitEventArgs.Create(m_EntityHash, Entity.Id, m_EntityTypeId, this, gameObject, userData));
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
            Entry.Event.FireNow(EntityDeinitEventArgs.EventId,
                EntityDeinitEventArgs.Create(m_EntityHash, Entity.Id, this, gameObject));
        }

        /// <summary>
        /// 实体回收。
        /// </summary>
        protected override void OnRecycle()
        {
            base.OnRecycle();

            Entry.Event.FireNow(EntityRecycleEventArgs.EventId, EntityRecycleEventArgs.Create(m_EntityHash, Entity.Id));
        }

        /// <summary>
        /// 实体显示。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            if (userData is EntityData entityData)
            {
                Transform newParent = entityData.Parent;
                Transform oldParent = m_Transform.parent;
                if (newParent != null && oldParent != newParent)
                {
                    m_OldParent = oldParent;
                    m_Transform.SetParent(newParent);
                    m_Transform.localScale = Vector3.one;
                }

                Entry.Event.FireNow(EntityShowEventArgs.EventId,
                    EntityShowEventArgs.Create(m_EntityHash, Entity.Id, this, gameObject, userData));

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
                m_Transform.SetParent(m_OldParent);
                m_OldParent = null;
            }

            Entry.Event.FireNow(EntityHideEventArgs.EventId,
                EntityHideEventArgs.Create(m_EntityHash, Entity.Id, isShutdown, userData));
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
                EntityAttachedEventArgs.Create(m_EntityHash, Entity.Id, childEntity, parentTransform, userData));
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
                EntityDetachedEventArgs.Create(m_EntityHash, Entity.Id, childEntity, userData));
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
                EntityAttachToEventArgs.Create(m_EntityHash, Entity.Id, parentEntity, parentTransform, userData));
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
                EntityDetachFromEventArgs.Create(m_EntityHash, Entity.Id, parentEntity, userData));
        }

        /// <summary>
        /// 实体轮询。
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            // Entry.Event.FireNow(EntityUpdateEventArgs.EventId,
            //     EntityUpdateEventArgs.Create(m_EntityHash, Entity.Id, elapseSeconds, realElapseSeconds, null));
        }
    }
}