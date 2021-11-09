using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UnityGameFramework.Editor.Extension.Asset
{
    public sealed class ModelProcessor : AssetProcessor
    {
        [Serializable]
        private class MeshInfo
        {
            public string Name;
            public string[] Materials = {};
        }

        [Serializable]
        private class ModelInfo
        {
            public string AnimationType;
            public bool Static;
            public MeshInfo[] Meshes = { };
        }

        public override string ResourceType => "Model";

        public override string SearchDirectory => "Assets/R/Models/Models";

        public override string SearchPattern => @"(\AAssets/R/Models/Models/)(.+)(\.json\z)";

        public override string SearchFilter => @"t:textasset";
        public override string PresetPath => "Assets/GameFramework/Extension/Editor/Asset/ModelFBXImporter.preset";

        public override bool Apply(string path)
        {
            const string materialDirectory = "Assets/R/Models/Materials";
            const string modelDirectory = "Assets/R/Models/Models";
            const string prefabDirectory = "Assets/R/Models/Prefabs";
            const string entityDirectory = "Assets/R/Models/Entities";
            if (Preset == null)
            {
                return false;
            }

            TextAsset textAsset = AssetDatabase.LoadAssetAtPath<TextAsset>(path);
            if (textAsset == null)
            {
                Debug.LogError($"Failed to load text asset from '{path}'.");
                return false;
            }

            string modelInfoJson = textAsset.text;
            ModelInfo modelInfo = new ModelInfo();
            EditorJsonUtility.FromJsonOverwrite(modelInfoJson, modelInfo);
            string name = textAsset.name;

            if (!Enum.TryParse(modelInfo.AnimationType, out ModelImporterAnimationType animationType))
            {
                Debug.LogError($"Invalid ModelImporterAnimationType '{modelInfo.AnimationType}', " +
                               $"must be '{ModelImporterAnimationType.Generic}' or '{ModelImporterAnimationType.Human}'.");
                return false;
            }

            string modelPath = $"{modelDirectory}/{name}.fbx";
            ModelImporter modelImporter = AssetImporter.GetAtPath(modelPath) as ModelImporter;
            if (modelImporter != null)
            {
                string[] propertyPaths =
                    {"m_MaterialImportMode", "m_MeshCompression", "m_IsReadable"};
                if (!Preset.ApplyTo(modelImporter, propertyPaths))
                {
                    Debug.LogError($"Failed to apply model animation preset into '{path}'.");
                    return false;
                }

                if (animationType == ModelImporterAnimationType.Generic)
                {
                    modelImporter.animationType = ModelImporterAnimationType.Generic;
                    modelImporter.avatarSetup = ModelImporterAvatarSetup.NoAvatar;
                }
                else if (animationType == ModelImporterAnimationType.Human)
                {
                    modelImporter.animationType = ModelImporterAnimationType.Human;
                    modelImporter.avatarSetup = ModelImporterAvatarSetup.CreateFromThisModel;
                }
                else
                {
                    Debug.LogError($"Unsupported {typeof(ModelImporterAnimationType).Name} '{animationType}'.");
                }

                modelImporter.SaveAndReimport();
            }
            else
            {
                Debug.LogError($"Failed to find model '{modelPath}'.");
                return false;
            }

            GameObject modelPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(modelPath);
            GameObject modelGameObject = PrefabUtility.InstantiatePrefab(modelPrefab) as GameObject;
            if (modelGameObject == null)
            {
                Debug.LogError($"Failed to instantiate prefab from '{modelPath}'.");
                return false;
            }

            for (int i = 0; i < modelInfo.Meshes.Length; i++)
            {
                MeshInfo meshInfo = modelInfo.Meshes[i];
                Transform meshTransform = modelGameObject.transform.Find(meshInfo.Name);
                if (meshTransform == null)
                {
                    Debug.LogError($"Failed to find mesh '{meshInfo.Name}' from '{modelPath}'");
                    continue; 
                }

                Renderer renderer = meshTransform.GetComponent<Renderer>();
                if (renderer == null)
                {
                    Debug.LogError($"Failed to find render from '{modelPath}'");
                    continue; 
                }

                List<Material> materials = new List<Material>();
                for (int j = 0; j < meshInfo.Materials.Length; j++)
                {
                    string materialPath = $"{materialDirectory}/{name}@{meshInfo.Name}.mat";
                    Material material = AssetDatabase.LoadAssetAtPath<Material>(materialPath);
                    if (material != null)
                    {
                        materials.Add(material);
                    }
                    else
                    {
                        Debug.LogError($"Failed to find material from '{materialPath}'");
                        continue;
                    }
                }

                renderer.sharedMaterials = materials.ToArray();
            }
            
            string prefabPath = $"{(modelInfo.Static ? prefabDirectory : entityDirectory)}/{name}.prefab";
            GameObject newPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            if (newPrefab == null)
            {
                newPrefab = new GameObject(name);
                newPrefab.transform.localPosition = Vector3.zero;
                modelGameObject.transform.SetParent(newPrefab.transform);
                modelGameObject.transform.localPosition = Vector3.zero;
                PrefabUtility.SaveAsPrefabAssetAndConnect(newPrefab, prefabPath, InteractionMode.UserAction);
            }
            else
            {
                newPrefab = PrefabUtility.InstantiatePrefab(newPrefab) as GameObject;
                if (newPrefab == null)
                {
                    Debug.LogError($"Failed to instantiate prefab from '{prefabPath}'");
                    return false;
                }

                Transform firstChild = newPrefab.transform.GetChild(0);
                if (firstChild != null)
                {
                    Object.DestroyImmediate(firstChild);
                }
                modelGameObject.transform.SetParent(newPrefab.transform);
                modelGameObject.transform.localPosition = Vector3.zero;
                modelGameObject.transform.SetAsFirstSibling();
                PrefabUtility.ApplyPrefabInstance(newPrefab, InteractionMode.AutomatedAction);
            }

            return true;
        }
    }
}