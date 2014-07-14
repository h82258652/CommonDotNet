using System;
using System.IO;
using System.Xml.Serialization;

namespace Common.Serialization.Xml
{
    public static partial class XmlSerializerHelper
    {
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
    }
}
