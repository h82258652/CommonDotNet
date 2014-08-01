using System;
using System.Runtime.Serialization;

namespace Common.Serialization.Json
{
    /// <summary>
    /// 表示 JSON 序列化或反序列化过程中产生异常。
    /// </summary>
    [Serializable]
    public class JsonException : Exception
    {
        /// <summary>
        /// 初始化 Common.Serialization.Json.JsonException 类的新实例。
        /// </summary>
        public JsonException()
        {
        }

        /// <summary>
        /// 使用指定的错误信息初始化 Common.Serialization.Json.JsonException 类的新实例。
        /// </summary>
        /// <param name="message">描述错误的消息。</param>
        public JsonException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// 使用指定错误消息和对作为此异常原因的内部异常的引用来初始化 Common.Serialization.Json.JsonException 类的新实例。
        /// </summary>
        /// <param name="message">解释异常原因的错误信息。</param>
        /// <param name="innerException">导致当前异常的异常；如果未指定内部异常，则是一个 null 引用（在 Visual Basic 中为 Nothing）。</param>
        public JsonException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// 用序列化数据初始化 Common.Serialization.Json.JsonException 类的新实例。
        /// </summary>
        /// <param name="info">System.Runtime.Serialization.SerializationInfo，它存有有关所引发的异常的序列化对象数据。</param>
        /// <param name="context">System.Runtime.Serialization.StreamingContext，它包含有关源或目标的上下文信息。</param>
        /// <exception cref="System.ArgumentNullException"><c>info</c> 参数为 null。</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">类名为 null 或 System.Exception.HResult 为零 (0)。</exception>
        protected JsonException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}