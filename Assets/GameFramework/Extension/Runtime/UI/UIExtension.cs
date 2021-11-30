using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// UI 拓展。
    /// </summary>
    public static class UIExtension
    {
        #region About Font, Set Get & Set Transform Functions

        private static TMP_FontAsset m_Font;
        
        /// <summary>
        /// 获取或设置默认字体。
        /// </summary>
        public static TMP_FontAsset Font {
            get => m_Font;
            set => m_Font = value;
        }
        
        private static readonly List<TMP_Text> s_Texts = new();

        /// <summary>
        /// 设置字体。
        /// </summary>
        /// <param name="root">根目录。</param>
        public static void SetTransformFont(Transform root)
        {
            root.GetComponentsInChildren(true, s_Texts);
            foreach (var text in s_Texts)
            {
                text.font = m_Font;
                string key = text.text;
                if (!string.IsNullOrEmpty(key))
                {
                    text.text = Entry.Localization.GetString(key);
                }
            }
        }

        #endregion

        #region About Dialog, Open Funcitons

        /// <summary>
        /// 打开对话框。
        /// </summary>
        /// <param name="uiComponent">UI 组件。</param>
        /// <param name="dialogParams">对话框参数。</param>
        public static void OpenDialog(this UIComponent uiComponent, DialogParams dialogParams)
        {
            if (((ProcedureBase) Entry.Procedure.CurrentProcedure).UseNativeDialog)
            {
                OpenNativeDialog(dialogParams);
            }
            else
            {
                Entry.BuiltinData.DialogForm.Open(dialogParams);
            }
        }

        private static void OpenNativeDialog(DialogParams dialogParams)
        {
            dialogParams.OnClickConfirm?.Invoke(dialogParams.UserData);
        }

        #endregion

        #region About Utilities, Set Sprite, Set Gray Functions

        /// <summary>
        /// 设置 Image 的 Sprite。
        /// </summary>
        /// <param name="image">要设置的 Image 。</param>
        /// <param name="assetPath">要设置的 Sprite 的资源路径。</param>
        public static void SetSprite(Image image, string assetPath)
        {
            Entry.R.LoadAsset(assetPath, typeof(Sprite),
                (assetName, asset, userData) =>
                {
                    if (asset is Sprite sprite)
                    {
                        image.sprite = sprite;
                    }
                });
        }

        public static void SetGray(Image image, bool isGray)
        {
        }

        public static void SetGray(TMP_Text text, bool isGray)
        {
        }

        #endregion
    }
}