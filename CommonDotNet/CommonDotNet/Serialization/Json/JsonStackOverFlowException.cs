using System;
using System.Runtime.Serialization;

namespace Common.Serialization.Json
{
    /// <summary>
    /// JSON 序列化或反序列化时超出指定的深度时产生的异常。
    /// </summary>
    [Serializable]
    public sealed class JsonStackOverFlowException : JsonException, ISerializable
    {
        /// <summary>
        /// 初始化 Common.Serialization.Json.JsonStackOverFlowException 类的新实例。
        /// </summary>
        public JsonStackOverFlowException()
        {
        }

        /// <summary>
        /// 使用指定错误消息和对作为此异常原因的内部异常的引用来初始化 Common.Serialization.Json.JsonStackOverFlowException 类的新实例。
        /// </summary>
        /// <param name="message">解释异常原因的错误信息。</param>
        /// <param name="innerException">导致当前异常的异常；如果未指定内部异常，则是一个 null 引用（在 Visual Basic 中为 Nothing）。</param>
        public JsonStackOverFlowException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// 使用指定的错误信息初始化 Common.Serialization.Json.JsonStackOverFlowException 类的新实例。
        /// </summary>
        /// <param name="message">描述错误的消息。</param>
        public JsonStackOverFlowException(string message)
            : base(message)
        {
        }

        internal JsonStackOverFlowException(int maxStackLevel)
        {
            MaxStackLevel = maxStackLevel;
        }

        private JsonStackOverFlowException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// 允许的最大深度。
        /// </summary>
        public int MaxStackLevel
        {
            get;
            private set;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            GetObjectData(info, context);
        }

        /// <summary>
        /// 显示当前异常的信息。
        /// </summary>
        /// <returns>异常的信息。</returns>
        public override string ToString()
        {
            return "序列化或反序列化超出最大深度：" + MaxStackLevel + "。";
        }
    }
}