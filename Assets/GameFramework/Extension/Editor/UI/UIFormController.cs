using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityGameFramework.Runtime.Extension;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace UnityGameFramework.Editor.Extension.UI
{
    /// <summary>
    /// 界面管理器。
    /// </summary>
    public sealed class UIFormController
    {
        private string m_FormPath;
        private string m_ScriptPath;
        private string m_ScriptTempPath;

        private UIFormData m_UIFormData;
        private List<FormInfo> m_FormInfos;

        public UIFormController()
        {
            m_UIFormData = new UIFormData();
            m_FormInfos = new List<FormInfo>();

            GameObject templatePrefab = AssetDatabase.LoadAssetAtPath<GameObject>(UIFormSettings.TemplatePrefabPath);
            if (templatePrefab == null)
            {
                Debug.LogError($"Failed to load template prefab from '{UIFormSettings.TemplatePrefabPath}'");
                return;
            }

            m_UIFormData.TemplatePrefab = templatePrefab;

            m_UIFormData.ComparerPath = UUtility.Path.Asset2SystemPath(UIFormSettings.ComparerPath);
            TextAsset templateLuaScript = AssetDatabase.LoadAssetAtPath<TextAsset>(UIFormSettings.TemplateScriptPath);
            if (templateLuaScript == null)
            {
                Debug.LogError($"Failed to load template script from '{UIFormSettings.TemplateScriptPath}'");
                return;
            }

            m_UIFormData.TemplateLuaScript = templateLuaScript.text;
            m_UIFormData.NamePattern = UIFormSettings.NamePattern;
            ComparerPath = UUtility.Path.Asset2SystemPath(UIFormSettings.ComparerPath);

            m_FormPath = UUtility.Path.Asset2SystemPath(UIFormSettings.FormPath);
            m_ScriptPath = UUtility.Path.Asset2SystemPath(UIFormSettings.ScriptPath);
            m_ScriptTempPath = UUtility.Path.Asset2SystemPath(UIFormSettings.ScriptTempPath);
            Directory.CreateDirectory(m_FormPath);
            Directory.CreateDirectory(m_ScriptPath);
            Directory.CreateDirectory(m_ScriptTempPath);

            Refresh();
        }

        public void Refresh()
        {
            CurrentFormInfo = null;
            m_UIFormData.Clear();

            DirectoryInfo panelDirectoryInfo = new DirectoryInfo(m_FormPath);
            FileInfo[] inputFileInfos = panelDirectoryInfo.GetFiles("*.prefab");
            Array.ForEach(inputFileInfos,
                fileInfo =>
                {
                    m_UIFormData.AddFormInfo(new FormInfo()
                        {Name = fileInfo.Name.Substring(0, fileInfo.Name.LastIndexOf('.')), IsChecked = false});
                });

            m_UIFormData.GetFormInfos(m_FormInfos);
        }

        public List<FormInfo> FormInfos => m_FormInfos;

        public bool HasFormInfo(string panelName)
        {
            return m_UIFormData.HasFormInfo(panelName);
        }

        public string NamePattern
        {
            get => m_UIFormData.NamePattern;
            set => m_UIFormData.NamePattern = value;
        }

        public string ComparerPath
        {
            get => m_UIFormData.ComparerPath;
            set => m_UIFormData.ComparerPath = value;
        }

        public GameObject TemplatePrefab
        {
            get => m_UIFormData.TemplatePrefab;
            set => m_UIFormData.TemplatePrefab = value;
        }

        public string Search
        {
            get => m_UIFormData.Search;
            set => m_UIFormData.Search = value;
        }

        public FormInfo CurrentFormInfo
        {
            get => m_UIFormData.CurrentFormInfo;
            set
            {
                if (value != null)
                {
                    value.IsChecked = true;
                    if (value.Prefab == null)
                    {
                        string prefabPath = $"{UIFormSettings.FormPath}/{value.Name}.prefab";
                        GameObject assetPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
                        value.Prefab = PrefabUtility.InstantiatePrefab(assetPrefab, null) as GameObject;
                    }
                }

                if (m_UIFormData.CurrentFormInfo != null)
                {
                    m_UIFormData.CurrentFormInfo.IsChecked = false;
                    if (m_UIFormData.CurrentFormInfo.Prefab != null)
                    {
                        Object.DestroyImmediate(m_UIFormData.CurrentFormInfo.Prefab);
                    }
                }

                m_UIFormData.CurrentFormInfo = value;
            }
        }

        public void CreateForm()
        {
            if (m_UIFormData.HasFormInfo(m_UIFormData.Search))
            {
                EditorUtility.DisplayDialog("UI Form", $"Duplicate created ui form '{m_UIFormData.Search}'.", "OK");
                return;
            }

            Match match = Regex.Match(m_UIFormData.Search, m_UIFormData.NamePattern);
            if (!match.Success)
            {
                EditorUtility.DisplayDialog("UI Form",
                    $"Invalid ui form name '{m_UIFormData.Search}' according to name patten '{m_UIFormData.NamePattern}'.",
                    "OK");
                return;
            }

            GameObject instance = Object.Instantiate(m_UIFormData.TemplatePrefab);
            instance.name = m_UIFormData.Search;
            string prefabPath = GetPrefabPath(m_UIFormData.Search);
            PrefabUtility.SaveAsPrefabAssetAndConnect(instance, prefabPath, InteractionMode.AutomatedAction);
            Object.DestroyImmediate(instance);

            FormInfo newFormInfo = new FormInfo {Name = m_UIFormData.Search, IsChecked = false};
            m_UIFormData.AddFormInfo(newFormInfo);
            CurrentFormInfo = newFormInfo;
            m_UIFormData.GetFormInfos(m_FormInfos);
        }

        public void CompareForm()
        {
            if (CurrentFormInfo != null)
            {
                string luaScriptPath = GetScriptPath(CurrentFormInfo.Name);
                string script = null;
                if (File.Exists(luaScriptPath))
                {
                    script = GenScript(CurrentFormInfo, File.ReadAllText(luaScriptPath));
                }
                else
                {
                    script = GenScript(CurrentFormInfo, m_UIFormData.TemplateLuaScript);
                    File.WriteAllText(luaScriptPath, script);
                }

                string tempPath = GetScriptTempPath(CurrentFormInfo.Name);
                File.WriteAllText(tempPath, script);
                AssetDatabase.Refresh();
                Process.Start(ComparerPath, $"{tempPath} {luaScriptPath}");
            }
        }

        public void DeleteForm()
        {
            if (CurrentFormInfo != null)
            {
                m_UIFormData.RemoveFormInfo(CurrentFormInfo);
                m_UIFormData.GetFormInfos(m_FormInfos);

                string prefabPath = GetPrefabPath(CurrentFormInfo.Name);
                AssetDatabase.DeleteAsset(prefabPath);
                string luaScriptPath = GetScriptPath(CurrentFormInfo.Name);
                if (File.Exists(luaScriptPath))
                {
                    File.Delete(luaScriptPath);
                }

                CurrentFormInfo = null;
            }
        }

        public void SaveForm()
        {
            if (CurrentFormInfo != null)
            {
                PrefabUtility.ApplyPrefabInstance(CurrentFormInfo.Prefab, InteractionMode.AutomatedAction);
            }
        }

        public void ExportForm()
        {
            if (CurrentFormInfo != null)
            {
                string luaScriptPath = GetScriptPath(CurrentFormInfo.Name);
                string script = null;
                if (File.Exists(luaScriptPath))
                {
                    script = GenScript(CurrentFormInfo, File.ReadAllText(luaScriptPath));
                }
                else
                {
                    script = GenScript(CurrentFormInfo, m_UIFormData.TemplateLuaScript);
                }

                if (File.Exists(luaScriptPath) && File.ReadAllText(luaScriptPath) == script)
                {
                    return;
                }

                File.WriteAllText(luaScriptPath, script);
                AssetDatabase.Refresh();
            }
        }

        private string GetPrefabPath(string panelName)
        {
            return $"{UIFormSettings.FormPath}/{panelName}.prefab";
        }

        private string GetScriptPath(string panelName)
        {
            return $"{m_ScriptPath}/{panelName.ToLower() + ".lua"}";
        }

        private string GetScriptTempPath(string panelName)
        {
            return $"{m_ScriptTempPath}/{panelName.ToLower() + ".lua"}";
        }

        private string GenScript(FormInfo formInfo, string template)
        {
            StringBuilder sb = new StringBuilder();
            ComponentMask[] exporters = formInfo.Prefab.GetComponentsInChildren<ComponentMask>(true);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < exporters.Length; i++)
            {
                ComponentMask exporter = exporters[i];
                if (exporter.gameObject == formInfo.Prefab)
                {
                    exporter.Exported = false;
                    continue;
                }

                Transform current = exporter.transform;
                while (current != formInfo.Prefab.transform)
                {
                    stringBuilder.Insert(0, "/");
                    stringBuilder.Insert(0, current.name);
                    current = current.parent;
                }

                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Remove(stringBuilder.Length - 1, 1);
                }

                exporter.Path = stringBuilder.ToString();
            }

            const string formNamePlaceholder = "$FORM_NAME$";
            const string initComponentStartPlaceholder = "--  $INIT_COMPONENT_START$";
            const string initComponentEndPlaceholder = "--  $INIT_COMPONENT_END$";
            const string initClickStartPlaceholder = "--  $INIT_CLICK_START$";
            const string initClickEndPlaceholder = "--  $INIT_CLICK_END$";
            const string deinitComponentStartPlaceholder = "--  $DEINIT_COMPONENT_START$";
            const string deinitComponentEndPlaceholder = "--  $DEINIT_COMPONENT_END$";
            const string deinitClickStartPlaceholder = "--  $DEINIT_CLICK_START$";
            const string deinitClickEndPlaceholder = "--  $DEINIT_CLICK_END$";

            template = m_UIFormData.TemplateLuaScript.Replace(formNamePlaceholder, formInfo.Prefab.name);

            int startIndex = -1;
            int endIndex = -1;
            startIndex = template.IndexOf(initComponentStartPlaceholder, StringComparison.Ordinal);
            endIndex = template.IndexOf(initComponentEndPlaceholder, StringComparison.Ordinal);
            sb.Append(template.Substring(0, startIndex + initComponentStartPlaceholder.Length));
            sb.Append("\n");
            sb.Append(GenComponentInit(exporters));
            sb.Append(template.Substring(endIndex));
            template = sb.ToString();
            sb.Clear();

            startIndex = template.IndexOf(initClickStartPlaceholder, StringComparison.Ordinal);
            endIndex = template.IndexOf(initClickEndPlaceholder, StringComparison.Ordinal);
            sb.Append(template.Substring(0, startIndex + initClickStartPlaceholder.Length));
            sb.Append("\n");
            sb.Append(GenClickInit(exporters));
            sb.Append(template.Substring(endIndex));
            template = sb.ToString();
            sb.Clear();

            startIndex = template.IndexOf(deinitComponentStartPlaceholder, StringComparison.Ordinal);
            endIndex = template.IndexOf(deinitComponentEndPlaceholder, StringComparison.Ordinal);
            sb.Append(template.Substring(0, startIndex + deinitComponentStartPlaceholder.Length));
            sb.Append("\n");
            sb.Append(GenComponentDeinit(exporters));
            sb.Append(template.Substring(endIndex));
            template = sb.ToString();
            sb.Clear();

            startIndex = template.IndexOf(deinitClickStartPlaceholder, StringComparison.Ordinal);
            endIndex = template.IndexOf(deinitClickEndPlaceholder, StringComparison.Ordinal);
            sb.Append(template.Substring(0, startIndex + deinitClickStartPlaceholder.Length));
            sb.Append("\n");
            sb.Append(GenClickDeinit(exporters));
            sb.Append(template.Substring(endIndex));
            template = sb.ToString();
            sb.Clear();

            template = InsertClickHandler(template, formInfo.Prefab.name, exporters);
            return template;
        }

        private string GenComponentInit(ComponentMask[] exporters)
        {
            if (exporters == null || exporters.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < exporters.Length; i++)
            {
                ComponentMask exporter = exporters[i];
                if (!exporter.Exported)
                {
                    continue;
                }

                string exporterName = UUtility.Text.ToLowerFirstChar(exporter.name);
                sb.Append(
                    $"\tself.{exporterName}_gameobject = utility.gameobject.find_child(self.gameobject, \"{exporter.Path}\")\n");
                for (int j = 0; j < exporter.Components.Count; j++)
                {
                    string comp = exporter.Components[j];
                    if (string.IsNullOrEmpty(comp))
                    {
                        continue;
                    }

                    sb.Append(
                        $"\tself.{exporterName}_{UUtility.Text.ToLowerFirstChar(comp)} = utility.gameobject.find_component(self.{exporterName}_gameobject, \"{comp}\")\n");
                }
            }

            return sb.ToString();
        }

        private string GenClickInit(ComponentMask[] exporters)
        {
            if (exporters == null || exporters.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < exporters.Length; i++)
            {
                ComponentMask exporter = exporters[i];
                if (!exporter.Exported || !exporter.Click)
                {
                    continue;
                }

                string exporterName = UUtility.Text.ToLowerFirstChar(exporter.name);
                sb.Append($"\tself.{exporterName}_click_handler = handler(self, self.on_{exporterName}_click)\n");
                sb.Append(
                    $"\tutility.gameobject.add_click_listener(self.{exporterName}_gameobject, self.{exporterName}_click_handler)\n");
            }

            return sb.ToString();
        }

        private string GenComponentDeinit(ComponentMask[] exporters)
        {
            if (exporters == null || exporters.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < exporters.Length; i++)
            {
                ComponentMask exporter = exporters[i];
                if (!exporter.Exported)
                {
                    continue;
                }

                string exporterName = UUtility.Text.ToLowerFirstChar(exporter.name);
                sb.Append($"\tself.{exporterName}_gameobject = nil\n");
                for (int j = 0; j < exporter.Components.Count; j++)
                {
                    string comp = exporter.Components[j];
                    if (string.IsNullOrEmpty(comp))
                    {
                        continue;
                    }

                    sb.Append($"\tself.{exporterName}_{UUtility.Text.ToLowerFirstChar(comp)} = nil\n");
                }
            }

            return sb.ToString();
        }

        private string GenClickDeinit(ComponentMask[] exporters)
        {
            if (exporters == null || exporters.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < exporters.Length; i++)
            {
                ComponentMask exporter = exporters[i];
                if (!exporter.Exported || !exporter.Click)
                {
                    continue;
                }

                string exporterName = UUtility.Text.ToLowerFirstChar(exporter.name);
                sb.Append(
                    $"\tutility.gameobject.remove_click_listener(self.{exporterName}_gameobject, self.{exporterName}_click_handler)\n");
                sb.Append($"\tself.{exporterName}_click_handler = nil\n");
            }

            return sb.ToString();
        }

        private string InsertClickHandler(string text, string formName, ComponentMask[] exporters)
        {
            const string clickInsertPlaceholder = "-- $CLICK_INSERT_PLACEHOLDER$";
            int index = text.IndexOf(clickInsertPlaceholder, StringComparison.Ordinal);
            index += clickInsertPlaceholder.Length;
            for (int i = 0; i < exporters.Length; i++)
            {
                ComponentMask exporter = exporters[i];
                if (!exporter.Exported || !exporter.Click)
                {
                    continue;
                }

                string handlerHeader = $"-- ${exporter.name.ToUpper()}$";
                if (text.IndexOf(handlerHeader, StringComparison.Ordinal) == -1)
                {
                    string handlerFunction = $"\n" + handlerHeader + "\n" +
                                             $"function {formName}:on_{UUtility.Text.ToLowerFirstChar(exporter.name)}_click(gameobject)\n" +
                                             $"end";
                    text = text.Insert(index, handlerFunction);
                }
            }

            return text;
        }
    }
}