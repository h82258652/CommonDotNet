using System;
using System.Runtime.Serialization;

namespace Common.Serialization.Json
{
    /// <summary>
    /// 表示 JSON 反序列化过程中产生异常。
    /// </summary>
    [Serializable]
    public class JsonDeserializeException : JsonException
    {
        /// <summary>
        /// 初始化 Common.Serialization.Json.JsonDeserializeException 类的新实例。
        /// </summary>
        public JsonDeserializeException()
        {
        }

        /// <summary>
        /// 使用指定的错误信息初始化 Common.Serialization.Json.JsonDeserializeException 类的新实例。
        /// </summary>
        /// <param name="message">描述错误的消息。</param>
        public JsonDeserializeException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// 使用指定错误消息和对作为此异常原因的内部异常的引用来初始化 Common.Serialization.Json.JsonDeserializeException 类的新实例。
        /// </summary>
        /// <param name="message">解释异常原因的错误信息。</param>
        /// <param name="innerException">导致当前异常的异常；如果未指定内部异常，则是一个 null 引用（在 Visual Basic 中为 Nothing）。</param>
        public JsonDeserializeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// 使用反序列化失败的字符串及类型初始化 JsonDeserializeException 类的新实例。
        /// </summary>
        /// <param name="input">反序列化失败的字符串。</param>
        /// <param name="type">反序列化失败的类型。</param>
        public JsonDeserializeException(string input, Type type)
            : base("无法将 " + input + " 反序列化为 " + PassThroughNonNull(type).Name + " 的类型。")
        {
        }

        /// <summary>
        /// 用序列化数据初始化 Common.Serialization.Json.JsonDeserializationException 类的新实例。
        /// </summary>
        /// <param name="info">System.Runtime.Serialization.SerializationInfo，它存有有关所引发的异常的序列化对象数据。</param>
        /// <param name="context">System.Runtime.Serialization.StreamingContext，它包含有关源或目标的上下文信息。</param>
        /// <exception cref="System.ArgumentNullException"><c>info</c> 参数为 null。</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">类名为 null 或 System.Exception.HResult 为零 (0)。</exception>
        protected JsonDeserializeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        private static Type PassThroughNonNull(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            return type;
        }
    }
}