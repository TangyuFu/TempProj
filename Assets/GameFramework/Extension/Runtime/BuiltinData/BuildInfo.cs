namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 构建信息。
    /// </summary>
    public class BuildInfo
    {
        /// <summary>
        /// 游戏版本。
        /// </summary>
        public string Version;

        /// <summary>
        /// 渠道号。
        /// </summary>
        public string Channel;

        /// <summary>
        /// 远程 CDN Url。
        /// </summary>
        public string Url;

        /// <summary>
        /// Windows 更新 Url。
        /// </summary>
        public string WindowsAppUrl;

        /// <summary>
        /// MacOS 更新 Url。
        /// </summary>
        public string OSXAppUrl;

        /// <summary>
        /// iOS 更新 Url。
        /// </summary>
        public string IOSAppUrl;

        /// <summary>
        /// Android 更新 Url。
        /// </summary>
        public string AndroidAppUrl;
    }
}