using GameFramework;

namespace UnityGameFramework.Runtime.Extension
{
    public static partial class UUtility
    {
        /// <summary>
        /// Unity 游戏框架字符串工具。
        /// </summary>
        public static class Text
        {
            /// <summary>
            /// 获取格式化字符串。
            /// </summary>
            /// <param name="format">字符串格式。</param>
            /// <param name="arg">字符串参数。</param>
            /// <returns>格式化后的字符串。</returns>
            public static string Format(string format, object arg)
            {
                return Utility.Text.Format(format, arg);
            }

            /// <summary>
            /// 获取格式化字符串。
            /// </summary>
            /// <param name="format">字符串格式。</param>
            /// <param name="arg1">字符串参数 1。</param>
            /// <param name="arg2">字符串参数 2。</param>
            /// <returns>格式化后的字符串。</returns>
            public static string Format(string format, object arg1, object arg2)
            {
                return Utility.Text.Format(format, arg1, arg2);
            }

            /// <summary>
            /// 获取格式化字符串。
            /// </summary>
            /// <param name="format">字符串格式。</param>
            /// <param name="arg1">字符串参数 1。</param>
            /// <param name="arg2">字符串参数 2。</param>
            /// <param name="arg3">字符串参数 3。</param>
            /// <returns>格式化后的字符串。</returns>
            public static string Format(string format, object arg1, object arg2, object arg3)
            {
                return Utility.Text.Format(format, arg1, arg2, arg3);
            }

            /// <summary>
            /// 获取格式化字符串。
            /// </summary>
            /// <param name="format">字符串格式。</param>
            /// <param name="arg1">字符串参数 1。</param>
            /// <param name="arg2">字符串参数 2。</param>
            /// <param name="arg3">字符串参数 3。</param>
            /// <param name="arg4">字符串参数 4。</param>
            /// <returns>格式化后的字符串。</returns>
            public static string Format(string format, object arg1, object arg2, object arg3, object arg4)
            {
                return Utility.Text.Format(format, arg1, arg2, arg3, arg4);
            }

            /// <summary>
            /// 获取格式化字符串。
            /// </summary>
            /// <param name="format">字符串格式。</param>
            /// <param name="arg1">字符串参数 1。</param>
            /// <param name="arg2">字符串参数 2。</param>
            /// <param name="arg3">字符串参数 3。</param>
            /// <param name="arg4">字符串参数 4。</param>
            /// <param name="arg5">字符串参数 5。</param>
            /// <returns>格式化后的字符串。</returns>
            public static string Format(string format, object arg1, object arg2, object arg3, object arg4, object arg5)
            {
                return Utility.Text.Format(format, arg1, arg2, arg3, arg4, arg5);
            }

            /// <summary>
            /// 转换首字母为小写字母。
            /// </summary>
            /// <param name="s">要转换的字符串。</param>
            /// <returns>首字母为小写字母的字符串。</returns>
            public static string ToLowerFirstChar(string s)
            {
                if (string.IsNullOrEmpty(s))
                {
                    return s;
                }

                return s.Length == 1 ? s.ToLower() : Utility.Text.Format("{0}{1}", char.ToLower(s[0]), s.Substring(1));
            }

            /// <summary>
            /// 转换首字母为大写字母。
            /// </summary>
            /// <param name="s">要转换的字符串。</param>
            /// <returns>首字母为大写字母的字符串。</returns>
            public static string ToUpperFirstChar(string s)
            {
                if (string.IsNullOrEmpty(s))
                {
                    return s;
                }

                return s.Length == 1 ? s.ToUpper() : Utility.Text.Format("{0}{1}", char.ToUpper(s[0]), s.Substring(1));
            }
        }
    }
}