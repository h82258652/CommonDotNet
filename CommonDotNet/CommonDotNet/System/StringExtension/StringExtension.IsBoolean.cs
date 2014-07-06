
namespace System
{
    public static partial class StringExtension
    {
        /// <summary>
        /// 指示当前字符串是否能转换为布尔值。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>是否能转换为布尔值。</returns>
        public static bool IsBoolean(this string value)
        {
            bool b;
            return bool.TryParse(value, out b);
        }
    }
}
