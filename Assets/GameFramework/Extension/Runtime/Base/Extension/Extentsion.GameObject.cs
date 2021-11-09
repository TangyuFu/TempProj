using System;
using System.Collections.Generic;
using GameFramework;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// Unity 游戏框架拓展。
    /// </summary>
    public static partial class Extension
    {
        private static readonly List<Transform> s_CachedTransforms = new List<Transform>();

        /// <summary>
        /// 获取游戏物体是否在场景中。
        /// </summary>
        /// <param name="go">要判定的游戏物体。</param>
        /// <returns>游戏物体是否在场景中。</returns>
        public static bool IsInScene(this GameObject go)
        {
            if (go == null)
            {
                throw new GameFrameworkException($"Invalid game object '{go}'.");
            }

            return go.scene.IsValid();
        }

        /// <summary>
        /// 获取或添加组件。
        /// </summary>
        /// <typeparam name="T">要获取或添加的组件。</typeparam>
        /// <param name="go">要获取或添加组件的游戏物体。</param>
        /// <returns>获取或添加的组件。</returns>
        public static T GetOrAddComponent<T>(this GameObject go) where T : Component
        {
            if (go == null)
            {
                throw new GameFrameworkException($"Invalid game object '{go}'.");
            }

            T component = go.GetComponent<T>();
            return component ? component : go.AddComponent<T>();
        }

        /// <summary>
        /// 获取或添加组件。
        /// </summary>
        /// <param name="go">要获取或添加组件的游戏物体。</param>
        /// <param name="type">要获取或添加的组件。</param>
        /// <returns>获取或添加的组件。</returns>
        public static Component GetOrAddComponent(this GameObject go, Type type)
        {
            if (go == null)
            {
                throw new GameFrameworkException($"Invalid game object '{go}'.");
            }

            Component component = go.GetComponent(type);
            return component ? component : go.AddComponent(type);
        }

        /// <summary>
        /// 设置游戏物体的层。
        /// </summary>
        /// <param name="go">要设置的游戏物体。</param>
        /// <param name="layer">要设置的层。</param>
        /// <param name="recursive">是否设置子物体，默认开启设置所有子物体。</param>
        public static void SetLayer(this GameObject go, int layer, bool recursive = true)
        {
            if (go == null)
            {
                throw new GameFrameworkException($"Invalid game object '{go}'.");
            }

            if (layer < 0 || layer > 31)
            {
                throw new GameFrameworkException($"Invalid layer '{layer}'.");
            }

            if (recursive)
            {
                go.GetComponentsInChildren(true, s_CachedTransforms);
                foreach (var t in s_CachedTransforms)
                {
                    t.gameObject.layer = layer;
                }

                s_CachedTransforms.Clear();
            }
            else
            {
                go.layer = layer;
            }
        }

        /// <summary>
        /// 设置游戏物体的标签。
        /// </summary>
        /// <param name="go">要设置的游戏物体。</param>
        /// <param name="tag">要设置的标签。</param>
        /// <param name="recursive">是否设置子物体，默认开启设置所有子物体。</param>
        public static void SetTag(this GameObject go, string tag, bool recursive = true)
        {
            if (go == null)
            {
                throw new GameFrameworkException($"Invalid game object '{null}'.");
            }

            if (string.IsNullOrEmpty(tag))
            {
                throw new GameFrameworkException($"Invalid tag '{tag}'.");
            }

            if (recursive)
            {
                go.GetComponentsInChildren(true, s_CachedTransforms);
                foreach (var t in s_CachedTransforms)
                {
                    t.gameObject.tag = tag;
                }

                s_CachedTransforms.Clear();
            }
            else
            {
                go.tag = tag;
            }
        }

        /// <summary>
        /// 遍历游戏物体的所有子物体。
        /// </summary>
        /// <param name="go">要遍历的游戏物体。</param>
        /// <param name="action">遍历子物体的行为。</param>
        /// <param name="includeSelf">是否包含自身。</param>
        public static void Foreach(this GameObject go, Action<GameObject> action, bool includeSelf)
        {
            if (go == null)
            {
                throw new GameFrameworkException($"Invalid game object '{null}'.");
            }

            if (action == null)
            {
                throw new GameFrameworkException("Invalid Action<GameObject>.");
            }


            go.GetComponentsInChildren(true, s_CachedTransforms);
            foreach (var t in s_CachedTransforms)
            {
                if (includeSelf || t.gameObject != go)
                {
                    continue;
                }

                action.Invoke(t.gameObject);
            }

            s_CachedTransforms.Clear();
        }
    }
}