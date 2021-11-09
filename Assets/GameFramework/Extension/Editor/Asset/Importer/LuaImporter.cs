using System.IO;
using UnityEngine;
using UnityGameFramework.Runtime.Extension;

namespace UnityGameFramework.Editor.Extension.Asset
{
    [UnityEditor.AssetImporters.ScriptedImporter(1, "lua")]
    public sealed class LuaImporter : UnityEditor.AssetImporters.ScriptedImporter
    {
        public override void OnImportAsset(UnityEditor.AssetImporters.AssetImportContext ctx)
        {
            string systemPath = UUtility.Path.Asset2SystemPath(assetPath);
            if (!File.Exists(systemPath))
            {
                return;
            }

            TextAsset textAsset = new TextAsset(File.ReadAllText(systemPath));
            ctx.AddObjectToAsset("text", textAsset);
        }
    }
}