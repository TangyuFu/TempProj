using System.Collections.Generic;

namespace UnityGameFramework.Runtime.Extension
{
    public static partial class UUtility
    {
        /// <summary>
        /// 设置值类型的值
        /// </summary>
        /// <param name="currentValue">设置的当前值</param>
        /// <param name="newValue">设置的目标值</param>
        /// <typeparam name="T">值类型</typeparam>
        /// <returns>是否设置成功</returns>
        public static bool SetStruct<T>(ref T currentValue, T newValue) where T : struct
        {
            if (EqualityComparer<T>.Default.Equals(currentValue, newValue))
                return false;

            currentValue = newValue;
            return true;
        }

        /// <summary>
        /// 设置对象类型的值
        /// </summary>
        /// <param name="currentValue">设置的当前对象</param>
        /// <param name="newValue">设置的目标对象</param>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns>是否设置成功</returns>
        public static bool SetClass<T>(ref T currentValue, T newValue) where T : class
        {
            if ((currentValue == null && newValue == null) || (currentValue != null && currentValue.Equals(newValue)))
                return false;

            currentValue = newValue;
            return true;
        }

        /// <summary>
        /// 值类型的值是否相等
        /// </summary>
        /// <param name="left">第一个值类型</param>
        /// <param name="right">第二值类型</param>
        /// <typeparam name="T">值类型</typeparam>
        /// <returns>值类型是否相等</returns>
        public static bool EqualStruct<T>(ref T left, ref T right) where T : struct
        {
            if (EqualityComparer<T>.Default.Equals(left, right))
                return true;
            return false;
        }

        /// <summary>
        /// 对象类型是否相等
        /// </summary>
        /// <param name="left">第一个对象</param>
        /// <param name="right">第二个对象</param>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns>对象是否相等</returns>
        public static bool EqualClass<T>(ref T left, ref T right) where T : class
        {
            if ((left == null && right == null) || (left != null && left.Equals(right)))
                return true;
            return false;
        }
    }
}