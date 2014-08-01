//using Common.Serialization.Json;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Diagnostics.CodeAnalysis;
//using System.Globalization;
//using System.Linq;
//using System.Numerics;
//using System.Reflection;
//using System.Text;
//using System.Text.RegularExpressions;

//namespace Common.Serialization.Json
//{
//    internal class JsonSerializer
//    {
//        private StringBuilder _buffer = new StringBuilder();

//        private int _currentStackLevel;

//        internal StringBuilder Buffer
//        {
//            get
//            {
//                // TODO build the next version by StringBuilder.
//                return _buffer;
//            }
//            set
//            {
//                _buffer = value;
//            }
//        }

//        internal int CurrentStackLevel
//        {
//            get
//            {
//                return _currentStackLevel;
//            }
//            set
//            {
//                _currentStackLevel = value;
//                if (_currentStackLevel > MaxStackLevel)
//                {
//                    throw new JsonStackOverFlowException(MaxStackLevel);
//                }
//            }
//        }

//        internal DateTimeFormat DateTimeFormat
//        {
//            get;
//            set;
//        }

//        internal EnumFormat EnumFormat
//        {
//            get;
//            set;
//        }

//        internal int MaxStackLevel
//        {
//            get;
//            set;
//        }

//        internal RegexFormat RegexFormat
//        {
//            get;
//            set;
//        }

//        [SuppressMessage("Microsoft.Maintainability", "CA1502")]
//        internal string SerializeObject(object obj)
//        {
//            CurrentStackLevel++;
//            string json;

//            for (; ; )
//            {
//                #region null

//                if (obj == null)
//                {
//                    json = "null";
//                    break;
//                }

//                #endregion null

//                #region Boolean

//                if (obj is bool)
//                {
//                    json = SerializeBoolean((bool)obj);
//                    break;
//                }

//                #endregion Boolean

//                #region Byte

//                if (obj is byte)
//                {
//                    json = SerializeByte((byte)obj);
//                    break;
//                }

//                #endregion Byte

//                #region Char

//                if (obj is char)
//                {
//                    json = SerializeChar((char)obj);
//                    break;
//                }

//                #endregion Char

//                #region Decimal

//                if (obj is decimal)
//                {
//                    json = SerializeDecimal((decimal)obj);
//                    break;
//                }

//                #endregion Decimal

//                #region Double

//                if (obj is double)
//                {
//                    json = SerializeDouble((double)obj);
//                    break;
//                }

//                #endregion Double

//                #region Int16

//                if (obj is short)
//                {
//                    json = SerializeInt16((short)obj);
//                    break;
//                }

//                #endregion Int16

//                #region Int32

//                if (obj is int)
//                {
//                    json = SerializeInt32((int)obj);
//                    break;
//                }

//                #endregion Int32

//                #region Int64

//                if (obj is long)
//                {
//                    json = SerializeInt64((long)obj);
//                    break;
//                }

//                #endregion Int64

//                #region SByte

//                if (obj is sbyte)
//                {
//                    json = SerializeSByte((sbyte)obj);
//                    break;
//                }

//                #endregion SByte

//                #region Single

//                if (obj is float)
//                {
//                    json = SerializeSingle((float)obj);
//                    break;
//                }

//                #endregion Single

//                #region String

//                var s = obj as string;
//                if (s != null)
//                {
//                    json = SerializeString(s);
//                    break;
//                }

//                #endregion String

//                #region UInt16

//                if (obj is ushort)
//                {
//                    json = SerializeUInt16((ushort)obj);
//                    break;
//                }

//                #endregion UInt16

//                #region UInt32

//                if (obj is uint)
//                {
//                    json = SerializeUInt32((uint)obj);
//                    break;
//                }

//                #endregion UInt32

//                #region UInt64

//                if (obj is ulong)
//                {
//                    json = SerializeUInt64((ulong)obj);
//                    break;
//                }

//                #endregion UInt64

