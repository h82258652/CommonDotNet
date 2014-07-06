
namespace System
{
    public static partial class StringExtension
    {
        /// <summary>
        /// 指示当前字符串是否能转换为 8 位无符号整数。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>是否能转换为 8 位无符号整数。</returns>
        public static bool IsByte(this string value)
        {
            byte b;
            return byte.TryParse(value, out b);
        }
    }
}
