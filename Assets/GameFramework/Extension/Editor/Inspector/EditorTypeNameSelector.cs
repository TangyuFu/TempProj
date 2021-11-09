using System;
using System.Collections.Generic;
using System.Linq;
using GameFramework;
using UnityEditor;

namespace UnityGameFramework.Editor.Extension
{
    /// <summary>
    /// 编辑器下绘制类名选择弹窗。
    /// </summary>
    internal sealed class EditorTypeNameSelector
    {
        private const string NoneOptionName = "<None>";
        private string[] m_TypeNames = null;
        private int m_TypeNameIndex = 0;

        private string m_Label;
        private SerializedProperty m_TypeNameSerializedProperty;
        private string m_BaseTypeName;

        public EditorTypeNameSelector(string label, SerializedProperty typeNameSerializedProperty, string baseTypeName)
            : this(label, typeNameSerializedProperty, Utility.Assembly.GetType(baseTypeName))
        {
        }

        public EditorTypeNameSelector(string label, SerializedProperty typeNameSerializedProperty, Type baseType)
        {
            m_Label = label ?? throw new GameFrameworkException($"Invalid label '{null}'.");
            m_TypeNameSerializedProperty = typeNameSerializedProperty ??
                                           throw new GameFrameworkException(
                                               $"Invalid type name serialized property '{null}'.");
            if (baseType == null)
            {
                throw new GameFrameworkException($"Invalid base type '{null}'.");
            }

            List<string> typeNames = new List<string> {NoneOptionName};
            typeNames.AddRange(
                EUtility.Type.GetSubTypes(baseType)
                    .Select(type => type.FullName)
                    .OrderBy(typeName => typeName));
            m_TypeNames = typeNames.ToArray();
            m_TypeNameIndex = 0;
            if (!string.IsNullOrEmpty(m_TypeNameSerializedProperty.stringValue))
            {
                m_TypeNameIndex = typeNames.IndexOf(m_TypeNameSerializedProperty.stringValue);
                if (m_TypeNameIndex <= 0)
                {
                    m_TypeNameIndex = 0;
                    m_TypeNameSerializedProperty.stringValue = null;
                }
            }
        }

        public string Label => m_Label;

        public SerializedProperty TypeNameSerializedProperty => m_TypeNameSerializedProperty;

        public string BaseTypeName => m_BaseTypeName;

        public void OnInspectorGUI()
        {
            int selectedIndex = EditorGUILayout.Popup(m_Label,
                m_TypeNameIndex,
                m_TypeNames);
            if (selectedIndex != m_TypeNameIndex)
            {
                m_TypeNameIndex = selectedIndex;
                m_TypeNameSerializedProperty.stringValue = selectedIndex <= 0
                    ? null
                    : m_TypeNames[selectedIndex];
            }
        }
    }
}