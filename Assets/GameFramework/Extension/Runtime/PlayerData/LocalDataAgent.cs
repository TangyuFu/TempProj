using GameFramework.Localization;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 本地数据代理。
    /// </summary>
    public sealed class LocalDataAgent : PlayerDataAgent<LocalData>
    {
        public override bool Local { get; } = true;
        protected override LocalData DefaultData { get; } = new LocalData();

        /// <summary>
        /// 语言。
        /// </summary>
        public Language Language
        {
            get => Data.Language;
            set => Data.Language = value;
        }

        /// <summary>
        /// 背景音乐状态。
        /// </summary>
        public bool MusicMuted
        {
            get => Data.MusicMuted;
            set => Data.MusicMuted = value;
        }

        /// <summary>
        /// 背景音乐音量。
        /// </summary>
        public float MusicVolume
        {
            get => Data.MusicVolume;
            set => Data.MusicVolume = value;
        }

        /// <summary>
        /// 3D 声效状态。
        /// </summary>
        public bool SoundMuted
        {
            get => Data.SoundMuted;
            set => Data.SoundMuted = value;
        }


        /// <summary>
        /// 3D 声效音量。
        /// </summary>
        public float SoundVolume
        {
            get => Data.SoundVolume;
            set => Data.SoundVolume = value;
        }

        /// <summary>
        /// UI 声效状态。
        /// </summary>
        public bool UISoundMuted
        {
            get => Data.UISoundMuted;
            set => Data.UISoundMuted = value;
        }

        /// <summary>
        /// UI 声效音量。
        /// </summary>
        public float UISoundVolume
        {
            get => Data.UISoundVolume;
            set => Data.UISoundVolume = value;
        }
    }
}