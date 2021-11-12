using UnityEngine;
using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;
using Entity = UnityGameFramework.Runtime.Extension.Entity;

namespace TempProj
{
    [Identity(30000001)]
    public class TipItemPresenter : EntityPresenter
    {
        private float m_Duration = 1f;

        public void OnInit(int uniqueId, int entityId, Entity entity, GameObject root,
            object userData)
        {
            base.OnInit(uniqueId, entityId, entity, root, userData);
            if (userData is TipItemEntityData tipItemData)
            {
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
                // m_View.Refresh(tipItemData.Content, m_FromPosition, m_FromColor);
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