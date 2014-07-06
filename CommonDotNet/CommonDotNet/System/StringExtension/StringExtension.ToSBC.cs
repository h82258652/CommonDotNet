using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace System
{
    public static partial class StringExtension
    {
        /// <summary>
        /// 将当前字符串转换为全角。
        /// </summary>
        /// <param name="value">需要转换的字符串。</param>
        /// <returns>转换后的字符串。</returns>
        /// <exception cref="System.ArgumentNullException"><c>value</c> 为 null。</exception>
        [SuppressMessage("Microsoft.Naming", "CA1709")]
        public static string ToSBC(this string value)
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
        public static string ToSBCSafely(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            return ToSBC(value);
        }
    }
}
