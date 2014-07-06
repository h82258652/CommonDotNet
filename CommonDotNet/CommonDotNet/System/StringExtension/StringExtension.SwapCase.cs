using System.Globalization;
using System.Text;

namespace System
{
    public static partial class StringExtension
    {
        /// <summary>
        /// 将字符串中的大写字母变小写字母，小写字母变大写字母。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>转换后的字符串。</returns>
        /// <exception cref="System.ArgumentNullException"><c>value</c> 为 null。</exception>
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
            foreach (char c in value)
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
    }
}
