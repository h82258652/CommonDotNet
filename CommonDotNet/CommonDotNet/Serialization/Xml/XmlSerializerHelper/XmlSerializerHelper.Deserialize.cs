using System.IO;
using System.Xml.Serialization;

namespace Common.Serialization.Xml
{
    public static partial class XmlSerializerHelper
    {
        /// <summary>
        /// 将指定的 XML 流反序列化为 T 类型的对象。
        /// </summary>
        /// <typeparam name="T">所生成对象的类型。</typeparam>
        /// <param name="input">要进行反序列化的 XML 流。</param>
        /// <returns>反序列化的对象。</returns>
        public static T Deserialize<T>(Stream input)
        {
            var xs = new XmlSerializer(typeof(T));
            return (T)xs.Deserialize(input);
        }

        /// <summary>
        /// 将指定的 XML 文件反序列化为 T 类型的对象。
        /// </summary>
        /// <typeparam name="T">所生成对象的类型。</typeparam>
        /// <param name="filePath">文件路径。</param>
        /// <returns>反序列化的对象。</returns>
        public static T Deserialize<T>(string filePath)
        {
            var xs = new XmlSerializer(typeof(T));
            return (T)xs.Deserialize(File.OpenRead(filePath));
        }
    }
}
