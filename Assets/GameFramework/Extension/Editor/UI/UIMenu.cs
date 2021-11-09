using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime.Extension;
using Object = UnityEngine.Object;

namespace UnityGameFramework.Editor.Extension.UI
{
    /// <summary>
    /// UI 菜单。
    /// </summary>
    public static class UIMenu
    {
        private const string c_FontAsstPath = "Assets/R/UIProj/Fonts/DefaultFont.asset";

        private static TMP_FontAsset s_FontAsset;

        private const string c_BlankAssetPath = "Assets/R/UIProj/Atlases/Common/_Blank_Img.png";

        private static Sprite s_BlankAsset;

        static UIMenu()
        {
            s_FontAsset = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(c_FontAsstPath);
            if (s_FontAsset == null)
            {
                Debug.LogError($"Failed to find default font asset '{c_FontAsstPath}'.");
            }

            s_BlankAsset = AssetDatabase.LoadAssetAtPath<Sprite>(c_BlankAssetPath);
            if (s_BlankAsset == null)
            {
                int width = 6, height = 6;
                Texture2D texture2D = new Texture2D(width, height);
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        texture2D.SetPixel(i, j, Color.white);
                    }
                }

                byte[] bytes = texture2D.EncodeToPNG();
                File.WriteAllBytes(UUtility.Path.Asset2SystemPath(c_BlankAssetPath), bytes);
                AssetDatabase.Refresh();
                TextureImporter textureImporter = AssetImporter.GetAtPath(c_BlankAssetPath) as TextureImporter;
                if (textureImporter != null)
                {
                    textureImporter.textureType = TextureImporterType.Sprite;
                    textureImporter.SaveAndReimport();
                    textureImporter.spriteBorder = Vector4.one * 2;
                }


                s_BlankAsset = AssetDatabase.LoadAssetAtPath<Sprite>(c_BlankAssetPath);
            }

