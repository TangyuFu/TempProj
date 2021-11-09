using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// UI Canvas渲染排序类。
    /// </summary>
    [ExecuteAlways]
    [RequireComponent(typeof(Canvas))]
    public class CanvasRenderSorter : RenderSorterBase
    {
        private Canvas m_Canvas;

        void Awake()
        {
            m_Canvas = GetComponent<Canvas>();
            if (m_Canvas == null)
            {
                Log.Error("Failed to get canvas.");
                return;
            }
        }

        protected override void SortSelf()
        {
            if (!m_Canvas.overrideSorting)
                m_Canvas.overrideSorting = true;

            m_Canvas.sortingOrder = StartOrder;
            EndOrder = StartOrder;
        }
    }
}