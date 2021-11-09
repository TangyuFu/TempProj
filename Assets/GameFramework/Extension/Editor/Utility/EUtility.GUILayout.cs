using System;
using UnityEditor;
using UnityEngine;

namespace UnityGameFramework.Editor.Extension
{
    public static partial class EUtility
    {
        /// <summary>
        /// Unity Editor 界面布局工具。
        /// </summary>
        public static class GUILayout
        {
            public static string TextField(string label, string text, params GUILayoutOption[] options)
            {
                Vector2 textDimensions = GUI.skin.label.CalcSize(new GUIContent(label));
                EditorGUIUtility.labelWidth = textDimensions.x;
                return UnityEditor.EditorGUILayout.TextField(label, text, options);
            }

            public static bool Toggle(string label, bool value, params GUILayoutOption[] options)
            {
                Vector2 textDimensions = GUI.skin.label.CalcSize(new GUIContent(label));
                EditorGUIUtility.labelWidth = textDimensions.x;
                return UnityEditor.EditorGUILayout.Toggle(label, value, options);
            }

            public static Enum EnumFlagsField(string label, Enum enumValue, params GUILayoutOption[] options)
            {
                Vector2 textDimensions = GUI.skin.label.CalcSize(new GUIContent(label));
                EditorGUIUtility.labelWidth = textDimensions.x;
                return UnityEditor.EditorGUILayout.EnumFlagsField(label, enumValue, options);
            }
        }
    }
}