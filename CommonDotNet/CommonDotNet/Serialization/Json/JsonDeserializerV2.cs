//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Data;
//using System.Globalization;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Media;
//using System.Numerics;
//using System.Reflection;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Windows.Markup;

//namespace Common.Serialization.Json
//{
//    internal class JsonDeserializerV2
//    {
//        private int _currentStackLevel;

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

//        internal int MaxStackLevel
//        {
//            get;
//            set;
//        }

//        internal object DeserializeFromJson(string input, Type type)
//        {
//            return DeserializeToObject(input, type);
//        }

//        private static object DeserializeToNull()
//        {
//            return null;
//        }

//        private double DeserializeToDouble(string input, Type type)
//        {
//            double d;
//            if (double.TryParse(input, out d) == false)
//            {
//                throw new JsonDeserializeException(input, type);
//            }
//            return d;
//        }

//        private object DeserializeToObject(string input, Type type)
//        {
//            CurrentStackLevel++;

//            object obj;
//            input = input.Trim();

//            if (input.Length == 0 || input == "null")
//            {
//                #region null

//                obj = DeserializeToNull();

//                #endregion
//            }
//            else if (type.IsValueType)
//            {
//                #region ValueType

//                obj = DeserializeToValueType(input, type);

//                #endregion
//            }
//            else
//            {
//                #region ReferenceType

//                obj = DeserializeToReferenceType(input, type);

//                #endregion
//            }

//            CurrentStackLevel--;
//            return obj;
//        }

//        private decimal DeserializeToDecimal(string input, Type type)
//        {
//            decimal d;
//            if (decimal.TryParse(input, out d) == false)
//            {
//                throw new JsonDeserializeException(input, type);
//            }
//            return d;
//        }

//        private char DeserializeToChar(string input, Type type)
//        {
//            if (input.StartsWith("\"") && input.EndsWith("\""))
//            {
//                var source = input;
//                input = input.Substring(1, input.Length - 2);
//                if (input == "\\\"")
//                {
//                    return '\"';
//                }
//                if (input == "\\\\")
//                {
//                    return '\\';
//                }
//                if (input == "\\b")
//                {
//                    return '\b';
//                }
//                if (input == "\\f")
//                {
//                    return '\f';
//                }
//                if (input == "\\n")
//                {
//                    return '\n';
//                }
//                if (input == "\\r")
//                {
//                    return '\r';
//                }
//                if (input == "\\t")
//                {
//                    return '\t';
//                }
//                if (input.StartsWith("\\u", StringComparison.Ordinal))
//                {
//                    input = input.Substring(2);
//                    if (input.Length == 4)
//                    {
//                        var c0 = input[0];
//                        var c1 = input[1];
//                        var c2 = input[2];
//                        var c3 = input[3];
//                        if (IsHex(c0) && IsHex(c1) && IsHex(c2) && IsHex(c3))
//                        {
//                            var b0 = Convert.ToByte(c2.ToString(CultureInfo.InvariantCulture) + c3.ToString(CultureInfo.InvariantCulture), 16);
//                            var b1 = Convert.ToByte(c0.ToString(CultureInfo.InvariantCulture) + c1.ToString(CultureInfo.InvariantCulture), 16);
//                            return Encoding.Unicode.GetChars(new[] { b0, b1 })[0];
//                        }
//                        throw new JsonDeserializeException(source, type);
//                    }
//                    throw new JsonDeserializeException(source, type);
//                }
//                if (input.Length == 1)
//                {
//                    return input[0];
//                }
//                throw new JsonDeserializeException(source);
//            }
//            throw new JsonDeserializeException(input, type);
//        }

//        private static bool IsHex(char value)
//        {
//            return ('0' <= value && value <= '9') || ('a' <= value && value <= 'f') || ('A' <= value && value <= 'F');
//        }

//        private object DeserializeToValueType(string input, Type type)
//        {
//            if (type == typeof(bool))
//            {
//                #region Boolean

