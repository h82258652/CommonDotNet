using System;
using System.Runtime.Serialization;

namespace Common.Serialization.Json
{
    /// <summary>
    /// 表示序列化 JSON 过程中值是必须的。
    /// </summary>
    [Serializable]
    public sealed class JsonValueRequiredException : JsonSerializeException, ISerializable
    {
        /// <summary>
        /// 初始化 Common.Serialization.Json.JsonValueRequiredException 类的新实例。
        /// </summary>
        public JsonValueRequiredException()
        {
        }

        /// <summary>
        /// 使用指定的错误信息初始化 Common.Serialization.Json.JsonValueRequiredException 类的新实例。
        /// </summary>
        /// <param name="message">描述错误的消息。</param>
        public JsonValueRequiredException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// 使用指定错误消息和对作为此异常原因的内部异常的引用来初始化 Common.Serialization.Json.JsonValueRequiredException 类的新实例。
        /// </summary>
        /// <param name="message">解释异常原因的错误信息。</param>
        /// <param name="innerException">导致当前异常的异常；如果未指定内部异常，则是一个 null 引用（在 Visual Basic 中为 Nothing）。</param>
        public JsonValueRequiredException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// 使用指定的错误信息初始化 Common.Serialization.Json.JsonValueRequiredException 类的新实例。
        /// </summary>
        /// <param name="message">描述错误的消息。</param>
        /// <param name="memberName">产生错误的成员名字。</param>
        public JsonValueRequiredException(string message, string memberName)
            : base(message)
        {
            MemberName = memberName;
        }

        /// <summary>
        /// 用序列化数据初始化 Common.Serialization.Json.JsonValueRequiredException 类的新实例。
        /// </summary>
        /// <param name="info">System.Runtime.Serialization.SerializationInfo，它存有有关所引发的异常的序列化对象数据。</param>
        /// <param name="context">System.Runtime.Serialization.StreamingContext，它包含有关源或目标的上下文信息。</param>
        /// <exception cref="System.ArgumentNullException"><c>info</c> 参数为 null。</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">类名为 null 或 System.Exception.HResult 为零 (0)。</exception>
        private JsonValueRequiredException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// 需要值的成员的名字。
        /// </summary>
        public string MemberName
        {
            get;
            private set;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            GetObjectData(info, context);
        }

        /// <summary>
        /// 指示产生该错误的成员名字。
        /// </summary>
        /// <returns>错误描述。</returns>
        public override string ToString()
        {
            return MemberName + " 的值必须。";
        }
    }
}