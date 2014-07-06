
namespace System
{
    public static partial class CharExtension
    {
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
                    return true;
                default:
                    return false;
            }
        }
    }
}
