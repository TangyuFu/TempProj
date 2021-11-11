using GameFramework;
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

        public static TipItemEntityData Create(string content)
        {
            TipItemEntityData tipItemEntityData = ReferencePool.Acquire<TipItemEntityData>();
            tipItemEntityData.Content = content;
            return tipItemEntityData;
        }

        public override void Clear()
        {
            base.Clear();
            Content = default;
        }
    }
}