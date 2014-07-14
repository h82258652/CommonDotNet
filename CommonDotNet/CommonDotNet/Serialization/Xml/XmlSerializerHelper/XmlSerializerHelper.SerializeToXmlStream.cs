using System.IO;
using System.Xml.Serialization;

namespace Common.Serialization.Xml
{
    public static partial class XmlSerializerHelper
    {
        /// <summary>
        /// 将当前对象 XML 序列化到内存流中。
        /// </summary>
        /// <typeparam name="T">序列化的对象的类型。</typeparam>
        /// <param name="obj">序列化的对象。</param>
        /// <returns>序列化的 XML 内存流。</returns>
        public static MemoryStream SerializeToXmlStream<T>(this T obj)
        {
            var xs = new XmlSerializer(typeof(T));
            var ms = new MemoryStream();
            xs.Serialize(ms, obj);
            return ms;
        }
    }
}
