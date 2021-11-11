using System.Collections.Generic;
using GameFramework.DataTable;
using GameFramework.UI;
using TMPro;
using UnityEngine;
using UnityGameFramework.Runtime.Extension.DataTable;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// UI 拓展。
    /// </summary>
    public static class UIExtension
    {
        private static Dictionary<string, int> m_CachedFormIds;

        /// <summary>
        /// 获取界面 Id。
        /// </summary>
        /// <param name="assetName">资源</param>
        /// <returns></returns>
        public static int GetFormId(string assetName)
        {
            if (m_CachedFormIds == null)
            {
                m_CachedFormIds = new Dictionary<string, int>();
                IDataTable<DRUIForm> dtUIForm = Entry.DataTable.GetDataTable<DRUIForm>();
                foreach (var drUIForm in dtUIForm)
                {
                    m_CachedFormIds.Add(UUtility.Asset.GetUIFormPath(drUIForm.AssetName), drUIForm.Id);
                }
            }

            return m_CachedFormIds.TryGetValue(assetName, out var formId) ? formId : 0;
        }

        /// <summary>
        /// 是否存在界面。
        /// </summary>
        /// <param name="uiComponent">UI 组件。</param>
        /// <param name="uiFormId">界面 Id。</param>
        /// <returns>界面是否存在。</returns>
        public static bool HasUIFormWithId(this UIComponent uiComponent, int uiFormId)
        {
            IDataTable<DRUIForm> dtUIForm = Entry.DataTable.GetDataTable<DRUIForm>();
            DRUIForm drUIForm = dtUIForm.GetDataRow(uiFormId);
            if (drUIForm == null)
            {
                return false;
            }

            IDataTable<DRUIFormGroup> dtUIFormGroups = Entry.DataTable.GetDataTable<DRUIFormGroup>();
            DRUIFormGroup drUIFormGroup = dtUIFormGroups.GetDataRow(drUIForm.GroupId);
            if (drUIFormGroup == null)
            {
                Log.Error($"UI form id '{drUIForm.Id}' has no group id '{drUIForm.GroupId}'.");
                return false;
            }

            string uiGroupName = drUIFormGroup.GroupName;
            IUIGroup uiGroup = uiComponent.GetUIGroup(uiGroupName);
            if (uiGroup == null)
            {
                return false;
            }

            string assetName = UUtility.Asset.GetUIFormPath(drUIForm.AssetName);
            return uiGroup.HasUIForm(assetName);
        }

        /// <summary>
        /// 获取界面。
        /// </summary>
        /// <param name="uiComponent">UI 界面。</param>
        /// <param name="uiFormId">界面 Id。</param>
        /// <returns>获取的界面。</returns>
        public static UIForm GetUIFormWithId(this UIComponent uiComponent, int uiFormId)
        {
            IDataTable<DRUIForm> dtUIForm = Entry.DataTable.GetDataTable<DRUIForm>();
            DRUIForm drUIForm = dtUIForm.GetDataRow(uiFormId);
            if (drUIForm == null)
            {
                return null;
            }

            IDataTable<DRUIFormGroup> dtUIFormGroups = Entry.DataTable.GetDataTable<DRUIFormGroup>();
            DRUIFormGroup drUIFormGroup = dtUIFormGroups.GetDataRow(drUIForm.GroupId);
            if (drUIFormGroup == null)
            {
                Log.Error($"UI form id '{drUIForm.Id}' has no group id '{drUIForm.GroupId}'.");
                return null;
            }

            string uiGroupName = drUIFormGroup.GroupName;

            IUIGroup uiGroup = uiComponent.GetUIGroup(uiGroupName);
            if (uiGroup == null)
            {
                return null;
            }

            string assetName = UUtility.Asset.GetUIFormPath(drUIForm.AssetName);
            Runtime.UIForm uiForm = (Runtime.UIForm) uiGroup.GetUIForm(assetName);
            if (uiForm == null)
            {
                return null;
            }

            return (UIForm) uiForm.Logic;
        }

        /// <summary>
        /// 关闭界面。
        /// </summary>
        /// <param name="uiComponent">UI 组件。</param>
        /// <param name="uiFormId">界面 Id 。</param>
        /// <param name="userData">用户自定义数据。</param>
        public static void CloseUIFormWithId(this UIComponent uiComponent, int uiFormId, object userData)
        {
            uiComponent.CloseUIForm(uiComponent.GetUIFormWithId(uiFormId).UIForm, userData);
        }

        /// <summary>
        /// 打开界面。
        /// </summary>
        /// <param name="uiComponent">UI 组件。</param>
        /// <param name="uiFormId">界面 Id。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>界面序列号。</returns>
        public static int? OpenUIFormWithId(this UIComponent uiComponent, int uiFormId, object userData = null)
        {
            IDataTable<DRUIForm> dtUIForm = Entry.DataTable.GetDataTable<DRUIForm>();
            DRUIForm drUIForm = dtUIForm.GetDataRow(uiFormId);
            if (drUIForm == null)
            {
                Log.Warning("Can not load UI form '{0}' from data table.", uiFormId.ToString());
                return null;
            }

            IDataTable<DRUIFormGroup> dtUIFormGroups = Entry.DataTable.GetDataTable<DRUIFormGroup>();
            DRUIFormGroup drUIFormGroup = dtUIFormGroups.GetDataRow(drUIForm.GroupId);
            if (drUIFormGroup == null)
            {
                Log.Error($"UI form id '{drUIForm.Id}' has no group id '{drUIForm.GroupId}'.");
                return null;
            }

            if (!uiComponent.HasUIGroup(drUIFormGroup.GroupName))
            {
                Entry.UI.AddUIGroup(drUIFormGroup.GroupName, drUIFormGroup.GroupDepth);
            }

            string assetName = UUtility.Asset.GetUIFormPath(drUIForm.AssetName);
            if (!drUIForm.AllowMultiInstance)
            {
                if (uiComponent.IsLoadingUIForm(assetName))
                {
                    return null;
                }

                if (uiComponent.HasUIForm(assetName))
                {
                    return null;
                }
            }

            return uiComponent.OpenUIForm(assetName, drUIFormGroup.GroupName, Constant.AssetPriority.UIFormAsset,
                drUIForm.PauseCoveredUIForm, userData);
        }


        private static TMP_FontAsset m_Font;

        /// <summary>
        /// 设置字体。
        /// </summary>
        /// <param name="font">字体。</param>
        public static void SetFont(TMP_FontAsset font)
        {
            if (font == null)
            {
                Log.Error($"Invalid font '{font}'.");
                return;
            }

            m_Font = font;
        }

        /// <summary>
        /// 获取字体。
        /// </summary>
        /// <returns>获取到的字体。</returns>
        public static TMP_FontAsset GetFont()
        {
            return m_Font;
        }

        private static readonly List<TMP_Text> s_Texts = new List<TMP_Text>();

        /// <summary>
        /// 设置字体。
        /// </summary>
        /// <param name="root">根目录。</param>
        public static void SetTransformFont(GameObject root)
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
    }
}