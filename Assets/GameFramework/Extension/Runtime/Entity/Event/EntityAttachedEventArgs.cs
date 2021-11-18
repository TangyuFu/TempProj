using GameFramework;
using GameFramework.Event;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 实体被附加子实体事件。
    /// </summary>
    public class EntityAttachedEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(EntityAttachedEventArgs).GetHashCode();
        public override int Id => EventId;

        public EntityAttachedEventArgs()
        {
        }

        public CustomEntityLogic Logic { get; private set; }

        public CustomEntityLogic ChildLogic { get; private set; }

        public Transform ParentTransform { get; private set; }

        public object UserData { get; private set; }

        public static EntityAttachedEventArgs Create(CustomEntityLogic logic, CustomEntityLogic childLogic,
            Transform parentTransform,
            object userData)
        {
            EntityAttachedEventArgs eventArgs = ReferencePool.Acquire<EntityAttachedEventArgs>();
            eventArgs.Logic = logic;
            eventArgs.ChildLogic = childLogic;
            eventArgs.ParentTransform = parentTransform;
            eventArgs.UserData = userData;
            return eventArgs;
        }

        public override void Clear()
        {
            Logic = default;
            ChildLogic = default;
            ParentTransform = default;
            UserData = default;
        }
    }
}