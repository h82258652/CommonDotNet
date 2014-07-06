
namespace System
{
    public static partial class StringExtension
    {
        /// <summary>
        /// 返回一个新字符串，其中当前实例中出现的所有指定字符串都替换为另一个指定的字符串。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <param name="oldValue">要被替换的字符串。</param>
        /// <param name="newValue">要替换出现的所有 oldValue 的字符串。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值之一。</param>
        /// <returns>等效于当前字符串（除了 oldValue 的所有实例都已替换为 newValue 外）的字符串。</returns>
        /// <exception cref="System.ArgumentNullException"><c>value</c> 为 null。</exception>
        /// <exception cref="System.ArgumentNullException"><c>oldValue</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>oldValue</c> 是空字符串 ("")。</exception>
        public static string Replace(this string value, string oldValue, string newValue,
            StringComparison comparisonType)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "未将对象引用设置到对象的实例。");
            }
            if (oldValue == null)
            {
                throw new ArgumentNullException("oldValue", "值不能为 null。");
            }
            if (oldValue.Length == 0)
            {
                throw new ArgumentException("字符串的长度不能为零。", "oldValue");
            }
            if (Enum.IsDefined(typeof(StringComparison), comparisonType) == false)
            {
                throw new ArgumentException("非法的 StringComparison。", "comparisonType");
            }
            while (true)
            {
                var index = value.IndexOf(oldValue, comparisonType);
                if (index == -1)
                {
                    return value;
                }
                value = value.Substring(0, index) + newValue + value.Substring(index + oldValue.Length);
            }
        }
    }
}
