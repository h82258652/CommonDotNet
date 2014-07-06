
namespace System
{
    public static partial class StringExtension
    {
        /// <summary>
        /// 指示当前字符串是否能转换为双精度浮点数。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>是否能转换为双精度浮点数。</returns>
        public static bool IsDouble(this string value)
        {
            double d;
            return double.TryParse(value, out d);
        }
    }
}
