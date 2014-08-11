using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable CheckNamespace
namespace System.IO
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// Stream 扩展类。
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        /// 从当前流异步读取字节序列，并将流中的位置向前移动读取的字节数。
        /// </summary>
        /// <param name="stream">当前 System.IO.Stream 对象。</param>
        /// <param name="buffer">数据写入的缓冲区。</param>
        /// <param name="offset"><c>buffer</c> 中的字节偏移量，从该偏移量开始写入从流中读取的数据。</param>
        /// <param name="count">最多读取的字节数。</param>
        /// <returns>表示异步读取操作的任务。 TResult 参数的值包含读入缓冲区的总字节数。 如果当前可用字节数少于所请求的字节数，则该结果值可能小于所请求的字节数，或者如果已到达流的末尾时，则为 0（零）。</returns>
        /// <exception cref="ArgumentNullException"><c>buffer</c> 为 null。</exception>
        /// <exception cref="ArgumentOutOfRangeException"><c>offset</c> 或 <c>count</c> 为负。</exception>
        /// <exception cref="ArgumentException"><c>offset</c> 与 <c>count</c> 的和大于缓冲区长度。</exception>
        /// <exception cref="NotSupportedException">流不支持读取。</exception>
        /// <exception cref="ObjectDisposedException">流已被释放。</exception>
        /// <exception cref="InvalidOperationException">该流正在由其前一次读取操作使用。</exception>
        public static Task<int> ReadAsync(this Stream stream, byte[] buffer, int offset, int count)
        {
            return ReadAsync(stream, buffer, offset, count, CancellationToken.None);
        }

        /// <summary>
        /// 从当前流异步读取字节序列，将流中的位置向前移动读取的字节数，并监控取消请求。
        /// </summary>
        /// <param name="stream">当前 System.IO.Stream 对象。</param>
        /// <param name="buffer">数据写入的缓冲区。</param>
        /// <param name="offset"><c>buffer</c> 中的字节偏移量，从该偏移量开始写入从流中读取的数据。</param>
        /// <param name="count">最多读取的字节数。</param>
        /// <param name="cancellationToken">针对取消请求监视的标记。 默认值为 None。</param>
        /// <returns>表示异步读取操作的任务。 TResult 参数的值包含读入缓冲区的总字节数。 如果当前可用字节数少于所请求的字节数，则该结果值可能小于所请求的字节数，或者如果已到达流的末尾时，则为 0（零）。</returns>
        /// <exception cref="ArgumentNullException"><c>buffer</c> 为 null。</exception>
        /// <exception cref="ArgumentOutOfRangeException"><c>offset</c> 或 <c>count</c> 为负。</exception>
        /// <exception cref="ArgumentException"><c>offset</c> 与 <c>count</c> 的和大于缓冲区长度。</exception>
        /// <exception cref="NotSupportedException">流不支持读取。</exception>
        /// <exception cref="ObjectDisposedException">流已被释放。</exception>
        /// <exception cref="InvalidOperationException">该流正在由其前一次读取操作使用。</exception>
        public static Task<int> ReadAsync(this Stream stream, byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            return cancellationToken.IsCancellationRequested ? (Task<int>)(typeof(Task).GetMethods(BindingFlags.Static | BindingFlags.NonPublic).First(temp => temp.Name == "FromCancellation" && temp.IsGenericMethod && temp.GetParameters()[0].ParameterType == typeof(CancellationToken)).MakeGenericMethod(typeof(int)).Invoke(null, new object[] { cancellationToken })) : (Task<int>)(typeof(Stream).GetMethod("BeginEndReadAsync", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(stream, new object[] { buffer, offset, count }));
        }
    }
}