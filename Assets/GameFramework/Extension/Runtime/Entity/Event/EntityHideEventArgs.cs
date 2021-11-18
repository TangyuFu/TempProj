using GameFramework;
using GameFramework.Event;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 实体隐藏事件。
    /// </summary>
    public class EntityHideEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(EntityHideEventArgs).GetHashCode();
        public override int Id => EventId;

        public EntityHideEventArgs()
        {
        }

        public CustomEntityLogic Logic { get; private set; }

        public bool IsShutdown { get; private set; }

        public object UserData { get; private set; }

        public static EntityHideEventArgs Create(CustomEntityLogic logic, bool isShutdown, object userData)
        {
            EntityHideEventArgs eventArgs = ReferencePool.Acquire<EntityHideEventArgs>();
            eventArgs.Logic = logic;
            eventArgs.UserData = userData;
            eventArgs.IsShutdown = isShutdown;
            return eventArgs;
        }

        public override void Clear()
        {
            Logic = default;
            IsShutdown = default;
            UserData = default;
        }
    }
}