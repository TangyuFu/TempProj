using System;
using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    public static partial class UUtility
    {
        /// <summary>
        /// Unity 游戏框架原生工具。
        /// </summary>
        public static class Native
        {
            /// <summary>
            /// 调用系统原生弹窗。
            /// </summary>
            /// <param name="title">弹窗标题</param>
            /// <param name="message">弹窗信息。</param>
            /// <param name="confirm">弹窗确认文本。</param>
            /// <param name="confirmCallback">弹窗确认回调。</param>
            public static void Alert(string title, string message, string confirm, Action confirmCallback)
            {
                switch (Application.platform)
                {
                    case RuntimePlatform.Android:

                        break;
                    case RuntimePlatform.IPhonePlayer:

                        break;
                    default:

                        break;
                }
            }

            /// <summary>
            /// 调用系统原生弹窗。
            /// </summary>
            /// <param name="title">弹窗标题。</param>
            /// <param name="message">弹窗信息。</param>
            /// <param name="ok">弹窗确认文本。</param>
            /// <param name="okCallback">弹窗确认回调。</param>
            /// <param name="cancel">弹窗取消文本。</param>
            /// <param name="cancelCallback">弹窗取消回调。</param>
            public static void Alert(string title, string message, string ok, string cancel, Action okCallback,
                Action cancelCallback)
            {
                switch (Application.platform)
                {
                    case RuntimePlatform.Android:

                        break;

                    case RuntimePlatform.IPhonePlayer:

                        break;

                    default:

                        break;
                }
            }

            /// <summary>
            /// 调用系统原生震动。
            /// </summary>
            /// <param name="strength">震动强度，1 - 10，依次增强。</param>
            /// <param name="duration">震动时长，以秒为单位。</param>
            public static void Vibrate(int strength, float duration)
            {
                switch (Application.platform)
                {
                    case RuntimePlatform.Android:

                        break;

                    case RuntimePlatform.IPhonePlayer:

                        break;

                    default:

                        break;
                }
            }

            /// <summary>
            /// 电池电量。
            /// </summary>
            public static float BatteryQuantity => 1f;
        }
    }
}