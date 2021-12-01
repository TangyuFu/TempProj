using System;
using GameFramework;
using GameFramework.DataTable;
using TempProj.DataTable;
using UnityEngine;
using UnityGameFramework.Runtime;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    /// <summary>
    /// 自定义实体数据。
    /// </summary>
    [Serializable]
    public abstract class EntityData : IReference
    {
        private int m_EntityId = 0;

        private int m_TypeId = 0;

        private DREntity m_DrEntity = null;

        private DREntityGroup m_DrEntityGroup = null;

        private Transform m_Parent = null;

        private Vector3 m_Position = Vector3.zero;

        private Vector3 m_Scale = Vector3.one;

        private Quaternion m_Rotation = Quaternion.identity;

        /// <summary>
        /// 实体编号。
        /// </summary>
        public int EntityId
        {
            get => m_EntityId;
            set => m_EntityId = value;
        }

        /// <summary>
        /// 实体配置。
        /// </summary>
        public DREntity DrEntity
        {
            get => m_DrEntity;
            set
            {
                if (value != null)
                {
                    m_DrEntity = value;
                    m_TypeId = m_DrEntity.GroupId;
                    IDataTable<DREntityGroup> dtEntityGroups = Entry.DataTable.GetDataTable<DREntityGroup>();
                    m_DrEntityGroup = dtEntityGroups.GetDataRow(m_DrEntity.GroupId);
                    if (m_DrEntityGroup == null)
                    {
                        Log.Error($"Failed to find entity group with id '{m_DrEntity.GroupId}'");
                    }
                }
                else
                {
                    Log.Error($"Invalid drEntity '{m_DrEntity}'");
                }
            }
        }

        /// <summary>
        /// 实体配置。
        /// </summary>
        public DREntityGroup DrEntityGroup
        {
            get => m_DrEntityGroup;
        }

        /// <summary>
        /// 实体类型编号。
        /// </summary>
        public int TypeId
        {
            get => m_TypeId;
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
        /// 实体本地位置。
        /// </summary>
        public Vector3 Position
        {
            get => m_Position;
            set => m_Position = value;
        }

        /// <summary>
        /// 实体本地缩放。
        /// </summary>
        public Vector3 Scale
        {
            get => m_Scale;
            set => m_Scale = value;
        }

        /// <summary>
        /// 实体本地旋转。
        /// </summary>
        public Quaternion Rotation
        {
            get => m_Rotation;
            set => m_Rotation = value;
        }

        /// <summary>
        /// 清理实体数据。
        /// </summary>
        public virtual void Clear()
        {
            m_EntityId = default;
            m_TypeId = default;
            m_DrEntityGroup = default;
            m_DrEntity = default;
            m_Parent = default;
            m_Position = Vector3.zero;
            m_Scale = Vector3.one;
            m_Rotation = Quaternion.identity;
        }
    }
}