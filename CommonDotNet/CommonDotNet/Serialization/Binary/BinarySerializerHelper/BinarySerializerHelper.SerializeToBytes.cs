using System.IO;

namespace Common.Serialization.Binary
{
    public static partial class BinarySerializeHelper
    {
        /// <summary>
        /// 将当前对象转换为字节数组。（需要对对象的类用 Serializable 进行标记）
        /// </summary>
        /// <typeparam name="T">序列化的对象的类型。</typeparam>
        /// <param name="input">序列化的对象。</param>
        /// <returns>序列化的字节数组。</returns>
        public static byte[] SerializeToBytes<T>(this T input)
        {
            using (var ms = new MemoryStream())
            {
                Bf.Serialize(ms, input);
                return ms.ToArray();
            }
        }
    }
}
