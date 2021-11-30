using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;
using TempProj.DataTable;

namespace TempProj
{
    [Identity(10000002)]
    public class PropItemPresenter : EntityPresenter
    {
        private Action<PropItemPresenter> m_ClickCallback;
        private Action<PropItemPresenter> m_ShowCallback;

        private GameObject m_Block;
        private Image m_Icon_Image;
        private TMP_Text m_Count_TMP_Text;
        private GameObject m_Selected;

        public override void OnInit(CustomEntityLogic logic, Transform root,
            object userData)
        {
            base.OnInit(logic, root, userData);

            m_Block = root.Find("Block").gameObject;
            m_Icon_Image = root.Find("Icon").GetComponent<Image>();
            m_Count_TMP_Text = root.Find("Count").GetComponent<TMP_Text>();
            m_Selected = root.Find("Selected").gameObject;

            m_Selected.SetActive(false);
            UIClickTrigger.Get(m_Block).onClick.AddListener(OnClick);
        }

        public override void OnDeinit()
        {
            UIClickTrigger.Get(m_Block).onClick.RemoveListener(OnClick);
            m_Block = null;
            m_Icon_Image = null;
            m_Count_TMP_Text = null;

            base.OnDeinit();
        }

        public override void OnShow(object userData)
        {
            base.OnShow(userData);

            if (userData is PropItemEntityData backpackItemData)
            {
                DRProp drProp = Entry.DataTable.GetDataTable<DRProp>()[backpackItemData.ItemId];
                DRPropGroup drPropGroup = Entry.DataTable.GetDataTable<DRPropGroup>()[drProp.GroupId];
                m_ClickCallback = backpackItemData.ClickCallback;
                m_ShowCallback = backpackItemData.ShowCallback;
                string icon = UUtility.Asset.GetUIAtlasSpritePath(drPropGroup.AtlasName, drProp.Icon);
                SetIcon(icon);
                SetCount(backpackItemData.ItemCount.ToString());
                backpackItemData.ShowCallback?.Invoke(this);
            }
            else
            {
                Log.Error("Invalid backpack item data.");
                return;
            }
        }

        public void SetIcon(string assetPath)
        {
            UnityGameFramework.Runtime.Extension.UIExtension.SetSprite(m_Icon_Image, assetPath);
        }

        public void SetCount(string text)
        {
            m_Count_TMP_Text.text = text;
        }

        public void SetSelected(bool isSelected)
        {
            m_Selected.SetActive(isSelected);
        }

        public void SetClickCallback(Action<PropItemPresenter> clickCallback)
        {
            m_ClickCallback = clickCallback;
        }

        public override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);

            m_ShowCallback = default;
            m_ClickCallback = null;
        }

        private void OnClick(GameObject gameObject)
        {
            m_ClickCallback?.Invoke(this);
        }
    }
}