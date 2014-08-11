// ReSharper disable CheckNamespace
namespace System.Reflection
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// MethodInfo 扩展类。
    /// </summary>
    public static class MethodInfoExtensions
    {
        /// <summary>
        /// 从此方法创建指定类型的委托。
        /// </summary>
        /// <param name="method">当前 System.Reflection.MethodInfo 对象。</param>
        /// <param name="delegateType">要创建的委托的类型。</param>
        /// <returns>此方法的委托。</returns>
        public static Delegate CreateDelegate(this MethodInfo method, Type delegateType)
        {
            var stackCrawMarkFlags = Type.GetType("System.Threading.StackCrawlMark");
            if (stackCrawMarkFlags == null)
            {
                throw new TypeLoadException();
            }
            var delegateBindingFlags = Type.GetType("System.DelegateBindingFlags");
            if (delegateBindingFlags == null)
            {
                throw new TypeLoadException();
            }

            var stackMark = Enum.ToObject(stackCrawMarkFlags, 1);

            return (Delegate)(typeof(MethodInfo).GetMethod("CreateDelegateInternal", BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(Type), typeof(object), delegateBindingFlags, stackCrawMarkFlags.MakeByRefType() }, null).Invoke(method, new[] { delegateType, null, Enum.ToObject(delegateBindingFlags, 0x00000004 | 0x00000080), stackMark }));
        }

        /// <summary>
        /// 从此方法创建具有指定目标的指定类型的委托。
        /// </summary>
        /// <param name="method">当前 System.Reflection.MethodInfo 对象。</param>
        /// <param name="delegateType">要创建的委托的类型。</param>
        /// <param name="target">代理以该对象为目标。</param>
        /// <returns>此方法的委托。</returns>
        public static Delegate CreateDelegate(this MethodInfo method, Type delegateType, object target)
        {
            var stackCrawMarkFlags = Type.GetType("System.Threading.StackCrawlMark");
            if (stackCrawMarkFlags == null)
            {
                throw new TypeLoadException();
            }
            var delegateBindingFlags = Type.GetType("System.DelegateBindingFlags");
            if (delegateBindingFlags == null)
            {
                throw new TypeLoadException();
            }

            var stackMark = Enum.ToObject(stackCrawMarkFlags, 1);

            return (Delegate)(typeof(MethodInfo).GetMethod("CreateDelegateInternal", BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(Type), typeof(object), delegateBindingFlags, stackCrawMarkFlags.MakeByRefType() }, null).Invoke(method, new[] { delegateType, target, Enum.ToObject(delegateBindingFlags, 0x00000080), stackMark }));
        }
    }
}