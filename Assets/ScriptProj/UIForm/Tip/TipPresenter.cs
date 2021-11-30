using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    [Identity((int) UIFormId.TipForm)]
    public class TipPresenter : UIFormPresenter
    {
        public override void OnInit(int uniqueId, int formId, CustomUIFormLogic logic, Transform root,
            object userData)
        {
            base.OnInit(uniqueId, formId, logic, root, userData);

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

                TipItemEntityData tipItemEntityData = TipItemEntityData.Create(tipEventArgs.Content, Root.transform);
                Entry.Entity.ShowEntity(tipItemEntityData);
            }
        }
    }
}