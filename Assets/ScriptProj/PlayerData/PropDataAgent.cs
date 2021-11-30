using System.Collections.Generic;
using GameFramework.DataTable;
using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;
using TempProj.DataTable;

namespace TempProj
{
    /// <summary>
    /// 背包数据代理。
    /// </summary>
    public class PropDataAgent : PlayerDataAgent<PropData>
    {
        public override bool Local { get; } = true;

        protected override PropData DefaultData { get; } = new()
        {
            DataList = new List<PropItemData>
            {
                new()
                {
                    Id = 10000001,
                    Count = 1,
                },
                new()
                {
                    Id = 10000002,
                    Count = 2,
                },
                new()
                {
                    Id = 10000003,
                    Count = 3,
                },
                new()
                {
                    Id = 20000001,
                    Count = 4,
                },
                new()
                {
                    Id = 30000001,
                    Count = 5,
                }
            }
        };

        private readonly Dictionary<int, PropItemData> m_Items = new();

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

            for (int i = 0; i < Data.DataList.Count; i++)
            {
                PropItemData rawData = Data.DataList[i];
                PropItemData itemData = InternalCreateItemData(rawData.Id, rawData.Count, rawData.IsNew);
                m_Items.Add(rawData.Id, itemData);
            }
            
            Data.DataList.Clear();
            return true;
        }

        public override bool Save()
        {
            foreach (var item in m_Items)
            {
                Data.DataList.Add(item.Value);
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
                if (itemData.Count > 0)
                {
                    PropItemData propItemData = new PropItemData
                    {
                        IsNew = itemData.IsNew,
                        Id = itemData.Id,
                        Count = itemData.Count,
                        DrPropGroup = itemData.DrPropGroup,
                        DrProp = itemData.DrProp,
                    };
                    results.Add(propItemData);
                }
            }
        }

        /// <summary>
        /// 检查道具是否足够。
        /// </summary>
        /// <param name="itemId">道具 Id。</param>
        /// <param name="compCount">对比数量。</param>
        /// <returns>道具是否足够。</returns>
        public bool IsItemEnough(int itemId, int compCount)
        {
            if (compCount < 0)
            {
                Log.Warning($"Compare item count with '{compCount}' less than 0");
            }

            return GetItemCount(itemId) >= compCount;
        }

        /// <summary>
        /// 获取道具数量。
        /// </summary>
        /// <param name="itemId">道具 Id。</param>
        /// <returns>道具数量。</returns>
        public int GetItemCount(int itemId)
        {
            return m_Items.ContainsKey(itemId) ? m_Items[itemId].Count : 0;
        }

        /// <summary>
        /// 设置道具数量。
        /// </summary>
        /// <param name="itemId">道具 Id。</param>
        /// <param name="itemCount">道具数量。</param>
        public void SetItemCount(int itemId, int itemCount)
        {
            PropItemData itemData = InternalGetItemData(itemId);
            itemData.Count = itemCount;
        }

        /// <summary>
        /// 增加道具。
        /// </summary>
        /// <param name="itemId">道具 Id。</param>
        /// <param name="addCount">增加数量。</param>
        public void AddItemCount(int itemId, int addCount)
        {
            if (addCount < 0)
            {
                Log.Error($"Add item count '{addCount}' less than 0");
                return;
            }

            PropItemData itemData = InternalGetItemData(itemId);
            itemData.Count += addCount;
        }

        /// <summary>
        /// 减少道具数量。
        /// </summary>
        /// <param name="itemId">道具 Id。</param>
        /// <param name="subCount">减少数量。</param>
        public void SubItemCount(int itemId, int subCount)
        {
            if (subCount < 0)
            {
                Log.Error($"Sub item count '{subCount}' less than 0");
                return;
            }

            PropItemData itemData = InternalGetItemData(itemId);
            if (subCount > itemData.Count)
            {
                Log.Error($"Sub too many item count '{subCount}', only left '{itemData.Count}'.");
            }
            else
            {
                itemData.Count -= subCount;
            }
        }

        /// <summary>
        /// 清空所有道具。
        /// </summary>
        public void RemoveAllItems()
        {
            m_Items.Clear();
        }

        private PropItemData InternalCreateItemData(int itemId, int itemCount, bool isNew)
        {
            DRProp drProp = m_DtProp[itemId];
            if (drProp == null)
            {
                Log.Error($"Invalid prop id '{itemId}', check prop config table.");
                return default;
            }

            DRPropGroup drPropGroup = m_DtPropGroup[drProp.GroupId];
            if (drPropGroup == null)
            {
                Log.Error($"Invalid prop group id '{drProp.GroupId}', check prop group config table.");
                return default;
            }

            PropItemData propItemData = new PropItemData
            {
                IsNew = isNew,
                Id = itemId,
                Count = itemCount,
                DrPropGroup = drPropGroup,
                DrProp = drProp,
            };
            return propItemData;
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
                itemData = InternalCreateItemData(itemId, 0, false);
                m_Items.Add(itemId, itemData);
            }

            return itemData;
        }
    }
}