﻿using System;

namespace Common.Serialization.Json
{
    /// <summary>
    /// 标记字段或属性以自定义 JSON 序列化。
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class JsonAttribute : Attribute
    {
        private Type _converter;

        /// <summary>
        /// 创建一个 JsonAttribute 的实例。
        /// </summary>
        public JsonAttribute()
        {
            CountMustGreaterThan = -1;
            CountMustLessThan = -1;
        }

        /// <summary>
        /// 使用自定义的序列化转换。
        /// </summary>
        public Type Converter
        {
            get
            {
                return _converter;
            }
            set
            {
                if (value == null || value.IsSubclassOf(typeof(JsonConverter)))
                {
                    _converter = value;
                }
                else
                {
                    throw new ArgumentException("Converter 必须为 JsonConverter 类的子类。");
                }
            }
        }

        /// <summary>
        /// 约束在序列化时字符串或数组或集合的元素个数必须大于指定值。小于零为不约束。默认为 -1。当对象为 null 时，此标签属性不作用。
        /// </summary>
        public int CountMustGreaterThan
        {
            get;
            set;
        }

        /// <summary>
        /// 约束在序列化时字符串或数组或集合的元素个数必须小于指定值。小于零为不约束。默认为 -1。当对象为 null 时，此标签属性不作用。
        /// </summary>
        public int CountMustLessThan
        {
            get;
            set;
        }

        /// <summary>
        /// 是否在序列化时忽略标记的字段或属性。默认 false。
        /// </summary>
        public bool Ignore
        {
            get;
            set;
        }

        /// <summary>
        /// 若标记的字段或属性为 null 时，是否在序列化时忽略。默认 false。
        /// </summary>
        public bool IgnoreNull
        {
            get;
            set;
        }

        /// <summary>
        /// 指定在序列化和反序列化时映射的名字。
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 是否序列化与反序列化非公有字段或属性。默认 false。
        /// </summary>
        public bool ProcessNonPublic
        {
            get;
            set;
        }

        /// <summary>
        /// 若序列化时，当前字段或属性为 null。则抛出异常。默认 false。（优先度低于 Ignore 和 IgnoreNull 属性）。
        /// </summary>
        public bool Required
        {
            get;
            set;
        }
    }
}