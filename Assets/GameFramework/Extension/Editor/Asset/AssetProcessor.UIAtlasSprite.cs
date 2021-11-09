using System.Linq;
using UnityEditor;
using UnityEngine;

namespace UnityGameFramework.Editor.Extension.Asset
{
    public sealed class UIAtlasSpriteProcessor : AssetProcessor
    {
        public override string ResourceType => "UI Atlas Sprite";

        public override string SearchDirectory => "Assets/R/UIProj/Atlases";

        public override string SearchPattern => @"(\AAssets/R/UIProj/Atlases/)(.+)/(.+)(\.psd|\.png|\.jpg\z)";

        public override string SearchFilter => @"t:texture2D";
        public override string PresetPath => "Assets/GameFramework/Extension/Editor/Asset/UI_Atlas_SpriteImporter.preset";

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

            string[] propertyPaths =
                Preset.PropertyModifications
                    .Select(modification => modification.propertyPath)
                    .Except(new[] {"m_SpriteBorder.x", "m_SpriteBorder.y", "m_SpriteBorder.z", "m_SpriteBorder.w"})
                    .ToArray();

            if (Preset.ApplyTo(textureImporter, propertyPaths))
            {
                AssetDatabase.ImportAsset(path);
                return true;
            }
            else
            {
                Debug.LogError($"Failed to apply ui atlas sprite preset into '{path}'.");
                return false;
            }
        }
    }
}