//                #region BigInteger

//                if (obj is BigInteger)
//                {
//                    json = SerializeBigInteger((BigInteger)obj);
//                    break;
//                }

//                #endregion BigInteger

//                #region DataTable

//                var dataTable = obj as DataTable;
//                if (dataTable != null)
//                {
//                    json = SerializeDataTable(dataTable);
//                    break;
//                }

//                #endregion DataTable

//                #region DateTime

//                if (obj is DateTime)
//                {
//                    json = SerializeDateTime((DateTime)obj);
//                    break;
//                }

//                #endregion DateTime

//                #region DBNull

//                if (obj is DBNull)
//                {
//                    json = SerializeDBNull(obj);
//                    break;
//                }

//                #endregion DBNull

//                #region Dictionary

//                var dict = obj as IDictionary;
//                if (dict != null)
//                {
//                    json = SerializeDictionary(dict);
//                    break;
//                }

//                #endregion Dictionary

//                #region Enum

//                var e = obj as Enum;
//                if (e != null)
//                {
//                    json = SerializeEnum(e);
//                    break;
//                }

//                #endregion Enum

//                #region Guid

//                if (obj is Guid)
//                {
//                    json = SerializeGuid((Guid)obj);
//                    break;
//                }

//                #endregion Guid

//                #region IEnumerable

//                var enumerable = obj as IEnumerable;
//                if (enumerable != null)
//                {
//                    json = SerializeIEnumerable(enumerable);
//                    break;
//                }

//                #endregion IEnumerable

//                #region Lazy

//                if (obj.GetType().IsGenericType && obj.GetType().GetGenericTypeDefinition() == typeof(Lazy<>))
//                {
//                    json = SerializeLazy((dynamic)obj);
//                    break;
//                }

//                #endregion Lazy

//                #region Nullable

//                if (obj.GetType().IsGenericType && obj.GetType().GetGenericTypeDefinition() == typeof(Nullable<>) && obj.GetType().GetElementType().IsValueType)
//                {
//                    json = SerializeNullable(obj);
//                    break;
//                }

//                #endregion Nullable

//                #region Regex

//                var regex = obj as Regex;
//                if (regex != null)
//                {
//                    json = SerializeRegex(regex);
//                    break;
//                }

//                #endregion Regex

//                #region Uri

//                var uri = obj as Uri;
//                if (uri != null)
//                {
//                    json = SerializeUri(uri);
//                    break;
//                }

//                #endregion Uri

//                #region Class

//                json = SerializeClass(obj);
//                break;

//                #endregion Class
//            }

//            CurrentStackLevel--;
//            return json;
//        }

//        [SuppressMessage("Microsoft.Performance", "CA1822")]
//        private string SerializeBigInteger(BigInteger bigInteger)
//        {
//            return bigInteger.ToString();
//        }

//        [SuppressMessage("Microsoft.Performance", "CA1822")]
//        private string SerializeBoolean(bool b)
//        {
//            return b ? "true" : "false";
//        }

//        [SuppressMessage("Microsoft.Performance", "CA1822")]
//        private string SerializeByte(byte b)
//        {
//            return b.ToString(CultureInfo.InvariantCulture);
//        }

//        [SuppressMessage("Microsoft.Performance", "CA1822")]
//        private string SerializeChar(char c)
//        {
//            switch (c)
//            {
//                case '\"':
//                    {
//                        return "\"\\\"\"";
//                    }
//                case '\\':
//                    {
//                        return "\"\\\\\"";
//                    }
//                case '\b':
//                    {
//                        return "\"\\b\"";
//                    }
//                case '\f':
//                    {
//                        return "\"\\f\"";
//                    }
//                case '\n':
//                    {
//                        return "\"\\n\"";
//                    }
//                case '\r':
//                    {
//                        return "\"\\r\"";
//                    }
//                case '\t':
//                    {
//                        return "\"\\t\"";
//                    }
//                default:
//                    {
//                        return "\"" + c + "\"";
//                    }
//            }
//        }

