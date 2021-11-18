using GameFramework;
using GameFramework.Event;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 实体附加子实体事件。
    /// </summary>
    public class EntityAttachToEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(EntityAttachToEventArgs).GetHashCode();
        public override int Id => EventId;

        public EntityAttachToEventArgs()
        {
        }

        public CustomEntityLogic Logic { get; private set; }

        public CustomEntityLogic ParentLogic { get; private set; }

        public Transform ParentTransform { get; private set; }

        public object UserData { get; private set; }

        public static EntityAttachToEventArgs Create(CustomEntityLogic logic, CustomEntityLogic parentLogic,
            Transform parentTransform,
            object userData)
        {
            EntityAttachToEventArgs eventArgs = ReferencePool.Acquire<EntityAttachToEventArgs>();
            eventArgs.Logic = logic;
            eventArgs.ParentLogic = parentLogic;
            eventArgs.ParentTransform = parentTransform;
            eventArgs.UserData = userData;
            return eventArgs;
        }

        public override void Clear()
        {
            Logic = default;
            ParentLogic = default;
            ParentTransform = default;
            UserData = default;
        }
    }
}