using System;
using System.Security.Cryptography;
using System.Text;

namespace Common.Security
{
    /// <summary>
    /// MD5 帮助类。
    /// </summary>
    public static partial class MD5Helper
    {
        /// <summary>
        /// 获取字符串的 32 位 MD5 大写。
        /// </summary>
        /// <param name="input">需计算 MD5 的字符串。</param>
        /// <returns> 32 位 MD5 大写。</returns>
        /// <exception cref="ArgumentNullException"><c>input</c> 为 null。</exception>
        public static string GetStringMD5(string input)
        {
            return GetStringMD5(input, null);
        }

        /// <summary>
        /// 获取字符串的 32 位 MD5 大写。
        /// </summary>
        /// <param name="input">需计算 MD5 的字符串。</param>
        /// <param name="prefix">需添加的字符串前缀。</param>
        /// <returns> 32 位 MD5 大写。</returns>
        /// <exception cref="ArgumentNullException"><c>input</c> 为 null。</exception>
        public static string GetStringMD5(string input, string prefix)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            prefix = prefix ?? string.Empty;
            using (var md5Csp = new MD5CryptoServiceProvider())
            {
                var bytes = md5Csp.ComputeHash(Encoding.UTF8.GetBytes(input + prefix));
                return BitConverter.ToString(bytes).Replace("-", string.Empty);
            }
        }
    }
}
