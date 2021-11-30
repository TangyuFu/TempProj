using System.Collections.Generic;
using GameFramework.DataTable;
using GameFramework.UI;
using TempProj.DataTable;
using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    public static class UIExtension
    {
        /// <summary>
        /// 打开界面。
        /// </summary>
        /// <param name="uiComponent">UI 组件。</param>
        /// <param name="uiFormId">界面 Id。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>界面序列号。</returns>
        public static int? OpenCustomUIForm(this UIComponent uiComponent, UIFormId uiFormId, object userData = null)
        {
            return uiComponent.OpenCustomUIForm((int) uiFormId, userData);
        }

        /// <summary>
        /// 打开界面。
        /// </summary>
        /// <param name="uiComponent">UI 组件。</param>
        /// <param name="uiFormId">界面 Id。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>界面序列号。</returns>
        public static int? OpenCustomUIForm(this UIComponent uiComponent, int uiFormId, object userData = null)
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

        /// <summary>
        /// 关闭界面，
        /// </summary>
        /// <param name="uiComponent">UI 租价。</param>
        /// <param name="uiFormId">界面 Id。</param>
        /// <param name="userData">用户自定义数据。</param>
        public static void CloseCustomUIForm(this UIComponent uiComponent, UIFormId uiFormId, object userData = null)
        {
            uiComponent.CloseCustomUIForm((int) uiFormId, userData);
        }

        /// <summary>
        /// 关闭界面。
        /// </summary>
        /// <param name="uiComponent">UI 组件。</param>
        /// <param name="uiFormId">界面 Id 。</param>
        /// <param name="userData">用户自定义数据。</param>
        public static void CloseCustomUIForm(this UIComponent uiComponent, int uiFormId, object userData)
        {
            uiComponent.CloseUIForm(uiComponent.GetCustomUIForm(uiFormId).UIForm, userData);
        }

        /// <summary>
        /// 是否存在界面。
        /// </summary>
        /// <param name="uiComponent">UI 组件。</param>
        /// <param name="uiFormId">界面 Id。</param>
        /// <returns>界面是否存在。</returns>
        public static bool HasCustomUIForm(this UIComponent uiComponent, UIFormId uiFormId)
        {
            return uiComponent.HasCustomUIForm((int) uiFormId);
        }

        /// <summary>
        /// 是否存在界面。
        /// </summary>
        /// <param name="uiComponent">UI 组件。</param>
        /// <param name="uiFormId">界面 Id。</param>
        /// <returns>界面是否存在。</returns>
        public static bool HasCustomUIForm(this UIComponent uiComponent, int uiFormId)
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
        public static CustomUIFormLogic GetCustomUIForm(this UIComponent uiComponent, UIFormId uiFormId)
        {
            return uiComponent.GetCustomUIForm((int) uiFormId);
        }

        /// <summary>
        /// 获取界面。
        /// </summary>
        /// <param name="uiComponent">UI 界面。</param>
        /// <param name="uiFormId">界面 Id。</param>
        /// <returns>获取的界面。</returns>
        public static CustomUIFormLogic GetCustomUIForm(this UIComponent uiComponent, int uiFormId)
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
            UIForm uiForm = (UIForm) uiGroup.GetUIForm(assetName);
            if (uiForm == null)
            {
                return null;
            }

            return (CustomUIFormLogic) uiForm.Logic;
        }


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
    }
}