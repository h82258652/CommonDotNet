
namespace System
{
    public static partial class CharExtension
    {
        /// <summary>
        /// 指示当前字符是否属于数字类别。（'0'-'9'及例如罗马字母'Ⅰ'等字符）
        /// </summary>
        /// <param name="value">测试的字符。</param>
        /// <returns>是否属于数字类别。</returns>
        public static bool IsNumber(this char value)
        {
            return char.IsNumber(value);
        }
    }
}
