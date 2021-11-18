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

        public CustomEntityLogic Logic { get; private set; }

        public CustomEntityLogic ChildLogic { get; private set; }

        public object UserData { get; private set; }

        public static EntityDetachedEventArgs Create(CustomEntityLogic logic, CustomEntityLogic childLogic,
            object userData)
        {
            EntityDetachedEventArgs eventArgs = ReferencePool.Acquire<EntityDetachedEventArgs>();
            eventArgs.Logic = logic;
            eventArgs.ChildLogic = childLogic;
            eventArgs.UserData = userData;
            return eventArgs;
        }

        public override void Clear()
        {
            Logic = default;
            ChildLogic = default;
            UserData = default;
        }
    }
}