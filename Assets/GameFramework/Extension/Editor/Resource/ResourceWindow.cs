using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UnityGameFramework.Editor.Extension.Resource
{
    public sealed class ResourceWindow : EditorWindow
    {
        [MenuItem("Game Framework/Extension/Resource", true, 400)]
        private static bool OpenValidate()
        {
            if (EditorApplication.isPlaying || EditorApplication.isCompiling || EditorApplication.isUpdating)
            {
                return false;
            }

            return true;
        }

        [MenuItem("Game Framework/Extension/Resource", false, 400)]
        private static void Open()
        {
            GetWindow<ResourceWindow>("Resource").position
                = new Rect(0, 0,
                    Screen.currentResolution.width * 0.5f,
                    Screen.currentResolution.height * 0.95f);
        }

        private void OnEnable()
        {
            ResourceController.Instance.Refresh();
        }

        private void OnDisable()
        {
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.BeginVertical("box", GUILayout.Width(position.width * 0.25f));
                {
                    EditorGUILayout.LabelField("Resource List", EditorStyles.boldLabel);
                    DrawResourcesView();
                }
                EditorGUILayout.EndVertical();

                EditorGUILayout.BeginVertical("box", GUILayout.Width(position.width * 0.25f));
                {
                    EditorGUILayout.LabelField("Asset List", EditorStyles.boldLabel);
                    DrawAssetsView();
                }
                EditorGUILayout.EndVertical();

                EditorGUILayout.BeginVertical("box", GUILayout.Width(position.width * 0.48f));
                {
                    EditorGUILayout.LabelField("Operation", EditorStyles.boldLabel);
                    DrawOperationView();
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndHorizontal();
        }

        private Vector2 m_ResourcesViewScrollPos;

        private void DrawResourcesView()
        {
            m_ResourcesViewScrollPos = EditorGUILayout.BeginScrollView(m_ResourcesViewScrollPos);
            Dictionary<string, ResourceName> resourceNames = ResourceController.Instance.ResourceResearch.ResourceNames;
            foreach (var keyValuePair in resourceNames)
            {
                string resourceName = keyValuePair.Value.Name;
                bool toggle = ResourceController.Instance.SelectedResourceName == resourceName;
                bool newToggle =
                    EditorGUILayout.ToggleLeft(resourceName, toggle, GUILayout.Width(position.width * 0.25f));
                if (newToggle != toggle)
                {
                    ResourceController.Instance.SelectedResourceName = newToggle ? resourceName : null;
                }
            }

            EditorGUILayout.EndScrollView();
        }

        private Vector2 m_AssetsViewScrollPos;

        private void DrawAssetsView()
        {
            m_AssetsViewScrollPos = EditorGUILayout.BeginScrollView(m_AssetsViewScrollPos);
            Dictionary<string, AssetName> assetNames = ResourceController.Instance.ResourceResearch.AssetNames;
            foreach (var keyValuePair in assetNames)
            {
                AssetName assetName = keyValuePair.Value;
                if (assetName.ResourceName == ResourceController.Instance.SelectedResourceName)
                {
                    EditorGUILayout.LabelField(assetName.Name, GUILayout.Width(position.width * 0.25f));
                }
            }

            EditorGUILayout.EndScrollView();
        }

        private void DrawOperationView()
        {
            EditorGUILayout.BeginHorizontal();
            {
                if (GUILayout.Button("Refresh"))
                {
                    ResourceController.Instance.Refresh();
                }

                EditorGUILayout.Space();
                if (GUILayout.Button("Clear"))
                {
                    ResourceController.Instance.Clear();
                }

                if (GUILayout.Button("Save Research"))
                {
                    ResourceController.Instance.SaveResearch();
                }

                EditorGUILayout.Space();
                if (GUILayout.Button("Save Collection"))
                {
                    ResourceController.Instance.SaveCollection();
                }
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}