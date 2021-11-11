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

        public int UniqueId { get; private set; }

        public int EntityId { get; private set; }

        public static EntityRecycleEventArgs Create(int uniqueId, int entityId)
        {
            EntityRecycleEventArgs entityRecycleEventArgs = ReferencePool.Acquire<EntityRecycleEventArgs>();
            entityRecycleEventArgs.UniqueId = uniqueId;
            entityRecycleEventArgs.EntityId = entityId;
            return entityRecycleEventArgs;
        }

        public override void Clear()
        {
            UniqueId = default;
            EntityId = default;
        }
    }
}