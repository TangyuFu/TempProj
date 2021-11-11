using GameFramework;
using GameFramework.Event;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 实体附加子实体事件。
    /// </summary>
    public class EntityAttachToEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(EntityAttachToEventArgs).GetHashCode();
        public override int Id => EventId;

        public EntityAttachToEventArgs()
        {
        }

        public int UniqueId { get; private set; }

        public int EntityId { get; private set; }

        public EntityLogic ParentEntity { get; private set; }

        public Transform ParentTransform { get; private set; }

        public object UserData { get; private set; }

        public static EntityAttachToEventArgs Create(int uniqueId, int entityId, EntityLogic parentEntity,
            Transform parentTransform,
            object userData)
        {
            EntityAttachToEventArgs entityAttachToEventArgs = ReferencePool.Acquire<EntityAttachToEventArgs>();
            entityAttachToEventArgs.UniqueId = uniqueId;
            entityAttachToEventArgs.EntityId = entityId;
            entityAttachToEventArgs.UserData = userData;
            entityAttachToEventArgs.ParentEntity = parentEntity;
            entityAttachToEventArgs.ParentTransform = parentTransform;
            return entityAttachToEventArgs;
        }

        public override void Clear()
        {
            EntityId = default;
            UniqueId = default;
            ParentEntity = default;
            ParentTransform = default;
            UserData = default;
        }
    }
}