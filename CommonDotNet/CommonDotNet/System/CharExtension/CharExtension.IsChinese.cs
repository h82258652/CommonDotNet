
namespace System
{
    public static partial class CharExtension
    {
        /// <summary>
        /// 指示当前字符是否属于中文字符。
        /// </summary>
        /// <param name="value">测试的字符。</param>
        /// <returns>是否属于中文字符。</returns>
        public static bool IsChinese(this char value)
        {
            return value >= 0x4e00 && value <= 0x9fa5;
        }
    }
}
