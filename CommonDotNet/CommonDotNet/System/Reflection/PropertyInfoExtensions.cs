using System.Diagnostics;

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
        public static Object GetValue(this PropertyInfo property, Object obj)
        {
            return property.GetValue(obj, null);
        }
    }
}