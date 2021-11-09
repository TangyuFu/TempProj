using System;
using UnityEditor;

namespace UnityGameFramework.Editor.Extension.Build
{
    /// <summary>
    /// 构建数据。
    /// </summary>
    [Serializable]
    public class BuildData
    {
        public string Version = "0.0.1";
        public int InternalVersion = 1;
        public string Channel = "Default";
        public int ResourceVersion = 1;
        public string Url = "http://10.5.20.52:8080/HFS_Root/";
        public string VersionUrl = null;
        public string ResourceUrl = null;
        public string StandaloneWindowsAppUrl = "https://gameframework.cn";
        public string StandaloneOSXAppUrl = "https://gameframework.cn";
        public string iOSAppUrl = "https://gameframework.cn";
        public string AndroidAppUrl = "https://gameframework.cn";

        public BuildTarget BuildTarget = BuildTarget.StandaloneWindows;
        public bool Released = false;
        public string KeystoreName = "Assets/GameFramework/Extension/Editor/Build/user.keystore";
        public string KeystorePass = "keystore";
        public string KeyaliasName = "keystore";
        public string KeyaliasPass = "keystore";

        public string Output = "Build/Player";

        public BuildOptions DevelopmentBuildOptions = BuildOptions.Development |
                                                      BuildOptions.ConnectWithProfiler |
                                                      BuildOptions.AllowDebugging |
                                                      BuildOptions.ConnectToHost |
                                                      BuildOptions.StrictMode;

        public BuildOptions ReleaseBuildOptions = BuildOptions.CompressWithLz4HC | BuildOptions.StrictMode;
    }
}