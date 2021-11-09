using System;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 粒子特效渲染排序类。
    /// </summary>
    [ExecuteAlways]
    public class EffectRenderSorter : RenderSorterBase
    {
        protected override void SortSelf()
        {
            Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>(true);
            if (renderers.Length == 0)
            {
                EndOrder = StartOrder;
                return;
            }

            // 子特效排序。
            Array.Sort(renderers, new Comparer<Renderer, int>((t) => t.sortingOrder));
            int orderTrack = StartOrder;
            // 特效排序起点。
            int sameTrack = renderers[0].sortingOrder;
            Array.ForEach(renderers, (t) =>
            {
                // Renderer.sortingOrder 和 Canvas.sortingOrder 只在 tag RenderType = Transparent情况时有效。
#if UNITY_EDITOR
                Material[] materials = t.sharedMaterials;
                if (materials.Length > 0)
                {
                    Array.ForEach(materials, (m) =>
                    {
                        // 一些材质可能为空，例如拖尾特效。
                        if (m != null && m.renderQueue != 3000)
                        {
                            Log.Error(
                                "Invalid renderer, renderer must have tag RenderType = Transparent, name: {t.name}");
                        }
                    });
                }
#endif
                if (t.sortingOrder != sameTrack)
                {
                    sameTrack = t.sortingOrder;
                    orderTrack++;
                }

                t.sortingOrder = orderTrack;
            });
            EndOrder = orderTrack;
        }
    }
}