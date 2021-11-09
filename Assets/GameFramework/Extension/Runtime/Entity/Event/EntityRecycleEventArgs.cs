using GameFramework;
using GameFramework.Event;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 实体回收事件。
    /// </summary>
    public class EntityRecycleEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(EntityRecycleEventArgs).GetHashCode();
        public override int Id => EventId;

        public EntityRecycleEventArgs()
        {
        }

        public int EntityHash { get; private set; }

        public int EntityId { get; private set; }

        public static EntityRecycleEventArgs Create(int entityHash, int entityId)
        {
            EntityRecycleEventArgs entityRecycleEventArgs = ReferencePool.Acquire<EntityRecycleEventArgs>();
            entityRecycleEventArgs.EntityHash = entityHash;
            entityRecycleEventArgs.EntityId = entityId;
            return entityRecycleEventArgs;
        }

        public override void Clear()
        {
            EntityHash = default;
            EntityId = default;
        }
    }
}