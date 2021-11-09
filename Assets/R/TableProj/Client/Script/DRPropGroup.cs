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
    /// 背包组表
    /// </summary>
    public partial class DRPropGroup : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 编号。
        /// </summary>
        public override int Id => m_Id;



	private bool m_ShowInBackpack;
	/// <summary>
	/// 是否出现在背包中
	/// <summary>
	public bool ShowInBackpack => m_ShowInBackpack;

	private string m_AtlasName;
	/// <summary>
	/// 
	/// <summary>
	public string AtlasName => m_AtlasName;

        public override bool ParseDataRow(string dataRowString, object userData)
        {
            string[] columnStrings = dataRowString.Split(DataTableExtension.DataSplitSeparators);

            int index = 0;


		m_Id = int.Parse(columnStrings[index++]);
		m_ShowInBackpack = bool.Parse(columnStrings[index++]);
		m_AtlasName = columnStrings[index++];

            return true;
        }
    }
}
