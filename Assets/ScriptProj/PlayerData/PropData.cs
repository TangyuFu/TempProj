using System.Collections.Generic;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    /// <summary>
    /// 背包数据。
    /// </summary>
    public class PropData : PlayerData
    {
        public List<int> ItemIds = new List<int>();
        public List<int> ItemCounts = new List<int>();
    }
}