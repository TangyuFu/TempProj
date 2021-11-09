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
    /// 常量配置表
    /// </summary>
    public partial class DRConstant : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 编号。
        /// </summary>
        public override int Id => m_Id;



	private string m_value;
	/// <summary>
	/// 备注-字符串
	/// <summary>
	public string value => m_value;

        public override bool ParseDataRow(string dataRowString, object userData)
        {
            string[] columnStrings = dataRowString.Split(DataTableExtension.DataSplitSeparators);

            int index = 0;


		m_Id = int.Parse(columnStrings[index++]);
		m_value = columnStrings[index++];

            return true;
        }
    }
}
