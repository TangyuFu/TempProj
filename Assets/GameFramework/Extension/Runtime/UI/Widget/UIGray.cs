using GameFramework;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;

#endif

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// UI 置灰。
    /// </summary>
    [RequireComponent(typeof(Graphic))]
    public sealed class UIGray : MonoBehaviour
    {
        private bool m_IsGray;

        private static Material m_DefaultGrayMatrial;

        private static Material DefaultGrayMaterial => m_DefaultGrayMatrial
            ? m_DefaultGrayMatrial
            : m_DefaultGrayMatrial = new Material(Shader.Find("UI/Gray"));

        /// <summary>
        /// 获取或创建 UIGray 组件。
        /// </summary>
        /// <param name="go">要获取的游戏物体。</param>
        public static UIGray Get(GameObject go)
        {
            if (go == null)
            {
                Log.Error($"Invalid game object '{null}'.");
                return null;
            }

            return go.GetOrAddComponent<UIGray>();
        }

        /// <summary>
        /// 是否将游戏物体下所有 Graphic 置灰。
        /// </summary>
        public bool IsGray
        {
            get => m_IsGray;
            set
            {
                if (m_IsGray != value)
                {
                    m_IsGray = value;
                    SetGray(m_IsGray);
                }
            }
        }

        private void SetGray(bool isGray)
        {
            Graphic[] graphics = GetComponentsInChildren<Graphic>();
            graphics.Foreach(graphic => graphic.material = isGray ? DefaultGrayMaterial : null);
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(UIGray))]
    public class UIGrayEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            UIGray gray = target as UIGray;
            if (gray != null) gray.IsGray = GUILayout.Toggle(gray.IsGray, " isGray");
            if (GUI.changed)
            {
                EditorUtility.SetDirty(target);
            }
        }
    }
#endif
}