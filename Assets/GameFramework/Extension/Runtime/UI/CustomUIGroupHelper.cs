using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 界面组辅助器。
    /// </summary>
    public class CustomUIGroupHelper : DefaultUIGroupHelper
    {
        public override void SetDepth(int depth)
        {
            base.SetDepth(depth);

            RectTransform rectTransform = gameObject.GetOrAddComponent<RectTransform>();
            rectTransform.localScale = Vector3.one;
            rectTransform.localPosition = Vector3.zero;
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.anchoredPosition = Vector2.zero;
            rectTransform.sizeDelta = Vector2.zero;

            CanvasRenderSorter canvasRenderSorter = gameObject.GetOrAddComponent<CanvasRenderSorter>();
            canvasRenderSorter.RenderSorterMode = RenderSorterMode.Absolute;
            canvasRenderSorter.RenderSorterOrder = depth * 100;
        }
    }
}