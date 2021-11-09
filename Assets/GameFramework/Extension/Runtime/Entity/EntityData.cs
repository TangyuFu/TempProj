using System;
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime.Extension.DataTable;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 自定义实体数据。
    /// </summary>
    [Serializable]
    public abstract class EntityData : IReference
    {
        private int m_EntityId = 0;

        private int m_TypeId = 0;

        private DREntity m_DrEntity;

        private Transform m_Parent;

        /// <summary>
        /// 实体编号。
        /// </summary>
        public int EntityId
        {
            get => m_EntityId;
            set => m_EntityId = value;
        }

        /// <summary>
        /// 实体类型编号。
        /// </summary>
        public int TypeId
        {
            get => m_TypeId;
            set => m_TypeId = value;
        }

        /// <summary>
        /// 实体数据表行数据。
        /// </summary>
        public DREntity DrEntity
        {
            get => m_DrEntity;
            set => m_DrEntity = value;
        }

        /// <summary>
        /// 实体父物体。
        /// </summary>
        public Transform Parent
        {
            get => m_Parent;
            set => m_Parent = value;
        }

        /// <summary>
        /// 清理实体数据。
        /// </summary>
        public virtual void Clear()
        {
            m_EntityId = default;
            m_TypeId = default;
            m_DrEntity = default;
            m_Parent = default;
        }
    }
}