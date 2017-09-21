using System;
using System.Text.RegularExpressions;

namespace Chris.Framework.Extensions
{
    /// <summary>
    /// 字符串扩展方法集合类
    /// </summary>
    public static class StringExtensions
    {
        #region 空判断
        public static bool IsNullOrEmpty(this string inputStr)
        {
            return string.IsNullOrEmpty(inputStr);
        }

        public static bool IsNullOrWhiteSpace(this string inputStr)
        {
            return string.IsNullOrWhiteSpace(inputStr);
        }
        /// <summary>
        /// 如果指定的对象字符串是 null、空还是仅由空白字符组成则返回默认值。
        /// </summary>
        /// <param name="inputStr"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string IfNullOrWhiteSpace(this string inputStr, string defaultValue)
        {
            return !inputStr.IsNullOrWhiteSpace() ? inputStr : defaultValue;
        }

        public static string Format(this string inputStr, params object[] obj)
        {
            return string.Format(inputStr, obj);
        }
        #endregion

        #region 常用正则表示式
        private static readonly Regex ChineseRegex = new Regex(@"^[\u4e00-\u9fa5]*$");
        private static readonly Regex EmailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
        private static readonly Regex MobilePhoneNumRegex = new Regex("^1[0-9]{10}$");
        private static readonly Regex IpRegex = new Regex(@"^(\d1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$");
        private static readonly Regex DateRegex = new Regex(@"(\d{4})-(\d{1,2})-(\d{1,2})");
        private static readonly Regex NumericRegex = new Regex(@"^[-]?[0-9]+(\.[0-9]+)?$");
        private static readonly Regex IdCardRegex = new Regex(@"(^[1-9]\d{5}(18|19|([23]\d))\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$)|(^[1-9]\d{5}\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{2}[0-9Xx]$)");
        private static readonly Regex ZipcodeRegex = new Regex(@"^\d{6}$");
        #endregion

        /// <summary>
        /// 是否中文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsChinese(this string str)
        {
            return !string.IsNullOrEmpty(str) && ChineseRegex.IsMatch(str);
        }

        /// <summary>
        /// 是否为邮箱名
        /// </summary>
        public static bool IsEmail(this string s)
        {
            return !string.IsNullOrEmpty(s) && EmailRegex.IsMatch(s);
        }

        /// <summary>
        /// 是否为手机号
        /// </summary>
        public static bool IsMobile(this string s)
        {
            return !string.IsNullOrEmpty(s) && MobilePhoneNumRegex.IsMatch(s);
        }

        /// <summary>
        /// 是否为IP
        /// </summary>
        public static bool IsIp(this string s)
        {
            return IpRegex.IsMatch(s);
        }

        /// <summary>
        /// 是否是身份证号
        /// </summary>
        public static bool IsIdCard(this string idCard)
        {
            return !string.IsNullOrEmpty(idCard) && IdCardRegex.IsMatch(idCard);
        }

        /// <summary>
        /// 是否为日期
        /// </summary>
        public static bool IsDate(this string s)
        {
            return DateRegex.IsMatch(s);
        }

        /// <summary>
        /// 是否为邮政编码
        /// </summary>
        public static bool IsZipCode(this string s)
        {
            return string.IsNullOrEmpty(s) || ZipcodeRegex.IsMatch(s);
        }

        /// <summary>
        /// 是否是图片文件名
        /// </summary>
        /// <returns> </returns>
        public static bool IsImgFileName(this string fileName)
        {
            if (fileName.IndexOf(".", StringComparison.Ordinal) == -1)
                return false;

            var tempFileName = fileName.Trim().ToLower();
            var extension = tempFileName.Substring(tempFileName.LastIndexOf(".", StringComparison.Ordinal));
            return extension == ".png" || extension == ".bmp" || extension == ".jpg" || extension == ".jpeg" || extension == ".gif";
        }

        /// <summary>
        /// 格式化手机号
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static string FmtMobile(this string mobile)
        {
            if (mobile.IsNullOrEmpty() || mobile.Length <= 7) return mobile;
            var regx = new Regex(@"(?<=\d{3}).+(?=\d{4})", RegexOptions.IgnoreCase);
            mobile = regx.Replace(mobile, "****");

            return mobile;
        }

        /// <summary>
        /// 格式化证件号码
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        public static string FmtIdCard(this string idCard)
        {
            if (idCard.IsNullOrEmpty() || idCard.Length <= 10) return idCard;
            var regx = new Regex(@"(?<=\w{6}).+(?=\w{4})", RegexOptions.IgnoreCase);
            idCard = regx.Replace(idCard, "********");

            return idCard;
        }

        /// <summary>
        /// 格式化银行卡号
        /// </summary>
        /// <param name="bankCark"></param>
        /// <returns></returns>
        public static string FmtBankCard(this string bankCark)
        {
            if (bankCark.IsNullOrEmpty() || bankCark.Length <= 4) return bankCark;
            var regx = new Regex(@"(?<=\d{4})\d+(?=\d{4})", RegexOptions.IgnoreCase);
            bankCark = regx.Replace(bankCark, " **** **** ");

            return bankCark;
        }

    }
}
