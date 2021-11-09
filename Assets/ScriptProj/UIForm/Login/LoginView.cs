using System;
using UnityEngine;
using UnityEngine.Events;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    public class LoginView : MVCView<LoginProp>
    {
        public UnityAction LoginClicked;
        public UnityAction RegisterClicked;

        public UnityAction<string> UserNameValueChanged;
        public UnityAction<string> PasswordValueChanged;

        public override void Init(LoginProp prop)
        {
            base.Init(prop);

            UIClickTrigger.Get(m_Prop.LoginGameObject).onClick.AddListener(OnLoginClick);
            UIClickTrigger.Get(m_Prop.RegisterGameObject).onClick.AddListener(OnRegisterClick);
            m_Prop.UserNameInputField.onValueChanged.AddListener(OnUserNameValueChanged);
            m_Prop.PasswordInputField.onValueChanged.AddListener(OnPasswordValueChanged);
        }

        public override void Deinit()
        {
            base.Deinit();

            UIClickTrigger.Get(m_Prop.LoginGameObject).onClick.RemoveListener(OnLoginClick);
            UIClickTrigger.Get(m_Prop.RegisterGameObject).onClick.RemoveListener(OnRegisterClick);
            m_Prop.UserNameInputField.onValueChanged.RemoveListener(OnUserNameValueChanged);
            m_Prop.UserNameInputField.onValueChanged.RemoveListener(OnUserNameValueChanged);

            LoginClicked = default;
            RegisterClicked = default;
            UserNameValueChanged = default;
            PasswordValueChanged = default;
        }

        private void OnLoginClick(GameObject go)
        {
            LoginClicked?.Invoke();
        }

        private void OnRegisterClick(GameObject go)
        {
            RegisterClicked?.Invoke();
        }

        private void OnUserNameValueChanged(string value)
        {
            UserNameValueChanged?.Invoke(value);
        }

        private void OnPasswordValueChanged(string value)
        {
            PasswordValueChanged?.Invoke(value);
        }
    }
}