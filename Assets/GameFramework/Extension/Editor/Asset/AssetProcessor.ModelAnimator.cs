using System;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace UnityGameFramework.Editor.Extension.Asset
{
    public sealed class ModelAnimatorProcessor : AssetProcessor
    {
        [Serializable]
        private class AnimatorStateEventInfo
        {
            public string Name;
            public int Keyframe;
        }

        [Serializable]
        private class AnimatorStateInfo
        {
            public string Name;
            public AnimatorStateEventInfo[] Events = { };
            public bool Loop;
        }

        [Serializable]
        private class AnimatorInfo
        {
            public string AnimationType;
            public AnimatorStateInfo[] States = { };
            public string DefaultState;
        }

        public override string ResourceType => "Model Animator";

        public override string SearchDirectory => "Assets/R/Models/Animators";

        public override string SearchPattern => @"(\AAssets/R/Models/Animators/)(.+)(\.json\z)";

        public override string SearchFilter => @"t:textasset";
        public override string PresetPath => "Assets/GameFramework/Extension/Editor/Asset/ModelAnimFBXImporter.preset";

        public override bool Apply(string path)
        {
            const string animationDirectory = "Assets/R/Models/Animations";
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

            string animatorInfoJson = textAsset.text;
            AnimatorInfo animatorInfo = new AnimatorInfo();
            EditorJsonUtility.FromJsonOverwrite(animatorInfoJson, animatorInfo);
            string name = textAsset.name;
            string animatorControllerPath = $"{path.Substring(0, path.LastIndexOf('.'))}.controller";
            AnimatorController animatorController = AssetDatabase.LoadAssetAtPath<AnimatorController>(animatorControllerPath);
            if (animatorController == null)
            {
                animatorController = AnimatorController.CreateAnimatorControllerAtPath(animatorControllerPath);
            }

            if (!Enum.TryParse(animatorInfo.AnimationType, out ModelImporterAnimationType animationType))
            {
                Debug.LogError($"Invalid ModelImporterAnimationType '{animatorInfo.AnimationType}', " +
                               $"must be '{ModelImporterAnimationType.Generic}' or '{ModelImporterAnimationType.Human}'.");
                return false;
            }

            AnimatorStateMachine animatorStateMachine = animatorController.layers[0].stateMachine;
            animatorController.parameters = new AnimatorControllerParameter[0];
            animatorStateMachine.states = new ChildAnimatorState[0];
            animatorStateMachine.anyStateTransitions = new AnimatorStateTransition[0];
            for (int i = 0; i < animatorInfo.States.Length; i++)
            {
                AnimatorStateInfo animatorStateInfo = animatorInfo.States[i];
                
                string animationPath = $"{animationDirectory}/{name}@{animatorStateInfo.Name}.fbx";
                ModelImporter modelImporter = AssetImporter.GetAtPath(animationPath) as ModelImporter;
                if (modelImporter != null)
                {
                    string[] propertyPaths =
                        {"m_MaterialImportMode", "m_MeshCompression", "m_IsReadable"};
                    if (!Preset.ApplyTo(modelImporter, propertyPaths))
                    {
                        Debug.LogError($"Failed to apply model animation preset into '{path}'.");
                        continue;
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

                    if (modelImporter.defaultClipAnimations == null || modelImporter.defaultClipAnimations.Length != 1)
                    {
                        Debug.LogError($"Model must have only one animation, check '{animationPath}'.");
                        continue;
                    }

                    ModelImporterClipAnimation clipAnimation = modelImporter.defaultClipAnimations[0];
                    clipAnimation.loopTime = animatorStateInfo.Loop;
                    clipAnimation.events = new AnimationEvent[animatorStateInfo.Events.Length];
                    for (int j = 0; j < clipAnimation.events.Length; j++)
                    {
                        AnimatorStateEventInfo animatorStateEventInfo = animatorStateInfo.Events[j];
                        clipAnimation.events[j] = new AnimationEvent
                        {
                            time = 0.1f, stringParameter = animatorStateEventInfo.Name
                        };
                    }

                    modelImporter.clipAnimations = new[] {clipAnimation};
                    modelImporter.SaveAndReimport();
                }
                else
                {
                    Debug.LogError(
                        $"Failed to find animation '{animationPath}' for animator '{animatorControllerPath}'.");
                    continue;
                }
                
                animatorController.AddParameter(animatorStateInfo.Name, AnimatorControllerParameterType.Trigger);
                AnimatorState animatorState =
                    animatorStateMachine.AddState(animatorStateInfo.Name, new Vector3(300, -100 * i, 0));
                AnimatorStateTransition stateTransition = animatorStateMachine.AddAnyStateTransition(animatorState);
                stateTransition.AddCondition(AnimatorConditionMode.If, 0, animatorStateInfo.Name);
                AnimationClip animationClip = AssetDatabase.LoadAssetAtPath<AnimationClip>(animationPath);
                if (animationClip != null)
                {
                    animatorState.motion = animationClip;
                }
                else
                {
                    Debug.LogError($"Failed to find animation clip from '{animationPath}'.");
                    continue;
                }

                if (animatorStateInfo.Name == animatorInfo.DefaultState)
                {
                    animatorStateMachine.defaultState = animatorState;
                }
            }

            return true;
        }
    }
}