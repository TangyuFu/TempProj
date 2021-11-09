using System.Collections.Generic;
using System.Reflection;

namespace UnityGameFramework.Editor.Extension
{
    public static partial class EUtility
    {
        /// <summary>
        /// Unity Editor 类型工具。
        /// </summary>
        public static class Type
        {
            private static readonly string[] AssemblyNames =
            {
                "UnityGameFramework.Runtime",
                "Assembly-CSharp"
            };

            private static readonly string[] EditorAssemblyNames =
            {
                "UnityGameFramework.Editor",
                "Assembly-CSharp-Editor"
            };

            /// <summary>
            /// 获取指定基类的所有子类的名称。
            /// </summary>
            /// <param name="baseType">基类类型。</param>
            /// <returns>指定基类的所有子类。</returns>
            internal static System.Type[] GetSubTypes(System.Type baseType)
            {
                return GetSubTypes(baseType, AssemblyNames);
            }


            /// <summary>
            /// 获取指定基类的所有子类的名称。
            /// </summary>
            /// <param name="baseType">基类类型。</param>
            /// <returns>指定基类的所有子类。</returns>
            internal static System.Type[] GetEditorTypes(System.Type baseType)
            {
                return GetSubTypes(baseType, EditorAssemblyNames);
            }

            private static System.Type[] GetSubTypes(System.Type baseType, string[] assemblyNames)
            {
                List<System.Type> subTypes = new List<System.Type>();
                foreach (string assemblyName in assemblyNames)
                {
                    Assembly assembly = null;
                    try
                    {
                        assembly = Assembly.Load(assemblyName);
                    }
                    catch
                    {
                        continue;
                    }

                    if (assembly == null)
                    {
                        continue;
                    }

                    System.Type[] types = assembly.GetTypes();
                    foreach (System.Type type in types)
                    {
                        if (type != baseType && type.IsClass && !type.IsAbstract && baseType.IsAssignableFrom(type))
                        {
                            subTypes.Add(type);
                        }
                    }
                }

                return subTypes.ToArray();
            }
        }
    }
}