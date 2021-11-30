using Newtonsoft.Json;
using TempProj.DataTable;

namespace TempProj
{
    [JsonObject(MemberSerialization.OptOut)]
    public class PropItemData
    {
        public int Id { get; set; }

        public int Count { get; set; }
        
        public bool IsNew { get; set; }

        [JsonIgnore] public DRPropGroup DrPropGroup { get; set; }

        [JsonIgnore] public DRProp DrProp { get; set; }
    }
}