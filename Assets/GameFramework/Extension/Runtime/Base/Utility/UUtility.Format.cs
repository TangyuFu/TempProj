using GameFramework;

namespace UnityGameFramework.Runtime.Extension
{
    public static partial class UUtility
    {
        /// <summary>
        /// Unity 游戏框架格式化工具。
        /// </summary>
        public static class Format
        {
            /// <summary>
            /// 格式化时间为 00:00 。
            /// </summary>
            /// <param name="seconds">时间，以秒为单位。</param>
            /// <returns>格式化后的字符串。</returns>
            public static string ToMin(int seconds)
            {
                int min = seconds / 60;
                int sec = seconds % 60;
                return Utility.Text.Format("{0:D2}:{1:D2}", min, sec);
            }

            /// <summary>
            /// 格式化时间为 00:00:00 。
            /// </summary>
            /// <param name="seconds">时间，以秒为单位。</param>
            /// <returns>格式化后的字符串。</returns>
            public static string ToHour(int seconds)
            {
                int hour = seconds / 3600;
                int min = seconds % 3600 / 60;
                int sec = seconds % 60;
                return Utility.Text.Format("{0:D2}:{1:D2}:{2:D2}", hour, min, sec);
            }

            private static readonly string[] s_LowerSuffixes = {"b", "kb", "mb", "gb", "tb", "pb", "eb"};
            private static readonly string[] s_UpperSuffixes = {"B", "KB", "MB", "GB", "TB", "PB", "EB"};
            private static readonly byte[] s_ByteOffsets = {0, 10, 20, 30, 40, 50, 60};

            /// <summary>
            /// 格式化长度为字符串，如 1.02mb 。
            /// </summary>
            /// <param name="length">长度。</param>
            /// <param name="upperCase">大写。</param>
            /// <returns>格式化的字符串。</returns>
            public static string ToByte(ulong length, bool upperCase = true)
            {
                int index = 0;
                for (int i = 0; i < s_ByteOffsets.Length; i++)
                {
                    if (length >> s_ByteOffsets[i] == 0)
                    {
                        break;
                    }

                    index = i;
                }

                UnityEngine.Debug.Log(index);
                return Utility.Text.Format("{0:0.##}{1}",
                    (double) length / (double) (1L << s_ByteOffsets[index]),
                    upperCase ? s_UpperSuffixes[index] : s_LowerSuffixes[index]);
            }
        }
    }
}