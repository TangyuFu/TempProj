using UnityEditor;
using UnityEngine;

namespace UnityGameFramework.Editor.Extension
{
    public static class HierarchyViewExt
    {
        [InitializeOnLoadMethod]
        private static void InitializeOnLoadMethod()
        {
            // EditorApplication.hierarchyWindowItemOnGUI += delegate(int instanceId, Rect selectionRect)
            // {
            //     if (Selection.activeObject && instanceId == Selection.activeObject.GetInstanceID())
            //     {
            //         float width = 50f;
            //         selectionRect.x += (selectionRect.width - width);
            //         selectionRect.width = width;
            //         GUI.color = Color.grey;
            //         // if (GUI.Button(selectionRect, AssetDatabase.LoadAssetAtPath<Texture>("Assets/unity.png")))
            //         // {
            //         //     Debug.Log($"click: '{Selection.activeObject.name}'");
            //         // }
            //         GUI.color = Color.white;
            //     }
            // };

            // EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
        }

        private static void OnHierarchyGUI(int instanceId, Rect selectionRect)
        {
            // if (Event.current != null && 
            //     selectionRect.Contains(Event.current.mousePosition) &&
            //     Event.current.button == 1 && 
            //     Event.current.type <= EventType.MouseUp)
            // {
            //     GameObject selectedGameObject = EditorUtility.InstanceIDToObject(instanceId) as GameObject;
            //     if (selectedGameObject)
            //     {
            //         Vector2 mousePosition = Event.current.mousePosition;
            //         
            //         EditorUtility.DisplayPopupMenu(new Rect(mousePosition.x, mousePosition.y, 0,0 ), "Window/Test", null);
            //         Event.current.Use();
            //     }
            // }
        }
    }
}