//        [SuppressMessage("Microsoft.Maintainability", "CA1502")]
//        private string SerializeClass(object obj)
//        {
//            var type = obj.GetType();
//            var values = new List<string>();

//            #region 字段

//            FieldInfo[] fields;
//            if (JsonCache.TypeFields.TryGetValue(type, out fields) == false)
//            {
//                fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
//                if (JsonCache.TypeFields.ContainsKey(type) == false)
//                {
//                    lock (JsonCache.TypeFields)
//                    {
//                        if (JsonCache.TypeFields.ContainsKey(type) == false)
//                        {
//                            JsonCache.TypeFields.Add(type, fields);
//                        }
//                    }
//                }
//            }
//            foreach (var field in fields)
//            {
//                var attribute = field.GetCustomAttributes(typeof(JsonAttribute), false).FirstOrDefault() as JsonAttribute;
//                string name;
//                object value;
//                string valueString;
//                if (attribute != null)
//                {
//                    // 不序列化此字段。
//                    if (attribute.Ignore)
//                    {
//                        continue;
//                    }
//                    // 非公有字段且不序列化。
//                    if (field.IsPublic == false && attribute.ProcessNonPublic == false)
//                    {
//                        continue;
//                    }
//                    value = field.GetValue(obj);
//                    // 不序列化 null 字段。
//                    if (attribute.IgnoreNull && value == null)
//                    {
//                        continue;
//                    }
//                    // 字段是否必须。
//                    if (attribute.Required && value == null)
//                    {
//                        throw new ArgumentNullException(field.Name, "该字段不能为 null。");
//                    }
//                    // 检查数量约束。
//                    var enumerable = value as IEnumerable<object>;
//                    var list = enumerable == null ? null : enumerable.ToList();
//                    if (enumerable != null)
//                    {
//                        var count = list.Count();
//                        if (attribute.CountMustLessThan > -1 && count >= attribute.CountMustLessThan)
//                        {
//                            throw JsonCountException.CreateCountMustLessThanException(list, attribute.CountMustLessThan);
//                        }
//                        if (attribute.CountMustGreaterThan > -1 && count <= attribute.CountMustGreaterThan)
//                        {
//                            throw JsonCountException.CreateCountMustGreaterThanException(list, attribute.CountMustGreaterThan);
//                        }
//                    }
//                    // 使用自定义序列化。
//                    if (attribute.Converter != null)
//                    {
//                        var converter = (JsonConverter)Activator.CreateInstance(attribute.Converter);
//                        var skip = false;
//                        valueString = converter.Serialize(value, field.FieldType, ref skip);
//                        if (skip)
//                        {
//                            continue;
//                        }
//                    }
//                    else
//                    {
//                        valueString = SerializeObject(value);
//                    }
//                    // 使用自定义映射名字。
//                    if (string.IsNullOrEmpty(attribute.Name) == false)
//                    {
//                        name = "\"" + attribute.Name + "\"";
//                    }
//                    else
//                    {
//                        name = "\"" + field.Name + "\"";
//                    }
//                }
//                else
//                {
//                    if (field.IsPublic == false)
//                    {
//                        continue;
//                    }
//                    name = "\"" + field.Name + "\"";
//                    value = field.GetValue(obj);
//                    valueString = SerializeObject(value);
//                }
//                values.Add(name + ":" + valueString);
//            }

//            #endregion 字段

//            #region 属性

