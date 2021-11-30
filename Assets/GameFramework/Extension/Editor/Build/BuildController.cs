using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityGameFramework.Runtime.Extension;

namespace UnityGameFramework.Editor.Extension.Build
{
    /// <summary>
    /// 构建控制器。
    /// </summary>
    public class BuildController : Singleton<BuildController>, IPreprocessBuildWithReport, IPostprocessBuildWithReport
    {
        private BuildData m_BuildData;

        public BuildController()
        {
        }

        public BuildData BuildData => m_BuildData;

        public void Refresh()
        {
            TextAsset buildDataTextAsset =
                AssetDatabase.LoadAssetAtPath<TextAsset>(BuildSettings.BuildDataPath);
            if (buildDataTextAsset == null || string.IsNullOrEmpty(buildDataTextAsset.text))
            {
                Debug.Log($"Failed to load build data from '{BuildSettings.BuildDataPath}'.");
                m_BuildData = new BuildData();
            }
            else
            {
                string buildDataText = buildDataTextAsset.text;
                try
                {
                    m_BuildData = JsonUtility.FromJson<BuildData>(buildDataText);
                    Debug.Log($"Succeeded to parse build data from '{BuildSettings.BuildDataPath}'.");
                }
                catch (Exception e)
                {
                    Debug.LogError(
                        $"Failed to parse build data from path '{BuildSettings.BuildDataPath}' with exception '{e}'.");
                }
            }
        }

        public void Clear()
        {
            try
            {
                File.Delete(UUtility.Path.Asset2SystemPath(BuildSettings.BuildDataPath));
                AssetDatabase.Refresh();
                Debug.Log($"Succeeded to clear build data from '{BuildSettings.BuildDataPath}'.");
            }
            catch (Exception e)
            {
                Debug.LogError(
                    $"Failed to clear build data from path '{BuildSettings.BuildDataPath}' with exception '{e}'.");
            }
            
            try
            {
                File.Delete(UUtility.Path.Asset2SystemPath(BuildSettings.BuildInfoPath));
                AssetDatabase.Refresh();
                Debug.Log($"Succeeded to clear build info data from '{BuildSettings.BuildInfoPath}'.");
            }
            catch (Exception e)
            {
                Debug.LogError(
                    $"Failed to clear build info data from '{BuildSettings.BuildInfoPath}' with exception '{e}'.");
            }
            
            try
            {
                File.Delete(UUtility.Path.Asset2SystemPath(BuildSettings.VersionInfoPath));
                AssetDatabase.Refresh();
                Debug.Log($"Succeeded to clear version info data from '{BuildSettings.VersionInfoPath}'.");
            }
            catch (Exception e)
            {
                Debug.LogError(
                    $"Failed to clear version info data from '{BuildSettings.VersionInfoPath}' with exception '{e}'.");
            }
        }

        public void Save()
        {
            try
            {
                string buildDataJson = JsonUtility.ToJson(m_BuildData, true);
                File.WriteAllText(UUtility.Path.Asset2SystemPath(BuildSettings.BuildDataPath), buildDataJson);
                Debug.Log($"Succeeded to save build data to '{BuildSettings.BuildDataPath}'.");
            }
            catch (Exception e)
            {
                Debug.LogError(
                    $"Failed to save build data to path '{BuildSettings.BuildDataPath}' with exception '{e}'.");
            }
            
            try
            {
                BuildInfo remoteBuildInfo = new BuildInfo
                {
                    Version = m_BuildData.Version,
                    Channel = m_BuildData.Channel,
                    Url = m_BuildData.Url,
                    WindowsAppUrl = m_BuildData.StandaloneWindowsAppUrl,
                    OSXAppUrl = m_BuildData.StandaloneOSXAppUrl,
                    AndroidAppUrl = m_BuildData.AndroidAppUrl,
                    IOSAppUrl = m_BuildData.iOSAppUrl,
                };
                
                string buildInfoJson = JsonUtility.ToJson(remoteBuildInfo, true);
                File.WriteAllText(UUtility.Path.Asset2SystemPath(BuildSettings.BuildInfoPath), buildInfoJson);
                Debug.Log($"Succeeded to save build info data to '{BuildSettings.BuildInfoPath}'.");
            }
            catch (Exception e)
            {
                Debug.LogError(
                    $"Failed to save build info data to path '{BuildSettings.BuildInfoPath}' with exception '{e}'.");
            }
                        
            try
            {
                VersionInfo versionInfo = new VersionInfo
                {
                    LatestVersion = m_BuildData.Version,
                    InternalVersion = m_BuildData.InternalVersion,
                    ResourceVersion = 0,
                    UpdateUrl = m_BuildData.Url,
                    VersionListLength = 0,
                    VersionListHashCode = 0,
                    VersionListCompressedLength = 0,
                    VersionListCompressedHashCode = 0,
                };
 
                string versionInfoJson = JsonUtility.ToJson(versionInfo, true);
                File.WriteAllText(UUtility.Path.Asset2SystemPath(BuildSettings.VersionInfoPath), versionInfoJson);
                Debug.Log($"Succeeded to save version inf data to '{BuildSettings.VersionInfoPath}'.");

            }
            catch (Exception e)
            {
                Debug.LogError(
                    $"Failed to save build data to path '{BuildSettings.VersionInfoPath}' with exception '{e}'.");
            }
            
            AssetDatabase.Refresh();
        }