//                return DeserializeToBoolean(input, type);

//                #endregion
//            }
//            if (type == typeof(byte))
//            {
//                #region Byte

//                return DeserializeToByte(input, type);

//                #endregion
//            }
//            if (type == typeof(char))
//            {
//                #region Char

//                return DeserializeToChar(input, type);

//                #endregion
//            }
//            if (type == typeof(decimal))
//            {
//                #region Decimal

//                return DeserializeToDecimal(input, type);

//                #endregion
//            }
//            if (type == typeof(double))
//            {
//                #region Double

//                return DeserializeToDouble(input, type);

//                #endregion
//            }
//            if (type.IsEnum)
//            {
//                #region Enum

//                return DeserializeToEnum(input, type);

//                #endregion
//            }
//            if (type == typeof(short))
//            {
//                #region Int16

//                return DeserializeToInt16(input, type);

//                #endregion
//            }
//            if (type == typeof(int))
//            {
//                #region Int32

//                return DeserializeToInt32(input, type);

//                #endregion
//            }
//            if (type == typeof(long))
//            {
//                #region Int64

//                return DeserializeToInt64(input, type);

//                #endregion
//            }
//            if (type == typeof(sbyte))
//            {
//                #region SByte

//                return DeserializeToSByte(input, type);

//                #endregion
//            }
//            if (type == typeof(float))
//            {
//                #region Single

//                return DeserializeToSingle(input, type);

//                #endregion
//            }
//            if (type == typeof(ushort))
//            {
//                #region UInt16

//                return DeserializeToUInt16(input, type);

//                #endregion
//            }
//            if (type == typeof(uint))
//            {
//                #region UInt32

//                return DeserializeToUInt32(input, type);

//                #endregion
//            }
//            if (type == typeof(ulong))
//            {
//                #region UInt64

//                return DeserializeToUInt64(input, type);

//                #endregion
//            }
//            if (type == typeof(BigInteger))
//            {
//                #region BigInteger

//                return DeserializeToBigInteger(input, type);

//                #endregion
//            }
//            if (type == typeof(DateTime))
//            {
//                #region DateTime

//                return DeserializeToDateTime(input, type);

//                #endregion
//            }
//            if (type == typeof(Guid))
//            {
//                #region Guid

//                return DeserializeToGuid(input, type);

//                #endregion
//            }
//            if (type == typeof(TimeSpan))
//            {
//                #region TimeSpan

//                return DeserializeToTimeSpan(input, type);

//                #endregion
//            }
//            #region Struct

//            return DeserializeToOther(input, type);

//            #endregion
//        }

//        private static readonly Regex DateTimeCreateRegex = new Regex(@"^new\s+Date\(\s*(\d*)\s*\)$", RegexOptions.Compiled);

//        private static readonly Regex DateTimeDefaultRegex = new Regex(@"^(\d{4})\-(\d{2})\-(\d{2})T(\d{2}):(\d{2}):(\d{2})(\.\d*)?([\+|\-]\d{2}:\d{2})?$", RegexOptions.Compiled);

//        private static readonly Regex DateTimeFunctionRegex = new Regex(@"^\\/Date\((\d+)\)\\/$", RegexOptions.Compiled);

//        private static readonly Regex RegexCreateRegex = new Regex("new\\s+RegExp\\(\\s*(\\\"(.*?)\\\"|\\'(.*?)\\')\\s*(,\\s*(\\\"(.*?)\\\"|\\'(.*?)\\')\\s*)?\\)", RegexOptions.Compiled);

//        private static readonly Regex RegexDefaultRegex = new Regex(@"^/(.*?)/(g|i|m|gi|gm|ig|im|mg|mi|gim|gmi|igm|img|mgi|mig)?$", RegexOptions.Compiled);


