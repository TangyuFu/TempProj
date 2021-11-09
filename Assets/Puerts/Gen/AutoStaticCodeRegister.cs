namespace PuertsStaticWrap
{
    public static class AutoStaticCodeRegister
    {
        public static void Register(Puerts.JsEnv jsEnv)
        {
            jsEnv.AddLazyStaticWrapLoader(typeof(System.Type), System_Type_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.Debug), UnityEngine_Debug_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.Time), UnityEngine_Time_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.GameObject), UnityEngine_GameObject_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.Component), UnityEngine_Component_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.Transform), UnityEngine_Transform_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.Camera), UnityEngine_Camera_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.Light), UnityEngine_Light_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.ParticleSystem), UnityEngine_ParticleSystem_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.RectTransform), UnityEngine_RectTransform_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.UI.Image), UnityEngine_UI_Image_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.UI.RawImage), UnityEngine_UI_RawImage_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.UI.Toggle), UnityEngine_UI_Toggle_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityEngine.UI.Slider), UnityEngine_UI_Slider_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(TMPro.TMP_Text), TMPro_TMP_Text_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(TMPro.TMP_Dropdown), TMPro_TMP_Dropdown_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(TMPro.TMP_InputField), TMPro_TMP_InputField_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.UUtility.Text), UnityGameFramework_Runtime_Extension_UUtility_Text_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.UUtility.Asset), UnityGameFramework_Runtime_Extension_UUtility_Asset_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Log), UnityGameFramework_Runtime_Log_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.Entry), UnityGameFramework_Runtime_Extension_Entry_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.BaseComponent), UnityGameFramework_Runtime_BaseComponent_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.DownloadComponent), UnityGameFramework_Runtime_DownloadComponent_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.DownloadStartEventArgs), UnityGameFramework_Runtime_DownloadStartEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.DownloadSuccessEventArgs), UnityGameFramework_Runtime_DownloadSuccessEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.DownloadFailureEventArgs), UnityGameFramework_Runtime_DownloadFailureEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.EntityComponent), UnityGameFramework_Runtime_EntityComponent_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Entity), UnityGameFramework_Runtime_Entity_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.Entity), UnityGameFramework_Runtime_Extension_Entity_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.ShowEntitySuccessEventArgs), UnityGameFramework_Runtime_ShowEntitySuccessEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.ShowEntityFailureEventArgs), UnityGameFramework_Runtime_ShowEntityFailureEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.HideEntityCompleteEventArgs), UnityGameFramework_Runtime_HideEntityCompleteEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.EntityAttachedEventArgs), UnityGameFramework_Runtime_Extension_EntityAttachedEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.EntityAttachToEventArgs), UnityGameFramework_Runtime_Extension_EntityAttachToEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.EntityDeinitEventArgs), UnityGameFramework_Runtime_Extension_EntityDeinitEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.EntityDetachedEventArgs), UnityGameFramework_Runtime_Extension_EntityDetachedEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.EntityHideEventArgs), UnityGameFramework_Runtime_Extension_EntityHideEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.EntityInitEventArgs), UnityGameFramework_Runtime_Extension_EntityInitEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.EntityRecycleEventArgs), UnityGameFramework_Runtime_Extension_EntityRecycleEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.EntityShowEventArgs), UnityGameFramework_Runtime_Extension_EntityShowEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.EventComponent), UnityGameFramework_Runtime_EventComponent_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.LocalizationComponent), UnityGameFramework_Runtime_LocalizationComponent_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.NetworkComponent), UnityGameFramework_Runtime_NetworkComponent_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.ResourceComponent), UnityGameFramework_Runtime_ResourceComponent_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.SceneComponent), UnityGameFramework_Runtime_SceneComponent_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.SettingComponent), UnityGameFramework_Runtime_SettingComponent_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.SoundComponent), UnityGameFramework_Runtime_SoundComponent_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.PlaySoundSuccessEventArgs), UnityGameFramework_Runtime_PlaySoundSuccessEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.PlaySoundFailureEventArgs), UnityGameFramework_Runtime_PlaySoundFailureEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.UIComponent), UnityGameFramework_Runtime_UIComponent_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.UIForm), UnityGameFramework_Runtime_UIForm_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.UIForm), UnityGameFramework_Runtime_Extension_UIForm_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.OpenUIFormSuccessEventArgs), UnityGameFramework_Runtime_OpenUIFormSuccessEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.OpenUIFormFailureEventArgs), UnityGameFramework_Runtime_OpenUIFormFailureEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.CloseUIFormCompleteEventArgs), UnityGameFramework_Runtime_CloseUIFormCompleteEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.UIFormCloseEventArgs), UnityGameFramework_Runtime_Extension_UIFormCloseEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.UIFormCoverEventArgs), UnityGameFramework_Runtime_Extension_UIFormCoverEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.UIFormDeinitEventArgs), UnityGameFramework_Runtime_Extension_UIFormDeinitEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.UIFormInitEventArgs), UnityGameFramework_Runtime_Extension_UIFormInitEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.UIFormOpenEventArgs), UnityGameFramework_Runtime_Extension_UIFormOpenEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.UIFormPauseEventArgs), UnityGameFramework_Runtime_Extension_UIFormPauseEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.UIFormRecycleEventArgs), UnityGameFramework_Runtime_Extension_UIFormRecycleEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.UIFormRefocusEventArgs), UnityGameFramework_Runtime_Extension_UIFormRefocusEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.UIFormResumeEventArgs), UnityGameFramework_Runtime_Extension_UIFormResumeEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.UIFormRevealEventArgs), UnityGameFramework_Runtime_Extension_UIFormRevealEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.BuiltinDataComponent), UnityGameFramework_Runtime_Extension_BuiltinDataComponent_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.CameraComponent), UnityGameFramework_Runtime_Extension_CameraComponent_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.TimeComponent), UnityGameFramework_Runtime_Extension_TimeComponent_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.Extension.ScriptComponent), UnityGameFramework_Runtime_Extension_ScriptComponent_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.WebRequestComponent), UnityGameFramework_Runtime_WebRequestComponent_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.WebRequestStartEventArgs), UnityGameFramework_Runtime_WebRequestStartEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.WebRequestSuccessEventArgs), UnityGameFramework_Runtime_WebRequestSuccessEventArgs_Wrap.GetRegisterInfo);
            jsEnv.AddLazyStaticWrapLoader(typeof(UnityGameFramework.Runtime.WebRequestFailureEventArgs), UnityGameFramework_Runtime_WebRequestFailureEventArgs_Wrap.GetRegisterInfo);
            
        }
    }
}