using DG.Tweening;
using UnityEngine;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    public class MaskView : MVCView<MaskProp>
    {
        private float m_WaitTime = 1f;
        private Sequence m_ShowSequence;

        public override void Init(MaskProp prop)
        {
            base.Init(prop);

            m_ShowSequence = DOTween.Sequence();
            Tweener waitTimer = DOTween.To(() => 0f, value => { }, 1f, m_WaitTime)
                .SetAutoKill(false)
                .OnComplete(() => m_Prop.ShowGameObject.SetActive(true));
            Tweener animatorTimer = m_Prop.LoadingTransform.DORotate(Vector3.forward * 180, 1f)
                .SetEase(Ease.Linear)
                .SetLoops(10000, LoopType.Incremental)
                .SetAutoKill(false);
            m_ShowSequence.Append(waitTimer);
            m_ShowSequence.Append(animatorTimer);

            Hide();
        }

        public override void Deinit()
        {
            DOTween.Kill(m_ShowSequence);
            m_ShowSequence = null;

            base.Deinit();
        }

        public void Show()
        {
            m_Prop.BlockGameObject.SetActive(true);

            m_ShowSequence.Restart();
        }

        public void Hide()
        {
            m_Prop.BlockGameObject.SetActive(false);
            m_Prop.ShowGameObject.SetActive(false);

            m_ShowSequence.Pause();
        }
    }
}