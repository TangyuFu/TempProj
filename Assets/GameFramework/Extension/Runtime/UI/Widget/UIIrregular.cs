using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;

#endif

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// UI 不规则点击组件。
    /// </summary>
    [RequireComponent(typeof(Graphic))]
    public class UIIrregular : Image
    {
        [SerializeField] private Collider2D m_Irregular;

        public Collider2D Irregular
        {
            get => m_Irregular;
            set
            {
                if (m_Irregular != null && m_Irregular != value)
                {
                    m_Irregular = value;
                }
            }
        }

        protected override void Awake()
        {
            base.Awake();

            m_Irregular = GetComponent<Collider2D>();
        }

        protected override void OnPopulateMesh(VertexHelper toFill)
        {
#if UNITY_EDITOR
            base.OnPopulateMesh(toFill);
#else
            toFill.Clear();
#endif
        }

        public override bool IsRaycastLocationValid(Vector2 screenPoint, UnityEngine.Camera eventCamera)
        {
            return m_Irregular == null || m_Irregular.OverlapPoint(eventCamera.ScreenToWorldPoint(screenPoint));
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(UIIrregular), true)]
    public class UIPolygonEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            UIIrregular irregular = target as UIIrregular;
            if (irregular != null)
            {
                irregular.Irregular = (Collider2D) EditorGUILayout.ObjectField(
                    "Irregular Collider2D",
                    irregular.Irregular,
                    typeof(Collider2D),
                    true);
            }

            if (GUI.changed)
            {
                EditorUtility.SetDirty(target);
            }
        }
    }
#endif
}