//        private DateTime DeserializeToDateTime(string input, Type type)
//        {
//            var match = DateTimeCreateRegex.Match(input);
//            if (match.Success)
//            {
//                var sms = match.Groups[1].Value;
//                double ms;
//                if (double.TryParse(sms, out ms) == false)
//                {
//                    throw new JsonDeserializeException(input, type);
//                }
//                return new DateTime(1970, 1, 1, 8, 0, 0).AddMilliseconds(ms);
//            }
//            match = DateTimeDefaultRegex.Match(input.Substring(1, input.Length - 2));
//            if (match.Success)
//            {
//                var syear = match.Groups[1].Value;
//                var smonth = match.Groups[2].Value;
//                var sday = match.Groups[3].Value;
//                var shour = match.Groups[4].Value;
//                var sminute = match.Groups[5].Value;
//                var ssecond = match.Groups[6].Value;
//                var sms = match.Groups[7].Value;
//                var szone = match.Groups[8].Value;

//                int year;
//                int month;
//                int day;
//                int hour;
//                int minute;
//                int second;
//                double ms;

//                if (int.TryParse(syear, out year) == false)
//                {
//                    throw new JsonDeserializeException(input, type);
//                }
//                if (int.TryParse(smonth, out month) == false)
//                {
//                    throw new JsonDeserializeException(input, type);
//                }
//                if (int.TryParse(sday, out day) == false)
//                {
//                    throw new JsonDeserializeException(input, type);
//                }
//                if (int.TryParse(shour, out hour) == false)
//                {
//                    throw new JsonDeserializeException(input, type);
//                }
//                if (int.TryParse(sminute, out minute) == false)
//                {
//                    throw new JsonDeserializeException(input, type);
//                }
//                if (int.TryParse(ssecond, out second) == false)
//                {
//                    throw new JsonDeserializeException(input, type);
//                }
//                if (double.TryParse("0" + sms, out ms) == false)
//                {
//                    throw new JsonDeserializeException(input, type);
//                }

//                if (szone.Length == 0)
//                {
//                    return new DateTime((new DateTime(year, month, day, hour, minute, second)).Ticks + (long)(ms * 10000000));
//                }
//                return new DateTime((new DateTime(year, month, day, hour, minute, second)).Ticks + (long)(ms * 10000000), DateTimeKind.Local);
//            }
//            match = DateTimeFunctionRegex.Match(input.Substring(1, input.Length - 2));
//            if (match.Success)
//            {
//                var sms = match.Groups[1].Value;
//                double ms;
//                if (double.TryParse(sms, out ms) == false)
//                {
//                    throw new JsonDeserializeException(input, type);
//                }
//                return new DateTime(1970, 1, 1, 8, 0, 0).AddMilliseconds(ms);
//            }
//            throw new JsonDeserializeException(input, type);
//        }



//        private Guid DeserializeToGuid(string input, Type type)
//        {
//            if (input.StartsWith("\"", StringComparison.Ordinal) && input.EndsWith("\"", StringComparison.Ordinal))
//            {
//                input = input.Substring(1, input.Length - 2);
//                return Guid.Parse(input);
//            }
//            throw new JsonDeserializeException(input, type);
//        }

//        private Enum DeserializeToEnum(string input, Type type)
//        {
//            if (input.StartsWith("\"", StringComparison.Ordinal) && input.EndsWith("\"", StringComparison.Ordinal))
//            {
//                var source = input;
//                input = input.Substring(1, input.Length - 2);
//                Enum value;
//                try
//                {
//                    value = (Enum)Enum.Parse(type, input, false);
//                }
//                catch (Exception)
//                {
//                    throw new JsonDeserializeException(source, type);
//                }
//                return value;
//            }
//            int i;
//            if (int.TryParse(input, out i))
//            {
//                return (Enum)Enum.Parse(type, i.ToString(CultureInfo.InvariantCulture), false);
//            }
//            throw new JsonDeserializeException(input, type);
//        }

//        private float DeserializeToSingle(string input, Type type)
//        {
//            float f;
//            if (float.TryParse(input, out f) == false)
//            {
//                throw new JsonDeserializeException(input, type);
//            }
//            return f;
//        }


