using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Chris.Framework.Extensions;

namespace Chris.Framework.Infrastructure
{

    public static class Guard
    {
        /// <summary>
        /// 当（路径）参数中是否包含非法字符，抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        [System.Diagnostics.DebuggerHidden]
        public static void ArgumentContainsInvalidPathChars(string argument, string argumentName)
        {
            if (argument.IsNullOrWhiteSpace())
            {
                return;
            }

            var invliadChars = Path.GetInvalidPathChars();

            if (argument.Any(c => invliadChars.Contains(c)))
            {
                throw new ArgumentException($"The provided String argument {argumentName} contains invalid path character.");
            }
        }

        /// <summary>
        /// 当条件不满足时，抛出异常。
        /// </summary>
        /// <param name="condition">判断条件</param>
        /// <param name="message">异常信息</param>
        /// <param name="paramName">参数名称</param>
        [System.Diagnostics.DebuggerHidden]
        public static void ArgumentCondition(bool condition, string message, string paramName = null)
        {
            if (!condition) return;

            var ex = paramName.IsNullOrWhiteSpace()
                ? new ArgumentException(message)
                : new ArgumentException(message, paramName);

            throw ex;
        }

        /// <summary>
        /// 当参数不是URI时，抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="kind"></param>
        [System.Diagnostics.DebuggerHidden]
        public static void ArgumentIsUri(string argument, string argumentName, UriKind kind = UriKind.RelativeOrAbsolute)
        {
            if (!argument.IsNullOrWhiteSpace())
            {
                if (Uri.IsWellFormedUriString(Uri.EscapeUriString(argument), kind))
                {
                    return;
                }
            }

            throw new ArgumentException($"The provided string argument {argumentName} must  be uri.");
        }

        /// <summary>
        /// 当参数不是绝对路径时，抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param> 
        [System.Diagnostics.DebuggerHidden]
        public static void ArgumentIsAbsolutePhysicalPath(string argument, string argumentName)
        {
            if (argument.IsNullOrWhiteSpace())
            {
                throw new ArgumentException($"The provided string argument {argumentName} must  be absolute physical path.");
            }

            if (!Path.IsPathRooted(argument))
            {
                throw new ArgumentException($"The provided string argument {argumentName} must  be absolute physical path.");
            }
        }

        /// <summary>
        /// 当参数不是相对路径（包括文件系统路径和 Uri）时，抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        [System.Diagnostics.DebuggerHidden]
        public static void ArgumentIsRelativePath(string argument, string argumentName)
        {
            if (argument.IsNullOrWhiteSpace())
            {
                throw new ArgumentException($"The provided string argument {argumentName} must  be relative path.");
            }

            ArgumentContainsInvalidPathChars(argument, argumentName);

            var virtualPath = argument.Replace(@"\", @"/");

            if (Uri.IsWellFormedUriString(Uri.EscapeUriString(virtualPath), UriKind.Absolute))
            {
                throw new ArgumentException($"The provided string argument {argumentName} must  be relative path.");
            }

            var path = argument.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);

            if (Path.IsPathRooted(path))
            {
                throw new ArgumentException($"The provided string argument {argumentName} must  be relative path.");
            }
        }
        /// <summary>
        /// 当参数为空对象时，抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        [System.Diagnostics.DebuggerHidden]
        public static void ArgumentNotNull(object argument, string argumentName = null)
        {
            if (argument.IsNull())
            {
                throw new ArgumentNullException(argumentName, $"The provided object argument {argumentName} must be not null");
            }
        }

        /// <summary>
        /// 当参数为null或者空字符串时，抛出异常
        /// </summary>
        /// <param name="argumentValue"></param>
        /// <param name="argumentName"></param>
        [System.Diagnostics.DebuggerHidden]
        public static void ArgumentNotNullOrEmptyString(string argumentValue, string argumentName)
        {
            ArgumentNotNullOrEmptyString(argumentValue, argumentName, false);
        }

        /// <summary>
        /// 当参数为null或者空格字符串时，抛出异常。
        /// </summary>
        /// <param name="argumentValue"></param>
        /// <param name="argumentName"></param>
        [System.Diagnostics.DebuggerHidden]
        public static void ArgumentNullOrWhiteSpaceString(string argumentValue, string argumentName)
        {
            ArgumentNotNullOrEmptyString(argumentValue, argumentName, true);
        }
        /// <summary>
        /// 当参数为null或者空格字符串时，抛出异常。
        /// </summary>
        /// <param name="argumentValue"></param>
        /// <param name="argumentName"></param>
        [System.Diagnostics.DebuggerHidden]
        public static void ArgumentNullOrWhiteSpaceString(List<string> argumentValue, string argumentName)
        {
            foreach (var item in argumentValue)
            {
                ArgumentNotNullOrEmptyString(item, argumentName, true);
            }
        }
        private static void ArgumentNotNullOrEmptyString(string argumentValue, string argumentName, bool trimString)
        {
            if (trimString && argumentValue.IsNullOrWhiteSpace() || !trimString && argumentValue.IsNullOrEmpty())
            {
                throw new ArgumentException($"The provided String argument {argumentName} must not be empty.");
            }
        }

        public static void EnumValueIsDefined(Type enumType, object value, string argumentName)
        {
            if (!enumType.HasAttribute<FlagsAttribute>())
            {
                if (Enum.IsDefined(enumType, value) == false)
                {
                    throw new ArgumentException($"The value of the argument {argumentName} provided for the enumeration {enumType} is invalid.");
                }
            }
            else
            {
                try
                {

                }
                catch (System.Exception )
                {


                    throw;
                }
            }
        }
    }
}
