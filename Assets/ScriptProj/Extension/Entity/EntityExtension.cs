using TempProj.DataTable;
using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    /// <summary>
    /// 实体拓展。
    /// </summary>
    public static class EntityExtension
    {
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

            DREntityGroup drEntityGroup = entityData.DrEntityGroup;
            DREntity drEntity = entityData.DrEntity;
            if (drEntityGroup == null || drEntity == null)
            {
                Log.Error($"Invalid drEntity '{drEntity}' or drEntityGroup '{drEntityGroup}'.");
                return;
            }

            if (!entityComponent.HasEntityGroup(drEntityGroup.GroupName))
            {
                entityComponent.AddEntityGroup(drEntityGroup.GroupName, drEntityGroup.ReleaseInterval,
                    drEntityGroup.Capacity, drEntityGroup.ExpireTime, drEntityGroup.Priority);
            }

            string assetName = null;
            switch (drEntity.From)
            {
                case 1:
                    assetName = UUtility.Asset.GetUIEntitiesPath(drEntity.AssetName);
                    break;

                case 2:
                    assetName = UUtility.Asset.GetEffectEntityPath(drEntity.AssetName);
                    break;

                case 3:
                    assetName = UUtility.Asset.GetModelEntityPath(drEntity.AssetName);
                    break;

                default:
                    Log.Error($"Invalid entity from '{drEntity.From}', must between 1 and 3。");
                    return;
            }

            entityComponent.ShowCustomEntity(entityData.EntityId, assetName, drEntityGroup.GroupName, 0, entityData);
        }
    }
}