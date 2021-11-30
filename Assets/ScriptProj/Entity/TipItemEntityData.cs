using GameFramework;
using TempProj.DataTable;
using UnityEngine;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    /// <summary>
    /// 提示项数据。
    /// </summary>
    public class TipItemEntityData : EntityData
    {
        public TipItemEntityData()
        {
        }

        public string Content { get; set; }

        public static TipItemEntityData Create(string content, Transform parent)
        {
            TipItemEntityData tipItemEntityData = ReferencePool.Acquire<TipItemEntityData>();
            int drEntityId = 10000001;
            DREntity drEntity = Entry.DataTable.GetDataTable<DREntity>().GetDataRow(drEntityId);
            tipItemEntityData.DrEntity = drEntity;
            
            tipItemEntityData.EntityId = Entry.Entity.GenerateSerialId();
            
            tipItemEntityData.Content = content;
            tipItemEntityData.Parent = parent;
            return tipItemEntityData;
        }

        public override void Clear()
        {
            base.Clear();
            Content = default;
        }
    }
}