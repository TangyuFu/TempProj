using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    /// <summary>
    /// 引导界面。
    /// </summary>
    [Identity((int) UIFormId.GuideForm)]
    public class GuidePresenter : UIFormPresenter<GuideView, GuideProp>
    {
        private readonly List<RaycastResult> m_RaycastResults = new List<RaycastResult>();

        public override void OnInit(GameObject target, object userData)
        {
            base.OnInit(target, userData);

            m_View.BlockClicked = BlockClick;
            m_View.FingerClicked = FingerClick;
        }

        public override void OnDeinit()
        {
            base.OnDeinit();
        }

        private void BlockClick(PointerEventData pointerEventData)
        {
        }

        private void FingerClick(PointerEventData pointerEventData)
        {
            m_RaycastResults.Clear();
            EventSystem.current.RaycastAll(pointerEventData, m_RaycastResults);
            for (int i = 0; i < m_RaycastResults.Count; i++)
            {
                GameObject current = m_RaycastResults[i].gameObject;
                if (current != m_Prop.BlockGameObject && current != m_Prop.BlockGameObject)
                {
                    ExecuteEvents.Execute(m_RaycastResults[i].gameObject, pointerEventData,
                        ExecuteEvents.pointerClickHandler);
                    //RaycastAll后ugui会自己排序，如果你只想响应透下去的最近的一个响应，这里ExecuteEvents.Execute后直接break就行。
                    break;
                }
            }
        }
    }
}