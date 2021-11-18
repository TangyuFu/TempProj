using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 实体列表。
    /// </summary>
    /// <typeparam name="TEntityPresenter">列表元素实体代表者类型。</typeparam>
    /// <typeparam name="TEntityData">列表元素实体数据。</typeparam>
    public sealed class EntityList<TEntityPresenter, TEntityData> : IEntityList
        where TEntityPresenter : class, IEntityPresenter
        where TEntityData : CustomEntityData
    {
        private readonly List<TEntityPresenter> m_EntityPresenters = new List<TEntityPresenter>();

        private readonly List<int> m_EntityIds = new List<int>();

        public EntityList()
        {
        }

        public void OnShow(int entityId, IEntityPresenter entityPresenter)
        {
            int subSiblingCount = 0;
            int index = -1;
            for (int i = 0; i < m_EntityIds.Count; i++)
            {
                if (m_EntityIds[i] == entityId)
                {
                    index = i;
                    break;
                }
                
                if (m_EntityPresenters[i] == null)
                {
                    subSiblingCount++;
                }
            }
            
            if (index == -1)
            {
                return;
            }

            int siblingIndex = index - subSiblingCount;
            Transform targetTransform = entityPresenter.Root.transform;
            if (targetTransform.GetSiblingIndex() != siblingIndex)
            {
                targetTransform.SetSiblingIndex(siblingIndex);
            }

            m_EntityPresenters[index] = entityPresenter as TEntityPresenter;
        }

        public void OnHide(int entityId, IEntityPresenter entityPresenter)
        {
            // int index = m_SerialIds.FindIndex(id => serialId == id);
            // if (index == -1)
            // {
            //     return;
            // }
            //
            // m_EntityPresenters.RemoveAt(serialId);
        }

        /// <summary>
        /// 添加实体。
        /// </summary>
        /// <param name="entityDataList">要添加的元素实体数据列表。</param>
        public void Add(List<TEntityData> entityDataList)
        {
            foreach (var entityData in entityDataList)
            {
                Add(entityData);
            }
        }

        /// <summary>
        /// 添加实体到末尾。
        /// </summary>
        /// <param name="entityData">要添加的实体数据。</param>
        public void Add(TEntityData entityData)
        {
            m_EntityIds.Add(entityData.EntityId);
            m_EntityPresenters.Add(null);
            Entry.Entity.ShowEntity(entityData);
        }

        /// <summary>
        /// 添加实体到对应位置。
        /// </summary>
        /// <param name="entityData">要添加的实体。</param>
        /// <param name="index">对应的位置。</param>
        public void AddAtIndex(TEntityData entityData, int index)
        {
            m_EntityIds.Insert(index, entityData.EntityId);
            m_EntityPresenters.Add(null);
            Entry.Entity.ShowEntity(entityData);
        }

        /// <summary>
        /// 删除实体。
        /// </summary>
        /// <param name="entityId">实体 Id。</param>
        /// <returns>是否删除成功。</returns>
        public bool Remove(int entityId)
        {
            int index = m_EntityIds.FindIndex(value => entityId == value);
            if (index == -1)
            {
                return false;
            }

            return RemoveAtIndex(index);
        }

        /// <summary>
        /// 删除实体。
        /// </summary>
        /// <param name="presenter">要删除的实体代表者。</param>
        /// <returns></returns>
        public bool Remove(TEntityPresenter presenter)
        {
            int index = m_EntityPresenters.FindIndex(value => value == presenter);
            if (index == -1)
            {
                return false;
            }

            return RemoveAtIndex(index);
        }

        /// <summary>
        /// 指定位置删除实体。
        /// </summary>
        /// <param name="index">实体位置。</param>
        /// <returns>是否删除成功。</returns>
        public bool RemoveAtIndex(int index)
        {
            if (index > -1 && index < m_EntityIds.Count)
            {
                Entry.Entity.HideEntity(m_EntityIds[index]);
                m_EntityIds.RemoveAt(index);
                m_EntityPresenters.RemoveAt(index);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 删除所有实体元素。
        /// </summary>
        public void RemoveAll()
        {
            foreach (var serialId in m_EntityIds)
            {
                Entry.Entity.HideEntity(serialId);
            }

            m_EntityIds.Clear();
            m_EntityPresenters.Clear();
        }

        /// <summary>
        /// 获取实体代表者。
        /// </summary>
        /// <param name="entityId">实体 Id。</param>
        /// <returns>获取到的实体代表真。</returns>
        public TEntityPresenter Get(int entityId)
        {
            int index = m_EntityIds.FindIndex(value => entityId == value);
            if (index == -1)
            {
                return null;
            }

            return GetAtIndex(index);
        }

        public int GetIndex(int entityId)
        {
            return m_EntityIds.IndexOf(entityId);
        }
        
        /// <summary>
        /// 获取实体代表者。
        /// </summary>
        /// <param name="predicate">获取条件。</param>
        /// <returns>获取到的实体代表真。</returns>
        public TEntityPresenter Get(Predicate<TEntityPresenter> predicate)
        {
            foreach (var presenter in m_EntityPresenters)
            {
                if (predicate(presenter))
                {
                    return presenter;
                }
            }

            return null;
        }

        /// <summary>
        /// 获取实体代表者。
        /// </summary>
        /// <param name="predicate">获取条件。</param>
        /// <param name="results">获取结果。</param>
        public void Get(Predicate<TEntityPresenter> predicate, List<TEntityPresenter> results)
        {
            results.Clear();
            foreach (var presenter in m_EntityPresenters)
            {
                if (predicate(presenter))
                {
                    results.Add(presenter);
                }
            }
        }

        /// <summary>
        /// 获取指定位置实体代表者。
        /// </summary>
        /// <param name="index">指定的位置。</param>
        /// <returns>获取到的实体代表者。</returns>
        public TEntityPresenter GetAtIndex(int index)
        {
            if (index > -1 && index < m_EntityIds.Count)
            {
                return m_EntityPresenters[index];
            }

            return null;
        }

        /// <summary>
        /// 遍历实体。
        /// </summary>
        /// <param name="action">便利行为</param>
        public void Foreach(Action<TEntityPresenter> action)
        {
            foreach (var presenter in m_EntityPresenters)
            {
                action(presenter);
            }
        }
    }
}