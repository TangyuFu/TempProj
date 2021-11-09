using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 实体代表者。
    /// </summary>
    public interface IEntityPresenter
    {
        /// <summary>
        /// 获取实体 Id。
        /// </summary>
        int EntityId { get; }

        /// <summary>
        /// 实体代表者的目标物体。
        /// </summary>
        public GameObject Target { get; }

        /// <summary>
        /// 初始化时调用，
        /// </summary>
        /// <param name="target">实体目标物体。</param>
        /// <param name="userData">用户自定义数据。</param>
        void OnInit(GameObject target, object userData);

        /// <summary>
        /// 反初始化时调用。
        /// </summary>
        void OnDeinit();

        /// <summary>
        /// 回收时调用，对象池回收时调用，使用 OnDeinit 作为反初始化。
        /// </summary>
        void OnRecycle();

        /// <summary>
        /// 显示时调用，
        /// </summary>
        /// <param name="entityId">实体序列化 Id。</param>
        /// <param name="userData">用户自定义数据。</param>
        void OnShow(int entityId, object userData);

        /// <summary>
        /// 隐藏时调用。
        /// </summary>
        /// <param name="isShutdown">是否关闭对象池。</param>
        /// <param name="userData">用户自定义数据。</param>
        void OnHide(bool isShutdown, object userData);

        /// <summary>
        /// 被其他实体依附时调用。
        /// </summary>
        /// <param name="childEntity">子实体。</param>
        /// <param name="parentTransform">父物体。</param>
        /// <param name="userData">用户自定义数据。</param>
        void OnAttached(EntityLogic childEntity, Transform parentTransform, object userData);

        /// <summary>
        /// 被其他实体解除依附时调用.
        /// </summary>
        /// <param name="childEntity">子实体。</param>
        /// <param name="userData">用户自定义数据。</param>
        void OnDetached(EntityLogic childEntity, object userData);

        /// <summary>
        /// 依附到其他实体时调用。
        /// </summary>
        /// <param name="parentEntity">父实体。</param>
        /// <param name="parentTransform">父物体。</param>
        /// <param name="userData">用户自定义数据。</param>
        void OnAttachTo(EntityLogic parentEntity, Transform parentTransform, object userData);

        /// <summary>
        /// 依附其他实体解除时调用。
        /// </summary>
        /// <param name="parentEntity">父实体。</param>
        /// <param name="userData">用户自定义数据。</param>
        void OnDetachFrom(EntityLogic parentEntity, object userData);

        /// <summary>
        /// 更新时调用。
        /// </summary>
        /// <param name="elapseSeconds">游戏逻辑流逝时间。</param>
        /// <param name="realElapseSeconds">游戏真实流逝时间。</param>
        void OnUpdate(float elapseSeconds, float realElapseSeconds);
    }
}