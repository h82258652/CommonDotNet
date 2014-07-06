
namespace System
{
    public static partial class StringExtension
    {
        /// <summary>
        /// 指示当前字符串是否能转换为 DateTime。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>是否能转换为 DateTime。</returns>
        public static bool IsDateTime(this string value)
        {
            DateTime dateTime;
            return DateTime.TryParse(value, out dateTime);
        }
    }
}
