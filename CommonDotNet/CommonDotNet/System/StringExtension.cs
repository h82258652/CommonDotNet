using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

// ReSharper disable CheckNamespace
namespace System
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// String 扩展类。
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 将当前字符串转换为 16 位有符号整数。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>成功则返回相应的 16 位有符号整数，失败则返回 -1。</returns>
        public static short AsInt16(this string value)
        {
            return AsInt16(value, -1);
        }

        /// <summary>
        /// 将当前字符串转换为 16 位有符号整数。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <param name="failureValue">无法转换时返回的默认值。</param>
        /// <returns>成功则返回相应的 16 位有符号整数，失败则返回指定的默认值。</returns>
        public static short AsInt16(this string value, short failureValue)
        {
            short s;
            return Int16.TryParse(value, out s) ? s : failureValue;
        }

        /// <summary>
        /// 将当前字符串转换为 32 位有符号整数。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>成功则返回相应的 32 位有符号整数，失败则返回 -1。</returns>
        public static int AsInt32(this string value)
        {
            return AsInt32(value, -1);
        }

        /// <summary>
        /// 将当前字符串转换为 32 位有符号整数。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <param name="failureValue">无法转换时返回的默认值。</param>
        /// <returns>成功则返回相应的 32 位有符号整数，失败则返回指定的默认值。</returns>
        public static int AsInt32(this string value, int failureValue)
        {
            int i;
            return Int32.TryParse(value, out i) ? i : failureValue;
        }

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
            return Int64.TryParse(value, out l) ? l : failureValue;
        }

        /// <summary>
        /// 将当前字符串进行 Base64 解码。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>解码后的字符串。</returns>
        /// <exception cref="ArgumentNullException"><c>value</c> 为 null。</exception>
        public static string Base64Decode(this string value)
        {
            return value.Base64Decode(null);
        }

        /// <summary>
        /// 将当前字符串进行 Base64 解码。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <param name="encoding">字符编码方式。</param>
        /// <returns>解码后的字符串。</returns>
        /// <exception cref="ArgumentNullException"><c>value</c> 为 null。</exception>
        public static string Base64Decode(this string value, Encoding encoding)
        {
            encoding = encoding ?? Encoding.UTF8;
            var bytes = Convert.FromBase64String(value);
            return encoding.GetString(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// 将当前字符串进行 Base64 解码。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>解码后的字符串。</returns>
        public static string Base64DecodeSafely(this string value)
        {
            return value == null ? null : value.Base64Decode();
        }

        /// <summary>
        /// 将当前字符串进行 Base64 解码。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <param name="encoding">字符编码方式。</param>
        /// <returns>解码后的字符串。</returns>
        public static string Base64DecodeSafely(this string value, Encoding encoding)
        {
            return value == null ? null : value.Base64Decode(encoding);
        }

        /// <summary>
        /// 将当前字符串进行 Base64 编码。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>编码后的字符串。</returns>
        /// <exception cref="ArgumentNullException"><c>value</c> 为 null。</exception>
        public static string Base64Encode(this string value)
        {
            return value.Base64Encode(null);
        }

        /// <summary>
        /// 对当前字符串进行 Base64 编码。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <param name="encoding">字符编码方式。</param>
        /// <returns>编码后的字符串。</returns>
        /// <exception cref="ArgumentNullException"><c>value</c> 为 null。</exception>
        public static string Base64Encode(this string value, Encoding encoding)
        {
            encoding = encoding ?? Encoding.UTF8;
            var bytes = encoding.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// 将当前字符串进行 Base64 编码。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>编码后的字符串。</returns>
        public static string Base64EncodeSafely(this string value)
        {
            return value == null ? null : value.Base64Encode();
        }

        /// <summary>
        /// 将当前字符串进行 Base64 编码。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <param name="encoding">字符编码方式。</param>
        /// <returns>编码后的字符串。</returns>
        public static string Base64EncodeSafely(this string value, Encoding encoding)
        {
            return value == null ? null : value.Base64Encode(encoding);
        }

        /// <summary>
        /// 返回一个值，该值指示指定的 System.String 对象是否出现在此字符串中。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <param name="comparisonValue">要搜寻的字符串。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值。</param>
        /// <returns>如果 value 参数出现在此字符串中，或者 value 为空字符串 ("")，则为 true；否则为 false。</returns>
        /// <exception cref="ArgumentNullException"><c>value</c> 为 null。</exception>
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

        /// <summary>
        /// 将指定字符串中的格式项替换为指定数组中相应对象的字符串表示形式。
        /// </summary>
        /// <param name="format">符合格式字符串（参见“备注”）。</param>
        /// <param name="args">一个对象数组，其中包含零个或多个要设置格式的对象。</param>
        /// <returns>format 的一个副本，其中格式项已替换为 args 中相应对象的字符串表示形式。</returns>
        /// <exception cref="ArgumentNullException"><c>format</c> 或 <c>args</c> 为 null。</exception>
        /// <exception cref="FormatException"><c>format</c> 无效。 - 或 - 格式项的索引小于零或大于等于 <c>args</c> 数组的长度。</exception>
        [SuppressMessage("Microsoft.Globalization", "CA1305")]
        public static string FormatWith(this string format, params object[] args)
        {
            return String.Format(format, args);
        }

        /// <summary>
        /// 将指定字符串中的格式项替换为指定数组中相应对象的字符串表示形式。 指定的参数提供区域性特定的格式设置信息。
        /// </summary>
        /// <param name="format">符合格式字符串（参见“备注”）。</param>
        /// <param name="provider">一个提供区域性特定的格式设置信息的对象。</param>
        /// <param name="args">一个对象数组，其中包含零个或多个要设置格式的对象。</param>
        /// <returns>format 的一个副本，其中格式项已替换为 args 中相应对象的字符串表示形式。</returns>
        /// <exception cref="ArgumentNullException"><c>format</c> 或 <c>args</c> 为 null。</exception>
        /// <exception cref="FormatException"><c>format</c> 无效。 - 或 - 格式项的索引小于零或大于等于 <c>args</c> 数组的长度。</exception>
        public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
        {
            return String.Format(provider, format, args);
        }

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

        /// <summary>
        /// 指示当前字符串是否能转换为布尔值。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>是否能转换为布尔值。</returns>
        public static bool IsBoolean(this string value)
        {
            bool b;
            return Boolean.TryParse(value, out b);
        }

        /// <summary>
        /// 指示当前字符串是否能转换为 8 位无符号整数。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>是否能转换为 8 位无符号整数。</returns>
        public static bool IsByte(this string value)
        {
            byte b;
            return Byte.TryParse(value, out b);
        }

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

        /// <summary>
        /// 指示当前字符串是否能转换为 Decimal。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>是否能转换为 Decimal。</returns>
        public static bool IsDecimal(this string value)
        {
            decimal d;
            return Decimal.TryParse(value, out d);
        }

        /// <summary>
        /// 指示当前字符串是否能转换为双精度浮点数。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>是否能转换为双精度浮点数。</returns>
        public static bool IsDouble(this string value)
        {
            double d;
            return Double.TryParse(value, out d);
        }

#if Net45
        /// <summary>
        /// 指示指定字符串是否为 E-mail 地址。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>若符合 E-mail 格式，则为 true，否则为 false。</returns>
        /// <exception cref="RegexMatchTimeoutException">发生超时。</exception>
#else
        /// <summary>
        /// 指示指定字符串是否为 E-mail 地址。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>若符合 E-mail 格式，则为 true，否则为 false。</returns>
#endif

        public static bool IsEmail(this string value)
        {
            return value != null && Regex.IsMatch(value, @"^\S+@\S+\.\S+$");
        }

        /// <summary>
        /// 指示当前字符串是否能转换为枚举值。
        /// </summary>
        /// <typeparam name="T">枚举类型。</typeparam>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>能否转换为枚举值。</returns>
        /// <exception cref="ArgumentException"><c>T</c> 不是枚举类型。</exception>
        [CLSCompliant(false)]
        [SuppressMessage("Microsoft.Design", "CA1004")]
        public static bool IsEnum<T>(this string value) where T : struct, IComparable, IFormattable, IConvertible
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
        /// <exception cref="ArgumentException"><c>T</c> 不是枚举类型。</exception>
        [CLSCompliant(false)]
        [SuppressMessage("Microsoft.Design", "CA1004")]
        public static bool IsEnum<T>(this string value, bool ignoreCase) where T : struct ,IComparable, IFormattable, IConvertible
        {
            T result;
            return Enum.TryParse(value, ignoreCase, out result);
        }

        /// <summary>
        /// 指示当前字符串是否能转换为 16 位有符号整数。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>能否转换为 16 位有符号整数。</returns>
        public static bool IsInt16(this string value)
        {
            short s;
            return Int16.TryParse(value, out s);
        }

        /// <summary>
        /// 指示当前字符串是否能转换为 32 位有符号整数。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>是否能转换为 32 位有符号整数。</returns>
        public static bool IsInt32(this string value)
        {
            int i;
            return Int32.TryParse(value, out i);
        }

        /// <summary>
        /// 指示当前字符串是否能转换为 64 位有符号整数。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>是否能转换为 64 位有符号整数。</returns>
        public static bool IsInt64(this string value)
        {
            long l;
            return Int64.TryParse(value, out l);
        }

        /// <summary>
        /// 指示指定的字符串是 null 还是 Empty 字符串。
        /// </summary>
        /// <param name="value">要测试的字符串。</param>
        /// <returns>如果 value 参数为 null 或空字符串 ("")，则为 true；否则为 false。</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return String.IsNullOrEmpty(value);
        }

        /// <summary>
        /// 指示指定的字符串是 null、空还是仅由空白字符组成。
        /// </summary>
        /// <param name="value">要测试的字符串。</param>
        /// <returns>如果 value 参数为 null 或 String.Empty，或者如果 value 仅由空白字符组成，则为 true。</returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return String.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// 指示当前字符串是否能转换为 8 位有符号整数。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>是否能转换为 8 位有符合整数。</returns>
        public static bool IsSByte(this string value)
        {
            sbyte sb;
            return SByte.TryParse(value, out sb);
        }

        /// <summary>
        /// 指示当前字符串是否能转换为单精度浮点数。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>是否能转换为单精度浮点数。</returns>
        public static bool IsSingle(this string value)
        {
            float f;
            return Single.TryParse(value, out f);
        }

        /// <summary>
        /// 指示当前字符串是否能转换为 16 位无符号整数。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>是否能转换为 16 位无符号整数。</returns>
        public static bool IsUInt16(this string value)
        {
            ushort us;
            return UInt16.TryParse(value, out us);
        }

        /// <summary>
        /// 指示当前字符串是否能转换为 32 位无符号整数。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>是否能转换为 32 位无符号整数。</returns>
        public static bool IsUInt32(this string value)
        {
            uint ui;
            return UInt32.TryParse(value, out ui);
        }

        /// <summary>
        /// 指示当前字符串是否能转换为 64 位无符号整数。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>是否能转换为 64 位无符号整数。</returns>
        public static bool IsUInt64(this string value)
        {
            ulong ul;
            return UInt64.TryParse(value, out ul);
        }

        /// <summary>
        /// 返回一个新字符串，其中当前实例中出现的所有指定字符串都替换为另一个指定的字符串。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <param name="oldValue">要被替换的字符串。</param>
        /// <param name="newValue">要替换出现的所有 oldValue 的字符串。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值之一。</param>
        /// <returns>等效于当前字符串（除了 oldValue 的所有实例都已替换为 newValue 外）的字符串。</returns>
        /// <exception cref="ArgumentException"><c>value</c> 为 null。</exception>
        /// <exception cref="ArgumentNullException"><c>oldValue</c> 为 null。</exception>
        /// <exception cref="ArgumentNullException"><c>oldValue</c> 是空字符串 ("")。</exception>
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

        /// <summary>
        /// 将字符串中的大写字母变小写字母，小写字母变大写字母。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>转换后的字符串。</returns>
        /// <exception cref="ArgumentNullException"><c>value</c> 为 null。</exception>
        public static string SwapCase(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (value.Length == 0)
            {
                return value;
            }
            var sb = new StringBuilder(value.Length);
            foreach (var c in value)
            {
                if (char.IsUpper(c))
                {
                    sb.Append(char.ToLower(c, CultureInfo.CurrentCulture));
                }
                else if (char.IsLower(c))
                {
                    sb.Append(char.ToUpper(c, CultureInfo.CurrentCulture));
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 将字符串中的大写字母变小写字母，小写字母变大写字母。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>转换后的字符串。</returns>
        public static string SwapCaseSafely(this string value)
        {
            return string.IsNullOrEmpty(value) ? value : SwapCase(value);
        }

        /// <summary>
        /// 将当前字符串转换为半角。
        /// </summary>
        /// <param name="value">需要转换的字符串。</param>
        /// <returns>转换后的字符串。</returns>
        /// <exception cref="ArgumentNullException"><c>value</c> 为 null。</exception>
        [SuppressMessage("Microsoft.Naming", "CA1709")]
// ReSharper disable InconsistentNaming
        public static string ToDBC(this string value)
// ReSharper restore InconsistentNaming
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (value.Length == 0)
            {
                return value;
            }
            var sb = new StringBuilder(value.Length);
            foreach (var c in value)
            {
                if (c == 12288)
                {
                    sb.Append((char)32);
                }
                else if (c > 65280 && c < 65375)
                {
                    sb.Append((char)(c - 65248));
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 将当前字符串转换为半角。
        /// </summary>
        /// <param name="value">需要转换的字符串。</param>
        /// <returns>转换后的字符串。</returns>
        [SuppressMessage("Microsoft.Naming", "CA1709")]
// ReSharper disable InconsistentNaming
        public static string ToDBCSafely(this string value)
// ReSharper restore InconsistentNaming
        {
            return string.IsNullOrEmpty(value) ? value : ToDBC(value);
        }

        /// <summary>
        /// 将当前字符串转换为全角。
        /// </summary>
        /// <param name="value">需要转换的字符串。</param>
        /// <returns>转换后的字符串。</returns>
        /// <exception cref="ArgumentNullException"><c>value</c> 为 null。</exception>
        [SuppressMessage("Microsoft.Naming", "CA1709")]
// ReSharper disable InconsistentNaming
        public static string ToSBC(this string value)
// ReSharper restore InconsistentNaming
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (value.Length == 0)
            {
                return value;
            }
            var sb = new StringBuilder(value.Length);
            foreach (var c in value)
            {
                if (c == 32)
                {
                    sb.Append((char)12288);
                }
                else if (c < 127)
                {
                    sb.Append((char)(c + 65248));
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 将当前字符串转换为全角。
        /// </summary>
        /// <param name="value">需要转换的字符串。</param>
        /// <returns>转换后的字符串。</returns>
        [SuppressMessage("Microsoft.Naming", "CA1709")]
// ReSharper disable InconsistentNaming
        public static string ToSBCSafely(this string value)
// ReSharper restore InconsistentNaming
        {
            return string.IsNullOrEmpty(value) ? value : ToSBC(value);
        }

        /// <summary>
        /// 从当前 System.String 对象移除数组中指定的一组字符的所有尾部匹配项。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <param name="trimChars">要删除的 Unicode 字符的数组，或 null。</param>
        /// <returns>从当前字符串的结尾移除所出现的所有 trimChars 参数中的字符后剩余的字符串。 如果 trimChars 为 null 或空数组，则改为删除 Unicode 空白字符。</returns>
        [SuppressMessage("Microsoft.Naming", "CA1720")]
        public static string TrimEndSafely(this string value, params  char[] trimChars)
        {
            return string.IsNullOrEmpty(value) ? value : value.TrimEnd(trimChars);
        }

        /// <summary>
        /// 从当前 System.String 对象移除所有前导空白字符和尾部空白字符。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>从当前字符串的开头和结尾删除所有空白字符后剩余的字符串。</returns>
        public static string TrimSafely(this string value)
        {
            return string.IsNullOrEmpty(value) ? value : value.Trim();
        }

        /// <summary>
        /// 从当前 System.String 对象移除数组中指定的一组字符的所有前导匹配项和尾部匹配项。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <param name="trimChars">要删除的 Unicode 字符的数组，或 null。</param>
        /// <returns>从当前字符串的开头和结尾删除所出现的所有 trimChars 参数中的字符后剩余的字符串。 如果 trimChars 为 null 或空数组，则改为移除空白字符。</returns>
        [SuppressMessage("Microsoft.Naming", "CA1720")]
        public static string TrimSafely(this string value, params char[] trimChars)
        {
            return string.IsNullOrEmpty(value) ? value : value.Trim(trimChars);
        }

        /// <summary>
        /// 从当前 System.String 对象移除数组中指定的一组字符的所有前导匹配项。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <param name="trimChars">要删除的 Unicode 字符的数组，或 null。</param>
        /// <returns>从当前字符串的开头移除所出现的所有 trimChars 参数中的字符后剩余的字符串。 如果 trimChars 为 null 或空数组，则改为移除空白字符。</returns>
        [SuppressMessage("Microsoft.Naming", "CA1720")]
        public static string TrimStartSafely(this string value, params  char[] trimChars)
        {
            return string.IsNullOrEmpty(value) ? value : value.TrimStart(trimChars);
        }
    }
}