using System.Diagnostics.CodeAnalysis;

namespace System
{
    public static partial class StringExtension
    {
        /// <summary>
        /// 从当前 System.String 对象移除所有前导空白字符和尾部空白字符。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>从当前字符串的开头和结尾删除所有空白字符后剩余的字符串。</returns>
        public static string TrimSafely(this string value)
        {
            return string.IsNullOrEmpty(value) ? value : value.Trim();
        }

        /// <summary>
        /// 从当前 System.String 对象移除数组中指定的一组字符的所有前导匹配项和尾部匹配项。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <param name="trimChars">要删除的 Unicode 字符的数组，或 null。</param>
        /// <returns>从当前字符串的开头和结尾删除所出现的所有 trimChars 参数中的字符后剩余的字符串。 如果 trimChars 为 null 或空数组，则改为移除空白字符。</returns>
        [SuppressMessage("Microsoft.Naming", "CA1720")]
        public static string TrimSafely(this string value, params char[] trimChars)
        {
            return string.IsNullOrEmpty(value) ? value : value.Trim(trimChars);
        }
    }
}
