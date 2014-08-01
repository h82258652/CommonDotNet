using System;
using System.Runtime.Serialization;

namespace Common.Serialization.Json
{
    /// <summary>
    /// JSON 序列化过程中产生重复的键引起的错误。
    /// </summary>
    [Serializable]
    public sealed class JsonKeyRepeatException : JsonSerializeException, ISerializable
    {
        /// <summary>
        /// 初始化 Common.Serialization.Json.JsonKeyRepeatException 类的新实例。
        /// </summary>
        public JsonKeyRepeatException()
        {
        }

        /// <summary>
        /// 使用指定的错误信息初始化 Common.Serialization.Json.JsonKeyRepeatException 类的新实例。
        /// </summary>
        /// <param name="message">描述错误的消息。</param>
        public JsonKeyRepeatException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// 使用指定错误消息和对作为此异常原因的内部异常的引用来初始化 Common.Serialization.Json.JsonKeyRepeatException 类的新实例。
        /// </summary>
        /// <param name="message">解释异常原因的错误信息。</param>
        /// <param name="innerException">导致当前异常的异常；如果未指定内部异常，则是一个 null 引用（在 Visual Basic 中为 Nothing）。</param>
        public JsonKeyRepeatException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// 由于重复键而引起 JSON 序列化错误。
        /// </summary>
        /// <param name="message">描述错误的消息。</param>
        /// <param name="key">引起错误的键。</param>
        public JsonKeyRepeatException(string message, string key)
            : base(message)
        {
            Key = key;
        }

        /// <summary>
        /// 用序列化数据初始化 Common.Serialization.Json.JsonKeyRepeatException 类的新实例。
        /// </summary>
        /// <param name="info">System.Runtime.Serialization.SerializationInfo，它存有有关所引发的异常的序列化对象数据。</param>
        /// <param name="context">System.Runtime.Serialization.StreamingContext，它包含有关源或目标的上下文信息。</param>
        /// <exception cref="System.ArgumentNullException"><c>info</c> 参数为 null。</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">类名为 null 或 System.Exception.HResult 为零 (0)。</exception>
        private JsonKeyRepeatException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// 引起错误的键的名称。
        /// </summary>
        public string Key
        {
            get;
            internal set;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            GetObjectData(info, context);
        }

        /// <summary>
        /// 指示该错误的原因。
        /// </summary>
        /// <returns>引起该错误的键的名称。</returns>
        public override string ToString()
        {
            return Key + " 键已经序列化。";
        }
    }
}