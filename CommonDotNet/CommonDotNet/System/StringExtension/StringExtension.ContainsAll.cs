using System.Linq;

namespace System
{
    public static partial class StringExtension
    {
        /// <summary>
        /// 返回一个值，该值指示当前字符串是否包含指定字符串对象中的全部。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值。</param>
        /// <param name="values">要搜寻的字符串列表。</param>
        /// <returns>是否包含所有。</returns>
        public static bool ContainsAll(this string value, StringComparison comparisonType, params string[] values)
        {
            return values.Any(temp => value.IndexOf(temp, comparisonType) == -1) == false;
        }
    }
}
