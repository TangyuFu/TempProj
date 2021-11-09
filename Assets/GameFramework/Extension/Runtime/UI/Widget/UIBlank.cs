using UnityEngine;
using UnityEngine.UI;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 空白图形，不绘制顶点，仅用于接收事件。
    /// </summary>
    [RequireComponent(typeof(CanvasRenderer))]
    public sealed class UIBlank : Graphic
    {
        /// <summary>
        /// 清理顶点网格。
        /// </summary>
        /// <param name="toFill">顶点辅助器。</param>
        protected override void OnPopulateMesh(VertexHelper toFill)
        {
            toFill.Clear();
        }
    }
}