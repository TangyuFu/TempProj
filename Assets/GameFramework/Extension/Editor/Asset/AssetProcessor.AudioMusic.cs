using UnityEditor;
using UnityEngine;

namespace UnityGameFramework.Editor.Extension.Asset
{
    public sealed class AudioMusicProcessor : AssetProcessor
    {
        public override string ResourceType => "Audio Music";

        public override string SearchDirectory => "Assets/R/UIProj/Audios/Musics";

        public override string SearchPattern => @"(\AAssets/R/UIProj/Audios/Musics/)(.+)(\.mp3|\.ogg\z)";

        public override string SearchFilter => @"t:audio";

        public override string PresetPath => "Assets/GameFramework/Extension/Editor/Asset/Audio_Music_Importer.preset";

        public override bool Apply(string path)
        {
            if (Preset == null)
            {
                return false;
            }

            AudioImporter audioImporter = AssetImporter.GetAtPath(path) as AudioImporter;
            if (audioImporter == null)
            {
                return false;
            }

            if (Preset.ApplyTo(audioImporter))
            {
                return true;
            }
            else
            {
                Debug.LogError($"Failed to apply audio music preset into '{path}'.");
                return false;
            }
        }
    }
}