using UnityEngine;
using UnityEngine.Events;
using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    public class PropItemView : MVCView<PropItemProp>
    {
        public UnityAction Clicked { get; set; }

        public override void Init(PropItemProp prop)
        {
            base.Init(prop);

            UIClickTrigger.Get(m_Prop.BlockGameObject).onClick.AddListener(OnClicked);
        }

        public override void Deinit()
        {
            UIClickTrigger.Get(m_Prop.BlockGameObject).onClick.RemoveListener(OnClicked);
            Clicked = null;

            base.Deinit();
        }

        public void SetIcon(string icon)
        {
            Entry.R.LoadAsset(icon, typeof(Sprite),
                delegate(string assetName, object asset, object userData)
                {
                    if (asset is Sprite sprite)
                    {
                        m_Prop.IconImage.sprite = sprite;
                    }
                    else
                    {
                        Log.Error($"Invalid asset '{asset}' with name '{assetName}'.");
                    }
                });
        }

        public void SetCount(string count)
        {
            m_Prop.CountText.text = count;
        }

        private void OnClicked(GameObject go)
        {
            Clicked?.Invoke();
        }
    }
}