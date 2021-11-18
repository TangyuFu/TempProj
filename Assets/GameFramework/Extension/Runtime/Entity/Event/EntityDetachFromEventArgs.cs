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

        public CustomEntityLogic Logic { get; private set; }

        public CustomEntityLogic ParentLogic { get; private set; }

        public object UserData { get; private set; }

        public static EntityDetachFromEventArgs Create(CustomEntityLogic logic, CustomEntityLogic parentLogic,
            object userData)
        {
            EntityDetachFromEventArgs eventArgs = ReferencePool.Acquire<EntityDetachFromEventArgs>();
            eventArgs.Logic = logic;
            eventArgs.ParentLogic = parentLogic;
            eventArgs.UserData = userData;
            return eventArgs;
        }

        public override void Clear()
        {
            Logic = default;
            ParentLogic = default;
            UserData = default;
        }
    }
}