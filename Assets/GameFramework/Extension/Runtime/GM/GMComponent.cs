using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// Unity 游戏框架 GM 组件。
    /// 提供注册到 Debugger 中的 GM 功能。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/GM")]
    public sealed partial class GMComponent : CustomGameFrameworkComponent
    {
        private const string AssemblyName = "Assembly-CSharp";

        private List<IGMOperator> m_Operators;

        public List<IGMOperator> Operators
        {
            get
            {
                if (m_Operators == null)
                {
                    m_Operators = new List<IGMOperator>();
                    Assembly assembly = Assembly.Load(AssemblyName);
                    Type[] types = assembly.GetTypes();
                    foreach (var type in types)
                    {
                        if (typeof(IGMOperator).IsAssignableFrom(type) && !type.IsAbstract)
                        {
                            IGMOperator @operator = Activator.CreateInstance(type) as IGMOperator;
                            if (@operator == null)
                            {
                                Log.Error($"Failed to creat operator '{type.FullName}'.");
                                continue;
                            }

                            Operators.Add(@operator);
                        }
                    }
                }

                return m_Operators;
            }
        }

        /// <summary>
        /// 初始化 R 组件。
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
        }

        internal override int Priority { get; } = ComponentPriority.GM;

        internal override void Poll(float elapseSeconds, float realElapseSeconds)
        {
        }

        internal override void Shutdown()
        {
            Operators.Clear();
        }
    }
}