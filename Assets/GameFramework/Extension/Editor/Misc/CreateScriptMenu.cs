using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

namespace UnityGameFramework.Editor.Extension
{
    /// <summary>
    /// 自定义新建 C# 脚本。
    /// </summary>
    public static class CreateScriptMenu
    {
        private const string CUSTOM_SCRIPT_PATH = "Assets/GameFramework/Extension/Editor/Misc/BehaviourScript.cs.txt";

        [MenuItem("Assets/Create/C# Custom Script", false, 80)]
        private static void CreateScript()
        {
            string locationPath = GetSelectedPathOrFallback();
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(
                0,
                ScriptableObject.CreateInstance<CustomDoCreateScriptAsset>(),
                locationPath + "/NewBehaviourScript.cs",
                null,
                CUSTOM_SCRIPT_PATH);
        }

        private static string GetSelectedPathOrFallback()
        {
            string path = "Assets";
            foreach (var obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets))
            {
                path = AssetDatabase.GetAssetPath(obj);
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    path = Path.GetDirectoryName(path);
                    break;
                }
            }

            return path;
        }

        class CustomDoCreateScriptAsset : EndNameEditAction
        {
            public override void Action(int instanceId, string pathName, string resourceFile)
            {
                UnityEngine.Object o = CreateScriptAssetFromTemplate(pathName, resourceFile);
                ProjectWindowUtil.ShowCreatedAsset(o);
            }

            internal static UnityEngine.Object CreateScriptAssetFromTemplate(string pathName, string resourceFile)
            {
                string fullPath = Path.GetFullPath(pathName);
                StreamReader streamReader = new StreamReader(resourceFile);
                string text = streamReader.ReadToEnd();
                streamReader.Close();
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pathName);

                // 替换文件
                text = Regex.Replace(text, "#NAME#", fileNameWithoutExtension);
                text = Regex.Replace(text, "#NAMESPACE#", "GameApplication");

                bool encoderShouldEmitUTF8Identifier = true;
                bool throwOnInvalidBytes = false;
                UTF8Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier, throwOnInvalidBytes);
                bool append = false;
                StreamWriter streamWriter = new StreamWriter(fullPath, append, encoding);
                streamWriter.Write(text);
                streamWriter.Close();
                AssetDatabase.ImportAsset(pathName);
                return AssetDatabase.LoadAssetAtPath(pathName, typeof(UnityEngine.Object));
            }
        }
    }
}