﻿// ReSharper disable CheckNamespace
namespace System.Runtime.CompilerServices
// ReSharper restore CheckNamespace
{
#if Net40
    /// <summary>
    /// 允许您获取该方法的调用者方法或属性名称。（需在 Visual Studio 2012 以上使用。）
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public sealed class CallerMemberNameAttribute : Attribute
    {
    }
#endif
}