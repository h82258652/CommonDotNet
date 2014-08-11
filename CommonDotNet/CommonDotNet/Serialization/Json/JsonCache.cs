using System;
using System.Collections.Generic;
using System.Reflection;

namespace Common.Serialization.Json
{
    internal static class JsonCache
    {
        /// <summary>
        /// 缓存 Lazy 类的 IsValueCreated 属性。
        /// </summary>
        private static volatile Dictionary<Type, PropertyInfo> _lazyTypeIsValueCreatedProperties = new Dictionary<Type, PropertyInfo>();

        /// <summary>
        /// 缓存 Lazy 类的 Value 属性。
        /// </summary>
        private static volatile Dictionary<Type, PropertyInfo> _lazyTypeValueProperties = new Dictionary<Type, PropertyInfo>();

        /// <summary>
        /// 缓存类的字段。
        /// </summary>
        private static volatile Dictionary<Type, FieldInfo[]> _typeFields = new Dictionary<Type, FieldInfo[]>();

        /// <summary>
        /// 缓存类的属性。
        /// </summary>
        private static volatile Dictionary<Type, PropertyInfo[]> _typeProperties = new Dictionary<Type, PropertyInfo[]>();

        internal static Dictionary<Type, PropertyInfo> LazyTypeIsValueCreatedProperties
        {
            get
            {
                return _lazyTypeIsValueCreatedProperties;
            }
        }

        internal static Dictionary<Type, PropertyInfo> LazyTypeValueProperties
        {
            get
            {
                return _lazyTypeValueProperties;
            }
        }

        internal static FieldInfo[] GetTypeFieldInfos(Type type)
        {
            if (_typeFields.ContainsKey(type))
            {
                return _typeFields[type];
            }
            lock (_typeFields)
            {
                if (_typeFields.ContainsKey(type))
                {
                    return _typeFields[type];
                }
                var fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
                _typeFields.Add(type, fieldInfos);
                return fieldInfos;
            }
        }

        internal static PropertyInfo[] GetTypePropertyInfos(Type type)
        {
            if (_typeProperties.ContainsKey(type))
            {
                return _typeProperties[type];
            }
            lock (_typeProperties)
            {
                if (_typeProperties.ContainsKey(type))
                {
                    return _typeProperties[type];
                }
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
                _typeProperties.Add(type, properties);
                return properties;
            }
        }
    }
}