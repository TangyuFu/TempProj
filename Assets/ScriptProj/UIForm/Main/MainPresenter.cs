using UnityEngine;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    [Identity((int) UIFormId.MainForm)]
    public class MainPresenter : UIFormPresenter<MainView, MainProp>
    {
        public override void OnInit(GameObject gameObject, object userData)
        {
            base.OnInit(gameObject, userData);

            m_View.GMClicked = OpenGMForm;
            m_View.SettingClicked = OpenSettingForm;
            m_View.BackpackClicked = OpenBackpackForm;
        }

        public override void OnDeinit()
        {
            base.OnDeinit();
        }
        
        private void OpenGMForm()
        {
            Entry.UI.OpenUIForm(UIFormId.GMForm);
        }

        private void OpenSettingForm()
        {
            Entry.UI.OpenUIForm(UIFormId.SettingForm);
        }

        private void OpenBackpackForm()
        {
            Entry.UI.OpenUIForm(UIFormId.BackpackForm);
        }
    }
}