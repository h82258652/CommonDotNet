
namespace System
{
    public static partial class StringExtension
    {
        /// <summary>
        /// 返回一个值，该值指示指定的 System.String 对象是否出现在此字符串中。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <param name="comparisonValue">要搜寻的字符串。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值。</param>
        /// <returns>如果 value 参数出现在此字符串中，或者 value 为空字符串 ("")，则为 true；否则为 false。</returns>
        /// <exception cref="System.ArgumentNullException"><c>value</c> 为 null。</exception>
        public static bool Contains(this string value, string comparisonValue, StringComparison comparisonType)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (value.Length == 0)
            {
                return true;
            }
            return value.IndexOf(comparisonValue, comparisonType) != -1;
        }
    }
}
