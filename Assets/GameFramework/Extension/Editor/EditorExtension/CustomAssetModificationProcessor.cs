using System;
using UnityEditor;
using UnityEngine;

namespace UnityGameFramework.Editor.Extension
{
    public class CustomAssetModificationProcessor : UnityEditor.AssetModificationProcessor
    {
        [InitializeOnLoadMethod]
        private static void InitializeOnLoadMethod()
        {
            // 全局监听 Project 视图下的资源是否发生变化（添加、删除、移动）
            EditorApplication.projectChanged += delegate()
            {
                // Debug.Log("change");
            };
        }

        // 监听 “双击鼠标左键，打开资源” 事件
        public static bool IsOpenForEdit(string assetPath, out string message)
        {
            message = null;
            // Debug.Log($"open assetPath: {assetPath}");
            // true 表示该资源可以打开，false 表示不允许在 Unity 中打开该资源
            return true;
        }

        // 监听 “资源即将被创建” 事件
        public static void OnWillCreateAsset(string path)
        {
            // Debug.Log($"create assetPath: {path}");
        }

        // 监听 “资源即将被保存” 事件
        public static string[] OnWillSaveAssets(string[] paths)
        {
            if (paths != null)
            {
                // Debug.Log($"save paths: {string.Join(",", paths)}");
            }

            return paths;
        }

        // 监听 “资源即将被移动” 事件
        public static AssetMoveResult OnWillMoveAsset(string sourcePath, string destinationPath)
        {
            // Debug.Log($"move asset from {sourcePath} to {destinationPath}");
            return AssetMoveResult.DidNotMove;
        }

        // 监听 “资源即将被删除” 事件
        public static AssetDeleteResult OnWillDeleteAsset(string assetPath, RemoveAssetOptions options)
        {
            // Debug.Log($"delete asset {assetPath}");
            return AssetDeleteResult.DidNotDelete;
        }
    }
}