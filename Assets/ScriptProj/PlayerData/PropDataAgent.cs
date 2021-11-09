using System.Collections.Generic;
using GameFramework.DataTable;
using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;
using UnityGameFramework.Runtime.Extension.DataTable;

namespace TempProj
{
    /// <summary>
    /// 背包数据代理。
    /// </summary>
    public class PropDataAgent : PlayerDataAgent<PropData>
    {
        public override bool Local { get; } = true;

        protected override PropData DefaultData { get; } = new PropData
        {
            ItemIds = {10000001, 10000002, 10000003, 20000001, 30000001},
            ItemCounts = {1, 2, 3, 4, 5}
        };

        private readonly Dictionary<int, PropItemData> m_Items = new Dictionary<int, PropItemData>();

        private IDataTable<DRPropGroup> m_DtPropGroup;

        private IDataTable<DRProp> m_DtProp;

        public override bool Load()
        {
            m_DtPropGroup = Entry.DataTable.GetDataTable<DRPropGroup>();
            m_DtProp = Entry.DataTable.GetDataTable<DRProp>();

            bool result = base.Load();
            if (result == false)
            {
                return false;
            }

            for (int i = 0; i < Data.ItemIds.Count; i++)
            {
                int itemId = Data.ItemIds[i];
                int itemCount = Data.ItemCounts[i];
                PropItemData itemData = CreateItemData(itemId, itemCount);
                m_Items.Add(itemId, itemData);
            }

            Data.ItemIds.Clear();
            Data.ItemCounts.Clear();
            return true;
        }

        public override bool Save()
        {
            foreach (var item in m_Items)
            {
                int itemId = item.Key;
                int itemCount = item.Value.ItemCount;
                Data.ItemIds.Add(itemId);
                Data.ItemCounts.Add(itemCount);
            }

            return base.Save();
        }

        /// <summary>
        /// 获取所有道具数据。
        /// </summary>
        /// <returns>所有道具数据。</returns>
        public PropItemData[] GetAllItemData()
        {
            List<PropItemData> results = new List<PropItemData>();
            GetAllItemData(results);
            return results.ToArray();
        }

        /// <summary>
        /// 获取所有道具数据。
        /// </summary>
        /// <param name="results">所有道具数据。</param>
        public void GetAllItemData(List<PropItemData> results)
        {
            if (results == null)
            {
                Log.Error("Invalid backpack item data list.");
                return;
            }

            results.Clear();
            foreach (var kv in m_Items)
            {
                PropItemData itemData = kv.Value;
                if (itemData.ItemCount > 0)
                {
                    results.Add(new PropItemData(itemData.ItemId, itemData.ItemCount, itemData.DrBackpackGroup,
                        itemData.DrBackpack));
                }
            }
        }

        /// <summary>
        /// 获取道具数量。
        /// </summary>
        /// <param name="itemId">道具 Id。</param>
        /// <returns>道具数量。</returns>
        public int GetItemCount(int itemId)
        {
            return m_Items.ContainsKey(itemId) ? m_Items[itemId].ItemCount : 0;
        }

        /// <summary>
        /// 设置道具数量。
        /// </summary>
        /// <param name="itemId">道具 Id。</param>
        /// <param name="itemCount">道具数量。</param>
        public void SetItemCount(int itemId, int itemCount)
        {
            PropItemData itemData = InternalGetItemData(itemId);
            itemData.ItemCount = itemCount;
        }

        /// <summary>
        /// 检查道具是否足够。
        /// </summary>
        /// <param name="itemId">道具 Id。</param>
        /// <param name="compCount">对比数量。</param>
        /// <returns>道具是否足够。</returns>
        public bool CheckItemEnough(int itemId, int compCount)
        {
            if (compCount < 0)
            {
                Log.Warning($"Compare item count with '{compCount}' less than 0");
            }

            return GetItemCount(itemId) >= compCount;
        }

        /// <summary>
        /// 增加道具。
        /// </summary>
        /// <param name="itemId">道具 Id。</param>
        /// <param name="itemCount">增加数量。</param>
        public void AddItemCount(int itemId, int itemCount)
        {
            if (itemCount < 0)
            {
                Log.Warning($"Add item count with '{itemCount}' less than 0");
            }

            PropItemData itemData = InternalGetItemData(itemId);
            itemData.ItemCount += itemCount;
        }

        /// <summary>
        /// 减少道具数量。
        /// </summary>
        /// <param name="itemId">道具 Id。</param>
        /// <param name="itemCount">减少数量。</param>
        public void RemoveItemCount(int itemId, int itemCount)
        {
            if (itemCount < 0)
            {
                Log.Warning($"Remove item count with '{itemCount}' less than 0");
            }

            PropItemData itemData = InternalGetItemData(itemId);
            itemData.ItemCount -= itemCount;
        }

        /// <summary>
        /// 清空所有道具。
        /// </summary>
        public void RemoveAllItems()
        {
            m_Items.Clear();
        }

        public PropItemData CreateItemData(int itemId, int itemCount)
        {
            if (m_Items.TryGetValue(itemId, out var itemData))
            {
                PropItemData propItemData = new PropItemData(itemId, itemCount, itemData.DrBackpackGroup, itemData.DrBackpack);
                return propItemData;
            }
            else
            {
                DRProp drBackpack = m_DtProp[itemId];
                if (drBackpack == null)
                {
                    Log.Error($"Invalid prop id '{itemId}', check prop config table.");
                    return default;
                }

                DRPropGroup drBackpackGroup = m_DtPropGroup[drBackpack.GroupId];
                if (drBackpackGroup == null)
                {
                    Log.Error($"Invalid prop group id '{drBackpack.GroupId}', check prop group config table.");
                    return default;
                }

                PropItemData propItemData = new PropItemData(itemId, itemCount, drBackpackGroup, drBackpack);
                return propItemData;
            }
        }

        /// <summary>
        /// 获取道具数据。
        /// </summary>
        /// <param name="itemId">道具 Id。</param>
        /// <returns>获取到的道具数据。</returns>
        private PropItemData InternalGetItemData(int itemId)
        {
            if (!m_Items.TryGetValue(itemId, out var itemData))
            {
                itemData = CreateItemData(itemId, 0);
                m_Items.Add(itemId, itemData);
            }

            return itemData;
        }
    }
}