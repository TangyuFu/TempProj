using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 闪屏界面。
    /// </summary>
    public sealed class SplashForm : MonoBehaviour
    {
        [SerializeField] private Image m_SplashImage = null;

        [SerializeField] private float m_Duration = 1;

        private float m_LeftTime = 1;

        private event Action m_OnComplete;

        private Coroutine m_SplashCoroutine;

        public event Action onComplete
        {
            add => m_OnComplete += value;
            remove => m_OnComplete -= value;
        }

        public void StartSplash()
        {
            m_SplashCoroutine ??= StartCoroutine(Splash());
        }

        private IEnumerator Splash()
        {
            m_LeftTime = m_Duration;
            while (m_LeftTime > 0)
            {
                m_LeftTime -= Time.deltaTime;
                m_SplashImage.color = new Color(1f, 1f, 1f, m_LeftTime);
                yield return null;
            }

            m_OnComplete?.Invoke();
            m_SplashCoroutine = null;
        }
    }
}