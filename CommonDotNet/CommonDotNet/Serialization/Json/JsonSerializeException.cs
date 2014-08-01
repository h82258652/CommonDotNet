using System;
using System.Runtime.Serialization;
using System.Text;

namespace Common.Serialization.Json
{
    /// <summary>
    /// 表示 JSON 序列化过程中产生异常。
    /// </summary>
    [Serializable]
    public class JsonSerializeException : JsonException, ISerializable
    {
        /// <summary>
        /// 初始化 Common.Serialization.Json.JsonSerializeException 类的新实例。
        /// </summary>
        public JsonSerializeException()
        {
        }

        /// <summary>
        /// 使用指定的错误信息初始化 Common.Serialization.Json.JsonSerializeException 类的新实例。
        /// </summary>
        /// <param name="message">描述错误的消息。</param>
        public JsonSerializeException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// 使用指定错误消息和对作为此异常原因的内部异常的引用来初始化 Common.Serialization.Json.JsonSerializeException 类的新实例。
        /// </summary>
        /// <param name="message">解释异常原因的错误信息。</param>
        /// <param name="innerException">导致当前异常的异常；如果未指定内部异常，则是一个 null 引用（在 Visual Basic 中为 Nothing）。</param>
        public JsonSerializeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// 序列化 JSON 过程中产生异常。
        /// </summary>
        /// <param name="processedJson">已经序列化的 JSON 部分。</param>
        public JsonSerializeException(StringBuilder processedJson)
        {
            if (processedJson != null)
            {
                ProcessedJson = processedJson.ToString();
            }
        }

        /// <summary>
        /// 用序列化数据初始化 Common.Serialization.Json.JsonSerializeException 类的新实例。
        /// </summary>
        /// <param name="info">System.Runtime.Serialization.SerializationInfo，它存有有关所引发的异常的序列化对象数据。</param>
        /// <param name="context">System.Runtime.Serialization.StreamingContext，它包含有关源或目标的上下文信息。</param>
        /// <exception cref="System.ArgumentNullException"><c>info</c> 参数为 null。</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">类名为 null 或 System.Exception.HResult 为零 (0)。</exception>
        protected JsonSerializeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// 表示产生异常时，已经序列化的 JSON 部分。
        /// </summary>
        public string ProcessedJson
        {
            get;
            internal set;
        }

        /// <summary>
        /// 当在派生类中重写时，用关于异常的信息设置 System.Runtime.Serialization.SerializationInfo。
        /// </summary>
        /// <param name="info">System.Runtime.Serialization.SerializationInfo，它存有有关所引发的异常的序列化对象数据。</param>
        /// <param name="context">System.Runtime.Serialization.StreamingContext，它包含有关源或目标的上下文信息。</param>
        /// <exception cref="System.ArgumentNullException"><c>info</c> 参数是空引用（Visual Basic 中为 Nothing）。</exception>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            base.GetObjectData(info, context);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            GetObjectData(info, context);
        }

        /// <summary>
        /// 表示该序列化 JSON 异常的信息。
        /// </summary>
        /// <returns>已序列化 JSON 的部分。</returns>
        public override string ToString()
        {
            return "序列化 JSON 中产生异常。" + Environment.NewLine + "已序列化 JSON 部分：" + Environment.NewLine + ProcessedJson;
        }
    }
}