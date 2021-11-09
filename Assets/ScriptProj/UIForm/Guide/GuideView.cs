using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    public class GuideView : MVCView<GuideProp>
    {
        public UnityAction<PointerEventData> BlockClicked { get; set; }
        public UnityAction<PointerEventData> FingerClicked { get; set; }

        public override void Init(GuideProp prop)
        {
            base.Init(prop);

            UIEventTrigger.Get(m_Prop.BlockGameObject).onPointerClick.AddListener(OnBlockClick);
            UIEventTrigger.Get(m_Prop.FingerGameObject).onPointerClick.AddListener(OnFingerClick);
        }

        public override void Deinit()
        {
            base.Deinit();

            UIEventTrigger.Get(m_Prop.BlockGameObject).onPointerClick.RemoveListener(OnBlockClick);
            UIEventTrigger.Get(m_Prop.FingerGameObject).onPointerClick.RemoveListener(OnFingerClick);

            BlockClicked = null;
            FingerClicked = null;
        }

        public void SetFingerPosition(RectTransform dest)
        {
            m_Prop.FingerRectTransform.ResetTo(dest);
        }

        private void OnBlockClick(PointerEventData pointerEventData)
        {
            BlockClicked?.Invoke(pointerEventData);
        }

        private void OnFingerClick(PointerEventData pointerEventData)
        {
            FingerClicked?.Invoke(pointerEventData);
        }
    }
}