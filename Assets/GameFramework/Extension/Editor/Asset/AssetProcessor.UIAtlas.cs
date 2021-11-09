using System.Linq;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.U2D;

namespace UnityGameFramework.Editor.Extension.Asset
{
    public sealed class UISpriteAtlasProcessor : AssetProcessor
    {
        public override string ResourceType => "UI Atlas";

        public override string SearchDirectory => "Assets/R/UIProj/Atlases";

        public override string SearchPattern => @"(\AAssets/R/UIProj/Atlases/)(.+)/(.+)(\.spriteatlas\z)";

        public override string SearchFilter => @"";
        public override string PresetPath => "Assets/GameFramework/Extension/Editor/Asset/UI_Atlas.preset";

        public override bool Apply(string path)
        {
            if (Preset == null)
            {
                return false;
            }

            SpriteAtlas spriteAtlas = AssetDatabase.LoadAssetAtPath<SpriteAtlas>(path);
            if (spriteAtlas == null)
            {
                return false;
            }

            string[] propertyPaths =
                Preset.PropertyModifications
                    .Select(modification => modification.propertyPath)
                    .Except(new[]
                    {
                        "m_PackedSprites.Array.size",
                        "m_EditorData.packables.Array.size",
                        "m_PackedSpriteNamesToIndex.Array.size"
                    })
                    .ToArray();

            if (Preset.ApplyTo(spriteAtlas, propertyPaths))
            {
                string folderPath = path.Substring(0, path.LastIndexOf('/'));
                Object folderObject = AssetDatabase.LoadAssetAtPath<Object>(folderPath);
                Object[] packables = spriteAtlas.GetPackables();
                if (packables != null && packables.Length == 1 && packables[0] == folderObject)
                {
                    return false;
                }

                spriteAtlas.Remove(packables);
                spriteAtlas.Add(new[] {folderObject});
                AssetDatabase.ImportAsset(path);
                return true;
            }
            else
            {
                Debug.LogError($"Failed to apply ui sprite atlas preset into '{path}'.");
                return false;
            }
        }
    }
}