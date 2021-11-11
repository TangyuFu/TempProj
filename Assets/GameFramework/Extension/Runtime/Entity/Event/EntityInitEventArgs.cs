using GameFramework;
using GameFramework.Event;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 实体初始化事件。
    /// </summary>
    public class EntityInitEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(EntityInitEventArgs).GetHashCode();
        public override int Id => EventId;

        public EntityInitEventArgs()
        {
        }

        public int UniqueId { get; private set; }

        public int EntityId { get; private set; }
        
        public int EntityTypeId { get; private set; }

        public Entity Entity { get; private set; }

        public GameObject Root { get; private set; }

        public object UserData { get; private set; }

        public static EntityInitEventArgs Create(int uniqueId, int entityId, int entityType, Entity entity, GameObject root,
            object userData)
        {
            EntityInitEventArgs entityInitEventArgs = ReferencePool.Acquire<EntityInitEventArgs>();
            entityInitEventArgs.UniqueId = uniqueId;
            entityInitEventArgs.EntityId = entityId;
            entityInitEventArgs.EntityTypeId = entityType;
            entityInitEventArgs.Entity = entity;
            entityInitEventArgs.Root = root;
            entityInitEventArgs.UserData = userData;
            return entityInitEventArgs;
        }

        public override void Clear()
        {
            UniqueId = default;
            EntityId = default;
            EntityTypeId = default;
            Entity = default;
            Root = default;
            UserData = default;
        }
    }
}