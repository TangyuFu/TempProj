using GameFramework;
using GameFramework.Event;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 实体被附加子实体事件。
    /// </summary>
    public class EntityAttachedEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(EntityAttachedEventArgs).GetHashCode();
        public override int Id => EventId;

        public EntityAttachedEventArgs()
        {
        }

        public int EntityHash { get; private set; }

        public int EntityId { get; private set; }

        public EntityLogic ChildEntity { get; private set; }

        public Transform ParentTransform { get; private set; }

        public object UserData { get; private set; }

        public static EntityAttachedEventArgs Create(int entityHash, int entityId, EntityLogic childEntity,
            Transform parentTransform,
            object userData)
        {
            EntityAttachedEventArgs entityAttachedEventArgs = ReferencePool.Acquire<EntityAttachedEventArgs>();
            entityAttachedEventArgs.EntityHash = entityHash;
            entityAttachedEventArgs.EntityId = entityId;
            entityAttachedEventArgs.UserData = userData;
            entityAttachedEventArgs.ChildEntity = childEntity;
            entityAttachedEventArgs.ParentTransform = parentTransform;
            return entityAttachedEventArgs;
        }

        public override void Clear()
        {
            EntityId = default;
            EntityHash = default;
            ChildEntity = default;
            ParentTransform = default;
            UserData = default;
        }
    }
}