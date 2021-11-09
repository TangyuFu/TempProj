using System;
using System.Reflection;
using GameFramework;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 单例基类。
    /// </summary>
    /// <typeparam name="T">单例类型。</typeparam>
    public abstract class Singleton<T> : ISingleton where T : Singleton<T>
    {
        /// <summary>
        /// 单例线程锁。
        /// </summary>
        private static readonly object m_Locker = new object();

        private static T m_Instance;

        /// <summary>
        /// 单例类的实例。
        /// </summary>
        public static T Instance
        {
            get
            {
                lock (m_Locker)
                {
                    if (m_Instance == null)
                    {
                        m_Instance = SingletonFactory.CreateSingleton<T>();
                        m_Instance.OnCreate();
                    }

                    return m_Instance;
                }
            }
        }

        /// <summary>
        /// 初始化单例。
        /// </summary>
        public virtual void OnCreate()
        {
        }

        /// <summary>
        /// 反初始化单例。
        /// </summary>
        public virtual void OnDestroy()
        {
        }
    }

    internal static class SingletonFactory
    {
        public static T CreateSingleton<T>() where T : Singleton<T>
        {
            ConstructorInfo[] constructorInfos = typeof(T).GetConstructors();
            ConstructorInfo constructorInfo = Array.Find(constructorInfos, c => c.GetParameters().Length == 0);
            if (constructorInfo == null)
            {
                throw new GameFrameworkException($"Failed to find non-parameter constructor in '{nameof(T)}'.");
            }

            if (!(constructorInfo.Invoke(null) is T singleton))
            {
                throw new GameFrameworkException($"Failed to create singleton from '{nameof(T)}'.");
            }

            return singleton;
        }
    }
}