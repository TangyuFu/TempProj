#if UNITY_EDITOR
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 组件标记，用于 UI 制作中的脚本客制化。
    /// </summary>
    [DisallowMultipleComponent]
    public class ComponentMask : MonoBehaviour
    {
        [SerializeField] private bool m_Exported = false;
        [SerializeField] private bool m_Click = false;
        [SerializeField] private string m_Path = null;
        [SerializeField] private List<string> m_Components = new List<string>();

        /// <summary>
        /// 是否导出。
        /// </summary>
        public bool Exported
        {
            get => m_Exported;
            set => m_Exported = value;
        }

        /// <summary>
        /// 是否点击。
        /// </summary>
        public bool Click
        {
            get => m_Click;
            set => m_Click = value;
        }

        /// <summary>
        /// 游戏物体相对预制件的路径。
        /// </summary>
        public string Path
        {
            get => m_Path;
            set => m_Path = value;
        }

        /// <summary>
        /// 是否点击。
        /// </summary>
        public List<string> Components => m_Components;

        /// <summary>
        /// 添加组件。
        /// </summary>
        /// <param name="component">要添加组件名称。</param>
        public void Add(string component)
        {
            if (!m_Components.Contains(component))
            {
                m_Components.Add(component);
            }
        }

        /// <summary>
        /// 删除组件。
        /// </summary>
        /// <param name="component"></param>
        public void Remove(string component)
        {
            if (m_Components.Contains(component))
            {
                m_Components.Remove(component);
            }
        }

        /// <summary>
        /// 清除组件。
        /// </summary>
        public void Clear()
        {
            m_Components.Clear();
        }
    }


    [CustomEditor(typeof(ComponentMask))]
    public class ComponentMarkEditor : UnityEditor.Editor
    {
        private SerializedProperty m_Exported = null;
        private SerializedProperty m_Components = null;
        private SerializedProperty m_Path = null;
        private SerializedProperty m_Click = null;

        private ComponentMask _mComponentMask;
        private string[] m_ComponentOptions;
        private int m_AddIndex = 0;
        private int m_RemoveIndex = 0;

        void OnEnable()
        {
            m_Exported = serializedObject.FindProperty("m_Exported");
            m_Components = serializedObject.FindProperty("m_Components");
            m_Path = serializedObject.FindProperty("m_Path");
            m_Click = serializedObject.FindProperty("m_Click");

            _mComponentMask = target as ComponentMask;
            if (_mComponentMask == null)
            {
                Log.Error("Invalid component mark.");
                return;
            }

            m_ComponentOptions = _mComponentMask.GetComponents<Component>().Where(t => t != _mComponentMask)
                .Select(t => t.GetType().FullName).ToArray();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(m_Exported);
            EditorGUILayout.PropertyField(m_Click);
            EditorGUILayout.PropertyField(m_Path);
            EditorGUILayout.PropertyField(m_Components);

            m_AddIndex = EditorGUILayout.Popup("Add Component", m_AddIndex, m_ComponentOptions);
            if (GUILayout.Button("Add"))
            {
                _mComponentMask.Add(m_ComponentOptions[m_AddIndex]);
            }

            m_RemoveIndex = EditorGUILayout.Popup("Remove Component", m_RemoveIndex, m_ComponentOptions);
            if (GUILayout.Button("Remove"))
            {
                _mComponentMask.Remove(m_ComponentOptions[m_RemoveIndex]);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}

#endif