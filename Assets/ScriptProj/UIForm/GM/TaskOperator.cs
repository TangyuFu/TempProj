using System;
using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    public class TaskOperator : IGMOperator
    {
        private PropDataAgent m_PropDataAgent;

        public Action[] m_Actions;

        public TaskOperator()
        {
            m_PropDataAgent = Entry.PlayerData.GetDataAgent<PropDataAgent>();
            m_Actions = new Action[] {SetItemCount, AddItemCount, RemoveItemCount, RemoveAllItems};
        }

        public int Priority { get; } = 0;
        public string Name { get; } = "任务";
        public string[] ArgNames { get; } = {"道具Id", "道具数量"};
        public string[] Args { get; set; } = {null, null};
        public string[] ActionNames{ get; } = new [] {"设置道具数量", "添加道具数量", "减少道具数量"};
        public Action[] Actions => new Action[] {SetItemCount, AddItemCount, RemoveItemCount};

        private void SetItemCount()
        {
            if (!int.TryParse(Args[0], out var itemId) || !int.TryParse(Args[1], out var itemCount))
            {
                Log.Error($"Invalid item id '{Args[0]}' or item count '{Args[1]}'.");
                return;
            }

            m_PropDataAgent.SetItemCount(itemId, itemCount);
        }

        private void AddItemCount()
        {
            if (!int.TryParse(Args[0], out var itemId) || !int.TryParse(Args[1], out var itemCount))
            {
                Log.Error($"Invalid item id '{Args[0]}' or item count '{Args[1]}'.");
                return;
            }

            m_PropDataAgent.AddItemCount(itemId, itemCount);
        }

        private void RemoveItemCount()
        {
            if (!int.TryParse(Args[0], out var itemId) || !int.TryParse(Args[1], out var itemCount))
            {
                Log.Error($"Invalid item id '{Args[0]}' or item count '{Args[1]}'.");
                return;
            }

            m_PropDataAgent.RemoveItemCount(itemId, itemCount);
        }

        private void RemoveAllItems()
        {
            m_PropDataAgent.RemoveAllItems();
        }
    }
}