        public void Build()
        {
            string output = GetBuildOutput();
            
            BuildOptions buildOptions = GetBuildOptions();
            string[] levels = EditorBuildSettings.scenes.Where(scene => scene.enabled).Select(scene => scene.path)
                .ToArray();
            if (levels.Length == 0)
            {
                Debug.LogError("Failed to find valid build scenes in build settings.");
                return;
            }

            PreprocessBuild();
            BuildReport buildReport = BuildPipeline.BuildPlayer(levels, output, m_BuildData.BuildTarget, buildOptions);
        }

        public string GetBuildOutput()
        {
            BuildTarget buildTarget = m_BuildData.BuildTarget;
            string name =
                $"{Application.identifier}_{m_BuildData.Version}_{(m_BuildData.Released ? "released" : "development")}";
            string outputFile = null;
            string platform = GetPlatformPath(buildTarget);
            switch (buildTarget)
            {
                case BuildTarget.StandaloneWindows:
                    outputFile = $"{m_BuildData.Output}/{platform}/{name}/{name}.exe";
                    break;

                case BuildTarget.StandaloneOSX:
                    outputFile = $"{m_BuildData.Output}/{platform}/{name}";
                    break;

                case BuildTarget.Android:
                    outputFile = $"{m_BuildData.Output}/{platform}/{name}.apk";
                    break;

                case BuildTarget.iOS:
                    outputFile = $"{m_BuildData.Output}/{platform}/{name}";
                    break;

                default:
                    Debug.LogError($"Unsupported build target '{buildTarget}'.");
                    break;
            }

            return outputFile;
        }

        public BuildOptions GetBuildOptions()
        {
            return m_BuildData.Released ? m_BuildData.ReleaseBuildOptions : m_BuildData.DevelopmentBuildOptions;
        }

        private void PreprocessBuild()
        {
            const string versionPattern = @"\A(\d+)\.(\d+)\.(\d+)\z";
            if (!Regex.Match(m_BuildData.Version, versionPattern).Success)
            {
                EditorUtility.DisplayDialog("Build Player",
                    $"Illegal game version '{m_BuildData.Version}' for pattern '{versionPattern}'.", "OK");
                return;
            }

            PlayerSettings.bundleVersion = m_BuildData.Version;
            PlayerSettings.Android.bundleVersionCode = m_BuildData.InternalVersion;
            PlayerSettings.iOS.buildNumber = m_BuildData.InternalVersion.ToString();

            PlayerSettings.Android.useCustomKeystore = true;
            PlayerSettings.Android.keystoreName = m_BuildData.KeystoreName;
            PlayerSettings.Android.keystorePass = m_BuildData.KeystorePass;
            PlayerSettings.Android.keyaliasName = m_BuildData.KeyaliasName;
            PlayerSettings.Android.keyaliasPass = m_BuildData.KeyaliasPass;
        }

        public int callbackOrder => -1;

        public void OnPostprocessBuild(BuildReport report)
        {
        }

        public void OnPreprocessBuild(BuildReport report)
        {
        }

        public string GetPlatformPath(BuildTarget buildTarget)
        {
            switch (buildTarget)
            {
                case BuildTarget.StandaloneWindows:
                    return "Windows";

                case BuildTarget.StandaloneOSX:
                    return "MacOS";

                case BuildTarget.Android:
                    return "IOS";

                case BuildTarget.iOS:
                    return "Android";

                default:
                    Debug.LogError($"Unsupported build target '{buildTarget}'.");
                    return null;
            }
        }

        private static void BuildAndroidRelease()
        {
            BuildController buildController = new BuildController();
            buildController.Refresh();
            buildController.BuildData.BuildTarget = BuildTarget.Android;
            buildController.BuildData.Released = true;
            buildController.Build();
        }

        private static void BuildAndroidDevelopment()
        {
            BuildController buildController = new BuildController();
            buildController.Refresh();
            buildController.BuildData.BuildTarget = BuildTarget.Android;
            buildController.BuildData.Released = false;
            buildController.Build();
        }

        private static void BuildIOSRelease()
        {
            BuildController buildController = new BuildController();
            buildController.Refresh();
            buildController.BuildData.BuildTarget = BuildTarget.iOS;
            buildController.BuildData.Released = true;
            buildController.Build();
        }

        private static void BuildIOSDevelopment()
        {
            BuildController buildController = new BuildController();
            buildController.Refresh();
            buildController.BuildData.BuildTarget = BuildTarget.iOS;
            buildController.BuildData.Released = false;
            buildController.Build();
        }

        private static void BuildWindowsRelease()
        {
            BuildController buildController = new BuildController();
            buildController.Refresh();
            buildController.BuildData.BuildTarget = BuildTarget.StandaloneWindows;
            buildController.BuildData.Released = true;
            buildController.Build();
        }
        
        private static void BuildWindowsDevelopment()
        {
            BuildController buildController = new BuildController();
            buildController.Refresh();
            buildController.BuildData.BuildTarget = BuildTarget.StandaloneWindows;
            buildController.BuildData.Released = false;
            buildController.Build();
        }
        
        private static void BuildOSXRelease()
        {
            BuildController buildController = new BuildController();
            buildController.Refresh();
            buildController.BuildData.BuildTarget = BuildTarget.StandaloneOSX;
            buildController.BuildData.Released = true;
            buildController.Build();
        }

        private static void BuildOSXDevelopment()
        {
            BuildController buildController = new BuildController();
            buildController.Refresh();
            buildController.BuildData.BuildTarget = BuildTarget.StandaloneOSX;
            buildController.BuildData.Released = true;
            buildController.Build();
        }

    }
}