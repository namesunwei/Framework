using System;

namespace Chris.Framework.Extensions
{
    /// <summary>
    /// 时间扩展类
    /// </summary>
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// 秒转时间戳
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static TimeSpan SecondsToTimeSpan(this int seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }
    }
}
