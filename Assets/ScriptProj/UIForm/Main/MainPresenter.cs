using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    [Identity((int) UIFormId.MainForm)]
    public class MainPresenter : UIFormPresenter
    {
        private GameObject m_GM;
        private GameObject m_Setting;
        private GameObject m_Prop;
        
        public override void OnInit(int uniqueId, int formId, CustomUIFormLogic logic, Transform root,
            object userData)
        {
            base.OnInit(uniqueId, formId, logic, root, userData);
            
            m_GM = root.Find("GM").gameObject;
            m_Setting = root.Find("Setting").gameObject;
            m_Prop = root.Find("Prop").gameObject;
            
            UIClickTrigger.Get(m_GM).onClick.AddListener(OpenGMForm);
            UIClickTrigger.Get(m_Setting).onClick.AddListener(OpenSettingForm);
            UIClickTrigger.Get(m_Prop).onClick.AddListener(OpenPropForm);
        }

        public override void OnDeinit()
        {
            UIClickTrigger.Get(m_GM).onClick.RemoveListener(OpenGMForm);
            UIClickTrigger.Get(m_Setting).onClick.RemoveListener(OpenSettingForm);
            UIClickTrigger.Get(m_Prop).onClick.RemoveListener(OpenPropForm);
            
            base.OnDeinit();
        }
        
        private void OpenGMForm(GameObject go)
        {
            // Entry.UI.OpenCustomUIForm(UIFormId.GMForm);
            Entry.Event.Fire(null, TipEventArgs.Create("hahahhahhhhahah"));
        }

        
        private void OpenSettingForm(GameObject go)
        {
            Entry.UI.OpenCustomUIForm(UIFormId.SettingForm);
        }

        private void OpenPropForm(GameObject go)
        {
            Entry.UI.OpenCustomUIForm(UIFormId.PropForm);
        }
    }
}