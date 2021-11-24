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
    public class GuidePresenter : UIFormPresenter
    {
        private GameObject m_Block;
        private GameObject m_BG;
        private GameObject m_Finger;

        private readonly List<RaycastResult> m_RaycastResults = new List<RaycastResult>();

        public override void OnInit(int uniqueId, int formId, CustomUIFormLogic customUIFormLogic, Transform root,
            object userData)
        {
            base.OnInit(uniqueId, formId, customUIFormLogic, root, userData);

            m_Block = root.Find("Block").gameObject;
            m_BG = root.Find("BG").gameObject;
            m_Finger = root.Find("Finger").gameObject;

            UIEventTrigger.Get(m_Block).onPointerClick.AddListener(OnBlock);
            UIEventTrigger.Get(m_Finger).onPointerClick.AddListener(OnFinger);

            HideGuide();
        }

        public override void OnDeinit()
        {
            UIEventTrigger.Get(m_Block).onPointerClick.RemoveListener(OnBlock);
            UIEventTrigger.Get(m_Finger).onPointerClick.RemoveListener(OnFinger);

            base.OnDeinit();
        }

        public override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            // to-do
        }

        private void HideGuide()
        {
            m_Block.SetActive(false);
            m_BG.SetActive(false);
            m_Finger.SetActive(false);
        }

        private void OnBlock(PointerEventData pointerEventData)
        {
        }

        private void OnFinger(PointerEventData pointerEventData)
        {
            m_RaycastResults.Clear();
            EventSystem.current.RaycastAll(pointerEventData, m_RaycastResults);
            for (int i = 0; i < m_RaycastResults.Count; i++)
            {
                GameObject current = m_RaycastResults[i].gameObject;
                if (current != m_Block && current != m_Finger)
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