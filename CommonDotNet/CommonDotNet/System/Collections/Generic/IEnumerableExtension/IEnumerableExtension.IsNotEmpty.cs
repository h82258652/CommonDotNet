using System.Linq;

namespace System.Collections.Generic
{
    public static partial class IEnumerableExtension
    {
        /// <summary>
        /// 指示序列是否包含元素。
        /// </summary>
        /// <typeparam name="T">元素的类型。</typeparam>
        /// <param name="source">序列。</param>
        /// <returns>若序列包含元素，则返回真，否则返回假。</returns>
        /// <exception cref="System.ArgumentNullException"><c>source</c> 为 null。</exception>
        public static bool IsNotEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Any() == false;
        }
    }
}
