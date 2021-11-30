using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    /// <summary>
    /// 背包界面。
    /// </summary>
    [Identity((int) UIFormId.PropForm)]
    public class PropPresenter : UIFormPresenter
    {
        private PropDataAgent m_PropDataAgent;

        private readonly EntityList<PropItemPresenter, PropItemEntityData> m_EntityList = new();

        private readonly List<PropItemData> m_PropItemDataList = new();

        private readonly List<PropItemEntityData> m_PropItemEntityDataList = new();

        private int m_Selectedndex = -1;

        private GameObject m_Back;
        private Transform m_PropList;

        public override void OnInit(int uniqueId, int formId, CustomUIFormLogic logic, Transform root,
            object userData)
        {
            base.OnInit(uniqueId, formId, logic, root, userData);

            m_Back = root.Find("Back").gameObject;
            m_PropList = root.Find("PropListScrollView/Viewport/PropList");
            UIClickTrigger.Get(m_Back).onClick.AddListener(OnBack);

            m_PropDataAgent = Entry.PlayerData.GetDataAgent<PropDataAgent>();
        }

        public override void OnDeinit()
        {
            UIClickTrigger.Get(m_Back).onClick.AddListener(OnBack);
            m_Back = null;
            m_PropList = default;

            base.OnDeinit();
        }

        private void OnBack(GameObject gameObject)
        {
            Close();
        }

        public override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            PresenterController.Instance.RegisterEntityList(m_EntityList);
            m_PropDataAgent.GetAllItemData(m_PropItemDataList);
            foreach (var itemData in m_PropItemDataList)
            {
                PropItemEntityData propItemEntityData =
                    PropItemEntityData.Create(m_PropList, itemData.Id, itemData.Count, false, OnClickItem);
                m_PropItemEntityDataList.Add(propItemEntityData);
            }

            m_EntityList.Add(m_PropItemEntityDataList);
        }

        public override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);

            m_PropItemDataList.Clear();
            m_PropItemEntityDataList.Clear();

            PresenterController.Instance.UnRegisterEntityList(m_EntityList);
            m_EntityList.RemoveAll();
            m_Selectedndex = -1;
        }

        private void OnClickItem(PropItemPresenter itemPresenter)
        {
            int currIndex = m_EntityList.GetIndex(itemPresenter.EntityId);
            if (currIndex != m_Selectedndex)
            {
                itemPresenter.SetSelected(true);
                if (m_Selectedndex != -1)
                {
                    PropItemPresenter prevItemPresenter = m_EntityList.GetAtIndex(m_Selectedndex);
                    prevItemPresenter?.SetSelected(false);
                }

                m_Selectedndex = currIndex;
            }
        }
    }
}