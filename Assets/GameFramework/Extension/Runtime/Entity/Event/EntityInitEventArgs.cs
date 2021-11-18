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

        public CustomEntityLogic Logic { get; private set; }

        public object UserData { get; private set; }

        public static EntityInitEventArgs Create(CustomEntityLogic logic, object userData)
        {
            EntityInitEventArgs eventArgs = ReferencePool.Acquire<EntityInitEventArgs>();
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