using GameFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using UnityGameFramework.Runtime.Extension;

namespace UnityGameFramework.Runtime.Extension.DataTable
{
    /// <summary>
    /// 背景音乐表
    /// </summary>
    public partial class DRMusic : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 编号。
        /// </summary>
        public override int Id => m_Id;



	private string m_AssetName;
	/// <summary>
	/// 资源名
	/// <summary>
	public string AssetName => m_AssetName;

        public override bool ParseDataRow(string dataRowString, object userData)
        {
            string[] columnStrings = dataRowString.Split(DataTableExtension.DataSplitSeparators);

            int index = 0;


		m_Id = int.Parse(columnStrings[index++]);
		m_AssetName = columnStrings[index++];

            return true;
        }
    }
}
