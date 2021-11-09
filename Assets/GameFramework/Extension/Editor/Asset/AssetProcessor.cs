using UnityEditor;
using UnityEditor.Presets;
using UnityEngine;

namespace UnityGameFramework.Editor.Extension.Asset
{
    /// <summary>
    /// 资源处理器基类。
    /// </summary>
    public abstract class AssetProcessor
    {
        /// <summary>
        /// 处理器要处理的资源类型
        /// </summary>
        public abstract string ResourceType { get; }

        /// <summary>
        /// 处理器搜索的目录。
        /// </summary>
        public abstract string SearchDirectory { get; }

        /// <summary>
        /// 处理器的搜索模式。
        /// </summary>
        public abstract string SearchPattern { get; }

        /// <summary>
        /// 资源过滤器。
        /// </summary>
        public abstract string SearchFilter { get; }

        /// <summary>
        /// 处理器要应用的预设路径。
        /// </summary>
        public abstract string PresetPath { get; }

        private Preset m_Preset;

        /// <summary>
        /// 资源要应用的预设。
        /// </summary>
        public Preset Preset
        {
            get
            {
                if (m_Preset != null)
                {
                    return m_Preset;
                }

                m_Preset = AssetDatabase.LoadAssetAtPath<Preset>(PresetPath);

                if (m_Preset == null)
                {
                    Debug.LogWarning($"Failed to load preset from '{PresetPath}'");
                }

                return m_Preset;
            }
            set => m_Preset = value;
        }

        /// <summary>
        /// 重新加载预设。
        /// </summary>
        public void ReloadPreset()
        {
            m_Preset = null;
        }

        /// <summary>
        /// 应用资源处理。
        /// </summary>
        /// <param name="path">要应用的路径。</param>
        /// <returns></returns>
        public abstract bool Apply(string path);
    }
}