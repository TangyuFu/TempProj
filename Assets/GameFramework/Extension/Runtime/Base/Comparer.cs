using System;
using System.Collections.Generic;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 比较器。
    /// </summary>
    public struct Comparer<TKey, TValue> : IComparer<TKey> where TValue : IComparable<TValue>
    {
        /// <summary>
        /// 获取比较值函数。
        /// </summary>
        private readonly Func<TKey, TValue> m_Func;

        /// <summary>
        /// 以比较值函数初始化比较器新实例。
        /// </summary>
        /// <param name="func"></param>
        public Comparer(Func<TKey, TValue> func)
        {
            m_Func = func ?? throw new NullReferenceException($"Invalid get value function '{func}'.");
        }

        /// <summary>
        /// 实现比较器接口。
        /// </summary>
        /// <param name="x">比较左值。</param>
        /// <param name="y">比较右值。</param>
        /// <returns>比较结果。</returns>
        public int Compare(TKey x, TKey y)
        {
            return m_Func(x).CompareTo(m_Func(y));
        }
    }
}