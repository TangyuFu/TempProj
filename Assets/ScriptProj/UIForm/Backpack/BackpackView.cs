using System;
using UnityEngine;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    public class BackpackView : MVCView<BackpackProp>
    {
        public Action OnBack { get; set; }

        public override void Init(BackpackProp prop)
        {
            base.Init(prop);
            
            UIClickTrigger.Get(m_Prop.BackGameObject).onClick.AddListener(OnBackClick);
        }

        public override void Deinit()
        {
            UIClickTrigger.Get(m_Prop.BackGameObject).onClick.RemoveListener(OnBackClick);
            
            base.Deinit();
        }

        private void OnBackClick(GameObject go)
        {
            OnBack?.Invoke();            
        }
    }
}