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
    /// 声音组表
    /// </summary>
    public partial class DRSoundGroup : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 编号。
        /// </summary>
        public override int Id => m_Id;



	private string m_GroupName;
	/// <summary>
	/// 声音组名
	/// <summary>
	public string GroupName => m_GroupName;

	private bool m_AvoidBeingReplaced;
	/// <summary>
	/// 声音是否避免被同优先级声音替换
	/// <summary>
	public bool AvoidBeingReplaced => m_AvoidBeingReplaced;

	private bool m_Mute;
	/// <summary>
	/// 声音组是否静音
	/// <summary>
	public bool Mute => m_Mute;

	private float m_Volume;
	/// <summary>
	/// 音量
	/// <summary>
	public float Volume => m_Volume;

	private int m_AgentHelperCount;
	/// <summary>
	/// 代理辅助器数量
		/// <summary>
	public int AgentHelperCount => m_AgentHelperCount;

        public override bool ParseDataRow(string dataRowString, object userData)
        {
            string[] columnStrings = dataRowString.Split(DataTableExtension.DataSplitSeparators);

            int index = 0;


		m_Id = int.Parse(columnStrings[index++]);
		m_GroupName = columnStrings[index++];
		m_AvoidBeingReplaced = bool.Parse(columnStrings[index++]);
		m_Mute = bool.Parse(columnStrings[index++]);
		m_Volume = float.Parse(columnStrings[index++]);
		m_AgentHelperCount = int.Parse(columnStrings[index++]);

            return true;
        }
    }
}
