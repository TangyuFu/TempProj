using System.Collections.Generic;
using GameFramework;
using GameFramework.Localization;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 本地化拓展。
    /// </summary>
    public static class LocalizationExtension
    {
        /// <summary>
        /// 获取默认语言，当系统不支持语言使用默认语言。
        /// </summary>
        /// <returns>获取到的默认语言。</returns>
        public const Language DefaultLanguage = Language.English; 
        
        /// <summary>
        /// 获取开发语言，游戏的开发使用语言。
        /// </summary>
        /// <returns>获取到的开发语言。</returns>
        public const Language DevelopLanguage = Language.ChineseSimplified;

        /// <summary>
        /// 获取支持的语言。
        /// </summary>
        public static readonly Language[] SupportLanguages =
        {
            Language.English,
            Language.ChineseSimplified,
            Language.ChineseTraditional,
            Language.Korean,
            Language.Japanese,
        };

        private static readonly Dictionary<Language, string> s_Variants = new Dictionary<Language, string>
        {
            {Language.English, "en"},
            {Language.Korean, "ko"},
            {Language.ChineseSimplified, "zh-CN"},
            {Language.ChineseTraditional, "zh-TW"},
            {Language.Japanese, "jp"},
        };

        /// <summary>
        /// 获取变体后缀。
        /// </summary>
        /// <param name="language">要获取的语言。</param>
        /// <returns>获取的变体后缀。</returns>
        public static string GetVariant(Language language)
        {
            return s_Variants.TryGetValue(language, out var variant) ? variant : string.Empty;
        }

        /// <summary>
        /// 获取变体路径。
        /// </summary>
        /// <param name="rawPath">原始路径。</param>
        /// <param name="language">变体语言。</param>
        /// <returns>获取的变体路径。</returns>
        public static string GetVariantPath(string rawPath, Language language)
        {
            if (string.IsNullOrEmpty(rawPath))
            {
                return rawPath;
            }

            if (!s_Variants.TryGetValue(language, out var suffix))
            {
                return rawPath;
            }

            int index = rawPath.LastIndexOf('.');
            return index == -1
                ? Utility.Text.Format("{0}_{1}", rawPath, suffix)
                : Utility.Text.Format("{0}_{1}{2}", rawPath.Substring(0, index), suffix, rawPath.Substring(index));
        }
    }
}