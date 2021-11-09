using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    public class SettingProp : MVCProp
    {
        public GameObject BackGameObject;
        public Toggle MusicMuteToggle;
        public Slider MusicVolumeSlider;
        public Toggle SoundMuteToggle;
        public Slider SoundVolumeSlider;
        public Toggle UISoundMuteToggle;
        public Slider UISoundVolumeSlider;
        public TMP_Dropdown LanguageDropdown;
    }
}