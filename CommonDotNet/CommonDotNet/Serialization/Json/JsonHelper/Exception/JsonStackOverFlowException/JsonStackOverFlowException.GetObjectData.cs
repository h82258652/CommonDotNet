using System.Runtime.Serialization;

namespace Common.Serialization.Json.Exception
{
    public sealed partial class JsonStackOverFlowException : System.Exception, ISerializable
    {
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            GetObjectData(info, context);
        }
    }
}
