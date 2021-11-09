using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    /// <summary>
    /// 背包界面。
    /// </summary>
    [Identity((int) UIFormId.BackpackForm)]
    public class BackpackPresenter : UIFormPresenter<BackpackView, BackpackProp>
    {
        private PropDataAgent m_PropDataAgent;

        private readonly List<PropItemData> m_BackpackItemDataList = new List<PropItemData>();

        private readonly EntityList<PropItemPresenter, PropItemEntityData> m_EntityList =
            new EntityList<PropItemPresenter, PropItemEntityData>();

        private readonly List<PropItemEntityData> m_BackpackItemEntityDataList = new List<PropItemEntityData>();

        public override void OnInit(GameObject target, object userData)
        {
            base.OnInit(target, userData);

            m_View.OnBack = CloseSelf;
            m_PropDataAgent = Entry.PlayerData.GetDataAgent<PropDataAgent>();
        }

        public override void OnDeinit()
        {
            base.OnDeinit();
        }

        public override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            Entry.MVC.RegisterEntityList(m_EntityList);
            m_PropDataAgent.GetAllItemData(m_BackpackItemDataList);
            foreach (var itemData in m_BackpackItemDataList)
            {
                int entityId = Entry.Entity.GenerateSerialId();
                int typeId = 30000002;
                PropItemEntityData propItemEntityData = PropItemEntityData.Create(itemData, OnClickItem);
                propItemEntityData.EntityId = entityId;
                propItemEntityData.TypeId = typeId;
                propItemEntityData.Parent = m_Prop.ContentTransform;
                m_BackpackItemEntityDataList.Add(propItemEntityData);
            }

            m_EntityList.Add(m_BackpackItemEntityDataList);
        }

        public override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);

            m_BackpackItemDataList.Clear();
            m_BackpackItemEntityDataList.Clear();

            Entry.MVC.UnRegisterEntityList(m_EntityList);
            m_EntityList.RemoveAll();
        }

        private void OnClickItem(PropItemPresenter itemPresenter)
        {
            Entry.Event.Fire(TipEventArgs.EventId, TipEventArgs.Create(itemPresenter.GetHashCode().ToString()));
        }

        private void CloseSelf()
        {
            Entry.UI.CloseUIForm(UIFormId.BackpackForm);
        }
    }
}