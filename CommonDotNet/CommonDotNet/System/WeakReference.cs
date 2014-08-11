#if Net40

using System.Diagnostics.CodeAnalysis;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using System.Security;

// ReSharper disable CheckNamespace
namespace System
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// 表示类型化的弱引用，即在引用对象的同时仍然允许垃圾回收来回收该对象。
    /// </summary>
    /// <typeparam name="T">所引用对象的类型。</typeparam>
    [Serializable]
    public sealed class WeakReference<T> : ISerializable where T : class
    {
        [SuppressMessage("Microsoft.Performance", "CA1823")]
        internal IntPtr MHandle;

        /// <summary>
        /// 创建 System.WeakReference&lt;T&gt; 类的、引用指定对象的新实例。
        /// </summary>
        /// <param name="target">要引用的对象，或 null。</param>
        public WeakReference(T target)
            : this(target, false)
        {
        }

        /// <summary>
        /// 初始化 System.WeakReference&lt;T&gt; 类的新实例，引用指定的对象并使用指定的复活跟踪。
        /// </summary>
        /// <param name="target">要引用的对象，或 null。</param>
        /// <param name="trackResurrection">如果在终结后跟踪对象；则为 true；如果仅在终结前跟踪对象，则为 false。</param>
        public WeakReference(T target, bool trackResurrection)
        {
            Create(target, trackResurrection);
        }

        internal WeakReference(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            var target = (T)info.GetValue("TrackedObject", typeof(T));
            var trackResurrection = info.GetBoolean("TrackResurrection");

            Create(target, trackResurrection);
        }

        [ResourceExposure(ResourceScope.None)]
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        [SecuritySafeCritical]
        extern ~WeakReference();

        private extern T Target
        {
            [ResourceExposure(ResourceScope.None)]
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            [SecuritySafeCritical]
            get;
            [ResourceExposure(ResourceScope.None)]
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            [SecuritySafeCritical]
            set;
        }

        [SecurityCritical]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("TrackedObject", Target, typeof(T));
            info.AddValue("TrackResurrection", IsTrackResurrection());
        }

        /// <summary>
        /// 设置 System.WeakReference&lt;T&gt; 对象引用的目标对象。
        /// </summary>
        /// <param name="target">新目标对象。</param>
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        public void SetTarget(T target)
        {
            Target = target;
        }

        /// <summary>
        /// 尝试检索通过当前 System.WeakReference&lt;T&gt; 对象引用的目标对象。
        /// </summary>
        /// <param name="target">当此方法返回时，包含目标对象（可用时）。 该参数未经初始化即被处理。</param>
        /// <returns>如果该目标已检索，则为 true；否则为 false。</returns>
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        public bool TryGetTarget(out T target)
        {
            var o = Target;
            target = o;
            return o != null;
        }

        [ResourceExposure(ResourceScope.None)]
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        [SecuritySafeCritical]
        private extern void Create(T target, bool trackResurrection);

        [ResourceExposure(ResourceScope.None)]
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        [SecuritySafeCritical]
        private extern bool IsTrackResurrection();
    }
}

#endif