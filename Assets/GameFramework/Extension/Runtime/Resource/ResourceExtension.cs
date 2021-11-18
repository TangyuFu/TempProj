using System;
using GameFramework;
using GameFramework.Resource;
using UnityEngine;
using UnityEngine.U2D;
using UnityGameFramework.Runtime;

namespace UnityGameFramework.Extension.Runtime
{
    /// <summary>
    /// 资源拓展方法。
    /// </summary>
    public static class ResourceExtension
    {
        // private static Action<string, object> m_SuccessCallback;
        // private static Action<string, string> m_FailureCallback;
        // private static LoadAssetCallbacks m_LoadAssetCallbacks;
        //
        // /// <summary>
        // /// 脚本资源注册回调函数。
        // /// </summary>
        // /// <param name="resourceComponent">资源组件。</param>
        // /// <param name="successCallback">加载资源成功回调事件。</param>
        // /// <param name="failureCallback">加载资源失败回调事件。</param>
        // public static void ScriptRegisterCallbacks(this ResourceComponent resourceComponent,
        //     Action<string, object> successCallback,
        //     Action<string, string> failureCallback)
        // {
        //     m_SuccessCallback = successCallback;
        //     m_FailureCallback = failureCallback;
        //     m_LoadAssetCallbacks = new LoadAssetCallbacks(
        //         delegate(string name, object asset, float duration, object data)
        //         {
        //             m_SuccessCallback?.Invoke(name, asset);
        //         },
        //         delegate(string name, LoadResourceStatus status, string message, object data)
        //         {
        //             m_FailureCallback?.Invoke(name, message);
        //         });
        // }
        //
        // /// <summary>
        // /// 脚本加载资源。
        // /// </summary>
        // /// <param name="resourceComponent">资源组件。</param>
        // /// <param name="assetName">资源名称。</param>
        // public static void ScriptLoadAsset(this ResourceComponent resourceComponent, string assetName)
        // {
        //     resourceComponent.LoadAsset(assetName, typeof(UnityEngine.Object), 0, m_LoadAssetCallbacks,
        //         null);
        // }
        //
        // /// <summary>
        // /// 脚本加载资源。
        // /// </summary>
        // /// <param name="resourceComponent">资源组件。</param>
        // /// <param name="assetType">资源类型。</param>
        // /// <param name="assetName">资源名称。</param>
        // /// <param name="priority">加载优先级。</param>
        // /// <param name="userData">用户自定义数据。</param>
        // public static void ScriptLoadAsset(this ResourceComponent resourceComponent,Type assetType,  string assetName, int priority, object userData)
        // {
        //     resourceComponent.LoadAsset(assetName, assetType, 0, m_LoadAssetCallbacks,0);
        // }

        // /// <summary>
        // /// 脚本加载图集精灵。
        // /// </summary>
        // /// <param name="resourceComponent">资源组件。</param>
        // /// <param name="assetName">资源名称。</param>
        // /// <param name="priority">优先级。</param>
        // private static void ScriptLoadSpriteFromAtlas(this ResourceComponent resourceComponent, string assetName,
        //     int priority)
        // {
        //     int lastSlashIndex = assetName.LastIndexOf('/');
        //     string atlasName = Utility.Text.Format("{0}{1}", assetName.Substring(0, lastSlashIndex), ".spriteatlas");
        //     int lastPeriodIndex = assetName.LastIndexOf('.');
        //
        //     string spriteName = lastPeriodIndex == -1 || lastPeriodIndex < lastSlashIndex
        //         ? atlasName.Substring(lastSlashIndex + 1)
        //         : assetName.Substring(lastSlashIndex + 1, lastPeriodIndex - lastSlashIndex - 1);
        //
        //     resourceComponent.LoadAsset(atlasName, typeof(SpriteAtlas), priority, new LoadAssetCallbacks(
        //         delegate(string s, object asset, float duration, object data)
        //         {
        //             SpriteAtlas spriteAtlas = asset as SpriteAtlas;
        //             if (spriteAtlas == null)
        //             {
        //                 m_FailCallback?.Invoke(assetName, Utility.Text.Format("No such atlas: {0}.", atlasName));
        //             }
        //             else
        //             {
        //                 Sprite sprite = spriteAtlas.GetSprite(spriteName);
        //                 if (sprite == null)
        //                     m_FailCallback?.Invoke(assetName,
        //                         Utility.Text.Format("No such sprite: {0} in atlas: {1}.", spriteName, atlasName));
        //                 else
        //                     m_SuccessCallback?.Invoke(assetName, sprite);
        //             }
        //         },
        //         delegate(string s, LoadResourceStatus status, string message, object data)
        //         {
        //             m_FailCallback?.Invoke(assetName,
        //                 Utility.Text.Format("Load atlas failed with error: {0}.", message));
        //         }), null);
        // }
    }
}