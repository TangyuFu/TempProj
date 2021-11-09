#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// UGUI 中 Graphic raycast 检测，以绿色框标注。
    /// </summary>
    [ExecuteInEditMode]
    public class GraphicRaycastAuxiliary : MonoBehaviour
    {
        private readonly List<Graphic> m_Graphics = new List<Graphic>();

        private void GetAllGraphics(List<Graphic> graphics)
        {
            Scene activeScene = SceneManager.GetActiveScene();
            GameObject[] rootGameObjects = activeScene.GetRootGameObjects();
            Array.ForEach(rootGameObjects, go => { graphics.AddRange(go.GetComponentsInChildren<Graphic>(false)); });
        }

        private void OnDrawGizmos()
        {
            Handles.color = Color.green;
            Vector3[] fourCorners = new Vector3[4];
            GetAllGraphics(m_Graphics);
            for (int i = 0; i < m_Graphics.Count; i++)
            {
                Graphic graphic = m_Graphics[i];
                if (!graphic.raycastTarget)
                {
                    continue;
                }

                RectTransform rectTransform = m_Graphics[i].GetComponent<RectTransform>();
                rectTransform.GetWorldCorners(fourCorners);
                Vector3 center = (fourCorners[0] + fourCorners[2]) * 0.5f;
                for (int j = 0; j < 4; j++)
                {
                    Vector3 corner = fourCorners[j];
                    corner += GetUnitVector3(corner - center) * 0.01f;
                    fourCorners[j] = corner;
                }

                for (int j = 0; j < 4; j++)
                {
                    Vector3 start = fourCorners[j];
                    Vector3 end = fourCorners[(j + 1) % 4];

                    Handles.DrawAAPolyLine(3, new Vector3[] {start, end});
                }
            }

            m_Graphics.Clear();
        }

        private Vector3 GetUnitVector3(Vector3 input)
        {
            return new Vector3(Mathf.Sign(input.x), Mathf.Sign(input.y), Mathf.Sign(input.z));
        }
    }
}
#endif