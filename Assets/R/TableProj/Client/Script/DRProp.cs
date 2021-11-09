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
    /// 背包表
    /// </summary>
    public partial class DRProp : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 编号。
        /// </summary>
        public override int Id => m_Id;



	private int m_GroupId;
	/// <summary>
	/// 物品组名
		/// <summary>
	public int GroupId => m_GroupId;

	private int m_ItemId;
	/// <summary>
	/// 物品组中的Id
		/// <summary>
	public int ItemId => m_ItemId;

	private int m_Name;
	/// <summary>
	/// 物品名
		/// <summary>
	public int Name => m_Name;

	private int m_Description;
	/// <summary>
	/// 物品描述
		/// <summary>
	public int Description => m_Description;

	private string m_Icon;
	/// <summary>
	/// 物品Icon
	/// <summary>
	public string Icon => m_Icon;

        public override bool ParseDataRow(string dataRowString, object userData)
        {
            string[] columnStrings = dataRowString.Split(DataTableExtension.DataSplitSeparators);

            int index = 0;


		m_Id = int.Parse(columnStrings[index++]);
		m_GroupId = int.Parse(columnStrings[index++]);
		m_ItemId = int.Parse(columnStrings[index++]);
		m_Name = int.Parse(columnStrings[index++]);
		m_Description = int.Parse(columnStrings[index++]);
		m_Icon = columnStrings[index++];

            return true;
        }
    }
}
