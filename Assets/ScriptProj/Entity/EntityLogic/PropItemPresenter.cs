using UnityEngine;
using UnityEngine.Events;
using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    [Identity(30000002)]
    public class PropItemPresenter : EntityPresenter<PropItemView, PropItemProp>
    {
        private PropItemData m_PropItemData;
        
        private UnityAction<PropItemPresenter> m_Clicked;

        public override void OnInit(GameObject target, object userData)
        {
            base.OnInit(target, userData);

            m_View.Clicked = OnClick;
        }

        public override void OnDeinit()
        {
            base.OnDeinit();
        }

        public override void OnShow(int entityId, object userData)
        {
            base.OnShow(entityId, userData);

            if (userData is PropItemEntityData backpackItemData)
            {
                m_PropItemData = backpackItemData.ItemData;
                m_Clicked = backpackItemData.Clicked;
                string icon = UUtility.Asset.GetUIAtlasSpritePath(
                    m_PropItemData.DrBackpackGroup.AtlasName,
                    m_PropItemData.DrBackpack.Icon);
                m_View.SetIcon(icon);
                m_View.SetCount(m_PropItemData.ItemCount.ToString());
            }
            else
            {
                Log.Error("Invalid backpack item data.");
                return;
            }
        }

        public override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            
            m_PropItemData = default;
            m_Clicked = null;
        }

        private void OnClick()
        {
            m_Clicked?.Invoke(this);
        }
    }
}