//        private ulong DeserializeToUInt64(string input, Type type)
//        {
//            ulong ul;
//            if (ulong.TryParse(input, out ul) == false)
//            {
//                throw new JsonDeserializeException(input, type);
//            }
//            return ul;
//        }

//        private uint DeserializeToUInt32(string input, Type type)
//        {
//            uint ui;
//            if (uint.TryParse(input, out ui) == false)
//            {
//                throw new JsonDeserializeException(input, type);
//            }
//            return ui;
//        }

//        private ushort DeserializeToUInt16(string input, Type type)
//        {
//            ushort us;
//            if (ushort.TryParse(input, out us) == false)
//            {
//                throw new JsonDeserializeException(input, type);
//            }
//            return us;
//        }

//        private sbyte DeserializeToSByte(string input, Type type)
//        {
//            sbyte sb;
//            if (sbyte.TryParse(input, out sb) == false)
//            {
//                throw new JsonDeserializeException(input, type);
//            }
//            return sb;
//        }

//        private byte DeserializeToByte(string input, Type type)
//        {
//            byte b;
//            if (byte.TryParse(input, out b) == false)
//            {
//                throw new JsonDeserializeException(input, type);
//            }
//            return b;
//        }

//        private bool DeserializeToBoolean(string input, Type type)
//        {
//            switch (input)
//            {
//                case "true":
//                    {
//                        return true;
//                    }
//                case "false":
//                    {
//                        return false;
//                    }
//                default:
//                    {
//                        throw new JsonDeserializeException(input, type);
//                    }
//            }
//        }
//        private BigInteger DeserializeToBigInteger(string input, Type type)
//        {
//            BigInteger bigInteger;
//            if (BigInteger.TryParse(input, out bigInteger) == false)
//            {
//                throw new JsonDeserializeException(input, type);
//            }
//            return bigInteger;
//        }

//        private DBNull DeserializeToDBNull(string input, Type type)
//        {
//            if (input.Length == 0 || input == "null")
//            {
//                return DBNull.Value;
//            }
//            throw new JsonDeserializeException(input, type);
//        }

//        private object DeserializeToDictionary(string input, Type type)
//        {
//            if (input.StartsWith("{", StringComparison.Ordinal) && input.EndsWith("}", StringComparison.Ordinal))
//            {
//                var source = input;
//                input = input.Substring(1, input.Length - 2);
//                var dictionary = Activator.CreateInstance(type, true) as IDictionary;
//                if (dictionary == null)
//                {
//                    throw new ArgumentException("type 不实现 IDictionary 接口。", "type");
//                }
//                // 获取键类型。
//                var keyType = type.GetGenericArguments()[0];
//                // 获取值类型。
//                var valueType = type.GetGenericArguments()[1];
//                foreach (var temp in JsonHelper.ItemReader(input))
//                {
//                    string key;
//                    string value;
//                    JsonHelper.ItemSpliter(temp, out key, out value);
//                    var oKey = DeserializeToObject(key, keyType);
//                    if (dictionary.Contains(oKey) == false)
//                    {
//                        var oValue = DeserializeToObject(value, valueType);
//                        dictionary.Add(oKey, oValue);
//                    }
//                    else
//                    {
//                        throw new JsonDeserializeException(source, type);
//                    }
//                }
//                return dictionary;
//            }
//            throw new JsonDeserializeException(input, type);
//        }

//        private Regex DeserializeToRegex(string input, Type type)
//        {
//            var match = RegexCreateRegex.Match(input);
//            if (match.Success)
//            {
//                var pattern = match.Groups[2].Success ? match.Groups[2].Value : match.Groups[3].Value;
//                var attributes = match.Groups[6].Success ? match.Groups[6].Value : match.Groups[7].Value;
//                var options = RegexOptions.None;
//                if (attributes.Contains("i"))
//                {
//                    options = options | RegexOptions.IgnoreCase;
//                }
//                if (attributes.Contains("m"))
//                {
//                    options = options | RegexOptions.Multiline;
//                }
//                return new Regex(pattern, options);
//            }

