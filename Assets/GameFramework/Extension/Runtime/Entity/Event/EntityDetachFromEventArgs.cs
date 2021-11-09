using GameFramework;
using GameFramework.Event;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 实体被解除子实体事件。
    /// </summary>
    public class EntityDetachFromEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(EntityDetachFromEventArgs).GetHashCode();
        public override int Id => EventId;

        public EntityDetachFromEventArgs()
        {
        }

        public int EntityHash { get; private set; }

        public int EntityId { get; private set; }

        public EntityLogic ParentEntity { get; private set; }

        public object UserData { get; private set; }

        public static EntityDetachFromEventArgs Create(int entityHash, int entityId, EntityLogic parentEntity,
            object userData)
        {
            EntityDetachFromEventArgs entityDetachFromEventArgs = ReferencePool.Acquire<EntityDetachFromEventArgs>();
            entityDetachFromEventArgs.EntityId = entityId;
            entityDetachFromEventArgs.EntityHash = entityHash;
            entityDetachFromEventArgs.UserData = userData;
            entityDetachFromEventArgs.ParentEntity = parentEntity;
            return entityDetachFromEventArgs;
        }

        public override void Clear()
        {
            EntityId = default;
            EntityHash = default;
            ParentEntity = default;
            UserData = default;
        }
    }
}