using System;
using System.IO;
using System.Xml;
using UnityEditor;
using UnityEngine;
using UnityGameFramework.Runtime.Extension;

namespace UnityGameFramework.Editor.Extension.Resource
{
    public class ResourceController : Singleton<ResourceController>
    {
        private ResourceResearch m_ResourceResearch;

        public string SelectedResourceName { get; set; }

        public ResourceController()
        {
        }

        public ResourceResearch ResourceResearch => m_ResourceResearch;

        public void Refresh()
        {
            TextAsset resourceDataTextAsset =
                AssetDatabase.LoadAssetAtPath<TextAsset>(ResourceSettings.ResourceResearchPath);
            if (resourceDataTextAsset == null || string.IsNullOrEmpty(resourceDataTextAsset.text))
            {
                Debug.Log($"Failed to load resource research data from '{ResourceSettings.ResourceResearchPath}'.");
                m_ResourceResearch = new ResourceResearch();
            }
            else
            {
                string resourceResearchDataText = resourceDataTextAsset.text;
                try
                {
                    m_ResourceResearch = UUtility.Convert.XmlStringToObject<ResourceResearch>(resourceResearchDataText);
                    Debug.Log(
                        $"Succeeded to parse resource research data from '{ResourceSettings.ResourceResearchPath}'.");
                }
                catch (Exception e)
                {
                    Debug.LogError(
                        $"Failed to parse resource research data from path '{ResourceSettings.ResourceResearchPath}' with exception '{e}'.");
                    return;
                }
            }

            m_ResourceResearch.RemoveAllResourceName();
            m_ResourceResearch.RemoveAllAssetName();
            SelectedResourceName = null;

            foreach (var folder in m_ResourceResearch.Folders)
            {
                string name = folder.Name;
                bool packed = folder.Packed;
                if (packed)
                {
                    AddUnpackedFolder(name);
                }
                else
                {
                    string[] guids = AssetDatabase.FindAssets("t:Folder", new[] {name});
                    foreach (var guid in guids)
                    {
                        string folderName = AssetDatabase.GUIDToAssetPath(guid);
                        AddPackedFolder(folderName);
                    }
                }
            }
        }
        
        private void AddUnpackedFolder(string folderName)
        {
            string[] guids = AssetDatabase.FindAssets("", new[] {folderName});
            foreach (var assetGuid in guids)
            {
                string assetName = AssetDatabase.GUIDToAssetPath(assetGuid);
                int index = assetName.LastIndexOf('.');
                string resourceName = index == -1 ? assetName : assetName.Substring(0,index);
                m_ResourceResearch.ResourceNames.Add(resourceName, new ResourceName {Name = resourceName, LoadType = "0", Packed = "False"});
                m_ResourceResearch.AssetNames.Add(assetGuid, new AssetName {Name = assetName, ResourceName = resourceName, Guid = assetGuid});
            }
        }

        private void AddPackedFolder(string folderName)
        {
            string resourceName = folderName;
            string[] guids = AssetDatabase.FindAssets("", new[] {folderName});
            m_ResourceResearch.ResourceNames.Add(resourceName, new ResourceName {Name = resourceName, LoadType = "0", Packed = "False"});
            foreach (var assetGuid in guids)
            {
                string assetName = AssetDatabase.GUIDToAssetPath(assetGuid);
                m_ResourceResearch.AssetNames.Add(assetName, new AssetName {Name = assetName, ResourceName = resourceName, Guid = assetGuid});
            }
        }

        public void Clear()
        {
            m_ResourceResearch.ResourceNames.Clear();
            m_ResourceResearch.AssetNames.Clear();

            try
            {
                File.Delete(UUtility.Path.Asset2SystemPath(ResourceSettings.ResourceResearchPath));
                AssetDatabase.Refresh();
                Debug.Log($"Succeeded to clear resource research data to '{ResourceSettings.ResourceResearchPath}'.");
            }
            catch (Exception e)
            {
                Debug.LogError(
                    $"Failed to save resource research data to path '{ResourceSettings.ResourceResearchPath}' with exception '{e}'.");
                return;
            }
        }

        public void SaveResearch()
        {
            try
            {
                string xml = UUtility.Convert.ObjectToXmlString(m_ResourceResearch);
                File.WriteAllText(UUtility.Path.Asset2SystemPath(ResourceSettings.ResourceResearchPath), xml);
                AssetDatabase.Refresh();
                Debug.Log($"Succeeded to save resource research data to '{ResourceSettings.ResourceResearchPath}'.");
            }
            catch (Exception e)
            {
                Debug.LogError(
                    $"Failed to save resource research data to path '{ResourceSettings.ResourceResearchPath}' with exception '{e}'.");
            }
        }

        public void SaveCollection()
        {
            string path = UUtility.Path.Asset2SystemPath(ResourceSettings.ResourceCollectionPath);
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.AppendChild(xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null));

            XmlElement xmlRoot = xmlDocument.CreateElement("UnityGameFramework");
            xmlDocument.AppendChild(xmlRoot);

            XmlElement xmlCollection = xmlDocument.CreateElement("ResourceCollection");
            xmlRoot.AppendChild(xmlCollection);

            XmlElement xmlResources = xmlDocument.CreateElement("Resources");
            xmlCollection.AppendChild(xmlResources);

            XmlElement xmlAssets = xmlDocument.CreateElement("Assets");
            xmlCollection.AppendChild(xmlAssets);

            XmlElement xmlElement = null;
            XmlAttribute xmlAttribute = null;
            
            foreach (ResourceName resource in m_ResourceResearch.ResourceNames.Values)
            {
                xmlElement = xmlDocument.CreateElement("Resource");
                xmlAttribute = xmlDocument.CreateAttribute("Name");
                xmlAttribute.Value = resource.Name;
                xmlElement.Attributes.SetNamedItem(xmlAttribute);
                xmlAttribute = xmlDocument.CreateAttribute("LoadType");
                xmlAttribute.Value = resource.LoadType;
                xmlElement.Attributes.SetNamedItem(xmlAttribute);
                xmlAttribute = xmlDocument.CreateAttribute("Packed");
                xmlAttribute.Value = resource.Packed;
                xmlElement.Attributes.SetNamedItem(xmlAttribute);
                xmlResources.AppendChild(xmlElement);
            }

            foreach (AssetName asset in m_ResourceResearch.AssetNames.Values)
            {
                xmlElement = xmlDocument.CreateElement("Asset");
                xmlAttribute = xmlDocument.CreateAttribute("Guid");
                xmlAttribute.Value = asset.Guid;
                xmlElement.Attributes.SetNamedItem(xmlAttribute);
                xmlAttribute = xmlDocument.CreateAttribute("ResourceName");
                xmlAttribute.Value = asset.ResourceName;
                xmlElement.Attributes.SetNamedItem(xmlAttribute);
                xmlAssets.AppendChild(xmlElement);
            }
            
            string configurationDirectoryName = Path.GetDirectoryName(path);
            if (configurationDirectoryName != null && !Directory.Exists(configurationDirectoryName))
            {
                Directory.CreateDirectory(configurationDirectoryName);
            }
            
            xmlDocument.Save(path);
            AssetDatabase.Refresh();
        }
    }
}