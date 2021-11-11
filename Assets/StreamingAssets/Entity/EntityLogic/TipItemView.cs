using System;
using DG.Tweening;
using UnityEngine;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    public class TipItemView : MVCView<TipItemProp>
    {
        private Tweener m_PositionTweener;
        private Tweener m_ColorTweener;
        private Tweener m_Timer;

        public Action OnComplete { get; set; }

        public override void Init(TipItemProp prop)
        {
            base.Init(prop);
        }

        public override void Deinit()
        {
            base.Deinit();
        }

        public void SetTweener(Vector3 toPosition, Color32 toColor, float duration)
        {
            m_PositionTweener = m_Prop.RootTransform.DOLocalMove(toPosition, duration)
                .SetAutoKill(false);
            m_ColorTweener = m_Prop.ContentText.DOColor(toColor, duration)
                .SetAutoKill(false);
            m_Timer = DOTween.To(() => 0, value => { }, 1, duration)
                .SetAutoKill(false)
                .OnComplete(OnTweenTwComplete);

            m_PositionTweener.Pause();
            m_ColorTweener.Pause();
            m_Timer.Pause();
        }

        public void Refresh(string content, Vector3 fromPosition, Color32 fromColor)
        {
            m_Prop.ContentText.text = content;

            m_Prop.RootTransform.localPosition = fromPosition;
            m_Prop.ContentText.color = fromColor;

            m_PositionTweener.Restart();
            m_ColorTweener.Restart();
            m_Timer.Restart();
        }

        private void OnTweenTwComplete()
        {
            OnComplete?.Invoke();
        }
    }
}