using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    public static class UIUtil
    {
        /// <summary>
        /// 打开界面。
        /// </summary>
        /// <param name="uiComponent">UI 组件。</param>
        /// <param name="uiFormId">界面 Id。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>界面序列号。</returns>
        public static int? OpenUIForm(this UIComponent uiComponent, UIFormId uiFormId, object userData = null)
        {
            return uiComponent.OpenUIFormWithId((int) uiFormId, userData);
        }

        /// <summary>
        /// 关闭界面，
        /// </summary>
        /// <param name="uiComponent">UI 租价。</param>
        /// <param name="uiFormId">界面 Id。</param>
        /// <param name="userData">用户自定义数据。</param>
        public static void CloseUIForm(this UIComponent uiComponent, UIFormId uiFormId, object userData = null)
        {
            uiComponent.CloseUIFormWithId((int) uiFormId, userData);
        }
    }
}