using System.IO;

namespace Common.Serialization.Binary
{
    public static partial class BinarySerializeHelper
    {
        /// <summary>
        /// 将指定的字节数组转换为 T 类型的对象。
        /// </summary>
        /// <typeparam name="T">所生成对象的类型。</typeparam>
        /// <param name="value">要进行反序列化的字节数组。</param>
        /// <returns>反序列化的对象。</returns>
        public static T Deserialize<T>(byte[] value)
        {
            using (var ms = new MemoryStream(value))
            {
                return (T)Bf.Deserialize(ms);
            }
        }
    }
}
