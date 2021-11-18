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

        public CustomEntityLogic Logic { get; private set; }

        public object UserData { get; private set; }

        public static EntityShowEventArgs Create(CustomEntityLogic logic, object userData)
        {
            EntityShowEventArgs eventArgs = ReferencePool.Acquire<EntityShowEventArgs>();
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