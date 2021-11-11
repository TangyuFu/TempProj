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

        public int UniqueId { get; private set; }
        
        public int EntityId { get; private set; }

        public bool IsShutdown { get; private set; }

        public object UserData { get; private set; }

        public static EntityHideEventArgs Create(int uniqueId, int entityId, bool isShutdown, object userData)
        {
            EntityHideEventArgs entityHideEventArgs = ReferencePool.Acquire<EntityHideEventArgs>();
            entityHideEventArgs.EntityId = entityId;
            entityHideEventArgs.UniqueId = uniqueId;
            entityHideEventArgs.UserData = userData;
            entityHideEventArgs.IsShutdown = isShutdown;
            return entityHideEventArgs;
        }

        public override void Clear()
        {
            EntityId = default;
            UniqueId = default;
            IsShutdown = default;
            UserData = default;
        }
    }
}