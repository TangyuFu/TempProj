using GameFramework.Sound;
using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;

namespace GameFramework.Runtime.Extension
{
    /// <summary>
    /// 声音拓展。
    /// </summary>
    public static class SoundExtension
    {
        private const string c_MusicGroupName = "Music";
        private const string c_SoundGroupName = "Sound";
        private const string c_UISoundGroupName = "UISound";

        private const float FadeVolumeDuration = 1f;
        private static int? s_MusicSerialId = null;

        private static LocalDataAgent s_LocalDataAgent;

        private static LocalDataAgent LocalDataAgent
        {
            get { return s_LocalDataAgent ??= Entry.PlayerData.GetDataAgent<LocalDataAgent>(); }
        }

        public static bool GetMusicMute(this SoundComponent soundComponent)
        {
            return LocalDataAgent.MusicMuted;
        }

        public static void SetMusicMute(this SoundComponent soundComponent, bool mute)
        {
            soundComponent.Mute(c_MusicGroupName, mute);
            LocalDataAgent.MusicMuted = mute;
        }

        public static float GetMusicVolume(this SoundComponent soundComponent)
        {
            return LocalDataAgent.MusicVolume;
        }

        public static void SetMusicVolume(this SoundComponent soundComponent, float volume)
        {
            soundComponent.SetVolume(c_MusicGroupName, volume);
            LocalDataAgent.MusicVolume = volume;
        }

        public static void StopMusic(this SoundComponent soundComponent)
        {
            if (!s_MusicSerialId.HasValue)
            {
                return;
            }

            soundComponent.StopSound(s_MusicSerialId.Value, FadeVolumeDuration);
            s_MusicSerialId = null;
        }

        public static bool GetSoundMute(this SoundComponent soundComponent)
        {
            return LocalDataAgent.SoundMuted;
        }

        public static void SetSoundMute(this SoundComponent soundComponent, bool mute)
        {
            soundComponent.Mute(c_SoundGroupName, mute);
            LocalDataAgent.SoundMuted = mute;
        }

        public static void SetSoundVolume(this SoundComponent soundComponent, float volume)
        {
            soundComponent.SetVolume(c_SoundGroupName, volume);
            LocalDataAgent.SoundVolume = volume;
        }

        public static float GetSoundVolume(this SoundComponent soundComponent)
        {
            return LocalDataAgent.SoundVolume;
        }

        public static bool GetUISoundMute(this SoundComponent soundComponent)
        {
            return LocalDataAgent.UISoundMuted;
        }

        public static void SetUISoundMute(this SoundComponent soundComponent, bool mute)
        {
            soundComponent.Mute(c_UISoundGroupName, mute);
            LocalDataAgent.UISoundMuted = mute;
        }

        public static void SetUISoundVolume(this SoundComponent soundComponent, float volume)
        {
            soundComponent.SetVolume(c_UISoundGroupName, volume);
            LocalDataAgent.UISoundVolume = volume;
        }

        public static float GetUISoundVolume(this SoundComponent soundComponent)
        {
            return LocalDataAgent.UISoundVolume;
        }

        private static bool IsMuted(this SoundComponent soundComponent, string soundGroupName)
        {
            if (string.IsNullOrEmpty(soundGroupName))
            {
                Log.Warning("Sound group is invalid.");
                return true;
            }

            ISoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);
            if (soundGroup == null)
            {
                Log.Warning("Sound group '{0}' is invalid.", soundGroupName);
                return true;
            }

            return soundGroup.Mute;
        }

        private static void Mute(this SoundComponent soundComponent, string soundGroupName, bool mute)
        {
            if (string.IsNullOrEmpty(soundGroupName))
            {
                Log.Warning("Sound group is invalid.");
                return;
            }

            ISoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);
            if (soundGroup == null)
            {
                Log.Warning("Sound group '{0}' is invalid.", soundGroupName);
                return;
            }

            soundGroup.Mute = mute;
        }

        private static float GetVolume(this SoundComponent soundComponent, string soundGroupName)
        {
            if (string.IsNullOrEmpty(soundGroupName))
            {
                Log.Warning("Sound group is invalid.");
                return 0f;
            }

            ISoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);
            if (soundGroup == null)
            {
                Log.Warning("Sound group '{0}' is invalid.", soundGroupName);
                return 0f;
            }

            return soundGroup.Volume;
        }

        private static void SetVolume(this SoundComponent soundComponent, string soundGroupName, float volume)
        {
            if (string.IsNullOrEmpty(soundGroupName))
            {
                Log.Warning("Sound group is invalid.");
                return;
            }

            ISoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);
            if (soundGroup == null)
            {
                Log.Warning("Sound group '{0}' is invalid.", soundGroupName);
                return;
            }

            soundGroup.Volume = volume;
        }
    }
}