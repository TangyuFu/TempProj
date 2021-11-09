namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 远程版本信息。
    /// </summary>
    public class VersionInfo
    {
        // 最新的游戏版本号
        public string LatestVersion;

        // 最新的游戏内部版本号
        public int InternalVersion;

        // 最新的资源内部版本号
        public int ResourceVersion;

        // 资源更新下载地址
        public string UpdateUrl;

        // 资源版本列表长度
        public int VersionListLength;

        // 资源版本列表哈希值
        public int VersionListHashCode;

        // 资源版本列表压缩后长度
        public int VersionListCompressedLength;

        // 资源版本列表压缩后哈希值
        public int VersionListCompressedHashCode;
    }
}