//            match = RegexDefaultRegex.Match(input);
//            if (match.Success)
//            {
//                var pattern = match.Groups[1].Value;
//                var attributes = match.Groups[2].Value;
//                var options = RegexOptions.None;
//                if (attributes.Contains("i"))
//                {
//                    options = options | RegexOptions.IgnoreCase;
//                }
//                if (attributes.Contains("m"))
//                {
//                    options = options | RegexOptions.Multiline;
//                }
//                return new Regex(pattern, options);
//            }

//            throw new JsonDeserializeException(input, type);
//        }


//        private object DeserializeToReferenceType(string input, Type type)
//        {
//            if (type == typeof(string))
//            {
//                // 因为 String 最常见，所以放在最前比较。

//                #region String

//                return DeserializeToString(input, type);

//                #endregion
//            }
//            if (type == typeof(DataTable))
//            {
//                #region DataTable;

//                return DeserializeToDataTable(input, type);

//                #endregion
//            }
//            if (type == typeof(DBNull))
//            {
//                #region DBNull

//                return DeserializeToDBNull(input, type);

//                #endregion
//            }
//            if (typeof(IDictionary).IsAssignableFrom(type))
//            {
//                // IDictionary 必须比 IEnumerable 先反序列化。

//                #region Dictionary

//                return DeserializeToDictionary(input, type);

//                #endregion
//            }
//            if (typeof(IEnumerable).IsAssignableFrom(type))
//            {
//                #region IEnumerable

//                DeserializeToIEnumerable();

//                #endregion
//            }
//            if (type == typeof(Regex))
//            {
//                #region Regex

//                return DeserializeToRegex(input, type);

//                #endregion
//            }
//            if (type == typeof(Uri))
//            {
//                #region Uri

//                return DeserializeToUri(input, type);

//                #endregion
//            }
//            if (type == typeof(Type))
//            {
//                return DeserializeToType(input, type);
//            }
//            if (type.IsGenericType)
//            {
//                var genericTypeDefinition = type.GetGenericTypeDefinition();
//                if (genericTypeDefinition == typeof(Lazy<>))
//                {
//                    #region  Lazy

//                    return DeserializeToLazy(input, type);

//                    #endregion
//                }
//                if (genericTypeDefinition == typeof(Nullable<>) && type.GetElementType().IsValueType)
//                {
//                    #region Nullable

//                    return DeserializeToNullable(input, type);

//                    #endregion
//                }

//            }

//            #region Class

//            return DeserializeToOther(input, type);

//            #endregion
//        }

//        private object DeserializeToOther(string input, Type type)
//        {
//            if (input.StartsWith("\"") && input.EndsWith("\""))
//            {
//                // 获取 JSON 键值对。
//                var keyValues = GetKeyValues(input, type);
//                if (IsAnonymousType(type))
//                {
//                    // 反序列化匿名类。
//                    return DeserializeToAnonymousType(input, keyValues, type);
//                }
//                // 创建反序列化实例。
//                var instance = CreateInstance(type);

//                // 反序列化字段。
//                DeserializeFields(ref instance, keyValues, type);

//                // 反序列化属性。
//                DeserializeProperties(ref instance, keyValues, type);

//                return instance;
//            }
//            throw new JsonDeserializeException(input, type);
//        }

//        private void DeserializeProperties(ref object instance, Dictionary<string, string> keyValues, Type type)
//        {
//            var properties = JsonCache.GetTypePropertyInfos(type);
//            foreach (var property in properties)
//            {
//                DeserializeProperty(ref instance, keyValues, property);
//            }
//        }

//        private void DeserializeFields(ref object instance, Dictionary<string, string> keyValues, Type type)
//        {
//            var fields = JsonCache.GetTypeFieldInfos(type);
//            foreach (var field in fields)
//            {
//                DeserializeField(ref instance, keyValues, field);
//            }
//        }

