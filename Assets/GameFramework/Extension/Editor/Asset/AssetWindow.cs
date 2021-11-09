using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Presets;
using UnityEngine;

namespace UnityGameFramework.Editor.Extension.Asset
{
    /// <summary>
    /// 资源窗口。
    /// </summary>
    public sealed class AssetWindow : EditorWindow
    {
        private class AssetProcessorData
        {
            public bool Foldout;
            public AssetProcessor AssetProcessor;
        }

        [MenuItem("Game Framework/Extension/Asset", true, 300)]
        private static bool OpenValidate()
        {
            if (EditorApplication.isPlaying || EditorApplication.isCompiling || EditorApplication.isUpdating)
            {
                return false;
            }

            return true;
        }

        [MenuItem("Game Framework/Extension/Asset", false, 300)]
        private static void Open()
        {
            GetWindow<AssetWindow>("Asset").position
                = new Rect(0, 0,
                    Screen.currentResolution.width * 0.5f,
                    Screen.currentResolution.height * 0.95f);
        }

        private AssetController m_AssetController;
        private List<AssetProcessorData> m_AssetProcessorData;

        private void OnEnable()
        {
            Refresh();
        }

        private void Refresh()
        {
            m_AssetController = new AssetController();
            m_AssetProcessorData =
                m_AssetController.AssetProcessors
                    .OrderBy(assetProcessor => assetProcessor.ResourceType)
                    .Select(processor => new AssetProcessorData {Foldout = false, AssetProcessor = processor})
                    .ToList();
        }

        private void OnDisable()
        {
        }
        
        private void OnGUI()
        {
            EditorGUILayout.BeginVertical();
            DrawAssetProcessView();
            EditorGUILayout.EndVertical();
        }

        private Vector2 m_AssetProcessViewScrollPos;

        private void DrawAssetProcessView()
        {
            m_AssetProcessViewScrollPos = EditorGUILayout.BeginScrollView(m_AssetProcessViewScrollPos);
            foreach (var assetProcessorData in m_AssetProcessorData)
            {
                AssetProcessor assetProcessor = assetProcessorData.AssetProcessor;
                assetProcessorData.Foldout =
                    EditorGUILayout.Foldout(assetProcessorData.Foldout, assetProcessor.ResourceType);
                if (assetProcessorData.Foldout)
                {
                    EditorGUILayout.BeginVertical();
                    EditorGUILayout.LabelField("Search Directory: ", assetProcessor.SearchDirectory);
                    EditorGUILayout.LabelField("Search Pattern: ", assetProcessor.SearchPattern);
                    EditorGUILayout.LabelField("Preset Path: ", assetProcessor.PresetPath);
                    assetProcessor.Preset =
                        EditorGUILayout.ObjectField("Preset : ", assetProcessor.Preset, typeof(Preset),
                            false) as Preset;
                    if (GUILayout.Button("Apply"))
                    {
                        m_AssetController.ApplyPreset(assetProcessor);
                    }

                    EditorGUILayout.EndVertical();
                }
            }

            EditorGUILayout.EndScrollView();
        }
    }
}