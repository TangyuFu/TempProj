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

        public CustomEntityLogic Logic { get; private set; }

        public object UserData { get; private set; }

        public static EntityDeinitEventArgs Create(CustomEntityLogic logic, object userData)
        {
            EntityDeinitEventArgs eventArgs = ReferencePool.Acquire<EntityDeinitEventArgs>();
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