using UnityEditor;
using UnityEngine;

namespace UnityGameFramework.Editor.Extension.Asset
{
    public sealed class UITextureProcessor : AssetProcessor
    {
        public override string ResourceType => "UI Texture";

        public override string SearchDirectory => "Assets/R/UIProj/Textures";

        public override string SearchPattern => @"(\AAssets/R/UIProj/Textures/)(.+)(\.psd|\.png|\.jpg\z)";

        public override string SearchFilter => @"t:texture2D";
        public override string PresetPath => "Assets/GameFramework/Extension/Editor/Asset/UI_Texture_Importer.preset";

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
                    Debug.LogError($"Illegal ui texture size, require square '{path}'.");
                    return false;
                }
            }
            else
            {
                Debug.LogError($"Failed to get size from ui texture '{path}'.");
                return false;
            }

            if (Preset.ApplyTo(textureImporter))
            {
                return true;
            }
            else
            {
                Debug.LogError($"Failed to apply ui texture preset into '{path}'.");
                return false;
            }
        }
    }
}