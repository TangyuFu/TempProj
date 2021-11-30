namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 实体拓展。
    /// </summary>
    public static class EntityExtension
    {
        // 关于 EntityId 的约定：
        // 0 为无效
        // 正值用于和服务器通信的实体（如玩家角色、NPC、怪等，服务器只产生正值）
        // 负值用于本地生成的临时实体（如特效、FakeObject等）
        private static int s_SerialId = 0;

        /// <summary>
        /// 产生实体编号，客户端只会产生负值，正值由服务端生成并且需同步。
        /// </summary>
        /// <param name="entityComponent">实体组件。</param>
        /// <returns>产生的实体编号。</returns>
        public static int GenerateSerialId(this EntityComponent entityComponent)
        {
            return --s_SerialId;
        }

        /// <summary>
        /// 显示自定义实体。
        /// </summary>
        /// <param name="entityComponent">实体组件</param>
        /// <param name="entityId">实体编号。</param>
        /// <param name="entityAssetName">实体资源名称。</param>
        /// <param name="entityGroupName">实体组名称。</param>
        /// <param name="priority">加载实体资源的优先级。</param>
        /// <param name="userData">用户自定义数据。</param>
        public static void ShowCustomEntity(this EntityComponent entityComponent, int entityId, string entityAssetName,
            string entityGroupName, int priority, object userData)
        {
            entityComponent.ShowEntity(entityId, typeof(CustomEntityLogic), entityAssetName, entityGroupName,
                priority, userData);
        }

        /// <summary>
        /// 获取实体。
        /// </summary>
        /// <param name="entityComponent">实体组件。</param>
        /// <param name="entityId">实体 Id 。</param>
        /// <returns>获取的实体</returns>
        public static CustomEntityLogic GetCustomEntity(this EntityComponent entityComponent, int entityId)
        {
            Entity entity = entityComponent.GetEntity(entityId);
            if (entity == null)
            {
                return null;
            }

            return (CustomEntityLogic) entity.Logic;
        }

        /// <summary>
        /// 隐藏实体。
        /// </summary>
        /// <param name="entityComponent">实体组件。</param>
        /// <param name="customEntityLogic">实体。</param>
        public static void HideCustomEntity(this EntityComponent entityComponent, CustomEntityLogic customEntityLogic)
        {
            entityComponent.HideEntity(customEntityLogic.Entity);
        }

        /// <summary>
        /// 附着实体。
        /// </summary>
        /// <param name="entityComponent">实体组件。</param>
        /// <param name="customEntityLogic">要附着的逻辑实体。</param>
        /// <param name="ownerId">被附着的实体 Id。</param>
        /// <param name="parentTransformPath">被附着的 Transform 路径。</param>
        /// <param name="userData">用户自定义数据。</param>
        public static void AttachCustomEntity(this EntityComponent entityComponent, CustomEntityLogic customEntityLogic,
            int ownerId,
            string parentTransformPath = null, object userData = null)
        {
            entityComponent.AttachEntity(customEntityLogic.Entity, ownerId, parentTransformPath, userData);
        }
    }
}