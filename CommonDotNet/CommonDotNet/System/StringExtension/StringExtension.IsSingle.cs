
namespace System
{
    public static partial class StringExtension
    {
        /// <summary>
        /// 指示当前字符串是否能转换为单精度浮点数。
        /// </summary>
        /// <param name="value">当前 System.String 对象。</param>
        /// <returns>是否能转换为单精度浮点数。</returns>
        public static bool IsSingle(this string value)
        {
            float f;
            return float.TryParse(value, out f);
        }
    }
}
