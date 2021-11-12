using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    [Identity((int) UIFormId.MainForm)]
    public class MainPresenter : UIFormPresenter
    {
        private GameObject m_GMBtn;
        private GameObject m_SettingBtn;
        private GameObject m_PropBtn;
        
        public override void OnInit(int uniqueId, int formId, UIForm uiForm, GameObject root, object userData)
        {
            base.OnInit(uniqueId, formId, uiForm, root, userData);

            m_GMBtn = root.transform.Find("GMBtn").gameObject;
            m_SettingBtn = root.transform.Find("SettingBtn").gameObject;
            m_PropBtn = root.transform.Find("PropBtn").gameObject;
            
            UIClickTrigger.Get(m_GMBtn).onClick.AddListener(OpenGMForm);
            UIClickTrigger.Get(m_SettingBtn).onClick.AddListener(OpenSettingForm);
            UIClickTrigger.Get(m_PropBtn).onClick.AddListener(OpenPropForm);
        }

        public override void OnDeinit()
        {
            base.OnDeinit();
        }
        
        private void OpenGMForm(GameObject go)
        {
            // Entry.UI.OpenUIForm(UIFormId.GMForm);
            Entry.Event.Fire(null, TipEventArgs.Create("hahahhahhhhahah"));
        }

        private void OpenSettingForm(GameObject go)
        {
            Entry.UI.OpenUIForm(UIFormId.SettingForm);
        }

        private void OpenPropForm(GameObject go)
        {
            Entry.UI.OpenUIForm(UIFormId.BackpackForm);
        }
    }
}