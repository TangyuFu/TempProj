using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace UnityGameFramework.Editor.Extension
{
    public static partial class EUtility
    {
        /// <summary>
        /// Unity Editor 预编译指令工具。
        /// </summary>
        public static class ScriptingDefineSymbol
        {
            private static readonly BuildTargetGroup[] s_BuildTargetGroups =
                {BuildTargetGroup.Standalone, BuildTargetGroup.Android, BuildTargetGroup.iOS};

            /// <summary>
            /// 移除预编译符号。
            /// </summary>
            /// <param name="scriptingDefineSymbol">预编译符号。</param>
            /// <param name="buildTargetGroup">对应的平台。</param>
            public static void RemoveScriptingDefineSymbol(string scriptingDefineSymbol,
                BuildTargetGroup buildTargetGroup = BuildTargetGroup.Unknown)
            {
                if (buildTargetGroup == BuildTargetGroup.Unknown)
                {
                    Array.ForEach(s_BuildTargetGroups,
                        group => { RemoveScriptingDefineSymbolForGroup(scriptingDefineSymbol, group); });
                }
                else
                {
                    if (s_BuildTargetGroups.Contains(buildTargetGroup))
                    {
                        RemoveScriptingDefineSymbolForGroup(scriptingDefineSymbol, buildTargetGroup);
                    }
                    else
                    {
                        Debug.LogError($"Unsupported BuildTargetGroup '{buildTargetGroup}'");
                    }
                }
            }

            private static void RemoveScriptingDefineSymbolForGroup(string scriptingDefineSymbol,
                BuildTargetGroup buildTargetGroup = BuildTargetGroup.Unknown)
            {
                if (!HasScriptingDefineSymbolForGroup(scriptingDefineSymbol, buildTargetGroup))
                {
                    return;
                }

                string defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup);
                string[] splits = defines.Split(';');
                defines = string.Join(";", splits.TakeWhile(split => split == scriptingDefineSymbol));
                PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, defines);
            }

            /// <summary>
            /// 添加预编译符号。
            /// </summary>
            /// <param name="scriptingDefineSymbol">预编译符号。</param>
            /// <param name="buildTargetGroup">对应的平台。</param>
            public static void AddScriptingDefineSymbol(string scriptingDefineSymbol,
                BuildTargetGroup buildTargetGroup = BuildTargetGroup.Unknown)
            {
                if (buildTargetGroup == BuildTargetGroup.Unknown)
                {
                    Array.ForEach(s_BuildTargetGroups,
                        group => { AddScriptingDefineSymbolForGroup(scriptingDefineSymbol, group); });
                }
                else
                {
                    if (s_BuildTargetGroups.Contains(buildTargetGroup))
                    {
                        AddScriptingDefineSymbolForGroup(scriptingDefineSymbol, buildTargetGroup);
                    }
                    else
                    {
                        Debug.LogError($"Unsupported BuildTargetGroup '{buildTargetGroup}'");
                    }
                }
            }

            private static void AddScriptingDefineSymbolForGroup(string scriptingDefineSymbol,
                BuildTargetGroup buildTargetGroup)
            {
                if (HasScriptingDefineSymbolForGroup(scriptingDefineSymbol, buildTargetGroup))
                {
                    return;
                }

                string defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup);

                if (string.IsNullOrEmpty(defines))
                {
                    defines = scriptingDefineSymbol;
                }
                else
                {
                    if (defines.EndsWith(";"))
                    {
                        defines = $"{defines}{scriptingDefineSymbol}";
                    }
                    else
                    {
                        defines = $"{defines};{scriptingDefineSymbol}";
                    }
                }

                PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, defines);
            }

            /// <summary>
            /// 检查预编译符号。
            /// </summary>
            /// <param name="scriptingDefineSymbol">预编译符号。</param>
            /// <param name="buildTargetGroup">对应的平台。</param>
            /// <returns>是否存在预编译符号。</returns>
            public static bool HasScriptingDefineSymbol(string scriptingDefineSymbol,
                BuildTargetGroup buildTargetGroup = BuildTargetGroup.Unknown)
            {
                if (buildTargetGroup == BuildTargetGroup.Unknown)
                {
                    return s_BuildTargetGroups.All(group =>
                        HasScriptingDefineSymbolForGroup(scriptingDefineSymbol, group));
                }
                else
                {
                    if (s_BuildTargetGroups.Contains(buildTargetGroup))
                    {
                        return HasScriptingDefineSymbolForGroup(scriptingDefineSymbol, buildTargetGroup);
                    }
                    else
                    {
                        Debug.LogError($"Unsupported BuildTargetGroup '{buildTargetGroup}'");
                        return false;
                    }
                }
            }

            private static bool HasScriptingDefineSymbolForGroup(string scriptingDefineSymbol,
                BuildTargetGroup buildTargetGroup)
            {
                string defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup);
                if (string.IsNullOrEmpty(defines))
                {
                    return false;
                }

                string[] splits = defines.Split(';');
                return splits.Contains(scriptingDefineSymbol);
            }
        }
    }
}