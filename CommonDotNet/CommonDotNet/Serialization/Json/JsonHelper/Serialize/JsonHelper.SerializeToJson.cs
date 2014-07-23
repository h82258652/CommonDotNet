using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json.Serialize;

namespace Common.Serialization.Json
{
    public static partial class JsonHelper
    {
        public static string SerializeToJson(this object value)
        {
            JsonSerializer serializer = new JsonSerializer()
            {
                DateTimeFormat = JsonHelper.DateTimeFormat,
                EnumFormat = JsonHelper.EnumFormat,
                RegexFormat = JsonHelper.RegexFormat,
                MaxStackLevel = JsonHelper.MaxStackLevel
            };

            string json;

            // 序列化
            json = serializer.SerializeObject(value);

            // 格式化
            json = FormatJson(json);

            return json;
        }
    }
}
