using DG.Tweening;
using UnityEngine;
using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    [Identity(10000001)]
    public class TipItemPresenter : EntityPresenter
    {
        private float m_Duration = 1f;

        private readonly Vector3 m_FromPosition = Vector3.up * -300;

        private readonly Vector3 m_ToPosition = Vector3.up * 0;

        private Tweener m_Timer;

        public override void OnInit(CustomEntityLogic logic, Transform root,
            object userData)
        {
            base.OnInit(logic, root, userData);

            if (userData is TipItemEntityData tipItemData)
            {
            }
            else
            {
                Log.Error("Invalid tip item data.");
                return;
            }

            m_Timer = root.DOLocalMove(m_ToPosition, m_Duration).SetAutoKill(false).OnComplete(Hide);
            m_Timer.Pause();
        }

        public override void OnDeinit()
        {
            m_Timer.Kill();
            m_Timer = null;

            base.OnDeinit();
        }

        public override void OnShow(object userData)
        {
            base.OnShow(userData);

            if (userData is TipItemEntityData tipItemData)
            {
                Root.localPosition = m_FromPosition;
                m_Timer.Restart();
            }
            else
            {
                Log.Error("Invalid tip item data.");
            }
        }

        public override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
        }
    }
}