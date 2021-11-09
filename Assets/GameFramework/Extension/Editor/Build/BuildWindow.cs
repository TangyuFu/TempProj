using UnityEditor;
using UnityEngine;

namespace UnityGameFramework.Editor.Extension.Build
{
    public sealed class BuildWindow : EditorWindow
    {
        [MenuItem("Game Framework/Extension/Build", true, 500)]
        private static bool OpenValidate()
        {
            if (EditorApplication.isPlaying || EditorApplication.isCompiling || EditorApplication.isUpdating)
            {
                return false;
            }

            return true;
        }

        [MenuItem("Game Framework/Extension/Build", false, 500)]
        private static void Open()
        {
            GetWindow<BuildWindow>("Build").position
                = new Rect(0, 0,
                    Screen.currentResolution.width * 0.5f,
                    Screen.currentResolution.height * 0.95f);
        }

        private void OnEnable()
        {
            BuildController.Instance.Refresh();
        }

        private void OnDisable()
        {
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical();
            {
                EditorGUILayout.LabelField("Environment Information", EditorStyles.boldLabel);
                EditorGUILayout.BeginVertical("box");
                {
                    DrawEnvironmentView();
                }
                EditorGUILayout.EndVertical();

                EditorGUILayout.LabelField("Build Target", EditorStyles.boldLabel);
                EditorGUILayout.BeginVertical("box");
                {
                    DrawBuildTargetView();
                }
                EditorGUILayout.EndVertical();

                EditorGUILayout.LabelField("Build Options", EditorStyles.boldLabel);
                EditorGUILayout.BeginHorizontal("box");
                {
                    DrawBuildOptionsView();
                }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.LabelField("Build", EditorStyles.boldLabel);
                EditorGUILayout.BeginVertical("box");
                {
                    DrawBuildView();
                }
                EditorGUILayout.EndVertical();

                EditorGUILayout.BeginHorizontal();
                {
                    DrawActionView();
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
        }

        private void DrawEnvironmentView()
        {
            EditorGUILayout.LabelField("Product Name", Application.productName);
            EditorGUILayout.LabelField("Company Name", Application.companyName);
            EditorGUILayout.LabelField("Game Identifier", Application.identifier);
            EditorGUILayout.LabelField("Unity Version", Application.unityVersion);
        }

        private void DrawBuildTargetView()
        {
            BuildTarget buildTarget = BuildController.Instance.BuildData.BuildTarget;
            buildTarget = (BuildTarget) EditorGUILayout.EnumPopup("Build Target", buildTarget);
            BuildController.Instance.BuildData.BuildTarget = buildTarget;
        }

        private void DrawBuildOptionsView()
        {
            BuildData buildData = BuildController.Instance.BuildData;

            bool released = buildData.Released;
            released = EditorGUILayout.Toggle("Released", released);
            buildData.Released = released;

            BuildOptions buildOptions = BuildController.Instance.GetBuildOptions();
            EditorGUILayout.EnumFlagsField("Build Options", buildOptions);
        }

        private void DrawBuildView()
        {
            BuildData buildData = BuildController.Instance.BuildData;

            string version = buildData.Version;
            version = EditorGUILayout.TextField("Version", version);
            buildData.Version = version;

            int internalVersion = buildData.InternalVersion;
            internalVersion = EditorGUILayout.IntField("Internal Version", internalVersion);
            buildData.InternalVersion = internalVersion;

            int resourceVersion = buildData.ResourceVersion;
            resourceVersion = EditorGUILayout.IntField("Resource Version", resourceVersion);
            buildData.ResourceVersion = resourceVersion;

            string channel = buildData.Channel;
            channel = EditorGUILayout.TextField("Channel", channel);
            buildData.Channel = channel;

            string url = buildData.Url;
            url = EditorGUILayout.TextField("Url", url);
            buildData.Url = url;

            string platformPath = BuildController.Instance.GetPlatformPath(buildData.BuildTarget);
            string versionUrl = $"{url}Version_{platformPath}_{buildData.Channel}.txt";
            buildData.VersionUrl = versionUrl;
            EditorGUILayout.TextField("Version Url", versionUrl);

            string resourceUrl =
                $"{url}{platformPath}/{buildData.Version.Replace('.', '_')}_{buildData.ResourceVersion}/";
            buildData.ResourceUrl = resourceUrl;
            EditorGUILayout.TextField("Resource Url", resourceUrl);

            string standaloneWindowsAppUrl = buildData.StandaloneWindowsAppUrl;
            standaloneWindowsAppUrl = EditorGUILayout.TextField($"Windows App Url", standaloneWindowsAppUrl);
            buildData.StandaloneWindowsAppUrl = standaloneWindowsAppUrl;

            string standaloneOSXAppUrl = buildData.StandaloneOSXAppUrl;
            standaloneOSXAppUrl = EditorGUILayout.TextField("OSX App Url", standaloneOSXAppUrl);
            buildData.StandaloneWindowsAppUrl = standaloneOSXAppUrl;

            string iOSAppUrl = buildData.iOSAppUrl;
            iOSAppUrl = EditorGUILayout.TextField("iOS App Url", iOSAppUrl);
            buildData.iOSAppUrl = iOSAppUrl;

            string androidAppUrl = buildData.AndroidAppUrl;
            androidAppUrl = EditorGUILayout.TextField("Android App Url", androidAppUrl);
            buildData.AndroidAppUrl = androidAppUrl;

            EditorGUILayout.LabelField("Output", buildData.Output);
        }

        private void DrawActionView()
        {
            if (GUILayout.Button("Refresh"))
            {
                BuildController.Instance.Refresh();
            }

            EditorGUILayout.Space();
            if (GUILayout.Button("Clear"))
            {
                BuildController.Instance.Clear();
            }

            if (GUILayout.Button("Save"))
            {
                BuildController.Instance.Save();
            }

            EditorGUILayout.Space();
            if (GUILayout.Button("Build"))
            {
                BuildController.Instance.Build();
            }
        }
    }
}