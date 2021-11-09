using System;
using GameFramework;
using GameFramework.DataTable;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 数据表拓展。
    /// </summary>
    public static class DataTableExtension
    {
        public const string DataRowNamespace = "UnityGameFramework.Runtime.Extension.DataTable";
        internal static readonly char[] DataSplitSeparators = {'\t'};

        /// <summary>
        /// 加载数据表。
        /// </summary>
        /// <param name="dataTableComponent">数据表组件。</param>
        /// <param name="dataTableName">数据表名称。</param>
        /// <param name="dataTableAssetName">数据表资源名称</param>
        /// <param name="userData">用户自定义数据。</param>
        public static void LoadDataTable(this DataTableComponent dataTableComponent, string dataTableName,
            string dataTableAssetName, object userData)
        {
            if (string.IsNullOrEmpty(dataTableName))
            {
                Log.Warning($"Invalid data table name '{dataTableName}'.");
                return;
            }

            string dataRowClassName = Utility.Text.Format("{0}.DR{1}", DataRowNamespace, dataTableName);
            Type dataRowType = Type.GetType(dataRowClassName);
            if (dataRowType == null)
            {
                Log.Warning($"Failed to get data row type with class name '{dataRowClassName}'.");
                return;
            }

            DataTableBase dataTable = dataTableComponent.CreateDataTable(dataRowType);
            dataTable.ReadData(dataTableAssetName, Constant.AssetPriority.DataTableAsset, userData);
        }

        /// <summary>
        /// 解析 Color32，形如 64,128,192,255 。
        /// </summary>
        /// <param name="value">Color32 文本。</param>
        /// <returns>Color32 值。</returns>
        public static Color32 ParseColor32(string value)
        {
            string[] splitValue = value.Split(',');
            return new Color32(byte.Parse(splitValue[0]), byte.Parse(splitValue[1]), byte.Parse(splitValue[2]),
                byte.Parse(splitValue[3]));
        }

        /// <summary>
        /// 解析 Color，形如 1.0,0.0,1.0,1.0 。
        /// </summary>
        /// <param name="value">Color 文本。</param>
        /// <returns>Color 值。</returns>
        public static Color ParseColor(string value)
        {
            string[] splitValue = value.Split(',');
            return new Color(float.Parse(splitValue[0]), float.Parse(splitValue[1]), float.Parse(splitValue[2]),
                float.Parse(splitValue[3]));
        }

        /// <summary>
        /// 解析 html 为 Color ，形如 #00FF00FF 或者 red blue etc. 。
        /// </summary>
        /// <param name="value">html 文本。</param>
        /// <returns>Color 值。</returns>
        public static Color ParseHtml(string value)
        {
            if (ColorUtility.TryParseHtmlString(value, out var color))
            {
                return color;
            }
            else
            {
                Log.Error($"Failed to parse html {value}.");
                return Color.white;
            }
        }

        /// <summary>
        /// 解析 Quaternion，形如 0.0,0.7,0.0,0.7 。
        /// </summary>
        /// <param name="value">Quaternion 文本。</param>
        /// <returns>Quaternion 值。</returns>
        public static Quaternion ParseQuaternion(string value)
        {
            string[] splitValue = value.Split(',');
            return new Quaternion(float.Parse(splitValue[0]), float.Parse(splitValue[1]), float.Parse(splitValue[2]),
                float.Parse(splitValue[3]));
        }

        /// <summary>
        /// 解析 Rect，形如 30.0,40.7,56.0,77.7 。
        /// </summary>
        /// <param name="value">Rect 文本。</param>
        /// <returns>Rect 值。</returns>
        public static Rect ParseRect(string value)
        {
            string[] splitValue = value.Split(',');
            return new Rect(float.Parse(splitValue[0]), float.Parse(splitValue[1]), float.Parse(splitValue[2]),
                float.Parse(splitValue[3]));
        }

        /// <summary>
        /// 解析 Vector2，形如 30.0,40.0 。
        /// </summary>
        /// <param name="value">Vector2 文本。</param>
        /// <returns>Vector2 值。</returns>
        public static Vector2 ParseVector2(string value)
        {
            string[] splitValue = value.Split(',');
            return new Vector2(float.Parse(splitValue[0]), float.Parse(splitValue[1]));
        }

        /// <summary>
        /// 解析 Vector3，形如 30.0,40.0,50.0 。
        /// </summary>
        /// <param name="value">Vector3 文本。</param>
        /// <returns>Vector3 值。</returns>
        public static Vector3 ParseVector3(string value)
        {
            string[] splitValue = value.Split(',');
            return new Vector3(float.Parse(splitValue[0]), float.Parse(splitValue[1]), float.Parse(splitValue[2]));
        }

        /// <summary>
        /// 解析 Vector4，形如 30.0,40.0,50.0,0.0 。
        /// </summary>
        /// <param name="value">Vector4 文本。</param>
        /// <returns>Vector4 值。</returns>
        public static Vector4 ParseVector4(string value)
        {
            string[] splitValue = value.Split(',');
            return new Vector4(float.Parse(splitValue[0]), float.Parse(splitValue[1]), float.Parse(splitValue[2]),
                float.Parse(splitValue[3]));
        }

        /// <summary>
        /// 解析 DateTime，形如 2009-05-01 14:57:32.8 。
        /// </summary>
        /// <param name="value">DateTime 文本。</param>
        /// <returns>DateTime 值。</returns>
        public static DateTime ParseDateTime(string value)
        {
            if (DateTime.TryParse(value, out var dateTime))
            {
                return dateTime;
            }
            else
            {
                Log.Error($"Failed to parse DateTime {value}.");
                return DateTime.Now;
            }
        }
    }
}