using System;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace UnityGameFramework.Editor.Extension
{
    public static partial class EUtility
    {
        /// <summary>
        /// Unity Editor UI 工具。
        /// </summary>
        public static class UI
        {
            /// <summary>
            /// 替换 UI 预制件 中的 TMP_Text。
            /// </summary>
            public static void ResetPrefabFont()
            {
                string fontAssetPath = "Assets/R/UI/Fonts/DefaultFont.asset";
                TMP_FontAsset fontAsset = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(fontAssetPath);
                string[] prefabDirectories = {"Assets/R/UI/Forms", "Assets/R/UI/Entities"};
                string[] prefabGuids = AssetDatabase.FindAssets("t:prefab", prefabDirectories);
                foreach (var guid in prefabGuids)
                {
                    string prefabPath = AssetDatabase.GUIDToAssetPath(guid);
                    GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
                    TMP_Text[] texts = prefab.GetComponentsInChildren<TMP_Text>(true);
                    foreach (var text in texts)
                    {
                        text.font = fontAsset;
                    }

                    PrefabUtility.SavePrefabAsset(prefab);
                }
            }
        }
    }
}