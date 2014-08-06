using System.Reflection;
using System.Security;

// ReSharper disable CheckNamespace
namespace System
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// GC 扩展类。
    /// </summary>
    // ReSharper disable InconsistentNaming
    public static class GCExtensions
    // ReSharper restore InconsistentNaming
    {
        /// <summary>
        /// 通过制定生成来强制从生成 0 进行垃圾回收，同时由 GCCollectionMode 值来指定，附加还有数值指定回收是否被阻止。
        /// </summary>
        /// <param name="generation">可执行垃圾回收的最早的代的编号。</param>
        /// <param name="mode">枚举值之一，指定是否强制（GCCollectionMode.Default 或 GCCollectionMode.Forced）或优化 (GCCollectionMode.Optimized) 垃圾回收。</param>
        /// <param name="blocking">true 执行阻拦垃圾回收；false 在可能的情况下执行后台垃圾回收。</param>
        /// <exception cref="ArgumentOutOfRangeException"><c>generation</c> 无效或 <c>mode</c> 不是 GCCollectionMode 值之一。</exception>
        [SecuritySafeCritical]
        public static void Collect(int generation, GCCollectionMode mode, bool blocking)
        {
            if (generation < 0)
            {
                throw new ArgumentOutOfRangeException("generation", (string)typeof(Environment).GetMethod("GetResourceString", BindingFlags.Static | BindingFlags.NonPublic, null, new[] { typeof(string) }, null).Invoke(null, new object[] { "ArgumentOutOfRange_GenericPositive" }));
            }

            if ((mode < GCCollectionMode.Default) || (mode > GCCollectionMode.Optimized))
            {
                throw new ArgumentOutOfRangeException((string)typeof(Environment).GetMethod("GetResourceString", BindingFlags.Static | BindingFlags.NonPublic, null, new[] { typeof(string) }, null).Invoke(null, new object[] { "ArgumentOutOfRange_Enum" }));
            }

            var iInternalModes = 0;

            if (mode == GCCollectionMode.Optimized)
            {
                iInternalModes |= 0x00000004;
            }

            if (blocking)
            {
                iInternalModes |= 0x00000002;
            }
            else
            {
                iInternalModes |= 0x00000001;
            }

            typeof(Environment).GetMethod("_Collect", BindingFlags.Static | BindingFlags.NonPublic, null, new[] { typeof(int), typeof(int) }, null).Invoke(null, new object[] { generation, iInternalModes });
        }
    }
}