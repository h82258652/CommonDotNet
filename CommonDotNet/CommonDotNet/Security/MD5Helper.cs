using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Common.Security
{
    /// <summary>
    /// MD5 帮助类。
    /// </summary>
    // ReSharper disable InconsistentNaming
    public static class MD5Helper
    // ReSharper restore InconsistentNaming
    {   /// <summary>
        /// 获取文件的 32 位 MD5 大写。
        /// </summary>
        /// <param name="filePath">需计算 MD5 的文件。</param>
        /// <returns> 32 位 MD5 大写。</returns>
        /// <exception cref="FileNotFoundException"><c>filePath</c> 不存在。</exception>
        // ReSharper disable InconsistentNaming
        public static string GetFileMD5(string filePath)
        // ReSharper restore InconsistentNaming
        {
            if (File.Exists(filePath) == false)
            {
                throw new FileNotFoundException("文件不存在！", filePath);
            }
            using (var md5Csp = new MD5CryptoServiceProvider())
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var bytes = md5Csp.ComputeHash(fs);
                    return BitConverter.ToString(bytes).Replace("-", string.Empty);
                }
            }
        }

        /// <summary>
        /// 获取字符串的 32 位 MD5 大写。
        /// </summary>
        /// <param name="input">需计算 MD5 的字符串。</param>
        /// <returns> 32 位 MD5 大写。</returns>
        /// <exception cref="ArgumentNullException"><c>input</c> 为 null。</exception>
        // ReSharper disable InconsistentNaming
        public static string GetStringMD5(string input)
        // ReSharper restore InconsistentNaming
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
        // ReSharper disable InconsistentNaming
        public static string GetStringMD5(string input, string prefix)
        // ReSharper restore InconsistentNaming
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