//        private void DeserializeProperty(ref object instance, Dictionary<string, string> keyValues, PropertyInfo property)
//        {
//            // 不序列化索引器。
//            if (property.GetIndexParameters().Length != 0)
//            {
//                return;
//            }
//            var attribute = Attribute.GetCustomAttribute(property, typeof(JsonAttribute)) as JsonAttribute;
//            string key;
//            object value;
//            if (attribute != null)
//            {
//                // 非公有属性且不反序列化。
//                if (property.CanWrite == false && attribute.ProcessNonPublic == false)
//                {
//                    return;
//                }
//                var setMethod = property.GetSetMethod(true);
//                if (setMethod == null)
//                {
//                    return;
//                }
//                // 使用自定义映射名字。
//                key = string.IsNullOrEmpty(attribute.Name) ? property.Name : attribute.Name;
//                if (keyValues.ContainsKey(key) == false)
//                {
//                    return;
//                }
//                // 使用自定义反序列化。
//                if (attribute.Converter != null)
//                {
//                    var converter = Activator.CreateInstance(attribute.Converter) as JsonConverter;
//                    if (converter != null)
//                    {
//                        var isSkip = false;
//                        value = converter.Deserialize(keyValues[key], property.PropertyType, ref isSkip);
//                        if (isSkip)
//                        {
//                            return;
//                        }
//                    }
//                    else
//                    {
//                        throw new JsonDeserializeException(keyValues[key], property.PropertyType);
//                    }
//                }
//                else
//                {
//                    value = DeserializeToObject(keyValues[key], property.PropertyType);
//                }
//                setMethod.Invoke(instance, new[] { value });
//            }
//            else
//            {
//                if (property.CanWrite == false)
//                {
//                    return;
//                }
//                key = property.Name;
//                if (keyValues.ContainsKey(key) == false)
//                {
//                    return;
//                }
//                value = DeserializeToObject(keyValues[key], property.PropertyType);
//                property.SetValue(instance, value, null);
//            }
//        }

//        private void DeserializeField(ref object instance, Dictionary<string, string> keyValues, FieldInfo field)
//        {
//            var attribute = Attribute.GetCustomAttribute(field, typeof(JsonAttribute)) as JsonAttribute;
//            string key;
//            object value;
//            if (attribute != null)
//            {
//                // 非公有字段且不反序列化。
//                if (field.IsPublic == false && attribute.ProcessNonPublic == false)
//                {
//                    return;
//                }
//                // 使用自定义映射名字。
//                key = string.IsNullOrEmpty(attribute.Name) ? field.Name : attribute.Name;
//                if (keyValues.ContainsKey(key) == false)
//                {
//                    return;
//                }
//                // 使用自定义反序列化。
//                if (attribute.Converter != null)
//                {
//                    var converter = Activator.CreateInstance(attribute.Converter) as JsonConverter;
//                    if (converter != null)
//                    {
//                        var isSkip = false;
//                        value = converter.Deserialize(keyValues[key], field.FieldType, ref isSkip);
//                        if (isSkip)
//                        {
//                            return;
//                        }
//                    }
//                    else
//                    {
//                        throw new JsonDeserializeException(keyValues[key], field.FieldType);
//                    }
//                }
//                else
//                {
//                    value = DeserializeToObject(keyValues[key], field.FieldType);
//                }
//            }
//            else
//            {
//                if (field.IsPublic == false)
//                {
//                    return;
//                }
//                key = field.Name;
//                if (keyValues.ContainsKey(key) == false)
//                {
//                    return;
//                }
//                value = DeserializeToObject(keyValues[key], field.FieldType);
//            }
//            field.SetValue(instance, value);
//        }

