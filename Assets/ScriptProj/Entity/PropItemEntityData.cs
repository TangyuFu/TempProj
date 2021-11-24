using System;
using GameFramework;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    /// <summary>
    /// 背包数据。
    /// </summary>
    public class PropItemEntityData : CustomEntityData
    {
        public PropItemEntityData()
        {
        }

        /// <summary>
        /// 道具 ID 。
        /// </summary>
        public int ItemId { get; set; }

        /// <summary> 
        /// 道具数量。
        /// </summary>
        public int ItemCount { get; set; }
        
        /// <summary> 
        /// 是否被选取。
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// 点击点击事件。
        /// </summary>
        public Action<PropItemPresenter> ShowCallback { get; set; }

        /// <summary>
        /// 点击点击事件。
        /// </summary>
        public Action<PropItemPresenter> ClickCallback { get; set; }

        public static PropItemEntityData Create(int itemId, int itemCount, bool isSelected, Action<PropItemPresenter> clickCallback = null,
            Action<PropItemPresenter> showCallback = null)
        {
            PropItemEntityData propItemEntityData = ReferencePool.Acquire<PropItemEntityData>();
            propItemEntityData.ItemId = itemId;
            propItemEntityData.ItemCount = itemCount;
            propItemEntityData.IsSelected = isSelected;
            propItemEntityData.ClickCallback = clickCallback;
            propItemEntityData.ShowCallback = showCallback;
            return propItemEntityData;
        }

        public override void Clear()
        {
            base.Clear();

            ItemId = default;
            ItemCount = default;
            ClickCallback = default;
            ShowCallback = default;
        }
    }
}