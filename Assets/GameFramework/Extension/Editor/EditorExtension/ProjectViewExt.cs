using UnityEditor;
using UnityEngine;

namespace UnityGameFramework.Editor
{
    public static class ProjectViewExt
    {
        [InitializeOnLoadMethod]
        private static void InitializeOnLoadMethod()
        {
            // EditorApplication.projectWindowItemOnGUI += delegate(string guid, Rect selectionRect)
            // {
            //     if (Selection.activeObject && guid == AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(Selection.activeObject)))
            //     {
            //         float width = 50f;
            //         selectionRect.x += (selectionRect.width - width);
            //         selectionRect.width = width;
            //         GUI.color = Color.grey;
            //         // if (GUI.Button(selectionRect, "Test"))
            //         // {
            //         //     Debug.Log($"click: '{Selection.activeObject.name}'");
            //         // }
            //         GUI.color = Color.white;
            //     }
            // };
        }
    }
}