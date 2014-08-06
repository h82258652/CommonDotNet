// ReSharper disable CheckNamespace
namespace System.Runtime.InteropServices
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// Marshal 扩展类。
    /// </summary>
    public static class MarshalExtensions
    {
        /// <summary>
        /// 返回非托管类型的大小（以字节为单位）。
        /// </summary>
        /// <typeparam name="T">要返回其大小的类型。</typeparam>
        /// <returns><c>T</c> 泛型类型参数指定的类型的大小（以字节为单位）。</returns>
        public static int SizeOf<T>()
        {
            return Marshal.SizeOf(typeof(T));
        }

        /// <summary>
        /// 返回指定类型的对象的非托管大小（以字节为单位）。
        /// </summary>
        /// <typeparam name="T">要返回其大小的对象。</typeparam>
        /// <param name="structure">structure 参数的类型。</param>
        /// <returns>非托管代码中指定对象的大小（以字节为单位）。</returns>
        /// <exception cref="ArgumentNullException"><c>structure</c> 参数为 null。</exception>
        public static int SizeOf<T>(T structure)
        {
            return Marshal.SizeOf(structure);
        }
    }
}