using System.Runtime.Serialization;

namespace Common.Serialization.Json.Exception
{
    public sealed partial class JsonStackOverFlowException : System.Exception, ISerializable
    {
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
