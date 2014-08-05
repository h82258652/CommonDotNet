#if Net40
using System.Collections.Generic;

// ReSharper disable CheckNamespace
namespace System.Reflection
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// 包含检索自定义特性的静态方法。
    /// </summary>
    public static class CustomAttributeExtensions
    {
        #region APIs that return a single attribute

        /// <summary>
        /// 检索应用于指定程序集的指定类型的自定义特性。
        /// </summary>
        /// <param name="element">要检查的程序集。</param>
        /// <param name="attributeType">要搜索的特性类型。</param>
        /// <returns>与 <c>attributeType</c> 匹配的自定义特性，如果未找到此类特性，则为 null。</returns>
        /// <exception cref="ArgumentNullException"><c>element</c> 或 <c>attributeType</c> 为 null。</exception>
        /// <exception cref="ArgumentException"><c>attributeType</c> 不从 Attribute 派生。</exception>
        /// <exception cref="AmbiguousMatchException">找到多个请求的属性。</exception>
        public static Attribute GetCustomAttribute(this Assembly element, Type attributeType)
        {
            return Attribute.GetCustomAttribute(element, attributeType);
        }

        /// <summary>
        /// 检索应用于指定模块的指定类型的自定义特性。
        /// </summary>
        /// <param name="element">要检查的模块。</param>
        /// <param name="attributeType">要搜索的特性类型。</param>
        /// <returns>与 <c>attributeType</c> 匹配的自定义特性，如果未找到此类特性，则为 null。</returns>
        /// <exception cref="ArgumentNullException"><c>element</c> 或 <c>attributeType</c> 为 null。</exception>
        /// <exception cref="ArgumentException"><c>attributeType</c> 不从 Attribute 派生。</exception>
        /// <exception cref="AmbiguousMatchException">找到多个请求的属性。</exception>
        public static Attribute GetCustomAttribute(this Module element, Type attributeType)
        {
            return Attribute.GetCustomAttribute(element, attributeType);
        }

        /// <summary>
        /// 检索应用于指定成员的指定类型的自定义特性。
        /// </summary>
        /// <param name="element">要检查的成员。</param>
        /// <param name="attributeType">要搜索的特性类型。</param>
        /// <returns>与 <c>attributeType</c> 匹配的自定义特性，如果未找到此类特性，则为 null。</returns>
        /// <exception cref="ArgumentNullException"><c>element</c> 或 <c>attributeType</c> 为 null。</exception>
        /// <exception cref="ArgumentException"><c>attributeType</c> 不从 Attribute 派生。</exception>
        /// <exception cref="NotSupportedException"><c>element</c> 不是构造函数、方法、属性、事件、类型或字段。</exception>
        /// <exception cref="AmbiguousMatchException">找到多个请求的属性。</exception>
        /// <exception cref="TypeLoadException">无法加载自定义特性类型。</exception>
        public static Attribute GetCustomAttribute(this MemberInfo element, Type attributeType)
        {
            return Attribute.GetCustomAttribute(element, attributeType);
        }

        /// <summary>
        /// 检索应用于指定参数的指定类型的自定义特性。
        /// </summary>
        /// <param name="element">要检查的参数。</param>
        /// <param name="attributeType">要搜索的特性类型。</param>
        /// <returns>与 <c>attributeType</c> 匹配的自定义特性，如果未找到此类特性，则为 null。</returns>
        /// <exception cref="ArgumentNullException"><c>element</c> 或 <c>attributeType</c> 为 null。</exception>
        /// <exception cref="ArgumentException"><c>attributeType</c> 不从 Attribute 派生。</exception>
        /// <exception cref="AmbiguousMatchException">找到多个请求的属性。</exception>
        /// <exception cref="TypeLoadException">无法加载自定义特性类型。</exception>
        public static Attribute GetCustomAttribute(this ParameterInfo element, Type attributeType)
        {
            return Attribute.GetCustomAttribute(element, attributeType);
        }

        /// <summary>
        /// 检索应用于指定程序集的指定类型的自定义特性。
        /// </summary>
        /// <typeparam name="T">要搜索的特性类型。</typeparam>
        /// <param name="element">要检查的程序集。</param>
        /// <returns>与 <c>T</c> 相匹配的自定义属性；否则，如果没有找到这类属性，则为 null。</returns>
        /// <exception cref="ArgumentNullException"><c>element</c> 为 null。</exception>
        /// <exception cref="AmbiguousMatchException">找到多个请求的属性。</exception>
        public static T GetCustomAttribute<T>(this Assembly element) where T : Attribute
        {
            return (T)GetCustomAttribute(element, typeof(T));
        }

        /// <summary>
        /// 检索应用于指定模块的指定类型的自定义特性。
        /// </summary>
        /// <typeparam name="T">要搜索的特性类型。</typeparam>
        /// <param name="element">要检查的模块。</param>
        /// <returns>与 <c>T</c> 相匹配的自定义属性；否则，如果没有找到这类属性，则为 null。</returns>
        /// <exception cref="ArgumentNullException"><c>element</c> 为 null。</exception>
        /// <exception cref="AmbiguousMatchException">找到多个请求的属性。</exception>
        public static T GetCustomAttribute<T>(this Module element) where T : Attribute
        {
            return (T)GetCustomAttribute(element, typeof(T));
        }

        /// <summary>
        /// 检索应用于指定成员的指定类型的自定义特性。
        /// </summary>
        /// <typeparam name="T">要搜索的特性类型。</typeparam>
        /// <param name="element">要检查的成员。</param>
        /// <returns>与 <c>T</c> 相匹配的自定义属性；否则，如果没有找到这类属性，则为 null。</returns>
        /// <exception cref="ArgumentNullException"><c>element</c> 为 null。</exception>
        /// <exception cref="NotSupportedException"><c>element</c> 不是构造函数、方法、属性、事件、类型或字段。</exception>
        /// <exception cref="AmbiguousMatchException">找到多个请求的属性。</exception>
        /// <exception cref="TypeLoadException">无法加载自定义特性类型。</exception>
        public static T GetCustomAttribute<T>(this MemberInfo element) where T : Attribute
        {
            return (T)GetCustomAttribute(element, typeof(T));
        }

        /// <summary>
        /// 检索应用于指定参数的指定类型的自定义特性。
        /// </summary>
        /// <typeparam name="T">要搜索的特性类型。</typeparam>
        /// <param name="element">要检查的参数。</param>
        /// <returns>与 <c>T</c> 相匹配的自定义属性；否则，如果没有找到这类属性，则为 null。</returns>
        /// <exception cref="ArgumentNullException"><c>element</c> 为 null。</exception>
        /// <exception cref="NotSupportedException"><c>element</c> 不是构造函数、方法、属性、事件、类型或字段。</exception>
        /// <exception cref="AmbiguousMatchException">找到多个请求的属性。</exception>
        /// <exception cref="TypeLoadException">无法加载自定义特性类型。</exception>
        public static T GetCustomAttribute<T>(this ParameterInfo element) where T : Attribute
        {
            return (T)GetCustomAttribute(element, typeof(T));
        }

        /// <summary>
        /// 检索应用于指定成员的指定类型的自定义特性，并可选择检查该成员的上级。
        /// </summary>
        /// <param name="element">要检查的成员。</param>
        /// <param name="attributeType">要搜索的特性类型。</param>
        /// <param name="inherit">如果检查 <c>element</c> 的上级，则为 true；否则为 false。</param>
        /// <returns>与 <c>attributeType</c> 匹配的自定义特性，如果未找到此类特性，则为 null。</returns>
        /// <exception cref="ArgumentNullException"><c>element</c> 或 <c>attributeType</c> 为 null。</exception>
        /// <exception cref="ArgumentException"><c>attributeType</c> 不从 Attribute 派生。</exception>
        /// <exception cref="NotSupportedException"><c>element</c> 不是构造函数、方法、属性、事件、类型或字段。</exception>
        /// <exception cref="AmbiguousMatchException">找到多个请求的属性。</exception>
        /// <exception cref="TypeLoadException">无法加载自定义特性类型。</exception>
        public static Attribute GetCustomAttribute(this MemberInfo element, Type attributeType, bool inherit)
        {
            return Attribute.GetCustomAttribute(element, attributeType, inherit);
        }

        /// <summary>
        /// 检索应用于指定参数的指定类型的自定义特性，并可选择检查该参数的上级。
        /// </summary>
        /// <param name="element">要检查的参数。</param>
        /// <param name="attributeType">要搜索的特性类型。</param>
        /// <param name="inherit">如果检查 <c>element</c> 的上级，则为 true；否则为 false。</param>
        /// <returns>匹配 <c>attributeType</c> 的自定义特性，如果未找到此类特性，则为 null。</returns>
        /// <exception cref="ArgumentNullException"><c>element</c> 或 <c>attributeType</c> 为 null。</exception>
        /// <exception cref="ArgumentException"><c>attributeType</c> 不从 Attribute 派生。</exception>
        /// <exception cref="AmbiguousMatchException">找到多个请求的属性。</exception>
        /// <exception cref="TypeLoadException">无法加载自定义特性类型。</exception>
        public static Attribute GetCustomAttribute(this ParameterInfo element, Type attributeType, bool inherit)
        {
            return Attribute.GetCustomAttribute(element, attributeType, inherit);
        }
        
        /// <summary>
        /// 检索应用于指定成员的指定类型的自定义特性，并可选择检查该成员的上级。
        /// </summary>
        /// <typeparam name="T">要搜索的特性类型。</typeparam>
        /// <param name="element">要检查的成员。</param>
        /// <param name="inherit">如果检查 <c>element</c> 的上级，则为 true；否则为 false。</param>
        /// <returns>与 <c>T</c> 相匹配的自定义属性；否则，如果没有找到这类属性，则为 null。</returns>
        /// <exception cref="ArgumentNullException"><c>element</c> 为 null。</exception>
        /// <exception cref="NotSupportedException"><c>element</c> 不是构造函数、方法、属性、事件、类型或字段。</exception>
        /// <exception cref="AmbiguousMatchException">找到多个请求的属性。</exception>
        /// <exception cref="TypeLoadException">无法加载自定义特性类型。</exception>
        public static T GetCustomAttribute<T>(this MemberInfo element, bool inherit) where T : Attribute
        {
            return (T)GetCustomAttribute(element, typeof(T), inherit);
        }

        /// <summary>
        /// 检索应用于指定参数的指定类型的自定义特性，并可选择检查该参数的上级。
        /// </summary>
        /// <typeparam name="T">要搜索的特性类型。</typeparam>
        /// <param name="element">要检查的参数。</param>
        /// <param name="inherit">如果检查 <c>element</c> 的上级，则为 true；否则为 false。</param>
        /// <returns>与 <c>T</c> 相匹配的自定义属性；否则，如果没有找到这类属性，则为 null。</returns>
        /// <exception cref="ArgumentNullException"><c>element</c> 为 null。</exception>
        /// <exception cref="NotSupportedException"><c>element</c> 不是构造函数、方法、属性、事件、类型或字段。</exception>
        /// <exception cref="AmbiguousMatchException">找到多个请求的属性。</exception>
        /// <exception cref="TypeLoadException">无法加载自定义特性类型。</exception>
        public static T GetCustomAttribute<T>(this ParameterInfo element, bool inherit) where T : Attribute
        {
            return (T)GetCustomAttribute(element, typeof(T), inherit);
        }

        #endregion

        #region APIs that return all attributes

        /// <summary>
        /// 检索应用于指定程序集的自定义特性集合。
        /// </summary>
        /// <param name="element">要检查的程序集。</param>
        /// <returns>将应用于 <c>element</c> 的自定义特性的集合，如果此类特性不存在，则为空集合。</returns>
        /// <exception cref="ArgumentNullException"><c>element</c> 为 null。</exception>
        public static IEnumerable<Attribute> GetCustomAttributes(this Assembly element)
        {
            return Attribute.GetCustomAttributes(element);
        }

        /// <summary>
        /// 检索应用于指定模块的自定义特性集合。
        /// </summary>
        /// <param name="element">要检查的模块。</param>
        /// <returns>将应用于 <c>element</c> 的自定义特性的集合，如果此类特性不存在，则为空集合。</returns>
        /// <exception cref="ArgumentNullException"><c>element</c> 为 null。</exception>
        public static IEnumerable<Attribute> GetCustomAttributes(this Module element)
        {
            return Attribute.GetCustomAttributes(element);
        }

        /// <summary>
        /// 检索应用于指定成员的自定义特性集合。
        /// </summary>
        /// <param name="element">要检查的成员。</param>
        /// <returns>将应用于 <c>element</c> 的自定义特性的集合，如果此类特性不存在，则为空集合。</returns>
        /// <exception cref="ArgumentNullException"><c>element</c> 为 null。</exception>
        /// <exception cref="NotSupportedException"><c>element</c> 不是构造函数、方法、属性、事件、类型或字段。</exception>
        /// <exception cref="TypeLoadException">无法加载自定义特性类型。</exception>
        public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo element)
        {
            return Attribute.GetCustomAttributes(element);
        }

        /// <summary>
        /// 检索应用于指定参数的自定义特性的集合。
        /// </summary>
        /// <param name="element">要检查的参数。</param>
        /// <returns>将应用于 <c>element</c> 的自定义特性的集合，如果此类特性不存在，则为空集合。</returns>
        /// <exception cref="ArgumentNullException"><c>element</c> 为 null。</exception>
        /// <exception cref="NotSupportedException"><c>element</c> 不是构造函数、方法、属性、事件、类型或字段。</exception>
        /// <exception cref="TypeLoadException">无法加载自定义特性类型。</exception>
        public static IEnumerable<Attribute> GetCustomAttributes(this ParameterInfo element)
        {
            return Attribute.GetCustomAttributes(element);
        }

        /// <summary>
        /// 检索应用于指定成员的自定义特性集合，并可选择检查该成员的上级。
        /// </summary>
        /// <param name="element">要检查的成员。</param>
        /// <param name="inherit">如果检查 <c>element</c> 的上级，则为 true；否则为 false。</param>
        /// <returns>将应用于指定的条件匹配的 <c>element</c> 的自定义特性的集合，如果此类特性不存在，则为空集。</returns>
        /// <exception cref="ArgumentNullException"><c>element</c> 为 null。</exception>
        /// <exception cref="NotSupportedException"><c>element</c> 不是构造函数、方法、属性、事件、类型或字段。</exception>
        /// <exception cref="TypeLoadException">无法加载自定义特性类型。</exception>
        public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo element, bool inherit)
        {
            return Attribute.GetCustomAttributes(element, inherit);
        }

        /// <summary>
        /// 检索应用于指定参数的自定义特性集合，并可选择检查该参数的上级。
        /// </summary>
        /// <param name="element">要检查的参数。</param>
        /// <param name="inherit">如果检查 <c>element</c> 的上级，则为 true；否则为 false。</param>
        /// <returns>将应用于 <c>element</c> 的自定义特性的集合，如果此类特性不存在，则为空集合。</returns>
        /// <exception cref="ArgumentNullException"><c>element</c> 为 null。</exception>
        /// <exception cref="NotSupportedException"><c>element</c> 不是构造函数、方法、属性、事件、类型或字段。</exception>
        /// <exception cref="TypeLoadException">无法加载自定义特性类型。</exception>
        public static IEnumerable<Attribute> GetCustomAttributes(this ParameterInfo element, bool inherit)
        {
            return Attribute.GetCustomAttributes(element, inherit);
        }

        #endregion

        #region APIs that return all attributes of a particular type
        /// <summary>
        /// 检索应用于指定程序集的指定类型的自定义特性集合。
        /// </summary>
        /// <param name="element">要检查的程序集。</param>
        /// <param name="attributeType">要搜索的特性类型。</param>
        /// <returns>将应用于与 <c>element</c> 并与 <c>attributeType</c> 匹配的自定义特性的集合，如果此类特性不存在，则为空集合。</returns>
        /// <exception cref="ArgumentNullException"><c>element</c> 或 <c>attributeType</c> 为 null。</exception>
        /// <exception cref="ArgumentException"><c>attributeType</c> 不从 Attribute 派生。</exception>
        public static IEnumerable<Attribute> GetCustomAttributes(this Assembly element, Type attributeType)
        {
            return Attribute.GetCustomAttributes(element, attributeType);
        }
        public static IEnumerable<Attribute> GetCustomAttributes(this Module element, Type attributeType)
        {
            return Attribute.GetCustomAttributes(element, attributeType);
        }
        public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo element, Type attributeType)
        {
            return Attribute.GetCustomAttributes(element, attributeType);
        }
        public static IEnumerable<Attribute> GetCustomAttributes(this ParameterInfo element, Type attributeType)
        {
            return Attribute.GetCustomAttributes(element, attributeType);
        }

        public static IEnumerable<T> GetCustomAttributes<T>(this Assembly element) where T : Attribute
        {
            return (IEnumerable<T>)GetCustomAttributes(element, typeof(T));
        }
        public static IEnumerable<T> GetCustomAttributes<T>(this Module element) where T : Attribute
        {
            return (IEnumerable<T>)GetCustomAttributes(element, typeof(T));
        }
        public static IEnumerable<T> GetCustomAttributes<T>(this MemberInfo element) where T : Attribute
        {
            return (IEnumerable<T>)GetCustomAttributes(element, typeof(T));
        }
        public static IEnumerable<T> GetCustomAttributes<T>(this ParameterInfo element) where T : Attribute
        {
            return (IEnumerable<T>)GetCustomAttributes(element, typeof(T));
        }

        public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo element, Type attributeType, bool inherit)
        {
            return Attribute.GetCustomAttributes(element, attributeType, inherit);
        }
        public static IEnumerable<Attribute> GetCustomAttributes(this ParameterInfo element, Type attributeType, bool inherit)
        {
            return Attribute.GetCustomAttributes(element, attributeType, inherit);
        }

        public static IEnumerable<T> GetCustomAttributes<T>(this MemberInfo element, bool inherit) where T : Attribute
        {
            return (IEnumerable<T>)GetCustomAttributes(element, typeof(T), inherit);
        }
        public static IEnumerable<T> GetCustomAttributes<T>(this ParameterInfo element, bool inherit) where T : Attribute
        {
            return (IEnumerable<T>)GetCustomAttributes(element, typeof(T), inherit);
        }
        #endregion

        #region IsDefined

        /// <summary>
        /// 确定是否将指定类型的任何自定义属性应用于指定的程序集。
        /// </summary>
        /// <param name="element">要检查的程序集。</param>
        /// <param name="attributeType">要搜索的特性类型。</param>
        /// <returns>如果将指定类型的特性应用于 <c>element</c>，则为 true；否则为 false。</returns>
        /// <exception cref="ArgumentNullException"><c>element</c> 或 <c>attributeType</c> 为 null。</exception>
        /// <exception cref="ArgumentException"><c>attributeType</c> 不从 Attribute 派生。</exception>
        public static bool IsDefined(this Assembly element, Type attributeType)
        {
            return Attribute.IsDefined(element, attributeType);
        }

        /// <summary>
        /// 确定是否将指定类型的任何自定义属性应用于指定的模块。
        /// </summary>
        /// <param name="element">要检查的模块。</param>
        /// <param name="attributeType">要搜索的特性类型。</param>
        /// <returns>如果将指定类型的特性应用于 <c>element</c>，则为 true；否则为 false。</returns>
        /// <exception cref="ArgumentNullException"><c>element</c> 或 <c>attributeType</c> 为 null。</exception>
        /// <exception cref="ArgumentException"><c>attribute</c> 不从 Attribute 派生。</exception>
        public static bool IsDefined(this Module element, Type attributeType)
        {
            return Attribute.IsDefined(element, attributeType);
        }
        public static bool IsDefined(this MemberInfo element, Type attributeType)
        {
            return Attribute.IsDefined(element, attributeType);
        }
        public static bool IsDefined(this ParameterInfo element, Type attributeType)
        {
            return Attribute.IsDefined(element, attributeType);
        }

        public static bool IsDefined(this MemberInfo element, Type attributeType, bool inherit)
        {
            return Attribute.IsDefined(element, attributeType, inherit);
        }
        public static bool IsDefined(this ParameterInfo element, Type attributeType, bool inherit)
        {
            return Attribute.IsDefined(element, attributeType, inherit);
        }
        #endregion
    }
}
#endif