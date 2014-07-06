
namespace System
{
    public static partial class StringExtension
    {
        /// <summary>
        /// 指示当前字符串是否能转换为 16 位有符号整数。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>能否转换为 16 位有符号整数。</returns>
        public static bool IsInt16(this string value)
        {
            short s;
            return short.TryParse(value, out s);
        }
    }
}