//        private object CreateInstance(Type type)
//        {
//            try
//            {
//                return Activator.CreateInstance(type, true);
//            }
//            catch (Exception)
//            {
//                var constructors = type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).OrderBy(temp => temp.IsPublic == false).ThenBy(temp => temp.GetParameters().Length);
//                var constructor = constructors.ElementAt(0);
//                return constructor.Invoke(new object[constructor.GetParameters().Length]);
//            }

//        }

//        private bool IsAnonymousType(Type type)
//        {
//            return type.Name.Contains("AnonymousType") && string.IsNullOrEmpty(type.Namespace);
//        }

//        private object DeserializeToAnonymousType(string soruce, Dictionary<string, string> keyValues, Type anonymousType)
//        {
//            // 获取匿名类构造函数。
//            var constructors = anonymousType.GetConstructors();

//            if (constructors.Length != 1)
//            {
//                throw new JsonDeserializeException(soruce, anonymousType);
//            }

//            // 获取匿名类唯一构造函数。
//            var constructor = constructors[0];

//            // 获取匿名类构造函数的参数。
//            var parameters = constructor.GetParameters();

//            // 存放反序列化的参数。
//            var args = new List<object>();

//            foreach (var parameter in parameters)
//            {
//                // 参数名字。
//                var parameterName = parameter.Name;
//                if (keyValues.ContainsKey(parameterName))
//                {
//                    // JSON 中存在对应的值。
//                    args.Add(DeserializeToObject(keyValues[parameterName], parameter.ParameterType));
//                }
//                else
//                {
//                    // JSON 中不存在对应的值，填充类型的默认值。
//                    var parameterType = parameter.ParameterType;
//                    args.Add(parameterType.IsValueType ? Activator.CreateInstance(parameterType) : null);
//                }
//            }

//            // 执行构造函数。
//            return constructor.Invoke(args.ToArray());
//        }

//        private Dictionary<string, string> GetKeyValues(string input, Type type)
//        {
//            var source = input;
//            input = input.Substring(1, input.Length - 2);
//            var keyValues = new Dictionary<string, string>();
//            foreach (var temp in JsonHelper.ItemReader(input))
//            {
//                string key, value;
//                JsonHelper.ItemSpliter(temp, out key, out value);
//                if (key.StartsWith("\"") && key.EndsWith("\""))
//                {
//                    key = key.Substring(1, key.Length - 2);
//                }
//                else
//                {
//                    throw new JsonDeserializeException(source, type);
//                }
//                if (keyValues.ContainsKey(key) == false)
//                {
//                    keyValues.Add(key, value);
//                }
//                else
//                {
//                    throw new JsonDeserializeException(source, type);
//                }
//            }
//            return keyValues;
//        }


//        private object DeserializeToLazy(string input, Type type)
//        {
//            var dictionary = new Dictionary<string, string>();
//            foreach (var temp in JsonHelper.ItemReader(input))
//            {
//                string key;
//                string value;
//                JsonHelper.ItemSpliter(temp, out key, out value);
//                dictionary.Add(key, value);
//            }

//            if (dictionary.ContainsKey("IsValueCreated") && dictionary.ContainsKey("Value"))
//            {
//                string isValueCreated = dictionary["IsValueCreated"];
//                switch (isValueCreated)
//                {
//                    case "true":
//                        {
//                            var elementType = type.GetGenericArguments()[0];
//                            var element = DeserializeToObject(dictionary["Value"], elementType);
//                            var lazyInstance = Activator.CreateInstance(type, new object[] { Expression.Lambda(Expression.Constant(element, elementType)).Compile() });

//                            // 获取 Value 属性的值，以使实例的 IsValueCreated 属性的值为 true。
//                            var valueProperty = type.GetProperty("Value");
//                            valueProperty.GetValue(lazyInstance, null);

//                            return lazyInstance;
//                        }
//                    case "false":
//                        {
//                            return Activator.CreateInstance(type);
//                        }
//                    default:
//                        {
//                            throw new JsonDeserializeException(input, type);
//                        }
//                }
//            }
//            throw new JsonDeserializeException(input, type);
//        }

