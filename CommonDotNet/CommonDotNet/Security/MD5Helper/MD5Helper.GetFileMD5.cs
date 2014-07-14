using System;
using System.IO;
using System.Security.Cryptography;

namespace Common.Security
{
    public static partial class MD5Helper
    {
        /// <summary>
        /// 获取文件的 32 位 MD5 大写。
        /// </summary>
        /// <param name="filePath">需计算 MD5 的文件。</param>
        /// <returns> 32 位 MD5 大写。</returns>
        /// <exception cref="FileNotFoundException"><c>filePath</c> 不存在。</exception>
        public static string GetFileMD5(string filePath)
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
    }
}
