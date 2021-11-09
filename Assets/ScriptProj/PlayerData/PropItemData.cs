using UnityGameFramework.Runtime.Extension.DataTable;

namespace TempProj
{
    /// <summary>
    /// 背包道具数据。
    /// </summary>
    public struct PropItemData
    {
        public PropItemData(int itemId, int itemCount, DRPropGroup drBackpackGroup, DRProp drBackpack)
        {
            ItemId = itemCount;
            ItemCount = itemCount;
            DrBackpackGroup = drBackpackGroup;
            DrBackpack = drBackpack;
        }

        /// <summary>
        /// 道具 Id。
        /// </summary>
        public int ItemId { get; }

        /// <summary>
        /// 道具数量。
        /// </summary>
        public int ItemCount { get; set; }

        /// <summary>
        /// 道具组配置。
        /// </summary>
        public DRPropGroup DrBackpackGroup { get; }

        /// <summary>
        /// 道具配置。
        /// </summary>
        public DRProp DrBackpack { get; }
    }
}