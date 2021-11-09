using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

namespace UnityGameFramework.Editor.Extension.Resource
{
    public class ResourceResearch
    {
        public readonly List<Folder> Folders = new List<Folder>
        {
            new Folder {Name = "Assets/R/Audios/Musics", Packed = true},
            new Folder {Name = "Assets/R/Audios/Sounds", Packed = true},
            new Folder {Name = "Assets/R/Audios/UISounds", Packed = true},
            
            // new Folder {Name = "Assets/R/Effects/Entities", Packed = true},
            //
            // new Folder {Name = "Assets/R/Scenes", Packed = true},
            //
            // new Folder {Name = "Assets/R/Models/Entities", Packed = true},
            //
            // new Folder {Name = "Assets/R/Tables/Client/Data", Packed = true},
            // new Folder {Name = "Assets/R/Tables/Jsons", Packed = true},
            //
            // new Folder {Name = "Assets/R/UI/Atlases", Packed = false},
            // new Folder {Name = "Assets/R/UI/Entities", Packed = true},
            // new Folder {Name = "Assets/R/UI/Sprites", Packed = true},
            // new Folder {Name = "Assets/R/UI/Fonts", Packed = true},
            // new Folder {Name = "Assets/R/UI/Forms", Packed = true},
            // new Folder {Name = "Assets/R/UI/Textures", Packed = true},
            
            // new Folder {Name = "Assets/R/Videos", Packed = true},
        };

        [XmlIgnore]
        public readonly Dictionary<string, ResourceName> ResourceNames = new Dictionary<string, ResourceName>();
        [XmlIgnore]
        public readonly Dictionary<string, AssetName> AssetNames = new Dictionary<string, AssetName>();

        public void AddResourceName(ResourceName resourceName)
        {
            if (ResourceNames.ContainsKey(resourceName.Name))
            {
                Debug.LogError($"Duplicated to add resource name '{resourceName.Name}'.");
                return;
            }
            
            ResourceNames.Add(resourceName.Name, resourceName);
        }
        
        public void RemoveResourceName(ResourceName resourceName)
        {
            if (!ResourceNames.ContainsKey(resourceName.Name))
            {
                Debug.LogError($"Has no resource name '{resourceName.Name}'.");
                return;
            }
            
            ResourceNames.Remove(resourceName.Name);
        }

        public void RemoveAllResourceName()
        {
            ResourceNames.Clear();
        }
        
        public void AddAssetName(AssetName assetName)
        {
            if (AssetNames.ContainsKey(assetName.Name))
            {
                Debug.LogError($"Duplicated to add asset name '{assetName.Name}'.");
                return;
            }
            
            AssetNames.Add(assetName.Name, assetName);
        }
        
        public void RemoveAssetName(AssetName assetName)
        {
            if (!AssetNames.ContainsKey(assetName.Name))
            {
                Debug.LogError($"Has no asset name '{assetName.Name}'.");
                return;
            }
            
            AssetNames.Remove(assetName.Name);
        }

        public void RemoveAllAssetName()
        {
            AssetNames.Clear();
        }
    }
}