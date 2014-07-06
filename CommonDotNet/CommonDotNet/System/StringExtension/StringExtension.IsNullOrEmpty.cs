
namespace System
{
    public static partial class StringExtension
    {
        /// <summary>
        /// 指示指定的字符串是 null 还是 Empty 字符串。
        /// </summary>
        /// <param name="value">要测试的字符串。</param>
        /// <returns>如果 value 参数为 null 或空字符串 ("")，则为 true；否则为 false。</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }
}
