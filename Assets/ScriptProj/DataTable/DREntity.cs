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
    /// 实体表
    /// </summary>
    public partial class DREntity : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 编号。
        /// </summary>
        public override int Id => m_Id;



	private int m_From;
	/// <summary>
	/// 实体源 1-Model 2-Effect 3-UI
		/// <summary>
	public int From => m_From;

	private int m_GroupId;
	/// <summary>
	/// 实体组Id
		/// <summary>
	public int GroupId => m_GroupId;

	private string m_AssetName;
	/// <summary>
	/// 资源名
	/// <summary>
	public string AssetName => m_AssetName;

	private int m_Priority;
	/// <summary>
	/// 优先级
		/// <summary>
	public int Priority => m_Priority;

        public override bool ParseDataRow(string dataRowString, object userData)
        {
            string[] columnStrings = dataRowString.Split(DataTableExtension.DataSplitSeparators);

            int index = 0;


		m_Id = int.Parse(columnStrings[index++]);
		m_From = int.Parse(columnStrings[index++]);
		m_GroupId = int.Parse(columnStrings[index++]);
		m_AssetName = columnStrings[index++];
		m_Priority = int.Parse(columnStrings[index++]);

            return true;
        }
    }
}
