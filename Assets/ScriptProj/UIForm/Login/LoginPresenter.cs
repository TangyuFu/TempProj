using UnityEngine;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    /// <summary>
    /// 登录界面。
    /// </summary>
    [Identity((int) UIFormId.LoginForm)]
    public class LoginPresenter : UIFormPresenter<LoginView, LoginProp>
    {
        public override void OnInit(GameObject target, object userData)
        {
            base.OnInit(target, userData);

            m_View.LoginClicked = Login;
            m_View.RegisterClicked = Register;
            m_View.UserNameValueChanged = OnUserNameValueChanged;
            m_View.PasswordValueChanged = OnPasswordValueChanged;
        }

        public override void OnDeinit()
        {
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
        
        private void Login()
        {
            Entry.UI.CloseUIForm(UIFormId.LoginForm);
            Entry.UI.OpenUIForm(UIFormId.MainForm);
        }

        private void Register()
        {

        }

        private void OnUserNameValueChanged(string value)
        {

        }

        private void OnPasswordValueChanged(string value)
        {

        }
    }
}