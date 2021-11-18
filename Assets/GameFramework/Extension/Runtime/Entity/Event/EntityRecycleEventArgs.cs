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

        public CustomEntityLogic Logic { get; private set; }

        public object UserData { get; private set; }


        public static EntityRecycleEventArgs Create(CustomEntityLogic logic,
            object userData)
        {
            EntityRecycleEventArgs eventArgs = ReferencePool.Acquire<EntityRecycleEventArgs>();
            eventArgs.Logic = logic;
            eventArgs.UserData = userData;
            return eventArgs;
        }

        public override void Clear()
        {
            Logic = default;
            UserData = default;
        }
    }
}