//            PropertyInfo[] properties;
//            if (JsonCache.TypeProperties.TryGetValue(type, out properties) == false)
//            {
//                properties = type.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
//                if (JsonCache.TypeProperties.ContainsKey(type) == false)
//                {
//                    lock (JsonCache.TypeProperties)
//                    {
//                        if (JsonCache.TypeProperties.ContainsKey(type) == false)
//                        {
//                            JsonCache.TypeProperties.Add(type, properties);
//                        }
//                    }
//                }
//            }
//            foreach (var property in properties)
//            {
//                if (property.GetIndexParameters().Length == 0)
//                {
//                    var attribute = property.GetCustomAttributes(typeof(JsonAttribute), false).FirstOrDefault() as JsonAttribute;
//                    string name;
//                    object value;
//                    string valueString;
//                    if (attribute != null)
//                    {
//                        // 不序列化此属性。
//                        if (attribute.Ignore)
//                        {
//                            continue;
//                        }
//                        // 非公有属性且不序列化。
//                        if (property.CanRead == false && attribute.ProcessNonPublic == false)
//                        {
//                            continue;
//                        }
//                        value = property.GetGetMethod(true).Invoke(obj, null);
//                        // 不序列化 null 属性。
//                        if (attribute.IgnoreNull && value == null)
//                        {
//                            continue;
//                        }
//                        // 属性是否必须。
//                        if (attribute.Required && value == null)
//                        {
//                            throw new ArgumentNullException(property.Name, "该属性不能为 null。");
//                        }
//                        // 检查数量约束。
//                        var enumerable = value as IEnumerable<object>;
//                        var list = enumerable == null ? null : enumerable.ToList();
//                        if (enumerable != null)
//                        {
//                            var count = list.Count();
//                            if (attribute.CountMustLessThan > -1 && count >= attribute.CountMustLessThan)
//                            {
//                                throw JsonCountException.CreateCountMustLessThanException(list, attribute.CountMustLessThan);
//                            }
//                            if (attribute.CountMustGreaterThan > -1 && count <= attribute.CountMustGreaterThan)
//                            {
//                                throw JsonCountException.CreateCountMustGreaterThanException(list, attribute.CountMustGreaterThan);
//                            }
//                        }
//                        // 使用自定义序列化。
//                        if (attribute.Converter != null)
//                        {
//                            var converter = (JsonConverter)Activator.CreateInstance(attribute.Converter);
//                            var skip = false;
//                            valueString = converter.Serialize(value, property.PropertyType, ref skip);
//                            if (skip)
//                            {
//                                continue;
//                            }
//                        }
//                        else
//                        {
//                            valueString = SerializeObject(value);
//                        }
//                        // 使用自定义映射名字。
//                        if (string.IsNullOrEmpty(attribute.Name) == false)
//                        {
//                            name = "\"" + attribute.Name + "\"";
//                        }
//                        else
//                        {
//                            name = "\"" + property.Name + "\"";
//                        }
//                    }
//                    else
//                    {
//                        if (property.CanRead == false)
//                        {
//                            continue;
//                        }
//                        name = "\"" + property.Name + "\"";
//                        value = property.GetValue(obj, null);
//                        valueString = SerializeObject(value);
//                    }
//                    values.Add(name + ":" + valueString);
//                }
//            }

//            #endregion 属性

//            return "{" + string.Join(",", values) + "}";
//        }

//        private string SerializeDataTable(DataTable table)
//        {
//            var rowsJson = new List<string>();
//            foreach (DataRow row in table.Rows)
//            {
//                var keyValues = new List<string>();
//                for (var i = 0; i < table.Columns.Count; i++)
//                {
//                    var column = table.Columns[i];
//                    var keyString = "\"" + column.ColumnName + "\"";
//                    var valueString = SerializeObject(row[column]);
//                    keyValues.Add(keyString + ":" + valueString);
//                }
//                rowsJson.Add("{" + string.Join(",", keyValues) + "}");
//            }
//            return "[" + string.Join(",", rowsJson) + "]";
//        }

