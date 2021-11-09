using GameFramework;
using GameFramework.Event;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 实体反初始化事件。
    /// </summary>
    public class EntityDeinitEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(EntityDeinitEventArgs).GetHashCode();
        public override int Id => EventId;

        public EntityDeinitEventArgs()
        {
        }

        public int EntityHash { get; private set; }

        public int EntityId { get; private set; }

        public EntityLogic Entity { get; private set; }

        public GameObject EntityGO { get; private set; }

        public static EntityDeinitEventArgs Create(int entityHash, int entityId, EntityLogic entity,
            GameObject entityGO)
        {
            EntityDeinitEventArgs entityDeinitEventArgs = ReferencePool.Acquire<EntityDeinitEventArgs>();
            entityDeinitEventArgs.EntityHash = entityHash;
            entityDeinitEventArgs.EntityId = entityId;
            entityDeinitEventArgs.Entity = entity;
            entityDeinitEventArgs.EntityGO = entityGO;
            return entityDeinitEventArgs;
        }

        public override void Clear()
        {
            EntityHash = default;
            EntityId = default;
            Entity = default;
            EntityGO = default;
        }
    }
}