using DG.Tweening;
using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    [Identity((int) UIFormId.MaskForm)]
    public class MaskPresenter : UIFormPresenter
    {
        private GameObject m_Block;
        private GameObject m_BG;
        private GameObject m_Loading;
        private Transform m_Loading_Transform;

        private float m_WaitTime = 1f;
        private Sequence m_ShowSequence;

        public override void OnInit(int uniqueId, int formId, CustomUIFormLogic customUIFormLogic, Transform root,
            object userData)
        {
            base.OnInit(uniqueId, formId, customUIFormLogic, root, userData);
            
            m_Block = root.Find("Block").gameObject;
            m_BG = root.Find("BG").gameObject;
            m_Loading = root.Find("Loading").gameObject;
            m_Loading_Transform = m_Loading.transform;

            m_ShowSequence = DOTween.Sequence();
            Tweener waitTimer = DOTween.To(() => 0f, value => { }, 1f, m_WaitTime)
                .SetAutoKill(false)
                .OnComplete(() =>
                {
                    m_BG.SetActive(true);
                    m_Loading.SetActive(true);
                });
            Tweener loadingTimer = m_Loading_Transform.DORotate(Vector3.forward * 180, 1f)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Incremental)
                .SetAutoKill(false);
            m_ShowSequence.Append(waitTimer);
            m_ShowSequence.Append(loadingTimer);
            m_ShowSequence.Pause();
            
            Hide();

            Entry.Event.Subscribe(MaskEventArgs.EventId, OnMask);
        }

        public override void OnDeinit()
        {
            Entry.Event.Unsubscribe(MaskEventArgs.EventId, OnMask);
            m_ShowSequence.Kill();
            m_ShowSequence = null;

            base.OnDeinit();
        }

        private void OnMask(object sender, GameEventArgs args)
        {
            if (args is MaskEventArgs maskEventArgs)
            {
                if (maskEventArgs.Show)
                {
                    Show();
                }
                else
                {
                    Hide();
                }
            }
        }

        private void Show()
        {
            m_Block.SetActive(true);

            m_ShowSequence.Restart();
        }

        private void Hide()
        {
            m_Block.SetActive(false);
            m_BG.SetActive(false);
            m_Loading.SetActive(false);

            m_ShowSequence.Pause();
        }
    }
}