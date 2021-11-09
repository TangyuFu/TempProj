using System.Collections.Generic;
using UnityEngine;

namespace UnityGameFramework.Editor.Extension.UI
{
    /// <summary>
    /// 界面数据。
    /// </summary>
    public class UIFormData
    {
        private SortedDictionary<string, FormInfo> m_PanelInfo;
        
        public UIFormData()
        {
            m_PanelInfo = new SortedDictionary<string, FormInfo>();
        }

        public string ComparerPath { get; set; }

        public GameObject TemplatePrefab { get; set; }
        
        public string TemplateLuaScript { get; set; }
        
        public string Search { get; set; }
        
        public FormInfo CurrentFormInfo { get; set; }

        public string NamePattern { get; set; }

        public bool HasFormInfo(string panelName)
        {
            return m_PanelInfo.ContainsKey(panelName);
        }
        
        public void AddFormInfo(FormInfo formInfo)
        {
            m_PanelInfo.Add(formInfo.Name, formInfo);
        }
        
        public void RemoveFormInfo(FormInfo excelInfo)
        {
            m_PanelInfo.Remove(excelInfo.Name);
        }
        
        public void GetFormInfos(List<FormInfo> results)
        {
            results.Clear();
            foreach (var panelInfo in m_PanelInfo)
            {
                results.Add(panelInfo.Value);
            }
        }

        public void Clear()
        {
            Search = null;
            CurrentFormInfo = null;
            m_PanelInfo.Clear();
        }
    }

    public class FormInfo
    {
        public string Name;
        public bool IsChecked;
        public GameObject Prefab;
    }
}