
namespace System
{
    public static partial class CharExtension
    {
        /// <summary>
        /// 指示当前字符是否属于大写字母类别。
        /// </summary>
        /// <param name="value">测试的字符。</param>
        /// <returns>是否属于大写字母类别。</returns>
        public static bool IsUpper(this char value)
        {
            return char.IsUpper(value);
        }
    }
}
