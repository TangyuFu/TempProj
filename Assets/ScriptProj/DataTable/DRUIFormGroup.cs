using GameFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using UnityGameFramework.Runtime.Extension;

namespace TempProj.DataTable
{
    /// <summary>
    /// 界面组表
    /// </summary>
    public partial class DRUIFormGroup : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 编号。
        /// </summary>
        public override int Id => m_Id;



	private string m_GroupName;
	/// <summary>
	/// 界面组名
	/// <summary>
	public string GroupName => m_GroupName;

	private int m_GroupDepth;
	/// <summary>
	/// 界面组名称
		/// <summary>
	public int GroupDepth => m_GroupDepth;

        public override bool ParseDataRow(string dataRowString, object userData)
        {
            string[] columnStrings = dataRowString.Split(DataTableExtension.DataSplitSeparators);

            int index = 0;


		m_Id = int.Parse(columnStrings[index++]);
		m_GroupName = columnStrings[index++];
		m_GroupDepth = int.Parse(columnStrings[index++]);

            return true;
        }
    }
}
