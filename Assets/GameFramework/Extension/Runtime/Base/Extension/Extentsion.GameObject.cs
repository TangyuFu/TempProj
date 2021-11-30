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
        private static readonly List<Transform> s_CachedTransforms = new();

        /// <summary>
        /// 获取游戏物体是否在场景中。
        /// </summary>
        /// <param name="gameObject">要判定的游戏物体。</param>
        /// <returns>游戏物体是否在场景中。</returns>
        public static bool IsInScene(this GameObject gameObject)
        {
            if (!gameObject)
            {
                throw new GameFrameworkException($"Invalid gameObject '{gameObject}'.");
            }

            return gameObject.scene.IsValid();
        }

        /// <summary>
        /// 获取或添加组件。
        /// </summary>
        /// <typeparam name="T">要获取或添加的组件。</typeparam>
        /// <param name="gameObject">要获取或添加组件的游戏物体。</param>
        /// <returns>获取或添加的组件。</returns>
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            if (!gameObject)
            {
                throw new GameFrameworkException($"Invalid gameObject '{gameObject}'.");
            }

            T component = gameObject.GetComponent<T>();
            return component ? component : gameObject.AddComponent<T>();
        }

        /// <summary>
        /// 获取或添加组件。
        /// </summary>
        /// <param name="gameObject">要获取或添加组件的游戏物体。</param>
        /// <param name="type">要获取或添加的组件。</param>
        /// <returns>获取或添加的组件。</returns>
        public static Component GetOrAddComponent(this GameObject gameObject, Type type)
        {
            if (!gameObject)
            {
                throw new GameFrameworkException($"Invalid gameObject '{gameObject}'.");
            }

            Component component = gameObject.GetComponent(type);
            return component ? component : gameObject.AddComponent(type);
        }

        /// <summary>
        /// 设置游戏物体的层。
        /// </summary>
        /// <param name="gameObject">要设置的游戏物体。</param>
        /// <param name="layer">要设置的层。</param>
        /// <param name="recursive">是否设置子物体，默认开启设置所有子物体。</param>
        public static void SetLayer(this GameObject gameObject, int layer, bool recursive = true)
        {
            if (!gameObject)
            {
                throw new GameFrameworkException($"Invalid gameObject '{gameObject}'.");
            }

            if (layer < 0 || layer > 31)
            {
                throw new GameFrameworkException($"Invalid layer '{layer}'.");
            }

            if (recursive)
            {
                gameObject.GetComponentsInChildren(true, s_CachedTransforms);
                foreach (var t in s_CachedTransforms)
                {
                    t.gameObject.layer = layer;
                }

                s_CachedTransforms.Clear();
            }
            else
            {
                gameObject.layer = layer;
            }
        }

        /// <summary>
        /// 设置游戏物体的标签。
        /// </summary>
        /// <param name="gameObject">要设置的游戏物体。</param>
        /// <param name="tag">要设置的标签。</param>
        /// <param name="recursive">是否设置子物体，默认开启设置所有子物体。</param>
        public static void SetTag(this GameObject gameObject, string tag, bool recursive = true)
        {
            if (!gameObject)
            {
                throw new GameFrameworkException($"Invalid gameObject '{gameObject}'.");
            }

            if (string.IsNullOrEmpty(tag))
            {
                throw new GameFrameworkException($"Invalid tag '{tag}'.");
            }

            if (recursive)
            {
                gameObject.GetComponentsInChildren(true, s_CachedTransforms);
                foreach (var t in s_CachedTransforms)
                {
                    t.gameObject.tag = tag;
                }

                s_CachedTransforms.Clear();
            }
            else
            {
                gameObject.tag = tag;
            }
        }

        /// <summary>
        /// 遍历游戏物体的所有子物体。
        /// </summary>
        /// <param name="gameObject">要遍历的游戏物体。</param>
        /// <param name="action">遍历子物体的行为。</param>
        /// <param name="includeSelf">是否包含自身。</param>
        public static void ForeachChild(this GameObject gameObject, Action<GameObject> action, bool includeSelf)
        {
            if (!gameObject)
            {
                throw new GameFrameworkException($"Invalid gameObject '{gameObject}'.");
            }

            if (action == null)
            {
                throw new GameFrameworkException($"Invalid action '{action}'.");
            }

            gameObject.GetComponentsInChildren(true, s_CachedTransforms);
            foreach (var t in s_CachedTransforms)
            {
                if (!includeSelf && t.gameObject == gameObject)
                {
                    continue;
                }

                action.Invoke(t.gameObject);
            }

            s_CachedTransforms.Clear();
        }
    }
}