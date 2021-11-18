using System;
using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    public class GMAddItemOperator : IGMOperator
    {
        public int Priority { get; } = 1000;
        public string Name { get; } = "添加道具数量";
        public string[] ArgNames { get; } = {"道具ID", "道具数量"};

        public string[][] DefaultArgs { get; } =
            {new string[] {"10000001", "10000002", "10000003"}, new string[] {"0", "10", "100"}};

        public string[] InputArgs { get; set; } = new string[2];

        public Action Action => OnAction;

        private void OnAction()
        {
            if (!int.TryParse(InputArgs[0], out int itemId))
            {
                Log.Error($"无效的道具ID '{InputArgs[0]}。'");
                return;
            }

            if (!int.TryParse(InputArgs[1], out int itemCount))
            {
                Log.Error($"无效的道具count '{InputArgs[1]}。'");
                return;
            }

            PropDataAgent propDataAgent = Entry.PlayerData.GetDataAgent<PropDataAgent>();
            propDataAgent.AddItemCount(itemId, itemCount);
        }
    }
}