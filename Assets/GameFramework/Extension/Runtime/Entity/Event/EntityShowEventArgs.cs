using GameFramework;
using GameFramework.Event;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 实体显示事件。
    /// </summary>
    public class EntityShowEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(EntityShowEventArgs).GetHashCode();
        public override int Id => EventId;

        public EntityShowEventArgs()
        {
        }

        public int EntityHash { get; private set; }

        public int EntityId { get; private set; }

        public EntityLogic Entity { get; private set; }

        public GameObject EntityGO { get; private set; }

        public object UserData { get; private set; }

        public static EntityShowEventArgs Create(int entityHash, int entityId, EntityLogic entity, GameObject entityGO,
            object userData)
        {
            EntityShowEventArgs entityShowEventArgs = ReferencePool.Acquire<EntityShowEventArgs>();
            entityShowEventArgs.EntityHash = entityHash;
            entityShowEventArgs.EntityId = entityId;
            entityShowEventArgs.Entity = entity;
            entityShowEventArgs.EntityGO = entityGO;
            entityShowEventArgs.UserData = userData;
            return entityShowEventArgs;
        }

        public override void Clear()
        {
            EntityHash = default;
            EntityId = default;
            Entity = default;
            EntityGO = default;
            UserData = default;
        }
    }
}