using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace System
{
    public static partial class StringExtension
    {
        /// <summary>
        /// 将当前字符串转换为半角。
        /// </summary>
        /// <param name="value">需要转换的字符串。</param>
        /// <returns>转换后的字符串。</returns>
        /// <exception cref="System.ArgumentNullException"><c>value</c> 为 null。</exception>
        [SuppressMessage("Microsoft.Naming","CA1709")]
        public static string ToDBC(this string value)
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
            foreach (char c in value)
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
        public static string ToDBCSafely(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            return ToDBC(value);
        }
    }
}