//        private object DeserializeToNullable(string input, Type type)
//        {
//            return input.Length == 0 || input == "null" ? null : DeserializeToObject(input, Nullable.GetUnderlyingType(type));
//        }




//        private Uri DeserializeToUri(string input, Type type)
//        {
//            if ((input.StartsWith("\"", StringComparison.Ordinal) && input.EndsWith("\"", StringComparison.Ordinal)))
//            {
//                var source = input;
//                input = input.Substring(1, input.Length - 2);
//                Uri value;
//                try
//                {
//                    value = new Uri(input);
//                }
//                catch
//                {
//                    throw new JsonDeserializeException(source, type);
//                }
//                return value;
//            }

//            throw new JsonDeserializeException(input, type);
//        }


//        private string DeserializeToString(string input, Type type)
//        {
//            if ((input.StartsWith("\"", StringComparison.Ordinal) && input.EndsWith("\"", StringComparison.Ordinal)) ==
//                false)
//            {
//                throw new JsonDeserializeException(input, type);
//            }

//            var source = input;
//            input = input.Substring(1, input.Length - 2);
//            var sb = new StringBuilder();
//            for (int i = 0, length = input.Length; i < length; i++)
//            {
//                if (input[i] == '\\')
//                {
//                    if (i + 1 == length)
//                    {
//                        throw new JsonDeserializeException(source, type);
//                    }
//                    if (input[i + 1] == '\"')
//                    {
//                        sb.Append("\"");
//                    }
//                    else if (input[i + 1] == '\\')
//                    {
//                        sb.Append("\\");
//                    }
//                    else if (input[i + 1] == 'b')
//                    {
//                        sb.Append("\b");
//                    }
//                    else if (input[i + 1] == 'f')
//                    {
//                        sb.Append("\f");
//                    }
//                    else if (input[i + 1] == 'n')
//                    {
//                        sb.Append("\n");
//                    }
//                    else if (input[i + 1] == 'r')
//                    {
//                        sb.Append("\r");
//                    }
//                    else if (input[i + 1] == 't')
//                    {
//                        sb.Append("\t");
//                    }
//                    else if (input[i + 1] == 'u' && i + 5 < length)
//                    {
//                        var c0 = input[i + 2];
//                        var c1 = input[i + 3];
//                        var c2 = input[i + 4];
//                        var c3 = input[i + 5];
//                        if (IsHex(c0) && IsHex(c1) && IsHex(c2) && IsHex(c3))
//                        {
//                            var b0 = Convert.ToByte(c2.ToString(CultureInfo.InvariantCulture) + c3.ToString(CultureInfo.InvariantCulture), 16);
//                            var b1 = Convert.ToByte(c0.ToString(CultureInfo.InvariantCulture) + c1.ToString(CultureInfo.InvariantCulture), 16);
//                            sb.Append(Encoding.Unicode.GetChars(new[] { b0, b1 })[0]);
//                            i += 4;
//                        }
//                        else
//                        {
//                            throw new JsonDeserializeException(source, type);
//                        }
//                    }
//                    else
//                    {
//                        throw new JsonDeserializeException(source, type);
//                    }
//                    i++;
//                }
//                else
//                {
//                    sb.Append(input[i]);
//                }
//            }
//            return sb.ToString();
//        }


//        private short DeserializeToInt16(string input, Type type)
//        {
//            short s;
//            if (short.TryParse(input, out s) == false)
//            {
//                throw new JsonDeserializeException(input, type);
//            }
//            return s;
//        }

//        private int DeserializeToInt32(string input, Type type)
//        {
//            int i;
//            if (int.TryParse(input, out i) == false)
//            {
//                throw new JsonDeserializeException(input, type);
//            }
//            return i;
//        }

//        private long DeserializeToInt64(string input, Type type)
//        {
//            long l;
//            if (long.TryParse(input, out l) == false)
//            {
//                throw new JsonDeserializeException(input, type);
//            }
//            return l;
//        }
//    }
//}