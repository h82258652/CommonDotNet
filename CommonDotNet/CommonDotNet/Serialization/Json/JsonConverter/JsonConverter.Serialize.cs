using System;

namespace Common.Serialization.Json
{
    public abstract partial class JsonConverter
    {
        /// <summary>
        /// 实现此方法以自定义 JSON 序列化。
        /// </summary>
        /// <param name="value">字段或属性的值。</param>
        /// <param name="type">字段或属性的类型。</param>
        /// <param name="skip">是否跳过此字段或属性的 JSON 序列化。默认 false。</param>
        /// <returns> JSON 字符串。</returns>
        public abstract string Serialize(object value, Type type, ref bool skip);
    }
}
