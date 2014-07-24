using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml.Serialization;

namespace Common.Serialization.Xml
{
    /// <summary>
    /// XmlSerializer 帮助类。
    /// </summary>
    public static class XmlSerializerHelper
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
            var xs = new XmlSerializer(typeof (T));
            using (var fs = File.OpenRead(filePath))
            {
                return (T) xs.Deserialize(fs);
            }
        }

        /// <summary>
        /// 将当前对象以 XML 格式保存在文件中。
        /// </summary>
        /// <typeparam name="T">序列化的对象的类型。</typeparam>
        /// <param name="obj">序列化的对象。</param>
        /// <param name="filePath">文件路径。</param>
        /// <returns>是否序列化成功。</returns>
        public static bool SerializeToXmlFile<T>(this T obj, string filePath)
        {
            var xs = new XmlSerializer(typeof(T));
            using (var fileStream = File.Create(filePath))
            {
                try
                {
                    xs.Serialize(fileStream, obj);
                    return true;
                }
                catch (InvalidOperationException)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 将当前对象 XML 序列化到内存流中。
        /// </summary>
        /// <typeparam name="T">序列化的对象的类型。</typeparam>
        /// <param name="obj">序列化的对象。</param>
        /// <returns>序列化的 XML 内存流。</returns>
        [SuppressMessage("Microsoft.Reliability","CA2000")]
        public static MemoryStream SerializeToXmlStream<T>(this T obj)
        {
            var xs = new XmlSerializer(typeof(T));
            var ms = new MemoryStream();
            xs.Serialize(ms, obj);
            return ms;
        }
    }
}