using System;
using System.Runtime.Serialization;

namespace Common.Serialization.Json.Exception
{
    /// <summary>
    /// JSON 序列化或反序列化时超出指定的深度时产生的异常。
    /// </summary>
    [Serializable]
    public sealed partial class JsonStackOverFlowException : System.Exception, ISerializable
    {
        internal JsonStackOverFlowException(int maxStackLevel)
        {
            MaxStackLevel = maxStackLevel;
        }
    }
}
