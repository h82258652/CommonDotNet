#if !Portable
using System.Numerics;
#endif

namespace System
{
    public static partial class StringExtension
    {
#if !Portable
        /// <summary>
        /// 指示当前字符串能否转换为任意大的带符号整数。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>是否能转换为任意大的带符号整数。</returns>
        public static bool IsBigInteger(this string value)
        {
            BigInteger bigInteger;
            return BigInteger.TryParse(value, out bigInteger);
        }
#endif
    }
}
