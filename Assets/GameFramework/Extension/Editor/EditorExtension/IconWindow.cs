using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UnityGameFramework.Editor
{
    public class IconWindow : EditorWindow
    {
        // [MenuItem("Test/Unload All AssetBundles")]
        public static void UnloadAllAssetBundles()
        {
            foreach (var assetBundle in AssetBundle.GetAllLoadedAssetBundles())
            {
                Debug.Log(assetBundle.name);
            }
            
            AssetBundle.UnloadAllAssetBundles(false);
        }

        // [MenuItem("Test/Open Test Window")]
        public static void OpenWindow()
        {
            EditorWindow.GetWindow<IconWindow>();
        }

        private Vector2 m_Scroll;
        private List<string> m_Icons;

        private void Awake()
        {
            m_Icons = new List<string>();
            Texture2D[] t = Resources.FindObjectsOfTypeAll<Texture2D>();
            foreach (var x in t)
            {
                Debug.unityLogger.logEnabled = false;
                GUIContent gc = EditorGUIUtility.IconContent(x.name);
                Debug.unityLogger.logEnabled = true;

                if (gc != null && gc.image != null)
                {
                    m_Icons.Add(x.name);
                }
            }
        }

        private void OnGUI()
        {
            m_Scroll = GUILayout.BeginScrollView(m_Scroll);
            float width = 50f;
            int count = (int) (position.width / width);
            for (int i = 0; i < m_Icons.Count; i += count)
            {
                GUILayout.BeginHorizontal();
                for (int j = 0; j < count; j++)
                {
                    int index = i + j;
                    if (index < m_Icons.Count)
                    {
                        if (GUILayout.Button(EditorGUIUtility.IconContent(m_Icons[index]), GUILayout.Width(width),
                            GUILayout.Height(30)))
                        {
                            Debug.Log(m_Icons[index]);
                        }
                    }
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndScrollView();
        }
    }
}