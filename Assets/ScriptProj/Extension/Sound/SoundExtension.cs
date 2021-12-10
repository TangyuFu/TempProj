using GameFramework.DataTable;
using GameFramework.Runtime.Extension;
using GameFramework.Sound;
using TempProj.DataTable;
using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    public static class SoundExtension
    {
        private const string c_MusicGroupName = "Music";
        private const string c_SoundGroupName = "Sound";
        private const string c_UISoundGroupName = "UISound";

        private const float FadeVolumeDuration = 1f;
        private static int? s_MusicSerialId = null;

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
    }
}