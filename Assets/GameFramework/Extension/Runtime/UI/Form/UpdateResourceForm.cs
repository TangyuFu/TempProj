using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 更新资源界面。
    /// </summary>
    public sealed class UpdateResourceForm : MonoBehaviour
    {
        [SerializeField] private TMP_Text m_DescriptionText = null;

        [SerializeField] private Slider m_ProgressSlider = null;

        public void SetDescription(string description)
        {
            m_DescriptionText.text = description;
        }

        public void SetProgress(float progress)
        {
            m_ProgressSlider.value = progress;
        }
    }
}