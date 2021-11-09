using System.Linq;
using UnityEditor;
using UnityEngine;

namespace UnityGameFramework.Editor.Extension.Asset
{
    public sealed class ModelTextureProcessor : AssetProcessor
    {
        public override string ResourceType => "Model Texture";

        public override string SearchDirectory => "Assets/R/ModelProj";

        public override string SearchPattern => @"(\AAssets/R/ModelProj/Textures/)(.+)(\.psd|\.png|\.jpg\z)";

        public override string SearchFilter => @"t:texture2D";
        public override string PresetPath => "Assets/GameFramework/Extension/Editor/Asset/Model_Texture_Importer.preset";

        public override bool Apply(string path)
        {
            if (Preset == null)
            {
                return false;
            }

            TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
            if (textureImporter == null)
            {
                return false;
            }

            // 检测精灵是否是方形。
            if (AssetController.GetTextureSize(textureImporter, out var size))
            {
                if (size[0] != size[1])
                {
                    Debug.LogError($"Illegal model texture size, require square '{path}'.");
                }
            }
            else
            {
                Debug.LogError($"Failed to get size from model texture '{path}'.");
            }

            string[] propertyPaths =
                Preset.PropertyModifications
                    .Select(modification => modification.propertyPath)
                    .Where(modification => modification.StartsWith("m_PlatformSettings"))
                    .Union(new[] {"m_EnableMipMap", "m_NPOTScale", "m_IsReadable"})
                    .ToArray();

            if (Preset.ApplyTo(textureImporter, propertyPaths))
            {
                return true;
            }
            else
            {
                Debug.LogError($"Failed to apply model texture preset into '{path}'.");
                return false;
            }
        }
    }
}