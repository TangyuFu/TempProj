using GameFramework;
using GameFramework.Event;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 实体更新事件。
    /// </summary>
    public class EntityUpdateEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(EntityHideEventArgs).GetHashCode();
        public override int Id => EventId;

        public EntityUpdateEventArgs()
        {
        }

        public int EntityHash { get; private set; }

        public int EntityId { get; private set; }

        public float ElapseSeconds { get; private set; }

        public float RealElapseSeconds { get; private set; }

        public object UserData { get; private set; }

        public static EntityUpdateEventArgs Create(int entityHash, int entityId, float elapseSeconds,
            float realElapseSeconds,
            object userData)
        {
            EntityUpdateEventArgs entityUpdateEventArgs = ReferencePool.Acquire<EntityUpdateEventArgs>();
            entityUpdateEventArgs.EntityHash = entityId;
            entityUpdateEventArgs.EntityId = entityId;
            entityUpdateEventArgs.ElapseSeconds = elapseSeconds;
            entityUpdateEventArgs.RealElapseSeconds = realElapseSeconds;
            entityUpdateEventArgs.UserData = userData;
            return entityUpdateEventArgs;
        }

        public override void Clear()
        {
            EntityHash = default;
            EntityId = default;
            ElapseSeconds = default;
            RealElapseSeconds = default;
            UserData = default;
        }
    }
}