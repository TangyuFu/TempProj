using System.Reflection;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.Presets;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.U2D;

namespace UnityGameFramework.Editor.Extension
{
    /// <summary>
    /// 自定义资源的后处理。
    /// </summary>
    public class CustomAssetPostprocessor : AssetPostprocessor
    {
        static CustomAssetPostprocessor()
        {
        }

        // void OnPreprocessAsset()
        // {
        // }
        //
        // static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets,
        //     string[] movedFromAssetPaths)
        // {
        //
        // }

        // /// <summary>
        // /// 导入贴图前。
        // /// </summary>
        // void OnPreprocessTexture()
        // {
        // }
        //
        // /// <summary>
        // /// 导入贴图后。
        // /// </summary>
        // /// <param name="texture"></param>
        // void OnPostprocessTexture(Texture2D texture)
        // {
        //
        // }
        //
        // void OnPostprocessSprites(Texture2D texture, Sprite[] sprites)
        // {
        // }
        //
        // void OnPostprocessCubemap(Cubemap cubemap)
        // {
        // }
        //
        // void OnPreprocessAnimation()
        // {
        // }
        //
        // void OnPostprocessAnimation(GameObject root, AnimationClip clip)
        // {
        // }
        //
        // void OnPreprocessSpeedTree()
        // {
        // }
        //
        // void OnPostprocessSpeedTree(GameObject speedTree)
        // {
        // }
        //
        // void OnPreprocessModel()
        // {
        // }
        //
        // void OnPostprocessModel(GameObject gameObject)
        // {
        // }
        //

        //
        // void OnPreprocessAudio()
        // {
        // }
        //
        // void OnPostprocessAudio(AudioClip audioClip)
        // {
        // }
        //
        // void OnPostprocessAssetbundleNameChanged(string assetPath1, string previousAssetBundleName,
        //     string newAssetBundleName)
        // {
        // }
        //
        // void OnPostprocessGameObjectWithAnimatedUserProperties(GameObject gameObject, EditorCurveBinding[] bindings)
        // {
        // }
        //
        // void OnPostprocessGameObjectWithUserProperties(GameObject go, string[] propNames, object[] values)
        // {
        // }
        //
        // void OnPostprocessMaterial(Material material)
        // {
        // }
        //
        // void OnPostprocessMeshHierarchy(GameObject root)
        // {
        // }
        //
        // void OnPreprocessMaterialDescription(MaterialDescription description, Material material,
        //     AnimationClip[] animations)
        // {
        // }
        //
        // Material OnAssignMaterialModel(Material material, Renderer renderer)
        // {
        //     return material;
        // }
    }
}