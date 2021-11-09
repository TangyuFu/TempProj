using System;
using UnityEngine;
using UnityEngine.Events;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    public class MainView : MVCView<MainProp>
    {
        public UnityAction GMClicked { get; set; }
        public UnityAction SettingClicked { get; set; }
        public UnityAction BackpackClicked { get; set; }

        public override void Init(MainProp prop)
        {
            base.Init(prop);

            UIClickTrigger.Get(m_Prop.GMGameObject).onClick.AddListener(OnGMClick);
            UIClickTrigger.Get(m_Prop.SettingGameObject).onClick.AddListener(OnSettingClick);
            UIClickTrigger.Get(m_Prop.BackpackGameObject).onClick.AddListener(OnBackpackClick);
        }

        public override void Deinit()
        {
            UIClickTrigger.Get(m_Prop.GMGameObject).onClick.RemoveListener(OnGMClick);
            UIClickTrigger.Get(m_Prop.SettingGameObject).onClick.RemoveListener(OnSettingClick);
            UIClickTrigger.Get(m_Prop.BackpackGameObject).onClick.RemoveListener(OnBackpackClick);

            SettingClicked = default;
            BackpackClicked = default;

            base.Deinit();
        }
        
        private void OnGMClick(GameObject go)
        {
            GMClicked?.Invoke();
        }

        private void OnSettingClick(GameObject go)
        {
            SettingClicked?.Invoke();
        }

        private void OnBackpackClick(GameObject go)
        {
            BackpackClicked.Invoke();
        }
    }
}