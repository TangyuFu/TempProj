using System;
using System.Collections.Generic;
using GameFramework;
using Puerts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;
using Entity = UnityGameFramework.Runtime.Extension.Entity;
using UIForm = UnityGameFramework.Runtime.Extension.UIForm;

[Configure]
public class PuertsConfigure
{
    /// <summary>
    /// 在js/ts调用时，可以找到该类；
    /// 会生成一个静态类（wrap），在js调用时，直接静态调用，加快调用速度，否则是通过反射调用。
    /// 在index.d.ts中生成函数的声明，在ts调用时，import时，可以找到。
    /// </summary>
    [Binding]
    static IEnumerable<Type> Bindings =>
        new List<Type>
        {
            // --- C# & UnityEngine
            typeof(Type),
            typeof(List<>),
            typeof(Dictionary<,>),
            
            typeof(Debug),
            typeof(Time),
            typeof(GameObject),
            typeof(Component),
            typeof(Transform),
            typeof(Camera),
            typeof(Light),
            typeof(ParticleSystem),
            
            typeof(RectTransform),
            typeof(Image),
            typeof(RawImage),
            typeof(Toggle),
            typeof(Slider),
            typeof(TMP_Text),
            typeof(TMP_Dropdown),
            typeof(TMP_InputField),

            // --- UnityGameFramework
            typeof(UUtility.Text),
            typeof(UUtility.Asset),
            typeof(Log),
            typeof(Entry),
            // Base
            typeof(BaseComponent),
            // Download
            typeof(DownloadComponent),
            typeof(DownloadStartEventArgs),
            typeof(DownloadSuccessEventArgs),
            typeof(DownloadFailureEventArgs),
            // Entity
            typeof(EntityComponent),
            typeof(UnityGameFramework.Runtime.Entity),
            typeof(Entity),
            typeof(ShowEntitySuccessEventArgs),
            typeof(ShowEntityFailureEventArgs),
            typeof(HideEntityCompleteEventArgs),
            typeof(EntityAttachedEventArgs),
            typeof(EntityAttachToEventArgs),
            typeof(EntityDeinitEventArgs),
            typeof(EntityDetachedEventArgs),
            typeof(EntityHideEventArgs),
            typeof(EntityInitEventArgs),
            typeof(EntityRecycleEventArgs),
            typeof(EntityShowEventArgs),
            // Event
            typeof(EventComponent),
            // Localization
            typeof(LocalizationComponent),
            // Network
            typeof(NetworkComponent),
            // Resource
            typeof(ResourceComponent),
            // Scene
            typeof(SceneComponent),
            // Setting
            typeof(SettingComponent),
            // Sound
            typeof(SoundComponent),
            typeof(PlaySoundSuccessEventArgs),
            typeof(PlaySoundFailureEventArgs),
            // UI
            typeof(UIComponent),
            typeof(UnityGameFramework.Runtime.UIForm),
            typeof(UIForm),
            typeof(OpenUIFormSuccessEventArgs),
            typeof(OpenUIFormFailureEventArgs),
            typeof(CloseUIFormCompleteEventArgs),
            typeof(UIFormCloseEventArgs),
            typeof(UIFormCoverEventArgs),
            typeof(UIFormDeinitEventArgs),
            typeof(UIFormInitEventArgs),
            typeof(UIFormOpenEventArgs),
            typeof(UIFormPauseEventArgs),
            typeof(UIFormRecycleEventArgs),
            typeof(UIFormRefocusEventArgs),
            typeof(UIFormResumeEventArgs),
            typeof(UIFormRevealEventArgs),
            // BuiltinData
            typeof(BuiltinDataComponent),
            // Camera
            typeof(CameraComponent),
            // Time
            typeof(TimeComponent),
            // Script
            typeof(ScriptComponent),
            // WebRequest
            typeof(WebRequestComponent),
            typeof(WebRequestStartEventArgs),
            typeof(WebRequestSuccessEventArgs),
            typeof(WebRequestFailureEventArgs),
            // Other
        };

    /// <summary>
    /// 该标签只是针对ts调用，相比Binding，该标签仅生成ts声明（即不会生成静态类，只会在index.d.ts中生成函数的声明给ts调用）。
    /// </summary>
    [Typing]
    static IEnumerable<Type> Typings =>
        new List<Type>
        {
        };

    /// <summary>
    /// 对Blittable值类型通过内存拷贝传递，可避免值类型传递产生的GC，需要开启unsafe编译选项。
    /// </summary>
    [BlittableCopy]
    static IEnumerable<Type> Blittables =>
        new List<Type>
        {
            typeof(Vector2),
            typeof(Vector2),
            typeof(Rect),
            typeof(DateTime),
            typeof(Color),
        };

    /// <summary>
    /// 过滤函数。
    /// </summary>
    /// <param name="memberInfo"></param>
    /// <returns></returns>
    [Filter]
    static bool Filter(System.Reflection.MemberInfo memberInfo)
    {
        return false;
    }
}