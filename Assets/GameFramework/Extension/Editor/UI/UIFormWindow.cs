using UnityEditor;
using UnityEngine;
using UnityGameFramework.Runtime.Extension;

namespace UnityGameFramework.Editor.Extension.UI
{
    /// <summary>
    /// 界面窗口。
    /// </summary>
    public sealed class UIFormWindow : EditorWindow
    {
        [MenuItem("Game Framework/Extension/UI Form", true, 200)]
        private static bool OpenValidate()
        {
            if (EditorApplication.isPlaying || EditorApplication.isCompiling || EditorApplication.isUpdating)
            {
                return false;
            }

            return true;
        }

        [MenuItem("Game Framework/Extension/UI Form", false, 200)]
        private static void Open()
        {
            GetWindow<UIFormWindow>("UI Form").position
                = new Rect(0, 0,
                    Screen.currentResolution.width * 0.5f,
                    Screen.currentResolution.height * 0.95f);
        }

        private UIFormController m_UIFormController;

        private void OnEnable()
        {
            m_UIFormController = new UIFormController();

            m_UIFormController.Refresh();
        }

        private void OnDisable()
        {
            m_UIFormController.CurrentFormInfo = null;
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginHorizontal(GUILayout.Width(position.width), GUILayout.Height(position.height));
            {
                EditorGUILayout.BeginVertical(GUILayout.Width(200));
                {
                    EditorGUILayout.LabelField("Panel Prefab List", EditorStyles.boldLabel);
                    EditorGUILayout.BeginHorizontal();
                    {
                        DrawPrefabMenuView();
                    }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginVertical("box");
                    {
                        DrawPrefabListView();
                    }
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.EndVertical();

                EditorGUILayout.BeginVertical(GUILayout.Width(position.width - 200));
                {
                    EditorGUILayout.LabelField("Panel Prefab Content", EditorStyles.boldLabel);
                    EditorGUILayout.BeginHorizontal();
                    {
                        DrawComparerView();
                    }
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    {
                        DrawPanelContentMenuView();
                    }
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginVertical("box");
                    {
                        DrawPanelContentView();
                    }
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndHorizontal();
        }

        private void DrawPrefabMenuView()
        {
            m_UIFormController.Search = EditorGUILayout.TextField(m_UIFormController.Search, GUILayout.Width(100));
            if (GUILayout.Button("Create", GUILayout.Width(50)))
            {
                m_UIFormController.CreateForm();
            }

            if (GUILayout.Button("Refresh", GUILayout.Width(80)))
            {
                m_UIFormController.Refresh();
            }
        }

        private Vector2 m_PrefabListViewScrollPos;

        private void DrawPrefabListView()
        {
            m_PrefabListViewScrollPos = EditorGUILayout.BeginScrollView(m_PrefabListViewScrollPos);
            {
                char lastFirstChar = char.MinValue;
                foreach (var panelInfo in m_UIFormController.FormInfos)
                {
                    char firstChar = panelInfo.Name[0];
                    if (lastFirstChar != firstChar)
                    {
                        EditorGUILayout.LabelField(firstChar.ToString(), EditorStyles.boldLabel);
                    }

                    bool beforeChecked = panelInfo.IsChecked;
                    panelInfo.IsChecked = EditorGUILayout.Toggle(panelInfo.Name, panelInfo.IsChecked);
                    bool afterChecked = panelInfo.IsChecked;
                    if (beforeChecked != afterChecked)
                    {
                        FormInfo selectedFormInfo = afterChecked ? panelInfo : null;
                        m_UIFormController.CurrentFormInfo = selectedFormInfo;
                        break;
                    }
                }
            }
            EditorGUILayout.EndScrollView();
        }

        private void DrawComparerView()
        {
            EditorGUILayout.LabelField("Comparer Path: ", GUILayout.Width(100));
            m_UIFormController.ComparerPath =
                EditorGUILayout.TextField(m_UIFormController.ComparerPath, GUILayout.Width(400));
            if (GUILayout.Button("Select", GUILayout.Width(80)))
            {
                string comparerPath = EditorUtility.OpenFilePanel("Comparer", Application.dataPath, "");
                m_UIFormController.ComparerPath = comparerPath;
            }
        }

        private void DrawPanelContentMenuView()
        {
            if (m_UIFormController == null)
            {
                return;
            }

            if (GUILayout.Button("Compare", GUILayout.Width(100)))
            {
                m_UIFormController.CompareForm();
            }

            if (GUILayout.Button("Delete", GUILayout.Width(50)))
            {
                m_UIFormController.DeleteForm();
            }

            if (GUILayout.Button("Save", GUILayout.Width(50)))
            {
                m_UIFormController.SaveForm();
            }

            if (GUILayout.Button("Export", GUILayout.Width(50)))
            {
                m_UIFormController.ExportForm();
            }
        }

        private Vector2 m_PrefabContentViewScrollPos;

        private void DrawPanelContentView()
        {
            if (m_UIFormController.CurrentFormInfo == null)
            {
                return;
            }

            m_PrefabContentViewScrollPos = EditorGUILayout.BeginScrollView(m_PrefabContentViewScrollPos);
            {
                DrawGameObjectView(m_UIFormController.CurrentFormInfo.Prefab, 0);
            }
            EditorGUILayout.EndScrollView();
        }

        private void DrawGameObjectView(GameObject gameObject, int space)
        {
            if (!gameObject)
            {
                return;
            }

            ComponentMask mask = gameObject.GetComponent<ComponentMask>();
            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Space(space * 20);
                gameObject.name = EditorGUILayout.TextField(gameObject.name, GUILayout.Width(100));
                GUILayout.Space(10);
                if (mask)
                {
                    SerializedObject serializedObject = new SerializedObject(mask);
                    SerializedProperty component = serializedObject.FindProperty("m_Components");
                    SerializedProperty exported = serializedObject.FindProperty("m_Exported");
                    SerializedProperty click = serializedObject.FindProperty("m_Click");
                    serializedObject.Update();
                    EditorGUILayout.PropertyField(exported, true, GUILayout.Width(100));
                    EditorGUILayout.PropertyField(click, true, GUILayout.Width(100));
                    EditorGUILayout.PropertyField(component, true, GUILayout.Width(500));
                    serializedObject.ApplyModifiedProperties();
                }
                else
                {
                    if (EUtility.GUILayout.Toggle("Exported", false, GUILayout.Width(80)))
                    {
                        mask = gameObject.AddComponent<ComponentMask>();
                        mask.Exported = true;
                    }
                }
            }
            EditorGUILayout.EndHorizontal();

            space++;
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                GameObject child = gameObject.transform.GetChild(i).gameObject;
                DrawGameObjectView(child, space);
            }
        }
    }
}