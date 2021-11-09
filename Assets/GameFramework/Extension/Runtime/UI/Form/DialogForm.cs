using TMPro;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 对话框界面。
    /// </summary>
    public sealed class DialogForm : MonoBehaviour
    {
        [SerializeField] private TMP_Text m_TitleText = null;

        [SerializeField] private TMP_Text m_MessageText = null;

        [SerializeField] private GameObject[] m_ModeObjects = null;

        [SerializeField] private GameObject[] m_ConfirmObjects = null;

        [SerializeField] private GameObject[] m_CancelObjects = null;

        [SerializeField] private GameObject[] m_OtherObjects = null;

        [SerializeField] private TMP_Text[] m_ConfirmTexts = null;

        [SerializeField] private TMP_Text[] m_CancelTexts = null;

        [SerializeField] private TMP_Text[] m_OtherTexts = null;

        private DialogParams m_DialogParams;

        private void Awake()
        {
            foreach (var go in m_ConfirmObjects)
            {
                UIClickTrigger.Get(go).onClick.AddListener(OnConfirm);
            }

            foreach (var go in m_CancelObjects)
            {
                UIClickTrigger.Get(go).onClick.AddListener(OnCancel);
            }

            foreach (var go in m_OtherObjects)
            {
                UIClickTrigger.Get(go).onClick.AddListener(OnOther);
            }
        }

        private void OnDestroy()
        {
            foreach (var go in m_ConfirmObjects)
            {
                UIClickTrigger.Get(go).onClick.RemoveAllListeners();
            }

            foreach (var go in m_CancelObjects)
            {
                UIClickTrigger.Get(go).onClick.RemoveAllListeners();
            }

            foreach (var go in m_OtherObjects)
            {
                UIClickTrigger.Get(go).onClick.RemoveAllListeners();
            }
        }

        public void Open(DialogParams dialogParams)
        {
            gameObject.SetActive(true);

            m_DialogParams = dialogParams;

            m_TitleText.text = dialogParams.Title;
            m_MessageText.text = dialogParams.Message;

            for (int i = 0; i < m_ModeObjects.Length; i++)
            {
                m_ModeObjects[i].SetActive(i == dialogParams.Mode - 1);
            }

            switch (dialogParams.Mode)
            {
                case 1:
                    m_ConfirmTexts[0].text = m_DialogParams.ConfirmText;
                    break;

                case 2:
                    m_ConfirmTexts[1].text = m_DialogParams.ConfirmText;
                    m_CancelTexts[0].text = m_DialogParams.CancelText;
                    break;

                case 3:
                    m_ConfirmTexts[2].text = m_DialogParams.ConfirmText;
                    m_CancelTexts[1].text = m_DialogParams.CancelText;
                    m_OtherTexts[0].text = m_DialogParams.OtherText;
                    break;
            }
        }

        private void Close()
        {
            m_DialogParams = null;
            gameObject.SetActive(false);
        }

        private void OnConfirm(GameObject go)
        {
            m_DialogParams.OnClickConfirm?.Invoke(m_DialogParams.UserData);
            Close();
        }

        private void OnCancel(GameObject go)
        {
            m_DialogParams.OnClickCancel?.Invoke(m_DialogParams.UserData);
            Close();
        }

        private void OnOther(GameObject go)
        {
            m_DialogParams.OnClickOther?.Invoke(m_DialogParams.UserData);
            Close();
        }
    }
}