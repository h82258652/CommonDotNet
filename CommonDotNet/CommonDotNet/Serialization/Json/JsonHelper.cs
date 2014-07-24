using Common.Serialization.Json.Deserialize;
using Common.Serialization.Json.Exception;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Common.Serialization.Json
{
    /// <summary>
    /// Json 帮助类。
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// 缓存类的字段。
        /// </summary>
        internal static volatile Dictionary<Type, FieldInfo[]> TypeFields = new Dictionary<Type, FieldInfo[]>();

        /// <summary>
        /// 缓存类的属性。
        /// </summary>
        internal static volatile Dictionary<Type, PropertyInfo[]> TypeProperties = new Dictionary<Type, PropertyInfo[]>();

        private static DateTimeFormat _dateTimeFormat = DateTimeFormat.Default;

        private static EnumFormat _enumFormat = EnumFormat.Default;

        private static int _maxStackLevel = 20;

        private static RegexFormat _regexFormat = RegexFormat.Default;

        /// <summary>
        /// 设置 DateTime 类型在序列化时的格式，默认 "yyyy-MM-ddTHH:mm:ss.FFFFFFFK"。
        /// </summary>
        public static DateTimeFormat DateTimeFormat
        {
            get
            {
                return _dateTimeFormat;
            }
            set
            {
                if (Enum.IsDefined(typeof(DateTimeFormat), value) == false)
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(DateTimeFormat));
                }
                _dateTimeFormat = value;
            }
        }

        /// <summary>
        /// 设置 Enum 类型在序列化时的格式，默认 value。
        /// </summary>
        public static EnumFormat EnumFormat
        {
            get
            {
                return _enumFormat;
            }
            set
            {
                if (Enum.IsDefined(typeof(EnumFormat), value) == false)
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(EnumFormat));
                }
                _enumFormat = value;
            }
        }

        /// <summary>
        /// Json 序列化与反序列化的最大深度。
        /// </summary>
        public static int MaxStackLevel
        {
            get
            {
                return _maxStackLevel;
            }
            set
            {
                _maxStackLevel = value;
            }
        }

        /// <summary>
        /// 设置 Regex 类型在序列化时的格式，默认 /pattern/attributes。
        /// </summary>
        public static RegexFormat RegexFormat
        {
            get
            {
                return _regexFormat;
            }
            set
            {
                if (Enum.IsDefined(typeof(RegexFormat), value) == false)
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(RegexFormat));
                }
                _regexFormat = value;
            }
        }

        /// <summary>
        /// 序列化时，缩进的空格数，默认为 0。
        /// </summary>
        public static int SerializeIndentationWhiteSpaceCount
        {
            get;
            set;
        }

        /// <summary>
        /// 序列化时，是否格式化 JSON，默认为否。
        /// </summary>
        public static bool SerializeWapp
        {
            get;
            set;
        }

        /// <summary>
        /// 将指定的 JSON 字符串转换为 T 类型的对象。
        /// </summary>
        /// <param name="input">要进行反序列化的 JSON 字符串。</param>
        /// <param name="type">所生成对象的类型。</param>
        /// <returns>反序列化的对象。</returns>
        /// <exception cref="JsonDeserializeException">JSON 格式错误时产生。</exception>
        public static object Deserialize(string input, Type type)
        {
            var deserializer = new JsonDeserializer
            {
                MaxStackLevel = MaxStackLevel
            };

            return deserializer.DeserializeToObject(input, type);
        }

        /// <summary>
        /// 将指定的 JSON 字符串转换为 T 类型的对象。
        /// </summary>
        /// <typeparam name="T">所生成对象的类型。</typeparam>
        /// <param name="input">要进行反序列化的 JSON 字符串。</param>
        /// <returns>反序列化的对象。</returns>
        /// <exception cref="JsonDeserializeException">JSON 格式错误时产生。</exception>
        public static T Deserialize<T>(string input)
        {
            return (T)Deserialize(input, typeof(T));
        }

        /// <summary>
        /// 格式化 JSON 字符串。
        /// </summary>
        /// <param name="json">JSON 字符串。</param>
        /// <returns>格式化后的 JSON 字符串。</returns>
        public static string FormatJson(string json)
        {
            if (SerializeIndentationWhiteSpaceCount < 0)
            {
                throw new ArgumentOutOfRangeException("json", "JSON 格式化缩进空格数不能小于 0。");
            }

            if (string.IsNullOrEmpty(json))
            {
                return json;
            }

            if (SerializeIndentationWhiteSpaceCount == 0 && SerializeWapp == false)
            {
                return json;
            }

            var sb = new StringBuilder();

            // 存储当前缩进等级。
            var level = 0;

            // 是否换行。
            var wrap = SerializeWapp ? Environment.NewLine : string.Empty;

            // 是否在字符串中。
            var inString = false;

            for (var i = 0; i < json.Length; i++)
            {
                if (json[i] == '\"' && i - 1 >= 0 && json[i - 1] != '\\')
                {
                    inString = !inString;
                }
                if (json[i] == '{' && inString == false)
                {
                    sb.Append('{');
                    sb.Append(wrap);
                    level++;
                    BuildIndentation(sb, level);
                }
                else if (json[i] == '}' && inString == false)
                {
                    sb.Append(wrap);
                    level--;
                    BuildIndentation(sb, level);
                    sb.Append('}');
                }
                else if (json[i] == '[' && inString == false)
                {
                    sb.Append('[');
                    sb.Append(wrap);
                    level++;
                    BuildIndentation(sb, level);
                }
                else if (json[i] == ']' && inString == false)
                {
                    sb.Append(wrap);
                    level--;
                    BuildIndentation(sb, level);
                    sb.Append(']');
                }
                else if (json[i] == ':' && inString == false)
                {
                    sb.Append(':');
                    sb.Append(' ');
                }
                else if (json[i] == ',' && inString == false)
                {
                    sb.Append(',');
                    sb.Append(wrap);
                    BuildIndentation(sb, level);
                }
                else if (json[i] == ' ' && inString == false)
                {
                    // 跳过不在字符串中的空白字符。
                }
                else
                {
                    sb.Append(json[i]);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 将当前对象转换为 JSON 字符串。
        /// </summary>
        /// <param name="value">需要进行 JSON 序列化的对象。</param>
        /// <returns>序列化的 JSON 字符串。</returns>
        public static string SerializeToJson(this object value)
        {
            var serializer = new JsonSerializer
            {
                DateTimeFormat = DateTimeFormat,
                EnumFormat = EnumFormat,
                RegexFormat = RegexFormat,
                MaxStackLevel = MaxStackLevel
            };

            // 序列化。
            var json = serializer.SerializeObject(value);

            // 格式化。
            json = FormatJson(json);

            return json;
        }

        /// <summary>
        /// 推断当前 json 基础字符串的类型。
        /// </summary>
        /// <param name="json">json 基础字符串。</param>
        /// <returns>推断类型。无法识别时返回 null。</returns>
        /// <exception cref="ArgumentNullException"><c>json</c> 为 null。</exception>
        public static Type TypeInference(string json)
        {
            if (json==null)
            {
                throw new ArgumentNullException("json");
            }
            json = json.Trim();
            if (json.StartsWith("[",StringComparison.Ordinal) && json.EndsWith("]",StringComparison.Ordinal))
            {
                return typeof(Array);
            }
            if (json.StartsWith("\"",StringComparison.Ordinal) && json.EndsWith("\"",StringComparison.Ordinal))
            {
                if (JsonDeserializer.DateTimeDefaultRegex.IsMatch(json))
                {
                    return typeof(DateTime);
                }
                return JsonDeserializer.DateTimeFunctionRegex.IsMatch(json) ? typeof(DateTime) : typeof(string);
            }
            if (json.StartsWith("{", StringComparison.Ordinal) && json.EndsWith("}", StringComparison.Ordinal))
            {
                return typeof(object);
            }
            if (json == "true" || json == "false")
            {
                return typeof(bool);
            }
            if (json == "null")
            {
                return typeof(object);
            }
            if (JsonDeserializer.DateTimeCreateRegex.IsMatch(json))
            {
                return typeof(DateTime);
            }
            int i;
            if (int.TryParse(json, out i))
            {
                return typeof(int);
            }
            double d;

            return double.TryParse(json, out d) ? typeof(double) : null;
        }

        internal static IEnumerable<string> ItemReader(string input)
        {
            var length = input.Length;
            if (length == 0)
            {
                yield break;
            }
            var startIndex = 0;
            var doubleQuote = 0;// 双引号。
            var bracket = 0;// 中括号。
            var brace = 0;// 大括号。
            for (var i = 0; i < length; i++)
            {
                switch (input[i])
                {
                    case '\\':
                        {
                            i++;
                            break;
                        }
                    case '\"':
                        {
                            doubleQuote = 1 - doubleQuote;
                            break;
                        }
                    case '[':
                        {
                            bracket++;
                            break;
                        }
                    case ']':
                        {
                            bracket--;
                            break;
                        }
                    case '{':
                        {
                            brace++;
                            break;
                        }
                    case '}':
                        {
                            brace--;
                            break;
                        }
                    case ',':
                        {
                            if (bracket == 0 && brace == 0)
                            {
                                var item = input.Substring(startIndex, i - startIndex);
                                startIndex = i + 1;
                                item = item.Trim();
                                yield return item;
                            }
                            break;
                        }
                }
            }
            {
                var item = input.Substring(startIndex, length - startIndex);
                item = item.Trim();
                yield return item;
            }
        }

        internal static void ItemSpliter(string keyValue, out string key, out string value)
        {
            key = string.Empty;
            value = string.Empty;
            for (var i = 1; i < keyValue.Length; i++)
            {
                if (keyValue[i] == '\"' && keyValue[i - 1] != '\\')
                {
                    key = keyValue.Substring(0, i + 1);
                    for (; i < keyValue.Length; i++)
                    {
                        if (keyValue[i] == ':')
                        {
                            value = keyValue.Substring(i + 1);
                            break;
                        }
                    }
                    break;
                }
            }
            key = key.Trim();
            value = value.Trim();
        }
  
        /// <summary>
        /// 为当前字符串创建缩进。
        /// </summary>
        /// <param name="sb">字符串。</param>
        /// <param name="level">缩进等级。</param>
        private static void BuildIndentation(StringBuilder sb, int level)
        {
            // 操作每一级。
            for (var i = 0; i < level; i++)
            {
                // 添加每一级的空格。
                for (var j = 0; j < SerializeIndentationWhiteSpaceCount; j++)
                {
                    sb.Append(' ');
                }
            }
        }
    }
}