using UnityEngine;
using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    [Identity(30000001)]
    public class TipItemPresenter : EntityPresenter<TipItemView, TipItemProp>
    {
        private float m_Duration = 1f;
        private Vector3 m_FromPosition = Vector3.up;
        private Vector3 m_ToPosition = Vector3.up * 500;
        private Color32 m_FromColor = Color.white * 0.2f;
        private Color32 m_ToColor = Color.white;

        public override void OnInit(GameObject target, object userData)
        {
            base.OnInit(target, userData);

            if (userData is TipItemEntityData tipItemData)
            {
                m_View.OnComplete = HideSelf;
                m_View.SetTweener(m_ToPosition, m_ToColor, m_Duration);
            }
            else
            {
                Log.Error("Invalid tip item data.");
                return;
            }
        }

        public override void OnDeinit()
        {
            base.OnDeinit();
        }

        public override void OnShow(int entityId, object userData)
        {
            base.OnShow(entityId, userData);

            if (userData is TipItemEntityData tipItemData)
            {
                m_View.Refresh(tipItemData.Content, m_FromPosition, m_FromColor);
            }
            else
            {
                Log.Error("Invalid tip item data.");
                return;
            }
        }

        public override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
        }

        private void HideSelf()
        {
            Entry.Entity.HideEntity(EntityId);
        }
    }
}