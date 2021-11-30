using GameFramework.DataTable;
using GameFramework.Sound;
using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;
using TempProj.DataTable;

namespace GameFramework.Runtime.Extension
{
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

        public static int? PlayMusic(this SoundComponent soundComponent, int musicId, object userData = null)
        {
            soundComponent.StopMusic();

            IDataTable<DRMusic> dtMusic = Entry.DataTable.GetDataTable<DRMusic>();
            DRMusic drMusic = dtMusic.GetDataRow(musicId);
            if (drMusic == null)
            {
                Log.Warning("Can not load music '{0}' from data table.", musicId.ToString());
                return null;
            }

            PlaySoundParams playSoundParams = PlaySoundParams.Create();
            playSoundParams.Priority = 64;
            playSoundParams.Loop = true;
            playSoundParams.VolumeInSoundGroup = 1f;
            playSoundParams.FadeInSeconds = FadeVolumeDuration;
            playSoundParams.SpatialBlend = 0f;
            s_MusicSerialId = soundComponent.PlaySound(UUtility.Asset.GetMusicPath(drMusic.AssetName), c_MusicGroupName,
                Constant.AssetPriority.MusicAsset, playSoundParams, null, userData);
            return s_MusicSerialId;
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

        public static int? PlaySound(this SoundComponent soundComponent, int soundId,
            UnityGameFramework.Runtime.Extension.CustomEntityLogic bindingCustomEntityLogic = null,
            object userData = null)
        {
            IDataTable<DRSound> dtSound = Entry.DataTable.GetDataTable<DRSound>();
            DRSound drSound = dtSound.GetDataRow(soundId);
            if (drSound == null)
            {
                Log.Warning("Can not load sound '{0}' from data table.", soundId.ToString());
                return null;
            }

            PlaySoundParams playSoundParams = PlaySoundParams.Create();
            playSoundParams.Priority = drSound.Priority;
            playSoundParams.Loop = drSound.Loop;
            playSoundParams.VolumeInSoundGroup = drSound.Volume;
            playSoundParams.SpatialBlend = drSound.SpatialBlend;
            return soundComponent.PlaySound(UUtility.Asset.GetSoundPath(drSound.AssetName), "Sound",
                Constant.AssetPriority.SoundAsset, playSoundParams,
                bindingCustomEntityLogic != null ? bindingCustomEntityLogic.Entity : null,
                userData);
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

        public static int? PlayUISound(this SoundComponent soundComponent, int uiSoundId, object userData = null)
        {
            IDataTable<DRUISound> dtUISound = Entry.DataTable.GetDataTable<DRUISound>();
            DRUISound drUISound = dtUISound.GetDataRow(uiSoundId);
            if (drUISound == null)
            {
                Log.Warning("Can not load UI sound '{0}' from data table.", uiSoundId.ToString());
                return null;
            }

            PlaySoundParams playSoundParams = PlaySoundParams.Create();
            playSoundParams.Priority = drUISound.Priority;
            playSoundParams.Loop = false;
            playSoundParams.VolumeInSoundGroup = drUISound.Volume;
            playSoundParams.SpatialBlend = 0f;
            return soundComponent.PlaySound(UUtility.Asset.GetUISoundPath(drUISound.AssetName), "UISound",
                Constant.AssetPriority.UISoundAsset, playSoundParams, userData);
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