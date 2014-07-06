
namespace System
{
    public static partial class StringExtension
    {
        /// <summary>
        /// 指示当前字符串是否能转换为 32 位无符号整数。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>是否能转换为 32 位无符号整数。</returns>
        public static bool IsUInt32(this string value)
        {
            uint ui;
            return uint.TryParse(value, out ui);
        }
    }
}
