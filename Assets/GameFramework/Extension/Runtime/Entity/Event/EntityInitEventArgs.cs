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

        public int EntityHash { get; private set; }

        public int EntityId { get; private set; }
        
        public int EntityTypeId { get; private set; }

        public EntityLogic Entity { get; private set; }

        public GameObject EntityGO { get; private set; }

        public object UserData { get; private set; }

        public static EntityInitEventArgs Create(int entityHash, int entityId, int entityType, EntityLogic entity, GameObject entityGO,
            object userData)
        {
            EntityInitEventArgs entityInitEventArgs = ReferencePool.Acquire<EntityInitEventArgs>();
            entityInitEventArgs.EntityHash = entityHash;
            entityInitEventArgs.EntityId = entityId;
            entityInitEventArgs.EntityTypeId = entityType;
            entityInitEventArgs.Entity = entity;
            entityInitEventArgs.EntityGO = entityGO;
            entityInitEventArgs.UserData = userData;
            return entityInitEventArgs;
        }

        public override void Clear()
        {
            EntityHash = default;
            EntityId = default;
            EntityTypeId = default;
            Entity = default;
            EntityGO = default;
            UserData = default;
        }
    }
}