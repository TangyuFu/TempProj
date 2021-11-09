using GameFramework.Localization;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 本地数据。
    /// </summary>
    public sealed class LocalData : PlayerData
    {
        /// <summary>
        /// 语言。
        /// </summary>
        public Language Language = Language.Unspecified;

        /// <summary>
        /// 背景音乐状态。
        /// </summary>
        public bool MusicMuted = false;

        /// <summary>
        /// 背景音乐音量。
        /// </summary>
        public float MusicVolume = 1f;

        /// <summary>
        /// 3D 声效状态。
        /// </summary>
        public bool SoundMuted = false;

        /// <summary>
        /// 3D 声效音量。
        /// </summary>
        public float SoundVolume = 1f;

        /// <summary>
        /// UI 声效状态。
        /// </summary>
        public bool UISoundMuted = false;

        /// <summary>
        /// UI 声效音量。
        /// </summary>
        public float UISoundVolume = 1f;
    }
}