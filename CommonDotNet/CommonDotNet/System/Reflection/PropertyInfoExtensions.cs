using System.Diagnostics;
using System.Runtime;

// ReSharper disable CheckNamespace
namespace System.Reflection
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// PropertyInfo 扩展类。
    /// </summary>
    public static class PropertyInfoExtensions
    {
        /// <summary>
        /// 返回指定对象的属性值。
        /// </summary>
        /// <param name="property">当前 System.Reflection.PropertyInfo 对象。</param>
        /// <param name="obj">将返回其属性值的对象。</param>
        /// <returns>指定对象的属性值。</returns>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static object GetValue(this PropertyInfo property, object obj)
        {
            return property.GetValue(obj, null);
        }

        /// <summary>
        /// 设置指定对象的属性值。
        /// </summary>
        /// <param name="property">当前 System.Reflection.PropertyInfo 对象。</param>
        /// <param name="obj">将设置其属性值的对象。</param>
        /// <param name="value">新的属性值。</param>
        [DebuggerHidden]
        [DebuggerStepThrough]
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        public static void SetValue(this PropertyInfo property, object obj, object value)
        {
            property.SetValue(obj, value, null);
        }
    }
}