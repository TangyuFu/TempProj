using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 自定义实体辅助器。
    /// </summary>
    public class CustomEntityHelper : DefaultEntityHelper
    {
        /// <summary>
        /// 释放实体时，添加反初始化回调。
        /// </summary>
        /// <param name="entityAsset">实体资源。</param>
        /// <param name="entityInstance">实体实例。</param>
        public override void ReleaseEntity(object entityAsset, object entityInstance)
        {
            GameObject entityGO = entityInstance as GameObject;
            if (entityGO != null)
            {
                entityGO.GetComponent<CustomEntityLogic>()?.OnDeinit();
            }

            base.ReleaseEntity(entityAsset, entityInstance);
        }
    }
}