using System.Linq;
using UnityEditor;
using UnityEngine;

namespace UnityGameFramework.Editor.Extension.Asset
{
    public sealed class UISpriteProcessor : AssetProcessor
    {
        public override string ResourceType => "UI Sprite";

        public override string SearchDirectory => "Assets/R/UIProj/Sprites";

        public override string SearchPattern => @"(\AAssets/R/UIProj/Sprites/)(.+)(\.psd|\.png|\.jpg\z)";

        public override string SearchFilter => @"t:texture2D";
        public override string PresetPath => "Assets/GameFramework/Extension/Editor/Asset/UI_Sprite_Importer.preset";

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
                    Debug.LogError($"Illegal ui sprite size, require square '{path}'.");
                    return false;
                }
            }
            else
            {
                Debug.LogError($"Failed to get size from ui sprite '{path}'.");
                return false;
            }

            string[] propertyPaths =
                Preset.PropertyModifications
                    .Select(modification => modification.propertyPath)
                    .Except(new[] {"m_SpriteBorder.x", "m_SpriteBorder.y", "m_SpriteBorder.z", "m_SpriteBorder.w"})
                    .ToArray();

            if (Preset.ApplyTo(textureImporter, propertyPaths))
            {
                return true;
            }
            else
            {
                Debug.LogError($"Failed to apply ui sprite preset into '{path}'.");
                return false;
            }
        }
    }
}