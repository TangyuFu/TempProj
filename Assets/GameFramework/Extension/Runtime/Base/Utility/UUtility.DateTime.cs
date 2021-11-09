using System;

namespace UnityGameFramework.Runtime.Extension
{
    public static partial class UUtility
    {
        /// <summary>
        /// Unity 游戏框架日期工具类。
        /// </summary>
        public static class DateTime
        {
            /// <summary>
            /// 时间戳世界时起始时间。
            /// </summary>
            public static System.DateTime UtcTimestampStart =
                new System.DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            /// <summary>
            /// 判断日期是否在同一天。
            /// </summary>
            /// <param name="x">日期 x 。</param>
            /// <param name="y">日期 y 。</param>
            /// <param name="startHour">一天的开始时间。</param>
            /// <returns>日期是否在同一天。</returns>
            public static bool IsSameDay(System.DateTime x, System.DateTime y, int startHour = 0)
            {
                x = x.Hour < startHour
                    ? new System.DateTime(x.Year, x.Month, x.Day).AddDays(-1)
                    : new System.DateTime(x.Year, x.Month, x.Day);
                y = y.Hour < startHour
                    ? new System.DateTime(y.Year, y.Hour, y.Day).AddDays(-1)
                    : new System.DateTime(y.Year, y.Hour, y.Day);

                return x == y;
            }

            /// <summary>
            /// 时间戳转日期。
            /// </summary>
            /// <param name="timestamp">要转换的时间戳。</param>
            /// <param name="timeZoneId">要转换的时区 Id 。</param>
            /// <returns>转化后的日期。</returns>
            public static System.DateTime Timestamp2DateTime(double timestamp,
                string timeZoneId = "China Standard Time")
            {
                return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                    UtcTimestampStart.AddSeconds(timestamp),
                    timeZoneId
                );
            }

            /// <summary>
            /// 日期转时间戳。
            /// </summary>
            /// <param name="dateTime">要转换的日期。</param>
            /// <returns>转化后的时间戳。</returns>
            public static double DateTime2Timestamp(System.DateTime dateTime)
            {
                return (TimeZoneInfo.ConvertTimeToUtc(dateTime) - UtcTimestampStart).TotalSeconds;
            }
        }
    }
}