using GameFramework.DataTable;
using UnityGameFramework.Runtime;

namespace UnityGameFramework.Runtime.Extension
{
    public abstract class DataRowBase : IDataRow
    {
        public abstract int Id { get; }

        public virtual bool ParseDataRow(string dataRowString, object userData)
        {
            Log.Warning($"Not implemented {nameof(ParseDataRow)}.");
            return false;
        }

        public virtual bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
        {
            Log.Warning($"Not implemented {nameof(ParseDataRow)}.");
            return false;
        }
    }
}