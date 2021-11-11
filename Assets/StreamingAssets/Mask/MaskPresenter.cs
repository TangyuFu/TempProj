using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    [Identity((int) UIFormId.MaskForm)]
    public class MaskPresenter : UIFormPresenter<MaskView, MaskProp>
    {
        public override void OnInit(GameObject gameObject, object userData)
        {
            base.OnInit(gameObject, userData);

            Entry.Event.Subscribe(MaskEventArgs.EventId, OnMask);
        }

        public override void OnDeinit()
        {
            Entry.Event.Unsubscribe(MaskEventArgs.EventId, OnMask);

            base.OnDeinit();
        }

        private void OnMask(object sender, GameEventArgs args)
        {
            if (args is MaskEventArgs maskEventArgs)
            {
                if (maskEventArgs.Show)
                {
                    m_View.Show();
                }
                else
                {
                    m_View.Hide();
                }
            }
        }
    }
}