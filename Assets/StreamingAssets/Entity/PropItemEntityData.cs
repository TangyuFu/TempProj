using GameFramework;
using UnityEngine.Events;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    /// <summary>
    /// 背包数据。
    /// </summary>
    public class PropItemEntityData : EntityData
    {
        public PropItemEntityData()
        {
        }

        /// <summary>
        /// 道具数据。
        /// </summary>
        public PropItemData ItemData;

        /// <summary>
        /// 点击点击事件。
        /// </summary>
        public UnityAction<PropItemPresenter> Clicked { get; set; }

        public static PropItemEntityData Create(PropItemData itemData,
            UnityAction<PropItemPresenter> clicked)
        {
            PropItemEntityData propItemEntityData = ReferencePool.Acquire<PropItemEntityData>();
            propItemEntityData.ItemData = itemData;
            propItemEntityData.Clicked = clicked;
            return propItemEntityData;
        }

        public override void Clear()
        {
            base.Clear();

            ItemData = default;
            Clicked = default;
        }
    }
}