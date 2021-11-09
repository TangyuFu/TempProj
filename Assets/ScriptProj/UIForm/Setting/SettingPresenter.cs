using System;
using GameFramework.Localization;
using GameFramework.Runtime.Extension;
using UnityEngine;
using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    [Identity((int) UIFormId.SettingForm)]
    public class SettingPresenter : UIFormPresenter<SettingView, SettingProp>
    {
        private string[] m_LanguageOptions = {"简体中文", "繁體中文", "English", "日本語", "한국어"};

        private Language[] m_Languages =
        {
            Language.ChineseSimplified, Language.ChineseTraditional, Language.English, Language.Japanese,
            Language.Korean
        };

        private int m_LanguageValue = -1;

        private LocalDataAgent m_LocalDataAgent;

        public override void OnInit(GameObject target, object userData)
        {
            base.OnInit(target, userData);

            m_View.BackClicked = CloseSelf;
            m_View.MusicMuteValueChanged = OnMusicMuteValueChanged;
            m_View.MusicVolumeValueChanged = OnMusicVolumeValueChanged;
            m_View.SoundMuteValueChanged = OnSoundMuteValueChanged;
            m_View.SoundVolumeValueChanged = OnSoundVolumeValueChanged;
            m_View.UISoundMuteValueChanged = OnUISoundMuteValueChanged;
            m_View.UISoundVolumeValueChanged = OnUISoundVolumeValueChanged;
            m_View.LanguageValueChanged = OnLanguageValueChanged;
            m_View.SetLanguageOptions(m_LanguageOptions);

            m_LocalDataAgent = Entry.PlayerData.GetDataAgent<LocalDataAgent>();
        }

        public override void OnDeinit()
        {
            base.OnDeinit();
        }

        public override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            m_View.SetMusicMuteValue(!m_LocalDataAgent.MusicMuted);
            m_View.SetMusicVolumeValue(m_LocalDataAgent.MusicVolume);
            m_View.SetSoundMuteValue(!m_LocalDataAgent.SoundMuted);
            m_View.SetSoundVolumeValue(m_LocalDataAgent.SoundVolume);
            m_View.SetUISoundMuteValue(!m_LocalDataAgent.UISoundMuted);
            m_View.SetUISoundVolumeValue(m_LocalDataAgent.UISoundVolume);

            m_LanguageValue = Array.FindIndex(m_Languages, language => m_LocalDataAgent.Language == language);
            if (m_LanguageValue == -1)
            {
                m_LanguageValue = 0;
            }

            m_View.SetLanguageValue(m_LanguageValue);
        }

        public override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
        }

        private void OnMusicMuteValueChanged(bool value)
        {
            if (m_LocalDataAgent.MusicMuted != !value)
            {
                Entry.Sound.SetMusicMute(!value);
            }
        }

        private void OnMusicVolumeValueChanged(float value)
        {
            if (m_LocalDataAgent.MusicVolume != value)
            {
                Entry.Sound.SetMusicVolume(value);
            }
        }

        private void OnSoundMuteValueChanged(bool value)
        {
            if (m_LocalDataAgent.SoundMuted != !value)
            {
                Entry.Sound.SetSoundMute(!value);
            }
        }

        private void OnSoundVolumeValueChanged(float value)
        {
            if (m_LocalDataAgent.SoundVolume != value)
            {
                Entry.Sound.SetSoundVolume(value);
            }
        }

        private void OnUISoundMuteValueChanged(bool value)
        {
            if (m_LocalDataAgent.UISoundMuted != !value)
            {
                Entry.Sound.SetUISoundMute(!value);
            }
        }

        private void OnUISoundVolumeValueChanged(float value)
        {
            if (m_LocalDataAgent.UISoundVolume != value)
            {
                Entry.Sound.SetUISoundVolume(value);
            }
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

        private void CloseSelf()
        {
            Entry.UI.CloseUIForm(UIFormId.SettingForm);
        }
    }
}