using GameFramework;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    public static partial class Extension
    {
        /// <summary>
        /// 获取 RectTransform 的大小。
        /// </summary>
        /// <param name="rectTransform">获取的目标。</param>
        /// <returns>目标的大小。</returns>
        public static Vector2 GetSize(this RectTransform rectTransform)
        {
            if (rectTransform == null)
            {
                throw new GameFrameworkException($"Invalid rectTransform '{null}'.");
            }

            return rectTransform.rect.size;
        }

        /// <summary>
        /// 设置 RectTransform 大小，不改变其他属性。
        /// </summary>
        /// <param name="rectTransform">设置的目标。</param>
        /// <param name="size">设置的大小。</param>
        public static void SetSize(this RectTransform rectTransform, Vector2 size)
        {
            if (rectTransform == null)
            {
                throw new GameFrameworkException($"Invalid rectTransform '{rectTransform}'.");
            }

            Transform parent = rectTransform.parent;
            RectTransform parentRectTransform = parent != null ? parent.GetComponent<RectTransform>() : null;
            if (parentRectTransform == null)
            {
                throw new GameFrameworkException($"Invalid rectTransform '{rectTransform}', must not on the top.");
            }

            Vector2 parentSize = parentRectTransform.rect.size;
            Vector2 anchorSize = parentSize * (rectTransform.anchorMax - rectTransform.anchorMin);
            rectTransform.sizeDelta = size - anchorSize;
        }

        /// <summary>
        /// 设置 RectTransform 锚点，不改变其他属性。
        /// </summary>
        /// <param name="rectTransform">设置的目标。</param>
        /// <param name="anchorMin">设置的左下角锚点。</param>
        /// <param name="anchorMax">设置的右上角锚点。</param>
        /// <exception cref="GameFrameworkException"></exception>
        public static void SetAnchors(this RectTransform rectTransform, Vector2 anchorMin, Vector2 anchorMax)
        {
            if (rectTransform == null)
            {
                throw new GameFrameworkException($"Invalid rectTransform '{rectTransform}'.");
            }

            Transform parent = rectTransform.parent;
            RectTransform parentRectTransform = parent != null ? parent.GetComponent<RectTransform>() : null;
            if (parentRectTransform == null)
            {
                throw new GameFrameworkException($"Invalid rectTransform '{rectTransform}', must not on the top.");
            }

            Vector2 parentSize = parentRectTransform.rect.size;
            Vector2 anchorSize = parentSize * (rectTransform.anchorMax - rectTransform.anchorMin);
            Vector2 size = rectTransform.sizeDelta + anchorSize;
            Vector2 pivot;
            Vector2 anchorPoint = rectTransform.anchorMin +
                                  (rectTransform.anchorMax - rectTransform.anchorMin) * (pivot = rectTransform.pivot);
            Vector2 newAnchorPoint = anchorMin + (anchorMax - anchorMin) * pivot;
            Vector2 newAnchorSize = parentSize * (anchorMax - anchorMin);
            rectTransform.anchorMax = anchorMax;
            rectTransform.anchorMin = anchorMin;
            rectTransform.anchoredPosition += (anchorPoint - newAnchorPoint) * parentSize;
            rectTransform.sizeDelta = size - newAnchorSize;
        }

        /// <summary>
        /// 重置 RectTransform 所有属性，不改变大小。
        /// </summary>
        /// <param name="rectTransform">重置的目标。</param>
        public static void Reset(this RectTransform rectTransform)
        {
            if (rectTransform == null)
            {
                throw new GameFrameworkException($"Invalid rectTransform '{rectTransform}'.");
            }

            Transform parent = rectTransform.parent;
            RectTransform parentRectTransform = parent != null ? parent.GetComponent<RectTransform>() : null;
            if (parentRectTransform == null)
            {
                throw new GameFrameworkException($"Invalid rectTransform '{rectTransform}', must not on the top.");
            }

            Vector2 size = GetSize(rectTransform);
            rectTransform.pivot = Vector2.one * 0.5f;
            rectTransform.anchorMin = Vector2.one * 0.5f;
            rectTransform.anchorMax = Vector2.one * 0.5f;
            rectTransform.anchoredPosition = Vector2.zero;
            rectTransform.sizeDelta = size;
        }

        /// <summary>
        /// 重置当前 RectTransform 到目标 RectTransform 的位置。
        /// </summary>
        /// <param name="source">重置源</param>
        /// <param name="destination">重置目标</param>
        public static void ResetTo(this RectTransform source, RectTransform destination)
        {
            Vector3[] worldCorners = new Vector3[4];
            Vector3 center = Vector3.zero;
            Vector2 size = Vector2.zero;
            destination.GetWorldCorners(worldCorners);
            for (var i = 0; i < worldCorners.Length; i++)
            {
                center += worldCorners[i];
            }

            center /= 4;
            var lossyScale = source.lossyScale;
            size.x = (worldCorners[2] - worldCorners[1]).x / lossyScale.x;
            size.y = (worldCorners[1] - worldCorners[0]).y / lossyScale.y;
            source.position = center;
            source.sizeDelta = size;
        }
    }
}