
namespace System
{
    public partial class StringExtension
    {
        /// <summary>
        /// 指示当前字符串是否能转换为 Decimal。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>是否能转换为 Decimal。</returns>
        public static bool IsDecimal(this string value)
        {
            decimal d;
            return decimal.TryParse(value, out d);
        }
    }
}
