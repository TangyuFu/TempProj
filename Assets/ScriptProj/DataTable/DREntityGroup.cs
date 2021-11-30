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
    /// 实体组表
    /// </summary>
    public partial class DREntityGroup : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 编号。
        /// </summary>
        public override int Id => m_Id;



	private string m_GroupName;
	/// <summary>
	/// 实体组名
	/// <summary>
	public string GroupName => m_GroupName;

	private float m_ReleaseInterval;
	/// <summary>
	/// 实例自动释放间隔
	/// <summary>
	public float ReleaseInterval => m_ReleaseInterval;

	private int m_Capacity;
	/// <summary>
	/// 实例容量
		/// <summary>
	public int Capacity => m_Capacity;

	private float m_ExpireTime;
	/// <summary>
	/// 实例过期时间
	/// <summary>
	public float ExpireTime => m_ExpireTime;

	private int m_Priority;
	/// <summary>
	/// 实例优先级
		/// <summary>
	public int Priority => m_Priority;

        public override bool ParseDataRow(string dataRowString, object userData)
        {
            string[] columnStrings = dataRowString.Split(DataTableExtension.DataSplitSeparators);

            int index = 0;


		m_Id = int.Parse(columnStrings[index++]);
		m_GroupName = columnStrings[index++];
		m_ReleaseInterval = float.Parse(columnStrings[index++]);
		m_Capacity = int.Parse(columnStrings[index++]);
		m_ExpireTime = float.Parse(columnStrings[index++]);
		m_Priority = int.Parse(columnStrings[index++]);

            return true;
        }
    }
}
