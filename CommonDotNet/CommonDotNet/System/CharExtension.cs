﻿// ReSharper disable CheckNamespace
namespace System
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// Char 扩展类。
    /// </summary>
    public static class CharExtension
    {
        /// <summary>
        /// 指示当前字符是否属于中文字符。
        /// </summary>
        /// <param name="value">测试的字符。</param>
        /// <returns>是否属于中文字符。</returns>
        public static bool IsChinese(this char value)
        {
            return value >= 0x4e00 && value <= 0x9fa5;
        }

        /// <summary>
        /// 指示当前字符是否属于十进制数字类别。（即字符'0'-'9'）
        /// </summary>
        /// <param name="value">测试的字符。</param>
        /// <returns>是否属于十进制数字类别。</returns>
        public static bool IsDigit(this char value)
        {
            return char.IsDigit(value);
        }

        /// <summary>
        /// 指示当前字符是否属于十六进制字符类别。
        /// </summary>
        /// <param name="value">测试的字符。</param>
        /// <returns>是否属于十六进制字符类别。</returns>
        public static bool IsHex(this char value)
        {
            switch (value)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case 'a':
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'f':
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                    {
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        /// <summary>
        /// 指示当前字符是否属于小写字母类别。
        /// </summary>
        /// <param name="value">测试的字符。</param>
        /// <returns>是否属于小写字母类别。</returns>
        public static bool IsLower(this char value)
        {
            return char.IsLower(value);
        }

        /// <summary>
        /// 指示当前字符是否属于数字类别。（'0'-'9'及例如罗马字母'Ⅰ'等字符）
        /// </summary>
        /// <param name="value">测试的字符。</param>
        /// <returns>是否属于数字类别。</returns>
        public static bool IsNumber(this char value)
        {
            return char.IsNumber(value);
        }

        /// <summary>
        /// 指示当前字符是否属于大写字母类别。
        /// </summary>
        /// <param name="value">测试的字符。</param>
        /// <returns>是否属于大写字母类别。</returns>
        public static bool IsUpper(this char value)
        {
            return char.IsUpper(value);
        }
    }
}