
namespace System
{
    public static partial class StringExtension
    {
        /// <summary>
        /// 将当前字符串转换为 64 位有符号整数。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>成功则返回相应的 64 位有符号整数，失败则返回 -1。</returns>
        public static long AsInt64(this string value)
        {
            return AsInt64(value, -1);
        }

        /// <summary>
        /// 将当前字符串转换为 64 位有符号整数。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <param name="failureValue">无法转换时返回的默认值。</param>
        /// <returns>成功则返回相应的 64 位有符号整数，失败则返回指定的默认值。</returns>
        public static long AsInt64(this string value, long failureValue)
        {
            long l;
            return long.TryParse(value, out l) ? l : failureValue;
        }
    }
}
