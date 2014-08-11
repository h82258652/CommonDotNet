#if Net40

// ReSharper disable CheckNamespace
namespace System.Runtime.CompilerServices
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// 允许您获取包含该调用者源文件的完整路径。这是在编译时的文件路径。（需在 Visual Studio 2012 以上使用。）
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public sealed class CallerFilePathAttribute : Attribute
    {
    }
}

#endif