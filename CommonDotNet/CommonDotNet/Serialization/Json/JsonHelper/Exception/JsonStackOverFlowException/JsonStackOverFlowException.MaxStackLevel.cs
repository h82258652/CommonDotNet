using System.Runtime.Serialization;

namespace Common.Serialization.Json.Exception
{
    public sealed partial class JsonStackOverFlowException : System.Exception, ISerializable
    {
        /// <summary>
        /// 允许的最大深度。
        /// </summary>
        public int MaxStackLevel
        {
            get;
            private set;
        }
    }
}
