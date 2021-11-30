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
    /// 界面表
    /// </summary>
    public partial class DRUIForm : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 编号。
        /// </summary>
        public override int Id => m_Id;



	private int m_GroupId;
	/// <summary>
	/// 界面组Id
		/// <summary>
	public int GroupId => m_GroupId;

	private string m_AssetName;
	/// <summary>
	/// 资源名称
	/// <summary>
	public string AssetName => m_AssetName;

	private bool m_AllowMultiInstance;
	/// <summary>
	/// 是否允许多个界面实例
	/// <summary>
	public bool AllowMultiInstance => m_AllowMultiInstance;

	private bool m_PauseCoveredUIForm;
	/// <summary>
	/// 是否暂停被遮挡界面
	/// <summary>
	public bool PauseCoveredUIForm => m_PauseCoveredUIForm;

	private bool m_IsLocked;
	/// <summary>
	/// 是否加锁
	/// <summary>
	public bool IsLocked => m_IsLocked;

	private string[] m_DependencyTables;
	/// <summary>
	/// 依赖数据表
	/// <summary>
	public string[] DependencyTables => m_DependencyTables;

        public override bool ParseDataRow(string dataRowString, object userData)
        {
            string[] columnStrings = dataRowString.Split(DataTableExtension.DataSplitSeparators);

            int index = 0;


		m_Id = int.Parse(columnStrings[index++]);
		m_GroupId = int.Parse(columnStrings[index++]);
		m_AssetName = columnStrings[index++];
		m_AllowMultiInstance = bool.Parse(columnStrings[index++]);
		m_PauseCoveredUIForm = bool.Parse(columnStrings[index++]);
		m_IsLocked = bool.Parse(columnStrings[index++]);
		m_DependencyTables = JsonConvert.DeserializeObject<string[]>(columnStrings[index++]);

            return true;
        }
    }
}
