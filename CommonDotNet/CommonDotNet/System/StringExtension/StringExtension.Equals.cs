
namespace System
{
    public static partial class StringExtension
    {
        /// <summary>
        /// 确定此字符串是否与指定的 System.String 对象具有相同的值。 参数指定区域性、大小写以及比较所用的排序规则。
        /// </summary>
        /// <param name="this">当前 System.String 对象。</param>
        /// <param name="value">要与此实例进行比较的字符串。</param>
        /// <returns>如果 value 参数的值为空或与此字符串相同，则为 true；否则为 false。</returns>
        public static bool EqualsSafely(this string @this, string value)
        {
            return EqualsSafely(@this, value, StringComparison.CurrentCulture);
        }

        /// <summary>
        /// 确定此字符串是否与指定的 System.String 对象具有相同的值。 参数指定区域性、大小写以及比较所用的排序规则。
        /// </summary>
        /// <param name="this">当前 System.String 对象。</param>
        /// <param name="value">要与此实例进行比较的字符串。</param>
        /// <param name="comparisonType">枚举值之一，用于指定将如何比较字符串。</param>
        /// <returns>如果 value 参数的值为空或与此字符串相同，则为 true；否则为 false。</returns>
        public static bool EqualsSafely(this string @this, string value, StringComparison comparisonType)
        {
            if (@this == null)
            {
                return value == null;
            }
            return Enum.IsDefined(typeof(StringComparison), comparisonType) && @this.Equals(value, comparisonType);
        }
    }
}