//        private string SerializeDateTime(DateTime dateTime)
//        {
//            switch (DateTimeFormat)
//            {
//                case DateTimeFormat.Create:
//                    {
//                        return "new Date(" + (dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0)).Ticks / 0x2710 + ")";
//                    }
//                case DateTimeFormat.Default:
//                    {
//                        return "\"" + dateTime.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFFK", CultureInfo.InvariantCulture) + "\"";
//                    }
//                case DateTimeFormat.Function:
//                    {
//                        return "\"\\/Date(" + (dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0)).Ticks / 0x2710 + ")\\/\"";
//                    }
//                default:
//                    {
//                        throw new InvalidEnumArgumentException("DateTimeFormat 错误。");
//                    }
//            }
//        }

//        // ReSharper disable UnusedParameter.Local
//        [SuppressMessage("Microsoft.Usage", "CA1801")]
//        [SuppressMessage("Microsoft.Performance", "CA1822")]
//        private string SerializeDBNull(object value)
//        // ReSharper restore UnusedParameter.Local
//        {
//            return "null";
//        }

//        [SuppressMessage("Microsoft.Performance", "CA1822")]
//        private string SerializeDecimal(decimal d)
//        {
//            return d.ToString(CultureInfo.InvariantCulture);
//        }

//        private string SerializeDictionary(IDictionary dictionary)
//        {
//            var enumerator = dictionary.GetEnumerator();
//            var sb = new StringBuilder("{");
//            if (enumerator.MoveNext())
//            {
//                sb.Append(SerializeObject(enumerator.Key));
//                sb.Append(':');
//                sb.Append(SerializeObject(enumerator.Value));
//                while (enumerator.MoveNext())
//                {
//                    sb.Append(',');
//                    sb.Append(SerializeObject(enumerator.Key));
//                    sb.Append(':');
//                    sb.Append(SerializeObject(enumerator.Value));
//                }
//            }
//            sb.Append('}');
//            return sb.ToString();
//        }

//        [SuppressMessage("Microsoft.Performance", "CA1822")]
//        private string SerializeDouble(double d)
//        {
//            return d.ToString(CultureInfo.InvariantCulture);
//        }

//        private string SerializeEnum(Enum e)
//        {
//            switch (EnumFormat)
//            {
//                case EnumFormat.Default:
//                    {
//                        return Convert.ToInt32(e, CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
//                    }
//                case EnumFormat.Name:
//                    {
//                        return "\"" + e + "\"";
//                    }
//                default:
//                    {
//                        throw new InvalidEnumArgumentException("EnumFormat 错误。");
//                    }
//            }
//        }

//        [SuppressMessage("Microsoft.Performance", "CA1822")]
//        private string SerializeGuid(Guid guid)
//        {
//            return "\"" + guid + "\"";
//        }

//        private string SerializeIEnumerable(IEnumerable enumerable)
//        {
//            var enumerator = enumerable.GetEnumerator();
//            var sb = new StringBuilder("[");
//            if (enumerator.MoveNext())
//            {
//                sb.Append(SerializeObject(enumerator.Current));
//                while (enumerator.MoveNext())
//                {
//                    sb.Append(',');
//                    sb.Append(SerializeObject(enumerator.Current));
//                }
//            }
//            sb.Append(']');
//            return sb.ToString();
//        }

//        [SuppressMessage("Microsoft.Performance", "CA1822")]
//        private string SerializeInt16(short s)
//        {
//            return s.ToString(CultureInfo.InvariantCulture);
//        }

//        [SuppressMessage("Microsoft.Performance", "CA1822")]
//        private string SerializeInt32(int i)
//        {
//            return i.ToString(CultureInfo.InvariantCulture);
//        }

//        [SuppressMessage("Microsoft.Performance", "CA1822")]
//        private string SerializeInt64(long l)
//        {
//            return l.ToString(CultureInfo.InvariantCulture);
//        }

//        private string SerializeLazy<T>(Lazy<T> lazy)
//        {
//            return lazy.IsValueCreated ? "{\"IsValueCreated\":true,\"Value\":" + SerializeObject(lazy.Value) + "}" : "{\"IsValueCreated\":false,\"Value\":" + SerializeObject(default(T)) + "}";
//        }

