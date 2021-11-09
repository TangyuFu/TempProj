using System;
using GameFramework.DataTable;
using UnityGameFramework.Runtime.Extension.DataTable;

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

        public static Entity GetEntity(this EntityComponent entityComponent, int entityId)
        {
            Runtime.Entity entity = entityComponent.GetEntity(entityId);
            if (entity == null)
            {
                return null;
            }

            return (Entity) entity.Logic;
        }

        /// <summary>
        /// 隐藏实体。
        /// </summary>
        /// <param name="entityComponent">实体组件。</param>
        /// <param name="entity">逻辑实体。</param>
        public static void HideEntity(this EntityComponent entityComponent, Entity entity)
        {
            entityComponent.HideEntity(entity.Entity);
        }

        /// <summary>
        /// 附着实体。
        /// </summary>
        /// <param name="entityComponent">实体组件。</param>
        /// <param name="entity">要附着的逻辑实体。</param>
        /// <param name="ownerId">被附着的实体 Id。</param>
        /// <param name="parentTransformPath">被附着的 Transform 路径。</param>
        /// <param name="userData">用户自定义数据。</param>
        public static void AttachEntity(this EntityComponent entityComponent, Entity entity, int ownerId,
            string parentTransformPath = null, object userData = null)
        {
            entityComponent.AttachEntity(entity.Entity, ownerId, parentTransformPath, userData);
        }

        /// <summary>
        /// 显示实体。
        /// </summary>
        /// <param name="entityComponent">实体组件。</param>
        /// <param name="entityData">实体数据。</param>
        public static void ShowEntity(this EntityComponent entityComponent, EntityData entityData)
        {
            if (entityData == null)
            {
                Log.Error($"Invalid entity data '{null}'.");
                return;
            }

            IDataTable<DREntity> dtEntity = Entry.DataTable.GetDataTable<DREntity>();
            DREntity drEntity = dtEntity.GetDataRow(entityData.TypeId);
            if (drEntity == null)
            {
                Log.Error("Can not load entity id '{0}' from data table.", entityData.TypeId.ToString());
                return;
            }

            IDataTable<DREntityGroup> dtEntityGroup = Entry.DataTable.GetDataTable<DREntityGroup>();
            DREntityGroup drEntityGroup = dtEntityGroup.GetDataRow(drEntity.GroupId);
            if (drEntityGroup == null)
            {
                Log.Error($"Entity id '{entityData.TypeId}' has no group id '{drEntity.GroupId}'.");
                return;
            }

            if (!entityComponent.HasEntityGroup(drEntityGroup.GroupName))
            {
                entityComponent.AddEntityGroup(drEntityGroup.GroupName, drEntityGroup.ReleaseInterval,
                    drEntityGroup.Capacity, drEntityGroup.ExpireTime, drEntityGroup.Priority);
            }

            entityData.DrEntity = drEntity;
            string assetName = null;
            switch (drEntity.From)
            {
                case 1:
                    assetName = UUtility.Asset.GetModelEntityPath(drEntity.AssetName);
                    break;

                case 2:
                    assetName = UUtility.Asset.GetEffectEntityPath(drEntity.AssetName);
                    break;

                case 3:
                    assetName = UUtility.Asset.GetUIItemPath(drEntity.AssetName);
                    break;

                default:
                    Log.Error($"Invalid entity from '{drEntity.From}', must between 1 and 3。");
                    return;
            }

            string entityGroup = drEntityGroup.GroupName;
            int priority = drEntity.Priority;
            entityComponent.ShowEntity(entityData.EntityId, typeof(Entity), assetName, entityGroup, priority, entityData);
        }

        /// <summary>
        /// 产生实体编号，客户端只会产生负值，正值由服务端生成并且需同步。
        /// </summary>
        /// <param name="entityComponent">实体组件。</param>
        /// <returns>产生的实体编号。</returns>
        public static int GenerateSerialId(this EntityComponent entityComponent)
        {
            return --s_SerialId;
        }
    }
}