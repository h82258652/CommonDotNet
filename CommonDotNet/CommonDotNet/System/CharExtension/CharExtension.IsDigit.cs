
namespace System
{
    public static partial class CharExtension
    {
        /// <summary>
        /// 指示当前字符是否属于十进制数字类别。（即字符'0'-'9'）
        /// </summary>
        /// <param name="value">测试的字符。</param>
        /// <returns>是否属于十进制数字类别。</returns>
        public static bool IsDigit(this char value)
        {
            return char.IsDigit(value);
        }
    }
}
