using GameFramework;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    public static partial class UUtility
    {
        /// <summary>
        /// Unity 游戏框架路径工具。
        /// </summary>
        public static class Path
        {
            /// <summary>
            /// 转化 Unity 项目路径为系统文件路径。
            /// </summary>
            /// <param name="projectPath">Unity 项目路径，如 Assets/Icon.png ProjectSettings/ProjectSettings.asset 。</param>
            /// <returns>转化后的系统文件路径。</returns>
            public static string Asset2SystemPath(string projectPath)
            {
                if (projectPath == null)
                {
                    throw new GameFrameworkException($"Invalid project path '{projectPath}'.");
                }

                projectPath = Utility.Path.GetRegularPath(projectPath);
                return Utility.Text.Format("{0}{1}",
                    Application.dataPath.Substring(0, Application.dataPath.Length - 6),
                    projectPath);
            }

            /// <summary>
            /// 转化系统文件路径为 Unity 项目路径。
            /// </summary>
            /// <param name="systemPath">系统文件路径。</param>
            /// <returns>转化后的 Unity 项目路径。</returns>
            public static string System2AssetPath(string systemPath)
            {
                if (string.IsNullOrEmpty(systemPath))
                {
                    throw new GameFrameworkException($"Invalid system path '{systemPath}'.");
                }

                systemPath = Utility.Path.GetRegularPath(systemPath);
                return systemPath.Substring(Application.dataPath.Length - 6);
            }
        }
    }
}