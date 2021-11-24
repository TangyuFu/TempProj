using UnityEngine;
using UnityGameFramework.Runtime.Extension;
using TMPro;

namespace TempProj
{
    /// <summary>
    /// 登录界面。
    /// </summary>
    [Identity((int) UIFormId.LoginForm)]
    public class LoginPresenter : UIFormPresenter
    {
        private TMP_InputField m_UserName_TMP_InputField;
        private TMP_InputField m_Password_TMP_InputField;

        public GameObject m_Login;

        public override void OnInit(int uniqueId, int formId, CustomUIFormLogic customUIFormLogic, Transform root,
            object userData)
        {
            base.OnInit(uniqueId, formId, customUIFormLogic, root, userData);

            m_UserName_TMP_InputField = root.Find("UserName").GetComponent<TMP_InputField>();
            m_Password_TMP_InputField = root.Find("Password").GetComponent<TMP_InputField>();
            m_Login = root.Find("Login").gameObject;
            UIClickTrigger.Get(m_Login).onClick.AddListener(OnLogin);
            m_UserName_TMP_InputField.onValueChanged.AddListener(OnUserNameValueChanged);
            m_Password_TMP_InputField.onValueChanged.AddListener(OnPasswordValueChanged);
        }

        public override void OnDeinit()
        {
            UIClickTrigger.Get(m_Login).onClick.RemoveListener(OnLogin);
            m_UserName_TMP_InputField.onValueChanged.RemoveListener(OnUserNameValueChanged);
            m_Password_TMP_InputField.onValueChanged.RemoveListener(OnPasswordValueChanged);

            base.OnDeinit();
        }

        public override void OnOpen(object userData)
        {
            base.OnOpen(userData);
        }

        public override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
        }

        private void OnLogin(GameObject gameObject)
        {
            Close();
            Entry.UI.OpenUIForm(UIFormId.MainForm);
        }

        private void OnUserNameValueChanged(string value)
        {
        }

        private void OnPasswordValueChanged(string value)
        {
        }
    }
}