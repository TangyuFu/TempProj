using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// Unity 游戏框架玩家数据组件。
    /// 提供玩家数据本地与远程无缝切换的存储功能。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Player Data")]
    public sealed class PlayerDataComponent : CustomGameFrameworkComponent
    {
        private readonly Dictionary<Type, IPlayerDataAgent> m_PlayerDataAgents =
            new Dictionary<Type, IPlayerDataAgent>();

        /// <summary>
        /// 初始化玩家数据组件。
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
        }

        /// <summary>
        /// 获取玩家数据代理。
        /// </summary>
        /// <typeparam name="T">玩家数据代理类型。</typeparam>
        /// <returns>玩家数据代理。</returns>
        public T GetDataAgent<T>() where T : IPlayerDataAgent, new()
        {
            return (T) GetDataAgent(typeof(T));
        }

        /// <summary>
        /// 获取玩家数据代理。
        /// </summary>
        /// <param name="type">玩家数据代理类型。</param>
        /// <returns>玩家数据代理。</returns>
        public IPlayerDataAgent GetDataAgent(Type type)
        {
            if (type == null)
            {
                Log.Error($"Invalid type '{null}'.");
                return null;
            }

            if (!typeof(IPlayerDataAgent).IsAssignableFrom(type))
            {
                Log.Error($"Invalid type '{type.FullName}', not assignable from '{typeof(IPlayerDataAgent)}'.");
                return null;
            }

            if (!m_PlayerDataAgents.TryGetValue(type, out var playerDataAgent))
            {
                playerDataAgent = Activator.CreateInstance(type) as IPlayerDataAgent;
                if (playerDataAgent == null)
                {
                    Log.Error($"Failed to create player data agent from '{type.FullName}'.");
                    return null;
                }

                if (!playerDataAgent.Load())
                {
                    Log.Error($"Failed to load player data agent from '{type.FullName}'.");
                }

                m_PlayerDataAgents.Add(type, playerDataAgent);
            }

            return playerDataAgent;
        }

        /// <summary>
        /// 获取所有玩家数据代理。
        /// </summary>
        /// <returns>所有玩家数据代理。</returns>
        public IPlayerDataAgent[] GetAllDataAgent()
        {
            List<IPlayerDataAgent> list = new List<IPlayerDataAgent>();
            GetAllDataAgent(list);
            return list.ToArray();
        }

        /// <summary>
        /// 获取所有玩家数据代理。
        /// </summary>
        /// <param name="results">所有玩家数据代理。</param>
        public void GetAllDataAgent(List<IPlayerDataAgent> results)
        {
            if (results == null)
            {
                Log.Error($"Invalid player data agent list '{null}'.");
                return;
            }

            results.Clear();
            foreach (var playerDataAgent in m_PlayerDataAgents)
            {
                results.Add(playerDataAgent.Value);
            }
        }

        /// <summary>
        /// 删除玩家数据代理。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>是否删除玩家数据代理成功。</returns>
        public bool RemoveDataAgent<T>() where T : IPlayerDataAgent
        {
            return RemoveDataAgent(typeof(T));
        }

        /// <summary>
        /// 删除玩家数据代理。
        /// </summary>
        /// <param name="type">玩家数据代理类型。</param>
        /// <returns>是否删除玩家数据代理成功。</returns>
        public bool RemoveDataAgent(Type type)
        {
            if (type == null)
            {
                Log.Error($"Invalid type '{null}'.");
                return false;
            }

            return m_PlayerDataAgents.Remove(type);
        }

        /// <summary>
        /// 删除玩家数据代理。
        /// </summary>
        /// <param name="playerDataAgent">玩家数据代理。</param>
        public bool RemoveDataAgent(IPlayerDataAgent playerDataAgent)
        {
            if (playerDataAgent == null)
            {
                Log.Error($"Invalid player data agent '{null}'.");
                return false;
            }

            return m_PlayerDataAgents.Remove(playerDataAgent.GetType());
        }

        /// <summary>
        /// 删除所有玩家数据代理。
        /// </summary>
        public void RemoveAllDataAgent()
        {
            m_PlayerDataAgents.Clear();
        }

        /// <summary>
        /// 保存玩家数据代理。
        /// </summary>
        /// <typeparam name="T">玩家数据代理类型。</typeparam>
        /// <returns>返回是否保存玩家数据代理成功。</returns>
        public bool SaveDataAgent<T>() where T : IPlayerDataAgent
        {
            return SaveDataAgent(typeof(T));
        }

        /// <summary>
        /// 保存玩家数据代理。
        /// </summary>
        /// <param name="type">玩家数据代理类型。</param>
        /// <returns>返回是否保存玩家数据代理成功。</returns>
        public bool SaveDataAgent(Type type)
        {
            if (type == null)
            {
                Log.Error($"Invalid type '{null}'.");
                return false;
            }

            if (m_PlayerDataAgents.TryGetValue(type, out var playerDataAgent))
            {
                playerDataAgent.Save();
                return true;
            }

            return false;
        }

        /// <summary>
        /// 保存玩家数据代理。
        /// </summary>
        /// <param name="playerDataAgent">玩家数据代理。</param>
        public void SaveDataAgent(IPlayerDataAgent playerDataAgent)
        {
            if (playerDataAgent == null)
            {
                Log.Error($"Invalid player data agent '{null}'.");
                return;
            }

            playerDataAgent.Save();
        }

        /// <summary>
        /// 保存所有玩家数据代理。
        /// </summary>
        public void SaveAllDataAgent()
        {
            foreach (var playerDataAgent in m_PlayerDataAgents)
            {
                if (!playerDataAgent.Value.Save())
                {
                    Log.Error($"Failed to save player data agent '{playerDataAgent.Key.FullName}'.");
                }
            }
        }

        /// <summary>
        /// 玩家数据组件优先级。
        /// </summary>
        internal override int Priority => ComponentPriority.PlayerData;

        /// <summary>
        /// 玩家数据组件轮询。
        /// </summary>
        /// <param name="elapseSeconds">游戏逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">游戏真实流逝时间，以秒为单位。</param>
        internal override void Poll(float elapseSeconds, float realElapseSeconds)
        {
        }

        /// <summary>
        /// 关闭并清理玩家数据组件。
        /// </summary>
        internal override void Shutdown()
        {
            SaveAllDataAgent();

            m_PlayerDataAgents.Clear();
        }
    }
}