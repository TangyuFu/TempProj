using System;
using System.Collections.Generic;
using GameFramework;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 自定义游戏框架入口。
    /// </summary>
    internal static class CustomGameFrameworkEntry
    {
        private static readonly GameFrameworkLinkedList<CustomGameFrameworkComponent> s_Components = new();

        /// <summary>
        /// 所有自定义游戏框架组件轮询。
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        internal static void Update(float elapseSeconds, float realElapseSeconds)
        {
            foreach (CustomGameFrameworkComponent component in s_Components)
            {
                component.Poll(elapseSeconds, realElapseSeconds);
            }
        }

        /// <summary>
        /// 关闭并清理所有游戏框架组件。
        /// </summary>
        public static void Shutdown()
        {
            for (LinkedListNode<CustomGameFrameworkComponent> current = s_Components.Last;
                current != null;
                current = current.Previous)
            {
                current.Value.Shutdown();
            }

            s_Components.Clear();
        }

        /// <summary>
        /// 获取自定义游戏框架组件。
        /// </summary>
        /// <typeparam name="T">要获取的自定义游戏框架组件类型。</typeparam>
        /// <returns>要获取的自定义游戏框架组件。</returns>
        public static T GetComponent<T>() where T : CustomGameFrameworkComponent
        {
            return (T) GetComponent(typeof(T));
        }

        /// <summary>
        /// 获取自定义游戏框架组件。
        /// </summary>
        /// <param name="type">要获取的自定义游戏框架组件类型。</param>
        /// <returns>要获取的自定义游戏框架组件。</returns>
        public static CustomGameFrameworkComponent GetComponent(Type type)
        {
            foreach (CustomGameFrameworkComponent component in s_Components)
            {
                if (component.GetType() == type)
                {
                    return component;
                }
            }

            return null;
        }

        /// <summary>
        /// 注册自定义游戏框架组件。
        /// </summary>
        public static void RegisterComponent<T>(T component) where T : CustomGameFrameworkComponent
        {
        }

        /// <summary>
        /// 注册自定义游戏框架组件。
        /// </summary>
        /// <param name="component">要注册的自定义游戏框架组件。</param>
        public static void RegisterComponent(CustomGameFrameworkComponent component)
        {
            LinkedListNode<CustomGameFrameworkComponent> current = s_Components.First;
            while (current != null)
            {
                if (component.Priority > current.Value.Priority)
                {
                    break;
                }

                current = current.Next;
            }

            if (current != null)
            {
                s_Components.AddBefore(current, component);
            }
            else
            {
                s_Components.AddLast(component);
            }
        }
    }
}