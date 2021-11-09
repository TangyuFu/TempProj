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
    /// 界面音效表
    /// </summary>
    public partial class DRUISound : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 编号。
        /// </summary>
        public override int Id => m_Id;



	private string m_AssetName;
	/// <summary>
	/// 资源名称
	/// <summary>
	public string AssetName => m_AssetName;

	private int m_Priority;
	/// <summary>
	/// 优先级（默认0，128最高，-128最低）
		/// <summary>
	public int Priority => m_Priority;

	private float m_Volume;
	/// <summary>
	/// 音量（0~1）
	/// <summary>
	public float Volume => m_Volume;

        public override bool ParseDataRow(string dataRowString, object userData)
        {
            string[] columnStrings = dataRowString.Split(DataTableExtension.DataSplitSeparators);

            int index = 0;


		m_Id = int.Parse(columnStrings[index++]);
		m_AssetName = columnStrings[index++];
		m_Priority = int.Parse(columnStrings[index++]);
		m_Volume = float.Parse(columnStrings[index++]);

            return true;
        }
    }
}
