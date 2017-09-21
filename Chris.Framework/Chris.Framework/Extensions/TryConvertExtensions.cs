using System;

namespace Chris.Framework.Extensions
{
    /// <summary>
    /// 类型转换扩展类
    /// </summary>
    public static class TryConvertExtensions
    {
        /// <summary>
        /// 字符串转换成int
        /// </summary>
        /// <param name="inputStr">输入</param>
        /// <param name="defaultNum">转换失败默认值</param>
        /// <returns></returns>
        public static int TryInt(this string inputStr, int defaultNum = 0)
        {
            return int.TryParse(inputStr, out int num) ? num : defaultNum;
        }

        /// <summary>
        /// 字符串转换成long
        /// </summary>
        /// <param name="inputStr">输入</param>
        /// <param name="defaultNum">转换失败默认值</param>
        /// <returns></returns>
        public static long TryLong(this string inputStr, int defaultNum = 0)
        {
            return long.TryParse(inputStr, out long num) ? num : defaultNum;
        }

        /// <summary>
        /// 字符串转换成double
        /// </summary>
        /// <param name="inputStr">输入</param>
        /// <param name="defaultNum">转换失败默认值</param>
        /// <returns></returns>
        public static double TryDouble(this string inputStr, double defaultNum = 0)
        {
            return double.TryParse(inputStr, out double num) ? num : defaultNum;
        }

        /// <summary>
        /// 字符串转decimal
        /// </summary>
        /// <param name="inputStr">输入</param>
        /// <param name="defaultNum">转换失败默认值</param>
        /// <returns></returns>
        public static float TryFloat(this string inputStr, float defaultNum = 0)
        {
            return float.TryParse(inputStr, out float num) ? num : defaultNum;
        }

        /// <summary>
        /// 字符串转bool
        /// </summary>
        /// <param name="inputStr">输入</param>
        /// <param name="defaultBool">转换失败默认值</param>
        /// <returns></returns>
        public static bool TryBool(this string inputStr, bool defaultBool = false)
        {
            return bool.TryParse(inputStr, out bool output) ? output : defaultBool;
        }

        /// <summary>
        /// 值类型转string
        /// </summary>
        /// <param name="inputObj">输入</param>
        /// <param name="defaultStr">转换失败默认值</param>
        /// <returns></returns>
        public static string TryString(this ValueType inputObj, string defaultStr = null)
        {
            return inputObj.IsNull() ? defaultStr : inputObj.ToString();
        }

        /// <summary>
        /// 字符串转时间
        /// </summary>
        /// <param name="inputStr">输入</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static DateTime TryDateTime(this string inputStr, DateTime defaultValue = default(DateTime))
        {
            if (inputStr.IsNullOrEmpty()) return defaultValue;

            return DateTime.TryParse(inputStr, out DateTime outPutDateTime) ? outPutDateTime : defaultValue;
        }

        /// <summary>
        /// 字符串去首尾空格
        /// </summary>
        /// <param name="inputStr">输入</param>
        /// <returns></returns>
        public static string TryTrim(this string inputStr)
        {
            return inputStr.IsNullOrEmpty() ? inputStr : inputStr.Trim();
        }

        /// <summary>
        /// 字符串转枚举
        /// </summary>
        /// <typeparam name="T">输入</typeparam>
        /// <param name="str"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T TryEnum<T>(this string str, T t = default(T)) where T : struct
        {
            return Enum.TryParse(str, out T result) ? result : t;
        }
    }
}
