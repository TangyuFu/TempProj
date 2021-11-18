using GameFramework.UI;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 界面辅助器。
    /// </summary>
    public class CustomUIFormHelper : DefaultUIFormHelper
    {
        public override object InstantiateUIForm(object uiFormAsset)
        {
            return base.InstantiateUIForm(uiFormAsset);
        }

        public override IUIForm CreateUIForm(object uiFormInstance, IUIGroup uiGroup, object userData)
        {
            GameObject formGameObject = uiFormInstance as GameObject;
            if (formGameObject == null)
            {
                Log.Error("Invalid ui form instance.");
                return null;
            }

            RectTransform formTransform = formGameObject.GetOrAddComponent<RectTransform>();
            formTransform.SetParent(((MonoBehaviour) uiGroup.Helper).transform);
            formTransform.localScale = Vector3.one;
            formTransform.localPosition = Vector3.zero;
            formTransform.anchorMin = Vector2.zero;
            formTransform.anchorMax = Vector2.one;
            formTransform.anchoredPosition = Vector2.zero;
            formTransform.sizeDelta = Vector2.zero;

            CustomUIFormLogic customUIFormLogic = formGameObject.GetOrAddComponent<CustomUIFormLogic>();
            return formGameObject.GetOrAddComponent<Runtime.UIForm>();
        }

        public override void ReleaseUIForm(object uiFormAsset, object uiFormInstance)
        {
            GameObject formGameObject = uiFormInstance as GameObject;
            if (formGameObject != null)
            {
                CustomUIFormLogic customUIFormLogic = formGameObject.GetComponent<CustomUIFormLogic>();
                if (customUIFormLogic != null)
                {
                    customUIFormLogic.OnDeinit();
                }
            }

            base.ReleaseUIForm(uiFormAsset, uiFormInstance);
        }
    }
}