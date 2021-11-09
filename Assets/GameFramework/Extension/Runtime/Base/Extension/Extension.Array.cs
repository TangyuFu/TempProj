using System;

namespace UnityGameFramework.Runtime.Extension
{
    public static partial class Extension
    {
        /// <summary>
        /// 数组遍历。
        /// </summary>
        /// <param name="array">要遍历的数组。</param>
        /// <param name="action">遍历数组的行为。</param>
        /// <typeparam name="T">数组元素类型。</typeparam>
        public static void Foreach<T>(this T[] array, Action<T> action)
        {
            if (array == null || array.Length == 0)
            {
                return;
            }

            Array.ForEach(array, action);
        }
    }
}