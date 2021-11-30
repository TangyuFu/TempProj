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
    /// 背包资源表
    /// </summary>
    public partial class DRPropResource : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 编号。
        /// </summary>
        public override int Id => m_Id;



        public override bool ParseDataRow(string dataRowString, object userData)
        {
            string[] columnStrings = dataRowString.Split(DataTableExtension.DataSplitSeparators);

            int index = 0;


		m_Id = int.Parse(columnStrings[index++]);

            return true;
        }
    }
}
