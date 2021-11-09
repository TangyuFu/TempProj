using System.IO;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityGameFramework.Runtime.Extension;

namespace UnityGameFramework.Editor.Extension
{
    /// <summary>
    /// 打开操作菜单。
    /// </summary>
    public static class Shortcut
    {
        private const string s_LauncherScenePath = "Assets/Settings/Launcher.unity";

        [MenuItem("Game Framework/Extension/Shortcut/Open Launcher", true, 1)]
        private static bool OpenLauncherValidate()
        {
            if (EditorApplication.isPlaying || EditorApplication.isCompiling || EditorApplication.isUpdating)
            {
                return false;
            }

            return EditorSceneManager.loadedSceneCount != 1 ||
                   SceneManager.GetActiveScene().path != s_LauncherScenePath;
        }

        /// <summary>
        /// 打开启动页场景。
        /// </summary>
        [MenuItem("Game Framework/Extension/Shortcut/Open Launcher", false, 1)]
        private static void OpenLauncher()
        {
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                EditorSceneManager.OpenScene(s_LauncherScenePath, OpenSceneMode.Single);
            }
        }

        [MenuItem("Game Framework/Extension/Shortcut/Clear Settings", true, 12)]
        private static bool ClearSettingsValidate()
        {
            if (EditorApplication.isPlaying || EditorApplication.isCompiling || EditorApplication.isUpdating)
            {
                return false;
            }

            return ES3.FileExists();
        }

        /// <summary>
        /// 清除设置文件。
        /// </summary>
        [MenuItem("Game Framework/Extension/Shortcut/Clear Settings", false, 12)]
        private static void ClearSettings()
        {
            ES3.DeleteFile();
        }

        private const string EXPORT_TABLE_SCRIPT_PATH = "Assets/R/TableProj/exporter.py";

        [MenuItem("Game Framework/Extension/Shortcut/Export Tables", true, 23)]
        private static bool ExportTablesValidate()
        {
            if (EditorApplication.isPlaying || EditorApplication.isCompiling || EditorApplication.isUpdating)
            {
                return false;
            }

            return File.Exists(UUtility.Path.Asset2SystemPath(EXPORT_TABLE_SCRIPT_PATH));
        }

        /// <summary>
        /// 导出数据表。
        /// </summary>
        [MenuItem("Game Framework/Extension/Shortcut/Export Tables", false, 23)]
        private static void ExportTables()
        {
            const int timeout = 30000;
            FileInfo fileInfo = new FileInfo(UUtility.Path.Asset2SystemPath(EXPORT_TABLE_SCRIPT_PATH));
            Task.Run(async () =>
            {
                UUtility.Process.ProcessResult result =
                    await UUtility.Process.ExecuteCommandAsync(fileInfo.Directory?.FullName,
                        new[] {$"python {fileInfo.Name}"}, timeout);
                Debug.Log(
                    $"Export tables completed, exit code: '{result.ExitCode}', error: '{result.Error}', output:\n'{result.Output}'");
            });
            AssetDatabase.Refresh();
        }

        private static readonly string[] s_GitPullScriptPaths =
        {
            "git-pull.py",
            "TsProj/git-push.py",
            "Assets/R/EffectProj/git-push.py",
            "Assets/R/ModelProj/git-push.py",
            "Assets/R/TableProj/git-push.py",
            "Assets/R/UIProj/git-push.py"
        };

        /// <summary>
        /// 更新所有仓库。
        /// </summary>
        [MenuItem("Game Framework/Extension/Shortcut/Update All Repo", false, 34)]
        private static void UpdateAllRepo()
        {
            if (EditorUtility.DisplayDialog("Pull All Repo",
                "Include TsProj, EffectProj, ModelProj, TableProj, UIProj.", "Ok", "Cancel"))
            {
                foreach (var scriptPath in s_GitPullScriptPaths)
                {
                    const int timeout = 60000;
                    FileInfo fileInfo = new FileInfo(UUtility.Path.Asset2SystemPath(scriptPath));
                    string dirPath = fileInfo.Directory?.FullName;
                    UUtility.Process.ProcessResult result =
                        UUtility.Process.ExecuteCommand(dirPath, new[] {$"python {fileInfo.Name}"}, timeout);
                    Debug.Log(
                        $"Pull repo {dirPath} completed, exit code: '{result.ExitCode}', error: '{result.Error}', output:\n'{result.Output}'");
                }

                AssetDatabase.Refresh();
            }
        }

        private static readonly string[] s_GitPushScriptPaths =
        {
            "git-push.py",
            "TsProj/git-push.py",
            "Assets/R/EffectProj/git-push.py",
            "Assets/R/ModelProj/git-push.py",
            "Assets/R/TableProj/git-push.py",
            "Assets/R/UIProj/git-push.py"
        };

        /// <summary>
        /// 提交所有仓库。
        /// </summary>
        [MenuItem("Game Framework/Extension/Shortcut/Push All Repo", false, 45)]
        private static void PushAllRepo()
        {
            if (EditorUtility.DisplayDialog("Push All Repo",
                "Include TsProj, EffectProj, ModelProj, TableProj, UIProj.", "Ok", "Cancel"))
            {
                foreach (var scriptPath in s_GitPushScriptPaths)
                {
                    const int timeout = 60000;
                    FileInfo fileInfo = new FileInfo(UUtility.Path.Asset2SystemPath(scriptPath));
                    string dirPath = fileInfo.Directory?.FullName;
                    UUtility.Process.ProcessResult result =
                        UUtility.Process.ExecuteCommand(dirPath, new[] {$"python {fileInfo.Name}"}, timeout);
                    Debug.Log(
                        $"Push repo {dirPath} completed, exit code: '{result.ExitCode}', error: '{result.Error}', output:\n'{result.Output}'");
                }

                AssetDatabase.Refresh();
            }
        }
    }
}