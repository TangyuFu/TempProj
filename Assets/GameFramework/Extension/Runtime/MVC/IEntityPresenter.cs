using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 实体代表者接口。
    /// </summary>
    public interface IEntityPresenter
    {
        /// <summary>
        /// 获取实体唯一标识符。
        /// </summary>
        int UniqueId { get; }

        /// <summary>
        /// 获取实体 Id。
        /// </summary>
        int EntityId { get; }

        /// <summary>
        /// 获取实体类型 ID 。
        /// </summary>
        int EntityTypeId { get; }

        /// <summary>
        /// 获取实体代表者的根物体。
        /// </summary>
        Transform Root { get; }
        
        /// <summary>
        /// 获取实体。
        /// </summary>
        CustomEntityLogic Logic { get; }
        
        /// <summary>
        /// 初始化时调用。
        /// </summary>
        /// <param name="logic">实体。</param>
        /// <param name="root">实体根物体。</param>
        /// <param name="userData">用户自定义数据。</param>
        void OnInit(CustomEntityLogic logic, Transform root, object userData);

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
        /// <param name="userData">用户自定义数据。</param>
        void OnShow(object userData);

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

        /// <summary>
        /// 隐藏当前实体。
        /// </summary>
        void Hide();
    }
}