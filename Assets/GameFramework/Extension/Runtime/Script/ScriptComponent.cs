using System;
using GameFramework.Resource;
using Puerts;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// Unity 游戏框架脚本组件。
    /// 提供热更新脚本语言的运行功能。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Script")]
    public sealed class ScriptComponent : CustomGameFrameworkComponent
    {
        public Action StartupCallback;
        public Action UpdateCallback;
        public Action ShutdownCallback;

        private JsEnv m_JsEnv;

        /// <summary>
        /// 初始化脚本组件。
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
        }

        /// <summary>
        /// 启动脚本语言。
        /// </summary>
        public void TurnOn()
        {
            const string bundleAssetName = "Assets/R/Src/bundle.js";
            Entry.Resource.LoadBinary(bundleAssetName, new LoadBinaryCallbacks(
                delegate(string assetName, byte[] bytes, float duration, object data)
                {
                    string chunk = UUtility.Convert.Bytes2String(bytes);
                    try
                    {
                        m_JsEnv = new JsEnv();
                        m_JsEnv.UsingAction<bool>();
                        m_JsEnv.UsingAction<int>();
                        m_JsEnv.UsingAction<float>();
                        m_JsEnv.UsingAction<Vector2>();
                        m_JsEnv.UsingAction<Vector3>();
                        m_JsEnv.UsingAction<RaycastHit>();
                        m_JsEnv.UsingAction<GameObject>();
                        m_JsEnv.UsingAction<Transform>();
                        m_JsEnv.Eval(chunk);
                        StartupCallback?.Invoke();
                    }
                    catch (Exception e)
                    {
                        m_JsEnv?.Dispose();
                        m_JsEnv = null;
                        StartupCallback = null;
                        UpdateCallback = null;
                        ShutdownCallback = null;
                        Debug.LogError($"Failed to initialize js env with exception '{e}'.");
                    }
                },
                delegate(string assetName, LoadResourceStatus status, string message, object data)
                {
                    Debug.LogError(
                        $"Failed to load bundle.js from '{assetName}' with status '{status}' message '{message}'.");
                }));
        }

        /// <summary>
        /// 关闭脚本语言。
        /// </summary>
        public void TurnOff()
        {
            ShutdownCallback?.Invoke();
            m_JsEnv?.Dispose();
            m_JsEnv = null;
            StartupCallback = null;
            UpdateCallback = null;
            ShutdownCallback = null;
        }

        /// <summary>
        /// 脚本组件优先级。
        /// </summary>
        internal override int Priority => ComponentPriority.Script;

        /// <summary>
        /// 脚本组件轮询。
        /// </summary>
        /// <param name="elapseSeconds">游戏逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">游戏真实流逝时间，以秒为单位。</param>
        internal override void Poll(float elapseSeconds, float realElapseSeconds)
        {
            m_JsEnv?.Tick();
            UpdateCallback?.Invoke();
        }

        /// <summary>
        /// 关闭并清理脚本组件。
        /// </summary>
        internal override void Shutdown()
        {
            TurnOff();
        }
    }
}