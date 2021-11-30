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
    /// 声效表
    /// </summary>
    public partial class DRSound : DataRowBase
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

	private bool m_Loop;
	/// <summary>
	/// 是否循环
	/// <summary>
	public bool Loop => m_Loop;

	private float m_Volume;
	/// <summary>
	/// 音量（0~1）
	/// <summary>
	public float Volume => m_Volume;

	private float m_SpatialBlend;
	/// <summary>
	/// 声音空间混合量（0为2D，1为3D，中间值混合效果）
	/// <summary>
	public float SpatialBlend => m_SpatialBlend;

	private float m_MaxDistance;
	/// <summary>
	/// 声音最大距离
	/// <summary>
	public float MaxDistance => m_MaxDistance;

        public override bool ParseDataRow(string dataRowString, object userData)
        {
            string[] columnStrings = dataRowString.Split(DataTableExtension.DataSplitSeparators);

            int index = 0;


		m_Id = int.Parse(columnStrings[index++]);
		m_AssetName = columnStrings[index++];
		m_Priority = int.Parse(columnStrings[index++]);
		m_Loop = bool.Parse(columnStrings[index++]);
		m_Volume = float.Parse(columnStrings[index++]);
		m_SpatialBlend = float.Parse(columnStrings[index++]);
		m_MaxDistance = float.Parse(columnStrings[index++]);

            return true;
        }
    }
}
