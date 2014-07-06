using System.Text.RegularExpressions;

namespace System
{
    public static partial class StringExtension
    {
#if Net40Client||Net40||Portable
        /// <summary>
        /// 指示指定字符串是否为 E-mail 地址。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>若符合 E-mail 格式，则为 true，否则为 false。</returns>
#endif
#if Net45
        /// <summary>
        /// 指示指定字符串是否为 E-mail 地址。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>若符合 E-mail 格式，则为 true，否则为 false。</returns>
        /// <exception cref="System.Text.RegularExpressions.RegexMatchTimeoutException">发生超时。</exception>
#endif
        public static bool IsEmail(this string value)
        {
            return value != null && Regex.IsMatch(value, @"^\S+@\S+\.\S+$");
        }
    }
}
