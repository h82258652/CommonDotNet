
namespace System
{
    public static partial class StringExtension
    {
        /// <summary>
        /// 指示当前字符串是否能转换为 8 位有符号整数。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>是否能转换为 8 位有符合整数。</returns>
        public static bool IsSByte(this string value)
        {
            sbyte sb;
            return sbyte.TryParse(value, out sb);
        }
    }
}
