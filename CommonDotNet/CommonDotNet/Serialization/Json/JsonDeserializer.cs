using Common.Serialization.Json.Exception;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Serialization.Json
{
    internal class JsonDeserializer
    {
        internal static readonly Regex DateTimeCreateRegex = new Regex(@"^new\s+Date\(\s*(\d*)\s*\)$", RegexOptions.Compiled);

        internal static readonly Regex DateTimeDefaultRegex = new Regex(@"^(\d{4})\-(\d{2})\-(\d{2})T(\d{2}):(\d{2}):(\d{2})(\.\d*)?([\+|\-]\d{2}:\d{2})?$", RegexOptions.Compiled);

        internal static readonly Regex DateTimeFunctionRegex = new Regex(@"^\\/Date\((\d+)\)\\/$", RegexOptions.Compiled);

        private static readonly Regex RegexCreateRegex = new Regex("new\\s+RegExp\\(\\s*(\\\"(.*?)\\\"|\\'(.*?)\\')\\s*(,\\s*(\\\"(.*?)\\\"|\\'(.*?)\\')\\s*)?\\)", RegexOptions.Compiled);

        private static readonly Regex RegexDefaultRegex = new Regex(@"^/(.*?)/(g|i|m|gi|gm|ig|im|mg|mi|gim|gmi|igm|img|mgi|mig)?$", RegexOptions.Compiled);

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

        internal int MaxStackLevel
        {
            get;
            set;
        }
        
        [SuppressMessage("Microsoft.Maintainability","CA1502")]
        internal object DeserializeToObject(string input, Type type)
        {
            CurrentStackLevel++;
            object obj;

            input = input.Trim();

            for (; ; )
            {
                #region null

                if (input == "null")
                {
                    obj = null;
                    break;
                }

                #endregion null

                #region Boolean

                if (type == typeof(bool))
                {
                    obj = DeserializeToBoolean(input, type);
                    break;
                }

                #endregion Boolean

                #region Byte

                if (type == typeof(byte))
                {
                    obj = DeserializeToByte(input, type);
                    break;
                }

                #endregion Byte

                #region Char

                if (type == typeof(char))
                {
                    obj = DeserializeToChar(input, type);
                    break;
                }

                #endregion Char

                #region Decimal

                if (type == typeof(decimal))
                {
                    obj = DeserializeToDecimal(input, type);
                    break;
                }

                #endregion Decimal

                #region Double

                if (type == typeof(double))
                {
                    obj = DeserializeToDouble(input, type);
                    break;
                }

                #endregion Double

                #region Int16

                if (type == typeof(short))
                {
                    obj = DeserializeToInt16(input, type);
                    break;
                }

                #endregion Int16

                #region Int32

                if (type == typeof(int))
                {
                    obj = DeserializeToInt32(input, type);
                    break;
                }

                #endregion Int32

                #region Int64

                if (type == typeof(long))
                {
                    obj = DeserializeToInt64(input, type);

                    break;
                }

                #endregion Int64

                #region SByte

                if (type == typeof(sbyte))
                {
                    obj = DeserializeToSByte(input, type);
                    break;
                }

                #endregion SByte

                #region Single

                if (type == typeof(float))
                {
                    obj = DeserializeToSingle(input, type);
                    break;
                }

                #endregion Single

                #region String

                if (type == typeof(string))
                {
                    obj = DeserializeToString(input, type);
                    break;
                }

                #endregion String

                #region UInt16

                if (type == typeof(ushort))
                {
                    obj = DeserializeToUInt16(input, type);
                    break;
                }

                #endregion UInt16

                #region UInt32

                if (type == typeof(uint))
                {
                    obj = DeserializeToUInt32(input, type);
                    break;
                }

                #endregion UInt32

                #region UInt64

                if (type == typeof(ulong))
                {
                    obj = DeserializeToUInt64(input, type);
                    break;
                }

                #endregion UInt64

                #region BigInteger

                if (type == typeof(BigInteger))
                {
                    obj = DeserializeToBigInteger(input, type);
                    break;
                }

                #endregion BigInteger

                #region DataTable

                if (type == typeof(DataTable))
                {
                    obj = DeserializeToDataTable(input, type);
                    break;
                }

                #endregion DataTable

                #region DateTime

                if (type == typeof(DateTime))
                {
                    obj = DeserializeToDateTime(input, type);
                    break;
                }

                #endregion DateTime

                #region Dictionary

                if (typeof(IDictionary).IsAssignableFrom(type))
                {
                    obj = DeserializeToDictionary(input, type);
                    break;
                }

                #endregion Dictionary

                #region Enum

                if (type.IsEnum)
                {
                    obj = DeserializeToEnum(input, type);
                    break;
                }

                #endregion Enum

                #region Guid

                if (type == typeof(Guid))
                {
                    obj = DeserializeToGuid(input, type);
                    break;
                }

                #endregion Guid

                #region IEnumerable

                if (typeof(IEnumerable).IsAssignableFrom(type))
                {
                    obj = DeserializeToIEnumerable(input, type);
                    break;
                }

                #endregion IEnumerable

                #region Lazy

                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Lazy<>))
                {
                    obj = DeserializeToLazy(input, type);
                    break;
                }

                #endregion Lazy

                #region Nullable

                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    obj = DeserializeToNullable(input, type);
                    break;
                }

                #endregion Nullable

                #region Regex

                if (type == typeof(Regex))
                {
                    obj = DeserializeToRegex(input, type);
                    break;
                }

                #endregion Regex

                #region Uri

                if (type == typeof(Uri))
                {
                    obj = DeserializeToUri(input, type);
                    break;
                }

                #endregion Uri

                #region Class

                obj = DeserializeToClass(input, type);
                break;

                #endregion Class
            }

            CurrentStackLevel--;
            return obj;
        }

        private static bool IsHex(char value)
        {
            if (value >= '0' && value <= '9')
            {
                return true;
            }
            if (value >= 'a' && value <= 'f')
            {
                return true;
            }
            return value >= 'A' && value <= 'F';
        }

        [SuppressMessage("Microsoft.Performance", "CA1822")]
        private BigInteger DeserializeToBigInteger(string input, Type type)
        {
            BigInteger bigInteger;
            if (BigInteger.TryParse(input, out bigInteger) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return bigInteger;
        }

        [SuppressMessage("Microsoft.Performance", "CA1822")]
        private bool DeserializeToBoolean(string input, Type type)
        {
            switch (input)
            {
                case "true":
                    {
                        return true;
                    }
                case "false":
                    {
                        return false;
                    }
                default:
                    {
                        throw new JsonDeserializeException(input, type);
                    }
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1822")]
        private byte DeserializeToByte(string input, Type type)
        {
            byte b;
            if (byte.TryParse(input, out b) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return b;
        }

        [SuppressMessage("Microsoft.Performance", "CA1822")]
        private char DeserializeToChar(string input, Type type)
        {
            if (input.StartsWith("\"", StringComparison.Ordinal) && input.EndsWith("\"", StringComparison.Ordinal))
            {
                var source = input;
                input = input.Substring(1, input.Length - 2);
                if (input == "\\\"")
                {
                    return '\"';
                }
                if (input == "\\\\")
                {
                    return '\\';
                }
                if (input == "\\b")
                {
                    return '\b';
                }
                if (input == "\\f")
                {
                    return '\f';
                }
                if (input == "\\n")
                {
                    return '\n';
                }
                if (input == "\\r")
                {
                    return '\r';
                }
                if (input == "\\t")
                {
                    return '\t';
                }
                if (input.StartsWith("\\u", StringComparison.Ordinal))
                {
                    input = input.Substring(2);
                    if (input.Length == 4)
                    {
                        var c0 = input[0];
                        var c1 = input[1];
                        var c2 = input[2];
                        var c3 = input[3];
                        if (IsHex(c0) && IsHex(c1) && IsHex(c2) && IsHex(c3))
                        {
                            var b0 = Convert.ToByte(c2.ToString(CultureInfo.InvariantCulture) + c3.ToString(CultureInfo.InvariantCulture), 16);
                            var b1 = Convert.ToByte(c0.ToString(CultureInfo.InvariantCulture) + c1.ToString(CultureInfo.InvariantCulture), 16);
                            return Encoding.Unicode.GetChars(new[] { b0, b1 })[0];
                        }
                        throw new JsonDeserializeException(source, type);
                    }
                    throw new JsonDeserializeException(source, type);
                }
                if (input.Length == 1)
                {
                    return input[0];
                }
                throw new JsonDeserializeException(source, type);
            }
            throw new JsonDeserializeException(input, type);
        }

        [SuppressMessage("Microsoft.Design", "CA1031")]
        [SuppressMessage("Microsoft.Maintainability", "CA1502")]
        private object DeserializeToClass(string input, Type type)
        {
            if (input.StartsWith("{", StringComparison.Ordinal) && input.EndsWith("}", StringComparison.Ordinal))
            {
                var source = input;
                input = input.Substring(1, input.Length - 2);
                var keyValue = new Dictionary<string, string>();
                foreach (var temp in JsonHelper.ItemReader(input))
                {
                    string key;
                    string value;
                    JsonHelper.ItemSpliter(temp, out key, out value);
                    if (key.StartsWith("\"", StringComparison.Ordinal) && key.EndsWith("\"", StringComparison.Ordinal))
                    {
                        key = key.Substring(1, key.Length - 2);
                    }
                    else
                    {
                        throw new JsonDeserializeException(source, type);
                    }
                    if (keyValue.ContainsKey(key) == false)
                    {
                        keyValue.Add(key, value);
                    }
                    else
                    {
                        throw new JsonDeserializeException(source, type);
                    }
                }

                #region 匿名类

                if (type.Name.Contains("AnonymousType") && string.IsNullOrEmpty(type.Namespace))
                {
                    // 获取匿名类唯一构造函数。
                    var constructor = type.GetConstructors().Single();

                    // 获取匿名类构造函数的参数。
                    var parameters = constructor.GetParameters();

                    // 存放反序列化的参数。
                    var args = new List<object>();

                    foreach (var parameter in parameters)
                    {
                        // 参数名字。
                        var parameterName = parameter.Name;
                        if (keyValue.ContainsKey(parameterName))
                        {
                            // json 中存在对应的值。
                            args.Add(DeserializeToObject(keyValue[parameterName], parameter.ParameterType));
                        }
                        else
                        {
                            // json 中不存在对应的值，填充类型的默认值。
                            var parameterType = parameter.ParameterType;
                            args.Add(parameterType.IsValueType ? Activator.CreateInstance(parameterType) : null);
                        }
                    }

                    // 执行构造函数。
                    return constructor.Invoke(args.ToArray());
                }

                #endregion 匿名类

                object instance;
                try
                {
                    instance = Activator.CreateInstance(type, true);
                }
                catch (System.Exception)
                {
                    var constructors = type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).OrderBy(temp => temp.IsPublic == false).ThenBy(temp => temp.GetParameters().Length);
                    var constructor = constructors.ElementAt(0);
                    instance = constructor.Invoke(new object[constructor.GetParameters().Length]);
                }

                #region 字段

                FieldInfo[] fields;
                if (JsonHelper.TypeFields.TryGetValue(type, out fields) == false)
                {
                    fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
                    if (JsonHelper.TypeFields.ContainsKey(type) == false)
                    {
                        lock (JsonHelper.TypeFields)
                        {
                            if (JsonHelper.TypeFields.ContainsKey(type) == false)
                            {
                                JsonHelper.TypeFields.Add(type, fields);
                            }
                        }
                    }
                }
                foreach (FieldInfo field in fields)
                {
                    var attribute = field.GetCustomAttributes(typeof(JsonAttribute), false).FirstOrDefault() as JsonAttribute;
                    if (attribute != null)
                    {
                        if (field.IsPublic == false && attribute.ProcessNonPublic == false)
                        {
                            continue;
                        }
                        var name = string.IsNullOrEmpty(attribute.Name) ? field.Name : attribute.Name;
                        if (keyValue.ContainsKey(name))
                        {
                            object value;
                            if (attribute.Converter != null)
                            {
                                var converter = Activator.CreateInstance(attribute.Converter) as JsonConverter;
                                if (converter != null)
                                {
                                    var skip = false;
                                    value = converter.Deserialize(keyValue[name], field.FieldType, ref skip);
                                    if (skip)
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    throw new JsonDeserializeException(source, type);
                                }
                            }
                            else
                            {
                                value = DeserializeToObject(keyValue[name], field.FieldType);
                            }
                            field.SetValue(instance, value);
                        }
                    }
                    else
                    {
                        if (field.IsPublic == false)
                        {
                            continue;
                        }
                        var name = field.Name;
                        if (keyValue.ContainsKey(name))
                        {
                            field.SetValue(instance, DeserializeToObject(keyValue[name], field.FieldType));
                        }
                    }
                }

                #endregion 字段

                #region 属性

                PropertyInfo[] properties;
                if (JsonHelper.TypeProperties.TryGetValue(type, out properties) == false)
                {
                    properties = type.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
                    if (JsonHelper.TypeProperties.ContainsKey(type) == false)
                    {
                        lock (JsonHelper.TypeProperties)
                        {
                            if (JsonHelper.TypeProperties.ContainsKey(type) == false)
                            {
                                JsonHelper.TypeProperties.Add(type, properties);
                            }
                        }
                    }
                }
                foreach (PropertyInfo property in properties)
                {
                    if (property.GetIndexParameters().Length == 0)
                    {
                        var attribute = property.GetCustomAttributes(typeof(JsonAttribute), false).FirstOrDefault() as JsonAttribute;
                        if (attribute != null)
                        {
                            if (property.CanWrite == false && attribute.ProcessNonPublic == false)
                            {
                                continue;
                            }
                            var setMethod = property.GetSetMethod(true);
                            if (setMethod == null)
                            {
                                continue;
                            }
                            var name = string.IsNullOrEmpty(attribute.Name) ? property.Name : attribute.Name;
                            if (keyValue.ContainsKey(name))
                            {
                                object value;
                                if (attribute.Converter != null)
                                {
                                    var converter = Activator.CreateInstance(attribute.Converter) as JsonConverter;
                                    if (converter != null)
                                    {
                                        var skip = false;
                                        value = converter.Deserialize(keyValue[name], property.PropertyType, ref skip);
                                        if (skip)
                                        {
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        throw new JsonDeserializeException(source, type);
                                    }
                                }
                                else
                                {
                                    value = DeserializeToObject(keyValue[name], property.PropertyType);
                                }

                                setMethod.Invoke(instance, new[] { value });
                            }
                        }
                        else
                        {
                            if (property.CanWrite == false)
                            {
                                continue;
                            }
                            var name = property.Name;
                            if (keyValue.ContainsKey(name))
                            {
                                property.SetValue(instance, DeserializeToObject(keyValue[name], property.PropertyType), null);
                            }
                        }
                    }
                }

                #endregion 属性

                return instance;
            }
            throw new JsonDeserializeException(input, type);
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000")]
        private DataTable DeserializeToDataTable(string input, Type type)
        {
            input = input.Trim();
            if (input.StartsWith("[", StringComparison.Ordinal) && input.EndsWith("]", StringComparison.Ordinal))
            {
                var rows = JsonHelper.ItemReader(input.Substring(1, input.Length - 2));
                var table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };
                foreach (var row in rows)
                {
                    var temp = row.Trim();
                    var values = new List<object>();
                    foreach (var column in JsonHelper.ItemReader(temp.Substring(1, temp.Length - 2)))
                    {
                        string columnName;
                        string value;
                        JsonHelper.ItemSpliter(column, out columnName, out value);
                        columnName = (string)DeserializeToObject(columnName, typeof(string));
                        var valueType = JsonHelper.TypeInference(value);
                        if (table.Columns.Contains(columnName) == false)
                        {
                            table.Columns.Add(columnName, valueType ?? typeof(object));
                        }
                        values.Add(valueType == null ? value : DeserializeToObject(value, valueType));
                    }
                    table.Rows.Add(values.ToArray());
                }
                return table;
            }
            throw new JsonDeserializeException(input, type);
        }

        [SuppressMessage("Microsoft.Performance", "CA1822")]
        private DateTime DeserializeToDateTime(string input, Type type)
        {
            var match = DateTimeCreateRegex.Match(input);
            if (match.Success)
            {
                var sms = match.Groups[1].Value;
                double ms;
                if (double.TryParse(sms, out ms) == false)
                {
                    throw new JsonDeserializeException(input, type);
                }
                return new DateTime(1970, 1, 1, 8, 0, 0).AddMilliseconds(ms);
            }
            match = DateTimeDefaultRegex.Match(input.Substring(1, input.Length - 2));
            if (match.Success)
            {
                var syear = match.Groups[1].Value;
                var smonth = match.Groups[2].Value;
                var sday = match.Groups[3].Value;
                var shour = match.Groups[4].Value;
                var sminute = match.Groups[5].Value;
                var ssecond = match.Groups[6].Value;
                var sms = match.Groups[7].Value;
                var szone = match.Groups[8].Value;

                int year;
                int month;
                int day;
                int hour;
                int minute;
                int second;
                double ms;

                if (int.TryParse(syear, out year) == false)
                {
                    throw new JsonDeserializeException(input, type);
                }
                if (int.TryParse(smonth, out month) == false)
                {
                    throw new JsonDeserializeException(input, type);
                }
                if (int.TryParse(sday, out day) == false)
                {
                    throw new JsonDeserializeException(input, type);
                }
                if (int.TryParse(shour, out hour) == false)
                {
                    throw new JsonDeserializeException(input, type);
                }
                if (int.TryParse(sminute, out minute) == false)
                {
                    throw new JsonDeserializeException(input, type);
                }
                if (int.TryParse(ssecond, out second) == false)
                {
                    throw new JsonDeserializeException(input, type);
                }
                if (double.TryParse("0" + sms, out ms) == false)
                {
                    throw new JsonDeserializeException(input, type);
                }

                if (szone.Length == 0)
                {
                    return new DateTime((new DateTime(year, month, day, hour, minute, second)).Ticks + (long)(ms * 10000000));
                }
                return new DateTime((new DateTime(year, month, day, hour, minute, second)).Ticks + (long)(ms * 10000000), DateTimeKind.Local);
            }
            match = DateTimeFunctionRegex.Match(input.Substring(1, input.Length - 2));
            if (match.Success)
            {
                var sms = match.Groups[1].Value;
                double ms;
                if (double.TryParse(sms, out ms) == false)
                {
                    throw new JsonDeserializeException(input, type);
                }
                return new DateTime(1970, 1, 1, 8, 0, 0).AddMilliseconds(ms);
            }
            throw new JsonDeserializeException(input, type);
        }

        [SuppressMessage("Microsoft.Performance", "CA1822")]
        private decimal DeserializeToDecimal(string input, Type type)
        {
            decimal d;
            if (decimal.TryParse(input, out d) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return d;
        }

        private object DeserializeToDictionary(string input, Type type)
        {
            if (input.StartsWith("{", StringComparison.Ordinal) && input.EndsWith("}", StringComparison.Ordinal))
            {
                var source = input;
                input = input.Substring(1, input.Length - 2);
                var dictionary = Activator.CreateInstance(type, true) as IDictionary;
                if (dictionary == null)
                {
                    throw new ArgumentException("type 不实现 IDictionary 接口。", "type");
                }
                // 获取键类型。
                var keyType = type.GetGenericArguments()[0];
                // 获取值类型。
                var valueType = type.GetGenericArguments()[1];
                foreach (var temp in JsonHelper.ItemReader(input))
                {
                    string key;
                    string value;
                    JsonHelper.ItemSpliter(temp, out key, out value);
                    var oKey = DeserializeToObject(key, keyType);
                    if (dictionary.Contains(oKey) == false)
                    {
                        var oValue = DeserializeToObject(value, valueType);
                        dictionary.Add(oKey, oValue);
                    }
                    else
                    {
                        throw new JsonDeserializeException(source, type);
                    }
                }
                return dictionary;
            }
            throw new JsonDeserializeException(input, type);
        }

        [SuppressMessage("Microsoft.Performance", "CA1822")]
        private double DeserializeToDouble(string input, Type type)
        {
            double d;
            if (double.TryParse(input, out d) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return d;
        }

        [SuppressMessage("Microsoft.Performance", "CA1822")]
        private Enum DeserializeToEnum(string input, Type type)
        {
            if (input.StartsWith("\"", StringComparison.Ordinal) && input.EndsWith("\"", StringComparison.Ordinal))
            {
                var source = input;
                input = input.Substring(1, input.Length - 2);
                Enum value;
                try
                {
                    value = (Enum)Enum.Parse(type, input, false);
                }
                catch (System.Exception)
                {
                    throw new JsonDeserializeException(source, type);
                }
                return value;
            }
            int i;
            if (int.TryParse(input, out i))
            {
                return (Enum)Enum.Parse(type, i.ToString(CultureInfo.InvariantCulture), false);
            }
            throw new JsonDeserializeException(input, type);
        }

        [SuppressMessage("Microsoft.Performance", "CA1822")]
        private Guid DeserializeToGuid(string input, Type type)
        {
            if ((input.StartsWith("\"", StringComparison.Ordinal) && input.EndsWith("\"", StringComparison.Ordinal)) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            input = input.Substring(1, input.Length - 2);
            return Guid.Parse(input);
        }

        [SuppressMessage("Microsoft.Performance", "CA1822")]
        private IEnumerable DeserializeToIEnumerable(string input, Type type)
        {
            if (type.IsArray)
            {
                if (input.StartsWith("[", StringComparison.Ordinal) && input.EndsWith("]", StringComparison.Ordinal))
                {
                    input = input.Substring(1, input.Length - 2).Trim();
                    // 获取元素类型。
                    var elementType = type.GetElementType();
                    var list = new ArrayList();
                    foreach (var temp in JsonHelper.ItemReader(input))
                    {
                        list.Add(DeserializeToObject(temp, elementType));
                    }
                    return list.ToArray(type.GetElementType());
                }
                throw new JsonDeserializeException(input, type);
            }
            if (typeof(IList).IsAssignableFrom(type))
            {
                if (input.StartsWith("[", StringComparison.Ordinal) && input.EndsWith("]", StringComparison.Ordinal))
                {
                    input = input.Substring(1, input.Length - 2).Trim();
                    // 获取元素类型。
                    var elementType = type.GetGenericArguments()[0];
                    var list = Activator.CreateInstance(type) as IList;
                    if (list == null)
                    {
                        throw new ArgumentException("type 不实现 IList 接口。", "type");
                    }
                    foreach (var temp in JsonHelper.ItemReader(input))
                    {
                        list.Add(DeserializeToObject(temp, elementType));
                    }
                    return list;
                }
                throw new JsonDeserializeException(input, type);
            }
            {
                if (input.StartsWith("[", StringComparison.Ordinal) && input.EndsWith("]", StringComparison.Ordinal))
                {
                    input = input.Substring(1, input.Length - 2).Trim();
                    // 获取元素类型。
                    var elementType = type.GetElementType();
                    var list = new List<object>();
                    var enumerator = JsonHelper.ItemReader(input).GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        list.Add(DeserializeToObject(enumerator.Current, elementType));
                    }
                    return list;
                }
                throw new JsonDeserializeException(input, type);
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1822")]
        private short DeserializeToInt16(string input, Type type)
        {
            short s;
            if (short.TryParse(input, out s) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return s;
        }

        [SuppressMessage("Microsoft.Performance", "CA1822")]
        private int DeserializeToInt32(string input, Type type)
        {
            int i;
            if (int.TryParse(input, out i) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return i;
        }

        [SuppressMessage("Microsoft.Performance", "CA1822")]
        private long DeserializeToInt64(string input, Type type)
        {
            long l;
            if (long.TryParse(input, out l) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return l;
        }

        private object DeserializeToLazy(string input, Type type)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var temp in JsonHelper.ItemReader(input))
            {
                string key;
                string value;
                JsonHelper.ItemSpliter(temp, out key, out value);
                dictionary.Add(key, value);
            }

            if (dictionary["IsValueCreated"] != "true")
            {
                return Activator.CreateInstance(type);
            }

            var elementType = type.GetGenericArguments()[0];

            var element = DeserializeToObject(dictionary["Value"], elementType);
            var lazyInstance = Activator.CreateInstance(type, new object[] { Expression.Lambda(Expression.Constant(element, elementType)).Compile() });

            var valueProperty = type.GetProperty("Value");
            valueProperty.GetValue(lazyInstance, null);

            return lazyInstance;
        }

        private object DeserializeToNullable(string input, Type type)
        {
            return input == "null" ? null : DeserializeToObject(input, Nullable.GetUnderlyingType(type));
        }

        [SuppressMessage("Microsoft.Performance", "CA1822")]
        private Regex DeserializeToRegex(string input, Type type)
        {
            var match = RegexCreateRegex.Match(input);
            if (match.Success)
            {
                var pattern = match.Groups[2].Success ? match.Groups[2].Value : match.Groups[3].Value;
                var attributes = match.Groups[6].Success ? match.Groups[6].Value : match.Groups[7].Value;
                var options = RegexOptions.None;
                if (attributes.Contains("i"))
                {
                    options = options | RegexOptions.IgnoreCase;
                }
                if (attributes.Contains("m"))
                {
                    options = options | RegexOptions.Multiline;
                }
                return new Regex(pattern, options);
            }
            match = RegexDefaultRegex.Match(input);

            if (match.Success == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            {
                var pattern = match.Groups[1].Value;
                var attributes = match.Groups[2].Value;
                var options = RegexOptions.None;
                if (attributes.Contains("i"))
                {
                    options = options | RegexOptions.IgnoreCase;
                }
                if (attributes.Contains("m"))
                {
                    options = options | RegexOptions.Multiline;
                }
                return new Regex(pattern, options);
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1822")]
        private sbyte DeserializeToSByte(string input, Type type)
        {
            sbyte sb;
            if (sbyte.TryParse(input, out sb) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return sb;
        }

        [SuppressMessage("Microsoft.Performance", "CA1822")]
        private float DeserializeToSingle(string input, Type type)
        {
            float f;
            if (float.TryParse(input, out f) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return f;
        }

        [SuppressMessage("Microsoft.Performance", "CA1822")]
        private string DeserializeToString(string input, Type type)
        {
            if ((input.StartsWith("\"", StringComparison.Ordinal) && input.EndsWith("\"", StringComparison.Ordinal)) ==
                false)
            {
                throw new JsonDeserializeException(input, type);
            }

            var source = input;
            input = input.Substring(1, input.Length - 2);
            var sb = new StringBuilder();
            for (int i = 0, length = input.Length; i < length; i++)
            {
                if (input[i] == '\\')
                {
                    if (i + 1 == length)
                    {
                        throw new JsonDeserializeException(source, type);
                    }
                    if (input[i + 1] == '\"')
                    {
                        sb.Append("\"");
                    }
                    else if (input[i + 1] == '\\')
                    {
                        sb.Append("\\");
                    }
                    else if (input[i + 1] == 'b')
                    {
                        sb.Append("\b");
                    }
                    else if (input[i + 1] == 'f')
                    {
                        sb.Append("\f");
                    }
                    else if (input[i + 1] == 'n')
                    {
                        sb.Append("\n");
                    }
                    else if (input[i + 1] == 'r')
                    {
                        sb.Append("\r");
                    }
                    else if (input[i + 1] == 't')
                    {
                        sb.Append("\t");
                    }
                    else if (input[i + 1] == 'u' && i + 5 < length)
                    {
                        var c0 = input[i + 2];
                        var c1 = input[i + 3];
                        var c2 = input[i + 4];
                        var c3 = input[i + 5];
                        if (IsHex(c0) && IsHex(c1) && IsHex(c2) && IsHex(c3))
                        {
                            var b0 = Convert.ToByte(c2.ToString(CultureInfo.InvariantCulture) + c3.ToString(CultureInfo.InvariantCulture), 16);
                            var b1 = Convert.ToByte(c0.ToString(CultureInfo.InvariantCulture) + c1.ToString(CultureInfo.InvariantCulture), 16);
                            sb.Append(Encoding.Unicode.GetChars(new[] { b0, b1 })[0]);
                            i += 4;
                        }
                        else
                        {
                            throw new JsonDeserializeException(source, type);
                        }
                    }
                    else
                    {
                        throw new JsonDeserializeException(source, type);
                    }
                    i++;
                }
                else
                {
                    sb.Append(input[i]);
                }
            }
            return sb.ToString();
        }

        [SuppressMessage("Microsoft.Performance", "CA1822")]
        private ushort DeserializeToUInt16(string input, Type type)
        {
            ushort us;
            if (ushort.TryParse(input, out us) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return us;
        }

        [SuppressMessage("Microsoft.Performance", "CA1822")]
        private uint DeserializeToUInt32(string input, Type type)
        {
            uint ui;
            if (uint.TryParse(input, out ui) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return ui;
        }

        [SuppressMessage("Microsoft.Performance", "CA1822")]
        private ulong DeserializeToUInt64(string input, Type type)
        {
            ulong ul;
            if (ulong.TryParse(input, out ul) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return ul;
        }

        [SuppressMessage("Microsoft.Performance", "CA1822")]
        private Uri DeserializeToUri(string input, Type type)
        {
            if ((input.StartsWith("\"", StringComparison.Ordinal) && input.EndsWith("\"", StringComparison.Ordinal)) == false)
            {
                throw new JsonDeserializeException(input, type);
            }

            var source = input;
            input = input.Substring(1, input.Length - 2);
            Uri value;
            try
            {
                value = new Uri(input);
            }
            catch
            {
                throw new JsonDeserializeException(source, type);
            }
            return value;
        }
    }
}