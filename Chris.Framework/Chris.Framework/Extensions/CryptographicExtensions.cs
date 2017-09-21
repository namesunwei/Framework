using System;
using System.Security.Cryptography;
using System.Text;
using Chris.Framework.Infrastructure;

namespace Chris.Framework.Extensions
{
    /// <summary>
    /// 字符串加解密扩展类
    /// </summary>
    public static class CryptographicExtensions
    {
        #region 加密/解密算法

        //todo Aes加密/解密
        //public static string EncodeAESString(this string source)
        //{

        //}

        //public static string DecodeAESString(this string source)
        //{

        //}
        #endregion

        #region Base64转换算法

        /// <summary>
        /// 将字符串使用base64算法编码 
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="encode">编码格式（encode=null时，编码格式：UTF-8）</param>
        /// <returns></returns>
        public static string EncodeBase64String(this string source, Encoding encode = null)
        {
            encode = encode ?? Encoding.UTF8;

            var bytes = encode.GetBytes(source);

            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// 将字符串使用base64算法解码
        /// </summary>
        /// <param name="base64String">base64加密后的字符串</param>
        /// <param name="encode">编码格式（encode=null时，编码格式：UTF-8）</param>
        /// <returns></returns>
        public static string DecodeBase64String(this string base64String, Encoding encode = null)
        {
            try
            {
                encode = encode ?? Encoding.UTF8;

                var bytes = Convert.FromBase64String(base64String);

                return encode.GetString(bytes);
            }
            catch
            {
                return string.Empty;
            }
        }
        #endregion

        #region 散列/哈希算法

        /// <summary>
        /// 将字符串使用MD5算法解码
        /// </summary>
        /// <param name="source">待加密字符串</param>
        /// <param name="toLower">是否转小写字母</param>
        /// <param name="encode">编码格式</param>
        /// <returns></returns>
        public static string EncodeMd5String(this string source, bool toLower = false, Encoding encode = null)
        {
            if (source.IsNullOrEmpty())
            {
                return default(string);
            }

            using (var md5 = MD5.Create())
            {
                encode = encode ?? Encoding.UTF8;

                var result = md5.ComputeHash(encode.GetBytes(source));

                return toLower ? BitConverter.ToString(result).Replace("-", "").ToLower() : BitConverter.ToString(result).Replace("-", "");
            }

        }

        /// <summary>
        ///  将字符串使用SHA1算法编码
        /// </summary>
        /// <param name="source">待加密字符串</param>
        /// <param name="toLower">是否转小写字母</param>
        /// <param name="encode">编码格式</param>
        /// <returns></returns>
        public static string EncodeSHA1String(this string source, bool toLower = false, Encoding encode = null)
        {
            encode = encode ?? Encoding.UTF8;

            using (var sha1 = SHA1.Create())
            {
                var result = sha1.ComputeHash(encode.GetBytes(source));

                return toLower ? BitConverter.ToString(result).Replace("-", "").ToLower() : BitConverter.ToString(result).Replace("-", "");
            }
        }

        /// <summary>
        ///  将字符串使用SHA256算法编码
        /// </summary>
        /// <param name="source">待加密字符串</param>
        /// <param name="toLower">是否转小写字母</param>
        /// <param name="encode">编码格式</param>
        /// <returns></returns>
        public static string EncodeSHA256String(this string source, bool toLower = false, Encoding encode = null)
        {
            encode = encode ?? Encoding.UTF8;

            using (var sha256 = SHA256.Create())
            {
                var result = sha256.ComputeHash(encode.GetBytes(source));

                return toLower ? BitConverter.ToString(result).Replace("-", "").ToLower() : BitConverter.ToString(result).Replace("-", "");
            }

        }

        /// <summary>
        ///  将字符串使用SHA384算法编码
        /// </summary>
        /// <param name="source">待加密字符串</param>
        /// <param name="toLower">是否转小写字母</param>
        /// <param name="encode">编码格式</param>
        /// <returns></returns>
        public static string EncodeSHA384String(this string source, bool toLower = false, Encoding encode = null)
        {
            encode = encode ?? Encoding.UTF8;

            using (var sha384 = SHA384.Create())
            {
                var result = sha384.ComputeHash(encode.GetBytes(source));

                return toLower ? BitConverter.ToString(result).Replace("-", "").ToLower() : BitConverter.ToString(result).Replace("-", "");
            }

        }

        /// <summary>
        ///  将字符串使用SHA512算法编码
        /// </summary>
        /// <param name="source">待加密字符串</param>
        /// <param name="toLower">是否转小写字母</param>
        /// <param name="encode">编码格式</param>
        /// <returns></returns>
        public static string EncodeSHA512String(this string source, bool toLower = false, Encoding encode = null)
        {
            encode = encode ?? Encoding.UTF8;

            using (var sha512 = SHA512.Create())
            {
                var result = sha512.ComputeHash(encode.GetBytes(source));

                return toLower ? BitConverter.ToString(result).Replace("-", "").ToLower() : BitConverter.ToString(result).Replace("-", "");
            }
        }
        #endregion
    }
}
