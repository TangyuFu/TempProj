using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    [Identity((int) UIFormId.TipForm)]
    public class TipPresenter : UIFormPresenter<TipView, TipProp>
    {
        public override void OnInit(GameObject gameObject, object userData)
        {
            base.OnInit(gameObject, userData);

            Entry.Event.Subscribe(TipEventArgs.EventId, OnTip);
        }

        public override void OnDeinit()
        {
            Entry.Event.Unsubscribe(TipEventArgs.EventId, OnTip);

            base.OnDeinit();
        }

        private void OnTip(object sender, GameEventArgs args)
        {
            if (args is TipEventArgs tipEventArgs)
            {
                int entityId = Entry.Entity.GenerateSerialId();
                int typeId = 30000001;
                TipItemEntityData tipItemEntityData = TipItemEntityData.Create(tipEventArgs.Content);
                tipItemEntityData.EntityId = entityId;
                tipItemEntityData.TypeId = typeId;
                tipItemEntityData.Parent = m_Prop.RootTransform;
                Entry.Entity.ShowEntity(tipItemEntityData);
            }
        }
    }
}