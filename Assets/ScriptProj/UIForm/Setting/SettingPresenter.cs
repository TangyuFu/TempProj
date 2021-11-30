using System;
using System.Collections.Generic;
using GameFramework.Localization;
using GameFramework.Runtime.Extension;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    [Identity((int) UIFormId.SettingForm)]
    public class SettingPresenter : UIFormPresenter
    {
        private Toggle m_MusicMute_Toggle;
        private Slider m_MusicVolume_Slider;
        private Toggle m_SoundMute_Toggle;
        private Slider m_SoundVolume_Slider;
        private Toggle m_UISoundMute_Toggle;
        private Slider m_UISoundVolume_Slider;
        private GameObject m_Confirm;
        private TMP_Dropdown m_Language_TMP_Dropdown;

        private string[] m_LanguageOptions = {"简体中文", "繁體中文", "English", "日本語", "한국어"};

        private Language[] m_Languages =
        {
            Language.ChineseSimplified, Language.ChineseTraditional, Language.English, Language.Japanese,
            Language.Korean
        };

        private int m_LanguageValue = -1;

        private LocalDataAgent m_LocalDataAgent;

        public override void OnInit(int uniqueId, int formId, CustomUIFormLogic logic, Transform root,
            object userData)
        {
            base.OnInit(uniqueId, formId, logic, root, userData);
            
            m_MusicMute_Toggle = root.Find("_Music/MusicMute").GetComponent<Toggle>();
            m_MusicVolume_Slider = root.Find("_Music/MusicVolume").GetComponent<Slider>();
            m_SoundMute_Toggle = root.Find("_Sound/SoundMute").GetComponent<Toggle>();
            m_SoundVolume_Slider = root.Find("_Sound/SoundVolume").GetComponent<Slider>();
            m_UISoundMute_Toggle = root.Find("_UISound/UISoundMute").GetComponent<Toggle>();
            m_UISoundVolume_Slider = root.Find("_UISound/UISoundVolume").GetComponent<Slider>();
            m_Confirm = root.Find("Confirm").gameObject;

            UIClickTrigger.Get(m_Confirm).onClick.AddListener(OnConfirm);
            m_MusicMute_Toggle.onValueChanged.AddListener(OnMusicMuteValueChanged);
            m_MusicVolume_Slider.onValueChanged.AddListener(OnMusicVolumeValueChanged);
            m_SoundMute_Toggle.onValueChanged.AddListener(OnSoundMuteValueChanged);
            m_SoundVolume_Slider.onValueChanged.AddListener(OnSoundVolumeValueChanged);
            m_UISoundMute_Toggle.onValueChanged.AddListener(OnUISoundMuteValueChanged);
            m_UISoundVolume_Slider.onValueChanged.AddListener(OnUISoundVolumeValueChanged);
            m_Language_TMP_Dropdown.onValueChanged.AddListener(OnLanguageValueChanged);
            m_Language_TMP_Dropdown.onValueChanged.AddListener(OnLanguageValueChanged);

            SetLanguageOptions(m_LanguageOptions);

            m_LocalDataAgent = Entry.PlayerData.GetDataAgent<LocalDataAgent>();
        }

        public override void OnDeinit()
        {
            UIClickTrigger.Get(m_Confirm).onClick.RemoveListener(OnConfirm);
            m_MusicMute_Toggle.onValueChanged.RemoveListener(OnMusicMuteValueChanged);
            m_MusicVolume_Slider.onValueChanged.RemoveListener(OnMusicVolumeValueChanged);
            m_SoundMute_Toggle.onValueChanged.RemoveListener(OnSoundMuteValueChanged);
            m_SoundVolume_Slider.onValueChanged.RemoveListener(OnSoundVolumeValueChanged);
            m_UISoundMute_Toggle.onValueChanged.RemoveListener(OnUISoundMuteValueChanged);
            m_UISoundVolume_Slider.onValueChanged.RemoveListener(OnUISoundVolumeValueChanged);
            m_Language_TMP_Dropdown.onValueChanged.RemoveListener(OnLanguageValueChanged);
            m_Language_TMP_Dropdown.onValueChanged.RemoveListener(OnLanguageValueChanged);

            base.OnDeinit();
        }

        public override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            SetMusicMuteValue(!m_LocalDataAgent.MusicMuted);
            SetMusicVolumeValue(m_LocalDataAgent.MusicVolume);
            SetSoundMuteValue(!m_LocalDataAgent.SoundMuted);
            SetSoundVolumeValue(m_LocalDataAgent.SoundVolume);
            SetUISoundMuteValue(!m_LocalDataAgent.UISoundMuted);
            SetUISoundVolumeValue(m_LocalDataAgent.UISoundVolume);

            m_LanguageValue = Array.FindIndex(m_Languages, language => m_LocalDataAgent.Language == language);
            if (m_LanguageValue == -1)
            {
                m_LanguageValue = 0;
            }

            SetLanguageValue(m_LanguageValue);
        }

        public override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
        }

        public void SetLanguageOptions(string[] languageOptions)
        {
            List<TMP_Dropdown.OptionData> optionDataList = new List<TMP_Dropdown.OptionData>();
            for (int i = 0; i < languageOptions.Length; i++)
            {
                optionDataList.Add(new TMP_Dropdown.OptionData(languageOptions[i]));
            }

            m_Language_TMP_Dropdown.options = optionDataList;
        }

        public void SetLanguageValue(int value)
        {
            m_Language_TMP_Dropdown.value = value;
        }

        private void OnLanguageValueChanged(int value)
        {
            if (m_LanguageValue != value)
            {
                m_LanguageValue = value;
                m_LocalDataAgent.Language = m_Languages[value];
                Entry.Event.Fire(TipEventArgs.EventId, TipEventArgs.Create("Set language succeed, restart late."));
            }
        }

        public void SetMusicMuteValue(bool value)
        {
            m_MusicMute_Toggle.isOn = value;
        }

        private void OnMusicMuteValueChanged(bool value)
        {
            if (m_LocalDataAgent.MusicMuted != !value)
            {
                Entry.Sound.SetMusicMute(!value);
            }
        }

        public void SetMusicVolumeValue(float value)
        {
            m_MusicVolume_Slider.value = value;
        }

        private void OnMusicVolumeValueChanged(float value)
        {
            if (m_LocalDataAgent.MusicVolume != value)
            {
                Entry.Sound.SetMusicVolume(value);
            }
        }

        public void SetSoundMuteValue(bool value)
        {
            m_SoundMute_Toggle.isOn = value;
        }

        private void OnSoundMuteValueChanged(bool value)
        {
            if (m_LocalDataAgent.SoundMuted != !value)
            {
                Entry.Sound.SetSoundMute(!value);
            }
        }

        public void SetSoundVolumeValue(float value)
        {
            m_SoundVolume_Slider.value = value;
        }

        private void OnSoundVolumeValueChanged(float value)
        {
            if (m_LocalDataAgent.SoundVolume != value)
            {
                Entry.Sound.SetSoundVolume(value);
            }
        }

        public void SetUISoundMuteValue(bool value)
        {
            m_UISoundMute_Toggle.isOn = value;
        }

        private void OnUISoundMuteValueChanged(bool value)
        {
            if (m_LocalDataAgent.UISoundMuted != !value)
            {
                Entry.Sound.SetUISoundMute(!value);
            }
        }

        public void SetUISoundVolumeValue(float value)
        {
            m_UISoundVolume_Slider.value = value;
        }

        private void OnUISoundVolumeValueChanged(float value)
        {
            if (m_LocalDataAgent.UISoundVolume != value)
            {
                Entry.Sound.SetUISoundVolume(value);
            }
        }

        private void OnConfirm(GameObject gameObject)
        {
            Close();
        }
    }
}