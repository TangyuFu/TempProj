using System;
using System.Collections.Generic;
using GameFramework.Resource;
using UnityEngine;
using UnityEngine.Events;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// Unity 游戏框架客制化 Resource 组件。
    /// 提供 Resource 加载和取消加载功能。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/R")]
    public sealed partial class RComponent : CustomGameFrameworkComponent
    {
        private static int s_SerialId = 0;

        private LoadAssetCallbacks m_LoadAssetCallbacks;

        private readonly Dictionary<int, LoadAssetInfo> m_LoadAssetInfos = new Dictionary<int, LoadAssetInfo>();

        /// <summary>
        /// 初始化 R 组件。
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            m_LoadAssetCallbacks = new LoadAssetCallbacks(OnLoadAssetSuccess, OnLoadAssetFailure);
        }

        public void RegisterCallback()
        {
            
        }

        /// <summary>
        /// 加载资源。
        /// </summary>
        /// <param name="assetName">资源名称。</param>
        /// <param name="assetType">资源类型。</param>
        /// <param name="successCallback">加载成功回调。</param>
        /// <param name="failureCallback">加载失败回调。</param>
        /// <param name="priority">优先级。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>资源加载序列号。</returns>
        public int LoadAsset(string assetName, Type assetType, UnityAction<string, object, object> successCallback,
            UnityAction<string, string, object> failureCallback = null,
            int priority = 0,
            object userData = null)
        {
            s_SerialId++;
            LoadAssetInfo info = LoadAssetInfo.Create(s_SerialId, successCallback, failureCallback, userData);
            m_LoadAssetInfos.Add(s_SerialId, info);
            Entry.Resource.LoadAsset(assetName, assetType, priority, m_LoadAssetCallbacks, info);
            return s_SerialId;
        }

        /// <summary>
        /// 取消加载资源。
        /// </summary>
        /// <param name="serialId">资源加载序列号。</param>
        /// <returns>是否取消加载资源成功。</returns>
        public bool CancelLoadAsset(int serialId)
        {
            return m_LoadAssetInfos.Remove(serialId);
        }

        private void OnLoadAssetSuccess(string assetName, object asset, float duration, object userData)
        {
            if (userData is LoadAssetInfo info)
            {
                if (m_LoadAssetInfos.TryGetValue(info.SerialId, out var loadAssetInfo))
                {
                    loadAssetInfo.SuccessCallback(assetName, asset, loadAssetInfo.UserData);
                    m_LoadAssetInfos.Remove(info.SerialId);
                }
            }
        }

        private void OnLoadAssetFailure(string assetName, LoadResourceStatus status, string errorMessage,
            object userData)
        {
            if (userData is LoadAssetInfo info)
            {
                if (m_LoadAssetInfos.TryGetValue(info.SerialId, out var loadAssetInfo))
                {
                    loadAssetInfo.FailureCallback(assetName, errorMessage, loadAssetInfo.UserData);
                    m_LoadAssetInfos.Remove(info.SerialId);
                }
            }
        }

        private void OnLoadAssetUpdate(string assetName, float progress, object userData)
        {
        }

        private void OnLoadAssetDependency(string assetName, string dependencyAssetName, int loadedCount,
            int totalCount, object userData)
        {
        }
        
        internal override int Priority { get; } = ComponentPriority.R;

        internal override void Poll(float elapseSeconds, float realElapseSeconds)
        {
        }

        internal override void Shutdown()
        {
            m_LoadAssetInfos.Clear();
        }
    }
}