using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    public class SettingView : MVCView<SettingProp>
    {
        public UnityAction BackClicked { get; set; }
        public UnityAction<bool> MusicMuteValueChanged { get; set; }
        public UnityAction<float> MusicVolumeValueChanged { get; set; }
        public UnityAction<bool> SoundMuteValueChanged { get; set; }
        public UnityAction<float> SoundVolumeValueChanged { get; set; }
        public UnityAction<bool> UISoundMuteValueChanged { get; set; }
        public UnityAction<float> UISoundVolumeValueChanged { get; set; }
        public UnityAction<int> LanguageValueChanged { get; set; }

        public override void Init(SettingProp prop)
        {
            base.Init(prop);

            UIClickTrigger.Get(m_Prop.BackGameObject).onClick.AddListener(OnBackClick);
            m_Prop.MusicMuteToggle.onValueChanged.AddListener(OnMusicMuteValueChanged);
            m_Prop.MusicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeValueChanged);
            m_Prop.SoundMuteToggle.onValueChanged.AddListener(OnSoundMuteValueChanged);
            m_Prop.SoundVolumeSlider.onValueChanged.AddListener(OnSoundVolumeValueChanged);
            m_Prop.UISoundMuteToggle.onValueChanged.AddListener(OnUISoundMuteValueChanged);
            m_Prop.UISoundVolumeSlider.onValueChanged.AddListener(OnUISoundVolumeValueChanged);
            m_Prop.LanguageDropdown.onValueChanged.AddListener(OnLanguageValueChanged);
        }

        public void SetLanguageOptions(string[] languageOptions)
        {
            List<TMP_Dropdown.OptionData> optionDataList = new List<TMP_Dropdown.OptionData>();
            for (int i = 0; i < languageOptions.Length; i++)
            {
                optionDataList.Add(new TMP_Dropdown.OptionData(languageOptions[i]));
            }

            m_Prop.LanguageDropdown.options = optionDataList;
        }

        public void SetMusicMuteValue(bool value)
        {
            m_Prop.MusicMuteToggle.isOn = value;
        }

        private void OnMusicMuteValueChanged(bool value)
        {
            MusicMuteValueChanged?.Invoke(value);
        }

        public void SetMusicVolumeValue(float value)
        {
            m_Prop.MusicVolumeSlider.value = value;
        }

        private void OnMusicVolumeValueChanged(float value)
        {
            MusicVolumeValueChanged?.Invoke(value);
        }

        public void SetSoundMuteValue(bool value)
        {
            m_Prop.SoundMuteToggle.isOn = value;
        }

        private void OnSoundMuteValueChanged(bool value)
        {
            SoundMuteValueChanged?.Invoke(value);
        }

        public void SetSoundVolumeValue(float value)
        {
            m_Prop.SoundVolumeSlider.value = value;
        }

        private void OnSoundVolumeValueChanged(float value)
        {
            SoundVolumeValueChanged?.Invoke(value);
        }

        public void SetUISoundMuteValue(bool value)
        {
            m_Prop.UISoundMuteToggle.isOn = value;
        }

        private void OnUISoundMuteValueChanged(bool value)
        {
            UISoundMuteValueChanged?.Invoke(value);
        }

        public void SetUISoundVolumeValue(float value)
        {
            m_Prop.UISoundVolumeSlider.value = value;
        }

        private void OnUISoundVolumeValueChanged(float value)
        {
            UISoundVolumeValueChanged?.Invoke(value);
        }

        public void SetLanguageValue(int value)
        {
            m_Prop.LanguageDropdown.value = value;
        }

        private void OnLanguageValueChanged(int value)
        {
            LanguageValueChanged?.Invoke(value);
        }

        public override void Deinit()
        {
            UIClickTrigger.Get(m_Prop.BackGameObject).onClick.RemoveListener(OnBackClick);
            m_Prop.MusicMuteToggle.onValueChanged.RemoveListener(OnMusicMuteValueChanged);
            m_Prop.MusicVolumeSlider.onValueChanged.RemoveListener(OnMusicVolumeValueChanged);
            m_Prop.SoundMuteToggle.onValueChanged.RemoveListener(OnSoundMuteValueChanged);
            m_Prop.SoundVolumeSlider.onValueChanged.RemoveListener(OnSoundVolumeValueChanged);
            m_Prop.UISoundMuteToggle.onValueChanged.RemoveListener(OnUISoundMuteValueChanged);
            m_Prop.UISoundVolumeSlider.onValueChanged.RemoveListener(OnUISoundVolumeValueChanged);
            m_Prop.LanguageDropdown.onValueChanged.RemoveListener(OnLanguageValueChanged);

            base.Deinit();
        }

        private void OnBackClick(GameObject go)
        {
            BackClicked?.Invoke();
        }
    }
}