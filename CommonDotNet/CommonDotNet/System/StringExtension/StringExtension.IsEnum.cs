using System.Diagnostics.CodeAnalysis;

namespace System
{
    public static partial class StringExtension
    {
        /// <summary>
        /// 指示当前字符串是否能转换为枚举值。
        /// </summary>
        /// <typeparam name="T">枚举类型。</typeparam>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>能否转换为枚举值。</returns>
        /// <exception cref="System.ArgumentException"><c>T</c> 不是枚举类型。</exception>
#if !Portable
        [CLSCompliant(false)]
#endif
        [SuppressMessage("Microsoft.Design", "CA1004")]
        public static bool IsEnum<T>(this string value) where T : struct, IComparable, IFormattable
#if !Portable
, IConvertible
#endif
        {
            T result;
            return Enum.TryParse(value, out result);
        }

        /// <summary>
        /// 指示当前字符串是否能转换为枚举值。
        /// </summary>
        /// <typeparam name="T">枚举类型。</typeparam>
        /// <param name="value">当前 System.String 对象。</param>
        /// <param name="ignoreCase">是否区分大小写。</param>
        /// <returns>能否转换为枚举值。</returns>
        /// <exception cref="System.ArgumentException"><c>T</c> 不是枚举类型。</exception>
#if !Portable
        [CLSCompliant(false)]
#endif
        [SuppressMessage("Microsoft.Design", "CA1004")]
        public static bool IsEnum<T>(this string value, bool ignoreCase) where T : struct ,IComparable, IFormattable
#if !Portable
, IConvertible
#endif
        {
            T result;
            return Enum.TryParse(value, ignoreCase, out result);
        }
    }
}
