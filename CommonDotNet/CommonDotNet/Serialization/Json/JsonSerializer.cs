using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Serialization.Json
{
    internal class JsonSerializer
    {
        private static readonly DateTime Date1970 = new DateTime(1970, 1, 1, 0, 0, 0);

        private StringBuilder _buffer;

        private int _currentStackLevel;

        internal int CurrentStackLevel
        {
            get
            {
                return _currentStackLevel;
            }
            set
            {
                _currentStackLevel = value;
                if (_currentStackLevel > MaxStackLevel)
                {
                    throw new JsonStackOverFlowException(MaxStackLevel);
                }
            }
        }

        internal DateTimeFormat DateTimeFormat
        {
            get;
            set;
        }

        internal EnumFormat EnumFormat
        {
            get;
            set;
        }

        internal int MaxStackLevel
        {
            get;
            set;
        }

        internal RegexFormat RegexFormat
        {
            get;
            set;
        }

        internal string SerializeToJson(object obj)
        {
            // 理论上 128 容量为最佳。
            _buffer = new StringBuilder(128);
            SerializeObject(obj);
            return _buffer.ToString();
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502")]
        private void SerializeObject(object obj)
        {
            CurrentStackLevel++;
            if (obj == null)
            {
                #region null

                SerializeNull();

                #endregion null

                CurrentStackLevel--;
                return;
            }
            if (obj is ValueType)
            {
                var @enum = obj as Enum;
                if (@enum != null)
                {
                    #region Enum

                    SerializeEnum(@enum);

                    #endregion Enum
                }
                else if (obj is bool)
                {
                    #region Boolean

                    SerializeBoolean((bool)obj);

                    #endregion Boolean
                }
                else if (obj is byte)
                {
                    #region Byte

                    SerializeByte((byte)obj);

                    #endregion Byte
                }
                else if (obj is char)
                {
                    #region Char

                    SerializeChar((char)obj);

                    #endregion Char
                }
                else if (obj is decimal)
                {
                    #region Decimal

                    SerializeDecimal((decimal)obj);

                    #endregion Decimal
                }
                else if (obj is double)
                {
                    #region Double

                    SerializeDouble((double)obj);

                    #endregion Double
                }
                else if (obj is short)
                {
                    #region Int16

                    SerializeInt16((short)obj);

                    #endregion Int16
                }
                else if (obj is int)
                {
                    #region Int32

                    SerializeInt32((int)obj);

                    #endregion Int32
                }
                else if (obj is long)
                {
                    #region Int64

                    SerializeInt64((long)obj);

                    #endregion Int64
                }
                else if (obj is sbyte)
                {
                    #region SByte

                    SerializeSByte((sbyte)obj);

                    #endregion SByte
                }
                else if (obj is float)
                {
                    #region Single

                    SerializeSingle((float)obj);

                    #endregion Single
                }
                else if (obj is ushort)
                {
                    #region UInt16

                    SerializeUInt16((ushort)obj);

                    #endregion UInt16
                }
                else if (obj is uint)
                {
                    #region UInt32

                    SerializeUInt32((uint)obj);

                    #endregion UInt32
                }
                else if (obj is ulong)
                {
                    #region UInt64

                    SerializeUInt64((ulong)obj);

                    #endregion UInt64
                }
                else if (obj is BigInteger)
                {
                    #region BigInteger

                    SerializeBigInteger((BigInteger)obj);

                    #endregion BigInteger
                }
                else if (obj is DateTime)
                {
                    #region DateTime

                    SerializeDateTime((DateTime)obj);

                    #endregion DateTime
                }
                else if (obj is Guid)
                {
                    #region Guid

                    SerializeGuid((Guid)obj);

                    #endregion Guid
                }
                else if (obj is TimeSpan)
                {
                    #region TimeSpan

                    SerializeTimeSpan((TimeSpan)obj);

                    #endregion TimeSpan
                }

                CurrentStackLevel--;
                return;
            }
            {
                var s = obj as string;
                if (s != null)
                {
                    #region String

                    SerializeString(s);

                    #endregion String

                    CurrentStackLevel--;
                    return;
                }
                var dataTable = obj as DataTable;
                if (dataTable != null)
                {
                    #region DataTable

                    SerializeDataTable(dataTable);

                    #endregion DataTable

                    CurrentStackLevel--;
                    return;
                }
                if (obj is DBNull)
                {
                    #region DBNull

                    SerializeDBNull();

                    #endregion DBNull

                    CurrentStackLevel--;
                    return;
                }
                var dict = obj as IDictionary;
                if (dict != null)
                {
                    #region Dictionary

                    SerializeDictionary(dict);

                    #endregion Dictionary

                    CurrentStackLevel--;
                    return;
                }
                var enumerable = obj as IEnumerable;
                if (enumerable != null)
                {
                    #region IEnumerable

                    SerializeIEnumerable(enumerable);

                    #endregion IEnumerable

                    CurrentStackLevel--;
                    return;
                }
                var regex = obj as Regex;
                if (regex != null)
                {
                    #region Regex

                    SerializeRegex(regex);

                    #endregion Regex

                    CurrentStackLevel--;
                    return;
                }
                var uri = obj as Uri;
                if (uri != null)
                {
                    #region Uri

                    SerializeUri(uri);

                    #endregion Uri

                    CurrentStackLevel--;
                    return;
                }
                var type = obj as Type;
                if (type != null)
                {
                    #region Type

                    SerializeType(type);

                    #endregion Type

                    CurrentStackLevel--;
                    return;
                }

                type = obj.GetType();
                if (type.IsGenericType)
                {
                    var genericTypeDefinition = type.GetGenericTypeDefinition();
                    if (genericTypeDefinition == typeof(Lazy<>))
                    {
                        #region Lazy

                        SerializeLazy(obj, type);

                        #endregion Lazy

                        CurrentStackLevel--;
                        return;
                    }
                    if (genericTypeDefinition == typeof(Nullable<>) && type.GetElementType().IsValueType)
                    {
                        #region Nullable

                        SerializeNullable(obj);

                        #endregion Nullable

                        CurrentStackLevel--;
                        return;
                    }
                }

                #region Class

                SerializeClass(obj, type);

                #endregion Class

                CurrentStackLevel--;
            }
        }

        private void AddOutputKey(ISet<string> outputKeys, string key)
        {
            if (outputKeys.Contains(key))
            {
                throw new JsonKeyRepeatException
                {
                    ProcessedJson = _buffer.ToString(),
                    Key = key
                };
            }
            if (outputKeys.Count > 0)
            {
                _buffer.Append(',');
            }
            outputKeys.Add(key);
        }

        private void SerializeBigInteger(BigInteger bigInteger)
        {
            _buffer.Append(bigInteger);
        }

        private void SerializeBoolean(bool b)
        {
            _buffer.Append(b ? "true" : "false");
        }

        private void SerializeByte(byte b)
        {
            _buffer.Append(b);
        }

        private void SerializeChar(char c)
        {
            switch (c)
            {
                case '\"':
                    {
                        _buffer.Append("\"\\\"\"");
                        break;
                    }
                case '\\':
                    {
                        _buffer.Append("\"\\\\\"");
                        break;
                    }
                case '\b':
                    {
                        _buffer.Append("\"\\b\"");
                        break;
                    }
                case '\f':
                    {
                        _buffer.Append("\"\\f\"");
                        break;
                    }
                case '\n':
                    {
                        _buffer.Append("\"\\n\"");
                        break;
                    }
                case '\r':
                    {
                        _buffer.Append("\"\\r\"");
                        break;
                    }
                case '\t':
                    {
                        _buffer.Append("\"\\t\"");
                        break;
                    }
                default:
                    {
                        _buffer.Append('\"');
                        _buffer.Append(c);
                        _buffer.Append('\"');
                        break;
                    }
            }
        }

        private void SerializeClass(object obj, Type type)
        {
            _buffer.Append('{');

            // 存储已经处理的 JSON 键。
            var outputKeys = new HashSet<string>();

            // 序列化字段。
            SerializeClassFields(obj, type, outputKeys);

            // 序列化属性。
            SerializeClassProperties(obj, type, outputKeys);

            _buffer.Append('}');
        }

        private void SerializeClassField(object obj, FieldInfo field, HashSet<string> outputKeys)
        {
            var attribute = Attribute.GetCustomAttribute(field, typeof (JsonAttribute)) as JsonAttribute;
            string key;
            object value;
            if (attribute != null)
            {
                // 不序列化此字段。
                if (attribute.Ignore)
                {
                    return;
                }
                // 非公有字段且不序列化。
                if (field.IsPublic == false && attribute.ProcessNonPublic == false)
                {
                    return;
                }
                value = field.GetValue(obj);
                // 不序列化 null 字段。
                if (attribute.IgnoreNull && value == null)
                {
                    return;
                }
                // 字段必须。
                if (attribute.Required && value == null)
                {
                    throw new JsonValueRequiredException("字段的值必须。", field.Name)
                    {
                        ProcessedJson = _buffer.ToString()
                    };
                }
                // 检查数量约束。
                var countLessThan = attribute.CountMustLessThan;
                var countGreaterThan = attribute.CountMustGreaterThan;
                if ((countLessThan > -1 || countGreaterThan > -1) && value != null && typeof(IEnumerable).IsAssignableFrom(field.FieldType))
                {
                    var enumerator = ((IEnumerable)value).GetEnumerator();
                    var list = new List<object>();
                    while (enumerator.MoveNext())
                    {
                        list.Add(enumerator.Current);
                    }
                    var count = list.Count;
                    if (count >= countLessThan)
                    {
                        var exception = JsonCountException.CreateCountMustLessThanException(list, countLessThan);
                        exception.ProcessedJson = _buffer.ToString();
                        throw exception;
                    }
                    if (count <= countGreaterThan)
                    {
                        var exception = JsonCountException.CreateCountMustGreaterThanException(list, countLessThan);
                        exception.ProcessedJson = _buffer.ToString();
                        throw exception;
                    }
                }
                // 使用自定义映射名字。
                key = string.IsNullOrEmpty(attribute.Name) ? field.Name : attribute.Name;
                // 使用自定义序列化。
                if (attribute.Converter != null)
                {
                    var converter = (JsonConverter)Activator.CreateInstance(attribute.Converter);
                    var isSkip = false;
                    var valueString = converter.Serialize(value, field.FieldType, ref isSkip);
                    if (isSkip)
                    {
                        return;
                    }
                    AddOutputKey(outputKeys, key);
                    SerializeObject(key);
                    _buffer.Append(':');
                    _buffer.Append(valueString);
                    return;
                }
            }
            else
            {
                if (field.IsPublic == false)
                {
                    return;
                }
                key = field.Name;
                value = field.GetValue(obj);
            }
            AddOutputKey(outputKeys, key);
            SerializeObject(key);
            _buffer.Append(':');
            SerializeObject(value);
        }

        private void SerializeClassFields(object obj, Type type, HashSet<string> outputKeys)
        {
            var fields = JsonCache.GetTypeFieldInfos(type);
            foreach (var field in fields)
            {
                SerializeClassField(obj, field, outputKeys);
            }
        }

        private void SerializeClassProperties(object obj, Type type, HashSet<string> outputKeys)
        {
            var properties = JsonCache.GetTypePropertyInfos(type);
            foreach (var property in properties)
            {
                SerializeClassProperty(obj, property, outputKeys);
            }
        }

        private void SerializeClassProperty(object obj, PropertyInfo property, HashSet<string> outputKeys)
        {
            // 不序列化索引器。
            if (property.GetIndexParameters().Length != 0)
            {
                return;
            }
            var attribute = Attribute.GetCustomAttribute(property, typeof (JsonAttribute)) as JsonAttribute;
            string key;
            object value;
            if (attribute != null)
            {
                // 不序列化此属性。
                if (attribute.Ignore)
                {
                    return;
                }
                // 非公有属性且不序列化。
                if (property.CanRead == false && attribute.ProcessNonPublic == false)
                {
                    return;
                }
                value = property.GetValue(obj, null);
                // 不序列化 null 属性。
                if (attribute.IgnoreNull && value == null)
                {
                    return;
                }
                // 属性必须。
                if (attribute.Required && value == null)
                {
                    throw new JsonValueRequiredException("属性的值缺少。", property.Name)
                    {
                        ProcessedJson = _buffer.ToString()
                    };
                }
                // 检查数量约束。
                var countLessThan = attribute.CountMustLessThan;
                var countGreaterThan = attribute.CountMustGreaterThan;
                if ((countLessThan > -1 || countGreaterThan > -1) && value != null && typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                {
                    var enumerator = ((IEnumerable)value).GetEnumerator();
                    var list = new List<object>();
                    while (enumerator.MoveNext())
                    {
                        list.Add(enumerator.Current);
                    }
                    var count = list.Count;
                    if (count >= countLessThan)
                    {
                        var exception = JsonCountException.CreateCountMustLessThanException(list, countLessThan);
                        exception.ProcessedJson = _buffer.ToString();
                        throw exception;
                    }
                    if (count <= countGreaterThan)
                    {
                        var exception = JsonCountException.CreateCountMustGreaterThanException(list, countLessThan);
                        exception.ProcessedJson = _buffer.ToString();
                        throw exception;
                    }
                }
                // 使用自定义映射名字。
                key = string.IsNullOrEmpty(attribute.Name) ? property.Name : attribute.Name;
                // 使用自定义序列化。
                if (attribute.Converter != null)
                {
                    var converter = (JsonConverter)Activator.CreateInstance(attribute.Converter);
                    var isSkip = false;
                    var valueString = converter.Serialize(value, property.PropertyType, ref isSkip);
                    if (isSkip)
                    {
                        return;
                    }
                    AddOutputKey(outputKeys, key);
                    SerializeObject(key);
                    _buffer.Append(':');
                    _buffer.Append(valueString);
                    return;
                }
            }
            else
            {
                if (property.CanRead == false)
                {
                    return;
                }
                key = property.Name;
                value = property.GetValue(obj, null);
            }
            AddOutputKey(outputKeys, key);
            SerializeObject(key);
            _buffer.Append(':');
            SerializeObject(value);
        }

        private void SerializeDataTable(DataTable table)
        {
            _buffer.Append('[');
            var rowEnumerator = table.Rows.GetEnumerator();
            if (rowEnumerator.MoveNext())
            {
                {
                    var row = rowEnumerator.Current as DataRow;
                    if (row != null)
                    {
                        _buffer.Append('{');
                        var columnEnumerator = table.Columns.GetEnumerator();
                        if (columnEnumerator.MoveNext())
                        {
                            {
                                var column = columnEnumerator.Current as DataColumn;
                                if (column != null)
                                {
                                    SerializeObject(column.ColumnName);
                                    _buffer.Append(':');
                                    SerializeObject(row[column]);
                                }
                            }
                            while (columnEnumerator.MoveNext())
                            {
                                _buffer.Append(',');
                                var column = columnEnumerator.Current as DataColumn;
                                if (column == null)
                                {
                                    continue;
                                }
                                SerializeObject(column.ColumnName);
                                _buffer.Append(':');
                                SerializeObject(row[column]);
                            }
                        }
                        _buffer.Append('}');
                    }
                }
                while (rowEnumerator.MoveNext())
                {
                    _buffer.Append(',');
                    var row = rowEnumerator.Current as DataRow;
                    if (row == null)
                    {
                        continue;
                    }
                    _buffer.Append('{');
                    var columnEnumerator = table.Columns.GetEnumerator();
                    if (columnEnumerator.MoveNext())
                    {
                        {
                            var column = columnEnumerator.Current as DataColumn;
                            if (column != null)
                            {
                                SerializeObject(column.ColumnName);
                                _buffer.Append(':');
                                SerializeObject(row[column]);
                            }
                        }
                        while (columnEnumerator.MoveNext())
                        {
                            _buffer.Append(',');
                            var column = columnEnumerator.Current as DataColumn;
                            if (column == null)
                            {
                                continue;
                            }
                            SerializeObject(column.ColumnName);
                            _buffer.Append(':');
                            SerializeObject(row[column]);
                        }
                    }
                    _buffer.Append('}');
                }
            }
            _buffer.Append(']');
        }

        private void SerializeDateTime(DateTime dateTime)
        {
            switch (DateTimeFormat)
            {
                case DateTimeFormat.Create:
                    {
                        _buffer.Append("new Date(");
                        _buffer.Append((dateTime.ToUniversalTime() - Date1970).Ticks / 10000);
                        _buffer.Append(')');
                        break;
                    }
                case DateTimeFormat.Default:
                    {
                        _buffer.Append('\"');
                        _buffer.Append(dateTime.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFFK", CultureInfo.InvariantCulture));
                        _buffer.Append('\"');
                        break;
                    }
                case DateTimeFormat.Function:
                    {
                        _buffer.Append("\"\\/Date(");
                        _buffer.Append((dateTime.ToUniversalTime() - Date1970).Ticks / 10000);
                        _buffer.Append(")\\/\"");
                        break;
                    }
                default:
                    {
                        throw new JsonSerializeException("DateTimeFormat 错误。", new InvalidEnumArgumentException("DateTimeFormat 错误。"));
                    }
            }
        }

        // ReSharper disable InconsistentNaming
        private void SerializeDBNull()
        // ReSharper restore InconsistentNaming
        {
            _buffer.Append("null");
        }

        private void SerializeDecimal(decimal d)
        {
            _buffer.Append(d);
        }

        private void SerializeDictionary(IDictionary dict)
        {
            var enumerator = dict.GetEnumerator();
            _buffer.Append('{');
            if (enumerator.MoveNext())
            {
                SerializeObject(enumerator.Key);
                _buffer.Append(':');
                SerializeObject(enumerator.Value);
                while (enumerator.MoveNext())
                {
                    _buffer.Append(',');
                    SerializeObject(enumerator.Key);
                    _buffer.Append(':');
                    SerializeObject(enumerator.Value);
                }
            }
            _buffer.Append('}');
        }

        private void SerializeDouble(double d)
        {
            _buffer.Append(d);
        }

        private void SerializeEnum(Enum @enum)
        {
            switch (EnumFormat)
            {
                case EnumFormat.Default:
                    {
                        _buffer.Append(Convert.ToInt32(@enum, CultureInfo.InvariantCulture));
                        break;
                    }
                case EnumFormat.Name:
                    {
                        _buffer.Append('\"');
                        _buffer.Append(@enum);
                        _buffer.Append('\"');
                        break;
                    }
                default:
                    {
                        throw new JsonSerializeException("EnumFormat 错误。", new InvalidEnumArgumentException("EnumFormat 错误。"));
                    }
            }
        }

        private void SerializeGuid(Guid guid)
        {
            _buffer.Append('\"');
            _buffer.Append(guid);
            _buffer.Append('\"');
        }

        private void SerializeIEnumerable(IEnumerable enumerable)
        {
            _buffer.Append('[');
            var enumerator = enumerable.GetEnumerator();
            if (enumerator.MoveNext())
            {
                SerializeObject(enumerator.Current);
                while (enumerator.MoveNext())
                {
                    _buffer.Append(',');
                    SerializeObject(enumerator.Current);
                }
            }
            _buffer.Append(']');
        }

        private void SerializeInt16(short s)
        {
            _buffer.Append(s);
        }

        private void SerializeInt32(int i)
        {
            _buffer.Append(i);
        }

        private void SerializeInt64(long l)
        {
            _buffer.Append(l);
        }

        private void SerializeLazy(object lazy, Type lazyType)
        {
            PropertyInfo isValueCreatedProperty;
            if (JsonCache.LazyTypeIsValueCreatedProperties.ContainsKey(lazyType) == false)
            {
                lock (JsonCache.LazyTypeIsValueCreatedProperties)
                {
                    if (JsonCache.LazyTypeIsValueCreatedProperties.ContainsKey(lazyType) == false)
                    {
                        isValueCreatedProperty = lazyType.GetProperty("IsValueCreated");
                        JsonCache.LazyTypeIsValueCreatedProperties.Add(lazyType, isValueCreatedProperty);
                    }
                    else
                    {
                        isValueCreatedProperty = JsonCache.LazyTypeIsValueCreatedProperties[lazyType];
                    }
                }
            }
            else
            {
                isValueCreatedProperty = JsonCache.LazyTypeIsValueCreatedProperties[lazyType];
            }
            PropertyInfo valueProperty;
            if (JsonCache.LazyTypeValueProperties.ContainsKey(lazyType) == false)
            {
                lock (JsonCache.LazyTypeValueProperties)
                {
                    if (JsonCache.LazyTypeValueProperties.ContainsKey(lazyType) == false)
                    {
                        valueProperty = lazyType.GetProperty("Value");
                        JsonCache.LazyTypeValueProperties.Add(lazyType, valueProperty);
                    }
                    else
                    {
                        valueProperty = JsonCache.LazyTypeValueProperties[lazyType];
                    }
                }
            }
            else
            {
                valueProperty = JsonCache.LazyTypeValueProperties[lazyType];
            }
            var value = valueProperty.GetValue(lazy, null);
            var isValueCreated = isValueCreatedProperty.GetValue(lazy, null);
            _buffer.Append("{\"IsValueCreated\":");
            SerializeObject(isValueCreated);
            _buffer.Append(",\"Value\":");
            SerializeObject(value);
            _buffer.Append('}');
        }

        private void SerializeNull()
        {
            _buffer.Append("null");
        }

        private void SerializeNullable(object nullable)
        {
            SerializeObject(nullable);
        }

        private void SerializeRegex(Regex regex)
        {
            switch (RegexFormat)
            {
                case RegexFormat.Create:
                    {
                        _buffer.Append("new RegExp(\"");
                        _buffer.Append(regex);
                        if (regex.Options.HasFlag(RegexOptions.IgnoreCase))
                        {
                            _buffer.Append(regex.Options.HasFlag(RegexOptions.Multiline) ? "\",\"mi\")" : "\",\"i\")");
                        }
                        else if (regex.Options.HasFlag(RegexOptions.Multiline))
                        {
                            _buffer.Append("\",\"m\")");
                        }
                        else
                        {
                            _buffer.Append("\")");
                        }
                        break;
                    }
                case RegexFormat.Default:
                    {
                        _buffer.Append('/');
                        _buffer.Append(regex);
                        if (regex.Options.HasFlag(RegexOptions.IgnoreCase))
                        {
                            _buffer.Append(regex.Options.HasFlag(RegexOptions.Multiline) ? "/im" : "/i");
                        }
                        else if (regex.Options.HasFlag(RegexOptions.Multiline))
                        {
                            _buffer.Append("/m");
                        }
                        else
                        {
                            _buffer.Append('/');
                        }
                        break;
                    }
                default:
                    {
                        throw new JsonSerializeException("RegexFormat 错误。", new InvalidEnumArgumentException("RegexFormat 错误。"));
                    }
            }
        }

        private void SerializeSByte(sbyte sb)
        {
            _buffer.Append(sb);
        }

        private void SerializeSingle(float f)
        {
            _buffer.Append(f);
        }

        private void SerializeString(string s)
        {
            _buffer.Append('\"');
            foreach (var c in s)
            {
                switch (c)
                {
                    case '\"':
                        {
                            _buffer.Append("\\\"");
                            break;
                        }
                    case '\\':
                        {
                            _buffer.Append("\\\\");
                            break;
                        }
                    case '\b':
                        {
                            _buffer.Append("\\b");
                            break;
                        }
                    case '\f':
                        {
                            _buffer.Append("\\f");
                            break;
                        }
                    case '\n':
                        {
                            _buffer.Append("\\n");
                            break;
                        }
                    case '\r':
                        {
                            _buffer.Append("\\f");
                            break;
                        }
                    case '\t':
                        {
                            _buffer.Append("\\t");
                            break;
                        }
                    default:
                        {
                            _buffer.Append(c);
                            break;
                        }
                }
            }
            _buffer.Append('\"');
        }

        private void SerializeTimeSpan(TimeSpan timeSpan)
        {
            _buffer.Append('\"');
            _buffer.Append(timeSpan.ToString("c", CultureInfo.InvariantCulture));
            _buffer.Append('\"');
        }

        private void SerializeType(Type type)
        {
            _buffer.Append('\"');
            _buffer.Append(type.AssemblyQualifiedName);
            _buffer.Append('\"');
        }

        private void SerializeUInt16(ushort us)
        {
            _buffer.Append(us);
        }

        private void SerializeUInt32(uint ui)
        {
            _buffer.Append(ui);
        }

        private void SerializeUInt64(ulong ul)
        {
            _buffer.Append(ul);
        }

        private void SerializeUri(Uri uri)
        {
            _buffer.Append('\"');
            _buffer.Append(uri.GetComponents(UriComponents.SerializationInfoString, UriFormat.UriEscaped));
            _buffer.Append('\"');
        }
    }
}