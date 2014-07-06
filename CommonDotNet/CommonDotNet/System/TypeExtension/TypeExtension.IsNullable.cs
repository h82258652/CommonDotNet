﻿
namespace System
{
    public static partial class TypeExtension
    {
        /// <summary>
        /// 指示类型是否为可空类型。
        /// </summary>
        /// <param name="type">当前 System.Nullable&lt;T&gt; 对象。</param>
        /// <returns>是否可空类型。</returns>
        public static bool IsNullable(this Type type)
        {
            return type != null && type.IsValueType && type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
}
