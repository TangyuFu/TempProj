using TempProj.DataTable;
using UnityEngine;
using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    /// <summary>
    /// Entity 代表者。
    /// </summary>
    public abstract class EntityPresenter : IEntityPresenter
    {
        private Transform m_OldParent;
        
        /// <summary>
        /// 获取实体唯一标识符。
        /// </summary>
        public int UniqueId => Logic.UniqueId;

        /// <summary>
        /// 获取实体 Id。
        /// </summary>
        public int EntityId => Logic.Entity.Id;

        /// <summary>
        /// 获取实体类型 ID 。
        /// </summary>
        public int EntityTypeId { get; private set; }

        /// <summary>
        /// 获取实体代表者的根物体。
        /// </summary>
        public Transform Root { get; private set; }

        /// <summary>
        /// 获取实体。
        /// </summary>
        public CustomEntityLogic Logic { get; private set; }

        public virtual void OnInit(CustomEntityLogic logic, Transform root, object userData)
        {
            Logic = logic;
            Root = root;
            Log.Debug(root.parent);
            
            if (userData is EntityData entityData)
            {
                EntityTypeId = entityData.TypeId;
                DREntity drEntity = entityData.DrEntity;
                if (drEntity != null)
                {
                    if (drEntity.From == 1)
                    {
                        UnityGameFramework.Runtime.Extension.UIExtension.SetTransformFont(Root);
                    }
                }
            }
            else
            {
                Log.Error($"Invalid entity data. Show entity with '{nameof(EntityExtension.ShowEntity)}'.");
            }
        }

        public virtual void OnDeinit()
        {
        }

        public virtual void OnRecycle()
        {
        }

        public virtual void OnShow(object userData)
        {
            if (userData is EntityData entityData)
            {
                EntityTypeId = entityData.TypeId;
                DREntity drEntity = entityData.DrEntity;
                if (drEntity != null)
                {
                    if (drEntity.From == 1)
                    {
                        UnityGameFramework.Runtime.Extension.UIExtension.SetTransformFont(Root);
                    }
                }
                Transform newParent = entityData.Parent;
                Transform oldParent = Root.parent;
                if (oldParent != newParent)
                {
                    m_OldParent = oldParent;
                    Root.SetParent(newParent);
                    Root.localPosition = entityData.Position;
                    Root.localScale = entityData.Scale;
                    Root.rotation = entityData.Rotation;
                }
            }
            else
            {
                Log.Error($"Invalid entity data. Show entity with '{nameof(EntityExtension.ShowEntity)}'.");
            }
            // Entity data will be released after initialized, do not keep reference of entity data.
        }

        public virtual void OnHide(bool isShutdown, object userData)
        {
            Root.SetParent(m_OldParent);
            m_OldParent = null;
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
            Entry.Entity.HideEntity(Logic.Entity);
        }
    }
}