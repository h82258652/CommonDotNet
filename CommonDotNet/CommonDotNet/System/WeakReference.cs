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
    /// ��ʾ���ͻ��������ã��������ö����ͬʱ��Ȼ�����������������ոö���
    /// </summary>
    /// <typeparam name="T">�����ö�������͡�</typeparam>
    [Serializable]
    public sealed class WeakReference<T> : ISerializable where T : class
    {
        [SuppressMessage("Microsoft.Performance", "CA1823")]
        internal IntPtr MHandle;

        /// <summary>
        /// ���� System.WeakReference&lt;T&gt; ��ġ�����ָ���������ʵ����
        /// </summary>
        /// <param name="target">Ҫ���õĶ��󣬻� null��</param>
        public WeakReference(T target)
            : this(target, false)
        {
        }

        /// <summary>
        /// ��ʼ�� System.WeakReference&lt;T&gt; �����ʵ��������ָ���Ķ���ʹ��ָ���ĸ�����١�
        /// </summary>
        /// <param name="target">Ҫ���õĶ��󣬻� null��</param>
        /// <param name="trackResurrection">������ս����ٶ�����Ϊ true����������ս�ǰ���ٶ�����Ϊ false��</param>
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
        /// ���� System.WeakReference&lt;T&gt; �������õ�Ŀ�����
        /// </summary>
        /// <param name="target">��Ŀ�����</param>
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        public void SetTarget(T target)
        {
            Target = target;
        }

        /// <summary>
        /// ���Լ���ͨ����ǰ System.WeakReference&lt;T&gt; �������õ�Ŀ�����
        /// </summary>
        /// <param name="target">���˷�������ʱ������Ŀ����󣨿���ʱ���� �ò���δ����ʼ����������</param>
        /// <returns>�����Ŀ���Ѽ�������Ϊ true������Ϊ false��</returns>
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