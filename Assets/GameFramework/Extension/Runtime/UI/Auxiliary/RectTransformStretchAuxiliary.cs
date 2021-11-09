#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// UGUI 中 RectTransform anchor stretch 检测，以红色框标注。
    /// </summary>Q
    [ExecuteInEditMode]
    public class RectTransformStretchAuxiliary : MonoBehaviour
    {
        private readonly List<RectTransform> m_RectTransforms = new List<RectTransform>();

        private void GetAllRectTransforms(List<RectTransform> rectTransforms)
        {
            Scene activeScene = SceneManager.GetActiveScene();
            GameObject[] rootGameObjects = activeScene.GetRootGameObjects();
            Array.ForEach(rootGameObjects,
                go => { rectTransforms.AddRange(go.GetComponentsInChildren<RectTransform>(false)); });
        }

        private void OnDrawGizmos()
        {
            Handles.color = Color.red;
            Vector3[] fourCorners = new Vector3[4];
            GetAllRectTransforms(m_RectTransforms);
            for (int i = 0; i < m_RectTransforms.Count; i++)
            {
                RectTransform rectTransform = m_RectTransforms[i];
                if (rectTransform.anchorMin == rectTransform.anchorMax)
                {
                    continue;
                }

                rectTransform.GetWorldCorners(fourCorners);
                Vector3 center = (fourCorners[0] + fourCorners[2]) * 0.5f;
                for (int j = 0; j < 4; j++)
                {
                    Vector3 corner = fourCorners[j];
                    corner += GetUnitVector3(corner - center) * 0.05f;
                    fourCorners[j] = corner;
                }

                for (int j = 0; j < 4; j++)
                {
                    Vector3 start = fourCorners[j];
                    Vector3 end = fourCorners[(j + 1) % 4];

                    Handles.DrawAAPolyLine(3, start, end);
                }
            }

            m_RectTransforms.Clear();
        }

        private Vector3 GetUnitVector3(Vector3 input)
        {
            return new Vector3(Mathf.Sign(input.x), Mathf.Sign(input.y), Mathf.Sign(input.z));
        }
    }
}
#endif