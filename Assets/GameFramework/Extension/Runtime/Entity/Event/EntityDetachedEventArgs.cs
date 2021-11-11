using GameFramework;
using GameFramework.Event;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 实体解除子实体事件。
    /// </summary>
    public class EntityDetachedEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(EntityDetachedEventArgs).GetHashCode();
        public override int Id => EventId;

        public EntityDetachedEventArgs()
        {
        }

        public int UniqueId { get; private set; }

        public int EntityId { get; private set; }

        public EntityLogic ChildEntity { get; private set; }

        public object UserData { get; private set; }

        public static EntityDetachedEventArgs Create(int uniqueId, int entityId, EntityLogic childEntity,
            object userData)
        {
            EntityDetachedEventArgs entityDetachedEventArgs = ReferencePool.Acquire<EntityDetachedEventArgs>();
            entityDetachedEventArgs.UniqueId = uniqueId;
            entityDetachedEventArgs.EntityId = entityId;
            entityDetachedEventArgs.UserData = userData;
            entityDetachedEventArgs.ChildEntity = childEntity;
            return entityDetachedEventArgs;
        }

        public override void Clear()
        {
            UniqueId = default;
            EntityId = default;
            ChildEntity = default;
            UserData = default;
        }
    }
}