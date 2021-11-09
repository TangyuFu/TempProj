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
    /// 背包装备表
    /// </summary>
    public partial class DRPropEquipment : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 编号。
        /// </summary>
        public override int Id => m_Id;



	private int m_Grade;
	/// <summary>
	/// 品级
		/// <summary>
	public int Grade => m_Grade;

        public override bool ParseDataRow(string dataRowString, object userData)
        {
            string[] columnStrings = dataRowString.Split(DataTableExtension.DataSplitSeparators);

            int index = 0;


		m_Id = int.Parse(columnStrings[index++]);
		m_Grade = int.Parse(columnStrings[index++]);

            return true;
        }
    }
}
