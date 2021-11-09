using GameFramework;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    public static partial class Extension
    {
        /// <summary>
        /// 获取 RectTransform 的大小。
        /// </summary>
        /// <param name="target">获取的目标。</param>
        /// <returns>目标的大小。</returns>
        public static Vector2 GetSize(this RectTransform target)
        {
            if (target == null)
            {
                throw new GameFrameworkException($"Invalid target '{null}'.");
            }

            return target.rect.size;
        }

        /// <summary>
        /// 设置 RectTransform 大小，不改变其他属性。
        /// </summary>
        /// <param name="target">设置的目标。</param>
        /// <param name="size">设置的大小。</param>
        public static void SetSize(this RectTransform target, Vector2 size)
        {
            if (target == null)
            {
                throw new GameFrameworkException($"Invalid target '{target}'.");
            }

            Transform parent = target.parent;
            RectTransform parentRectTransform = parent != null ? parent.GetComponent<RectTransform>() : null;
            if (parentRectTransform == null)
            {
                throw new GameFrameworkException($"Invalid rect transform '{target}', must not on the top.");
            }

            Vector2 parentSize = parentRectTransform.rect.size;
            Vector2 anchorSize = parentSize * (target.anchorMax - target.anchorMin);
            target.sizeDelta = size - anchorSize;
        }

        /// <summary>
        /// 设置 RectTransform 锚点，不改变其他属性。
        /// </summary>
        /// <param name="target">设置的目标。</param>
        /// <param name="anchorMin">设置的左下角锚点。</param>
        /// <param name="anchorMax">设置的右上角锚点。</param>
        /// <exception cref="GameFrameworkException"></exception>
        public static void SetAnchors(this RectTransform target, Vector2 anchorMin, Vector2 anchorMax)
        {
            if (target == null)
            {
                throw new GameFrameworkException($"Invalid target '{target}'.");
            }

            Transform parent = target.parent;
            RectTransform parentRectTransform = parent != null ? parent.GetComponent<RectTransform>() : null;
            if (parentRectTransform == null)
            {
                throw new GameFrameworkException($"Invalid rect transform '{target}', must not on the top.");
            }

            Vector2 parentSize = parentRectTransform.rect.size;
            Vector2 anchorSize = parentSize * (target.anchorMax - target.anchorMin);
            Vector2 size = target.sizeDelta + anchorSize;
            Vector2 pivot;
            Vector2 anchorPoint = target.anchorMin + (target.anchorMax - target.anchorMin) * (pivot = target.pivot);
            Vector2 newAnchorPoint = anchorMin + (anchorMax - anchorMin) * pivot;
            Vector2 newAnchorSize = parentSize * (anchorMax - anchorMin);
            target.anchorMax = anchorMax;
            target.anchorMin = anchorMin;
            target.anchoredPosition += (anchorPoint - newAnchorPoint) * parentSize;
            target.sizeDelta = size - newAnchorSize;
        }

        /// <summary>
        /// 重置 RectTransform 所有属性，不改变大小。
        /// </summary>
        /// <param name="target">重置的目标。</param>
        public static void Reset(this RectTransform target)
        {
            if (target == null)
            {
                throw new GameFrameworkException($"Invalid target '{target}'.");
            }

            Transform parent = target.parent;
            RectTransform parentRectTransform = parent != null ? parent.GetComponent<RectTransform>() : null;
            if (parentRectTransform == null)
            {
                throw new GameFrameworkException($"Invalid rect transform '{target}', must not on the top.");
            }

            Vector2 size = GetSize(target);
            target.pivot = Vector2.one * 0.5f;
            target.anchorMin = Vector2.one * 0.5f;
            target.anchorMax = Vector2.one * 0.5f;
            target.anchoredPosition = Vector2.zero;
            target.sizeDelta = size;
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