            if (s_BlankAsset == null)
            {
                Debug.LogError($"Failed to find blank asset '{c_BlankAssetPath}'.");
            }
        }

        [MenuItem("GameObject/UI Custom/Text", false, 1)]
        private static void AddText(MenuCommand menuCommand)
        {
            EditorApplication.ExecuteMenuItem("GameObject/UI/Text - TextMeshPro");
            GameObject gameObject = Selection.activeGameObject;
            gameObject.transform.localPosition = Vector3.zero;

            TextMeshProUGUI text = gameObject.GetComponent<TextMeshProUGUI>();
            text.raycastTarget = false;
            text.font = s_FontAsset;
        }

        [MenuItem("GameObject/UI Custom/Image", false, 2)]
        private static void AddImage(MenuCommand menuCommand)
        {
            EditorApplication.ExecuteMenuItem("GameObject/UI/Image");
            GameObject gameObject = Selection.activeGameObject;
            gameObject.transform.localPosition = Vector3.zero;

            Image image = gameObject.GetComponent<Image>();
            image.raycastTarget = false;
        }

        [MenuItem("GameObject/UI Custom/Raw Image", false, 3)]
        private static void AddRawImage(MenuCommand menuCommand)
        {
            EditorApplication.ExecuteMenuItem("GameObject/UI/Raw Image");
            GameObject gameObject = Selection.activeGameObject;
            gameObject.transform.localPosition = Vector3.zero;

            RawImage rawImage = gameObject.GetComponent<RawImage>();
            rawImage.raycastTarget = false;
        }

        [MenuItem("GameObject/UI Custom/Button", false, 4)]
        private static void AddButton(MenuCommand menuCommand)
        {
            EditorApplication.ExecuteMenuItem("GameObject/UI/Button - TextMeshPro");
            GameObject gameObject = Selection.activeGameObject;
            gameObject.transform.localPosition = Vector3.zero;

            Button button = gameObject.GetComponent<Button>();
            Object.DestroyImmediate(button);
            Image image = gameObject.GetComponent<Image>();
            image.sprite = s_BlankAsset;
            TextMeshProUGUI text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
            text.raycastTarget = false;
            text.font = s_FontAsset;
        }

        [MenuItem("GameObject/UI Custom/Toggle", false, 5)]
        private static void AddToggle(MenuCommand menuCommand)
        {
            EditorApplication.ExecuteMenuItem("GameObject/UI/Toggle");
            GameObject gameObject = Selection.activeGameObject;
            gameObject.transform.localPosition = Vector3.zero;

            Toggle toggle = gameObject.GetComponent<Toggle>();
            toggle.graphic.GetComponent<Image>().raycastTarget = false;

            Text text = gameObject.GetComponentInChildren<Text>();
            GameObject label = text.gameObject;
            Object.DestroyImmediate(text);
            TextMeshProUGUI newText = label.AddComponent<TextMeshProUGUI>();
            newText.font = s_FontAsset;
        }

        [MenuItem("GameObject/UI Custom/Slider", false, 6)]
        private static void AddSlider(MenuCommand menuCommand)
        {
            EditorApplication.ExecuteMenuItem("GameObject/UI/Slider");
            GameObject gameObject = Selection.activeGameObject;
            gameObject.transform.localPosition = Vector3.zero;

            Slider slider = Selection.activeGameObject.GetComponent<Slider>();
            foreach (var image in gameObject.GetComponentsInChildren<Image>(true))
            {
                image.sprite = s_BlankAsset;
            }
        }

        [MenuItem("GameObject/UI Custom/Dropdown", false, 6)]
        private static void AddDropdown(MenuCommand menuCommand)
        {
            EditorApplication.ExecuteMenuItem("GameObject/UI/Dropdown - TextMeshPro");
            GameObject gameObject = Selection.activeGameObject;
            gameObject.transform.localPosition = Vector3.zero;

            ScrollRect scrollRect = gameObject.GetComponentInChildren<ScrollRect>(true);
            if (scrollRect != null)
            {
                Object.DestroyImmediate(scrollRect.verticalScrollbar);
            }

            foreach (var text in gameObject.GetComponentsInChildren<TMP_Text>(true))
            {
                text.font = s_FontAsset;
                text.raycastTarget = false;
            }

            foreach (var image in gameObject.GetComponentsInChildren<Image>(true))
            {
                image.raycastTarget = false;
                image.sprite = s_BlankAsset;
            }

            gameObject.GetComponent<Image>().raycastTarget = true;
            Toggle toggle = gameObject.GetComponentInChildren<Toggle>(true);
            toggle.targetGraphic.raycastTarget = true;
        }

        [MenuItem("GameObject/UI Custom/Input Field", false, 7)]
        public static void AddInputField(MenuCommand menuCommand)
        {
            EditorApplication.ExecuteMenuItem("GameObject/UI/Input Field - TextMeshPro");
            GameObject gameObject = Selection.activeGameObject;
            gameObject.transform.localPosition = Vector3.zero;

            TMP_InputField inputField = gameObject.GetComponent<TMP_InputField>();
            foreach (var text in gameObject.GetComponentsInChildren<TMP_Text>(true))
            {
                text.font = s_FontAsset;
                text.raycastTarget = false;
            }

            foreach (var image in gameObject.GetComponentsInChildren<Image>(true))
            {
                image.sprite = s_BlankAsset;
                image.raycastTarget = false;
            }

            gameObject.GetComponent<Image>().raycastTarget = true;
        }

        [MenuItem("GameObject/UI Custom/Scroll View", false, 8)]
        private static void AddScrollView(MenuCommand menuCommand)
        {
            EditorApplication.ExecuteMenuItem("GameObject/UI/Scroll View");
            GameObject gameObject = Selection.activeGameObject;
            gameObject.transform.localPosition = Vector3.zero;

            ScrollRect scrollRect = gameObject.GetComponent<ScrollRect>();
            Object.DestroyImmediate(scrollRect.horizontalScrollbar.gameObject);
            scrollRect.horizontalScrollbar = null;
            Object.DestroyImmediate(scrollRect.verticalScrollbar.gameObject);
            scrollRect.verticalScrollbar = null;

            scrollRect.viewport.sizeDelta = Vector2.zero;
            var content = scrollRect.content;
            content.pivot = Vector2.up;
            content.sizeDelta = Vector2.zero;
            content.gameObject.AddComponent<GridLayoutGroup>();
            content.gameObject.AddComponent<ContentSizeFitter>();

            foreach (var text in gameObject.GetComponentsInChildren<TMP_Text>(true))
            {
                text.font = s_FontAsset;
                text.raycastTarget = false;
            }

            foreach (var image in gameObject.GetComponentsInChildren<Image>(true))
            {
                image.sprite = s_BlankAsset;
                image.raycastTarget = false;
            }

            gameObject.GetComponent<Image>().raycastTarget = true;
        }
    }
}