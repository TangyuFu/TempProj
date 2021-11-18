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

        public CustomEntityLogic Logic { get; private set; }

        public float ElapseSeconds { get; private set; }

        public float RealElapseSeconds { get; private set; }

        public object UserData { get; private set; }

        public static EntityUpdateEventArgs Create(CustomEntityLogic logic, float elapseSeconds,
            float realElapseSeconds,
            object userData)
        {
            EntityUpdateEventArgs entityUpdateEventArgs = ReferencePool.Acquire<EntityUpdateEventArgs>();
            entityUpdateEventArgs.Logic = logic;
            entityUpdateEventArgs.ElapseSeconds = elapseSeconds;
            entityUpdateEventArgs.RealElapseSeconds = realElapseSeconds;
            entityUpdateEventArgs.UserData = userData;
            return entityUpdateEventArgs;
        }

        public override void Clear()
        {
            Logic = default;
            ElapseSeconds = default;
            RealElapseSeconds = default;
            UserData = default;
        }
    }
}