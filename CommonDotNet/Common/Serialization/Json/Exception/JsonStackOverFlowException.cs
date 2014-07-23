using System;
using System.Runtime.Serialization;

namespace Common.Serialization.Json.Exception
{
    /// <summary>
    /// JSON 序列化或反序列化时超出指定的深度时产生的异常。
    /// </summary>
    [Serializable]
    public sealed class JsonStackOverFlowException : System.Exception, ISerializable
    {
        public JsonStackOverFlowException()
        {
        }

        public JsonStackOverFlowException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

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