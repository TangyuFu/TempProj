using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace UnityGameFramework.Editor.Extension.Asset
{
    /// <summary>
    /// 资源控制器。
    /// </summary>
    public class AssetController
    {
        private List<AssetProcessor> m_AssetProcessors;

        public AssetController()
        {
            m_AssetProcessors =
                (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                    from assemblyType in domainAssembly.GetTypes()
                    where assemblyType.IsSubclassOf(typeof(AssetProcessor))
                    select Activator.CreateInstance(assemblyType) as AssetProcessor).ToList();
        }

        /// <summary>
        /// 获取所有资源处理器。
        /// </summary>
        public List<AssetProcessor> AssetProcessors => m_AssetProcessors;

        /// <summary>
        ///  重新加载资源预设。
        /// </summary>
        /// <param name="assetProcessor">要重新加载的资源处理器。</param>
        public void ReloadPreset(AssetProcessor assetProcessor)
        {
            assetProcessor.ReloadPreset();
        }

        /// <summary>
        /// 应用资源预设。
        /// </summary>
        /// <param name="assetProcessor">要应用预设的资源处理器。</param>
        public void ApplyPreset(AssetProcessor assetProcessor)
        {
            string[] assets =
                AssetDatabase.FindAssets(assetProcessor.SearchFilter, new[] {assetProcessor.SearchDirectory});
            assets
                .Select(AssetDatabase.GUIDToAssetPath)
                .Where(asset => Regex.Match(asset, assetProcessor.SearchPattern, RegexOptions.IgnoreCase).Success)
                .ToList()
                .ForEach(asset => { assetProcessor.Apply(asset); });
        }

        /// <summary>
        /// 获取贴图的原始大小。
        /// </summary>
        /// <param name="textureImporter">贴图导入器。</param>
        /// <param name="size">贴图大小。</param>
        /// <returns>是否获取成功。</returns>
        public static bool GetTextureSize(TextureImporter textureImporter, out Vector2Int size)
        {
            size = new Vector2Int();
            object[] args = new object[2];
            MethodInfo methodInfo = typeof(TextureImporter).GetMethod("GetWidthAndHeight",
                BindingFlags.NonPublic | BindingFlags.Instance);
            if (methodInfo == null)
            {
                size = Vector2Int.zero;
                return false;
            }

            methodInfo.Invoke(textureImporter, args);
            size = new Vector2Int((int) args[0], (int) args[1]);
            return true;
        }
    }
}