//        private string SerializeNullable(object nullable)
//        {
//            return SerializeObject(nullable);
//        }

//        private string SerializeRegex(Regex regex)
//        {
//            switch (RegexFormat)
//            {
//                case RegexFormat.Create:
//                    {
//                        var flags = new StringBuilder(2);
//                        if (regex.Options.HasFlag(RegexOptions.IgnoreCase))
//                        {
//                            flags.Append("i");
//                        }
//                        if (regex.Options.HasFlag(RegexOptions.Multiline))
//                        {
//                            flags.Append("m");
//                        }
//                        return flags.Length > 0 ? "new RegExp(\"" + regex + "\",\"" + flags + "\")" : "new RegExp(\"" + regex + "\")";
//                    }
//                case RegexFormat.Default:
//                    {
//                        var sb = new StringBuilder("/");
//                        sb.Append(regex);
//                        sb.Append("/");
//                        if (regex.Options.HasFlag(RegexOptions.IgnoreCase))
//                        {
//                            sb.Append("i");
//                        }
//                        if (regex.Options.HasFlag(RegexOptions.Multiline))
//                        {
//                            sb.Append("m");
//                        }
//                        return sb.ToString();
//                    }
//                default:
//                    {
//                        throw new InvalidEnumArgumentException("RegexFormat 错误。");
//                    }
//            }
//        }

//        [SuppressMessage("Microsoft.Performance", "CA1822")]
//        private string SerializeSByte(sbyte sb)
//        {
//            return sb.ToString(CultureInfo.InvariantCulture);
//        }

//        [SuppressMessage("Microsoft.Performance", "CA1822")]
//        private string SerializeSingle(float f)
//        {
//            return f.ToString(CultureInfo.InvariantCulture);
//        }

//        [SuppressMessage("Microsoft.Performance", "CA1822")]
//        private string SerializeString(string s)
//        {
//            var sb = new StringBuilder("\"");
//            foreach (var c in s)
//            {
//                switch (c)
//                {
//                    case '\"':
//                        {
//                            sb.Append('\\');
//                            sb.Append('\"');
//                            break;
//                        }
//                    case '\\':
//                        {
//                            sb.Append('\\');
//                            sb.Append('\\');
//                            break;
//                        }
//                    case '\b':
//                        {
//                            sb.Append('\\');
//                            sb.Append('b');
//                            break;
//                        }
//                    case '\f':
//                        {
//                            sb.Append('\\');
//                            sb.Append('f');
//                            break;
//                        }
//                    case '\n':
//                        {
//                            sb.Append('\\');
//                            sb.Append('n');
//                            break;
//                        }
//                    case '\r':
//                        {
//                            sb.Append('\\');
//                            sb.Append('r');
//                            break;
//                        }
//                    case '\t':
//                        {
//                            sb.Append('\\');
//                            sb.Append('t');
//                            break;
//                        }
//                    default:
//                        {
//                            sb.Append(c);
//                            break;
//                        }
//                }
//            }
//            sb.Append('\"');
//            return sb.ToString();
//        }

//        [SuppressMessage("Microsoft.Performance", "CA1822")]
//        private string SerializeUInt16(ushort us)
//        {
//            return us.ToString(CultureInfo.InvariantCulture);
//        }

//        [SuppressMessage("Microsoft.Performance", "CA1822")]
//        private string SerializeUInt32(uint ui)
//        {
//            return ui.ToString(CultureInfo.InvariantCulture);
//        }

//        [SuppressMessage("Microsoft.Performance", "CA1822")]
//        private string SerializeUInt64(ulong ul)
//        {
//            return ul.ToString(CultureInfo.InvariantCulture);
//        }

//        [SuppressMessage("Microsoft.Performance", "CA1822")]
//        private string SerializeUri(Uri uri)
//        {
//            return "\"" + uri.GetComponents(UriComponents.SerializationInfoString, UriFormat.UriEscaped) + "\"";
//        }
//    }
//}