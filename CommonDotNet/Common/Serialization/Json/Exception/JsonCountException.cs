using System;
using System.Collections;
using System.Runtime.Serialization;

namespace Common.Serialization.Json.Exception
{
    /// <summary>
    /// 表示 JSON 序列化时字符串或数组或集合的元素个数有误。
    /// </summary>
    [Serializable]
    public sealed class JsonCountException : System.Exception, ISerializable
    {
        private int _greaterThan = -1;

        private int _lessThan = -1;

        public JsonCountException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        public JsonCountException(string message)
            : base(message)
        {
        }

        public JsonCountException()
        {
        }

        private JsonCountException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// 引发当前异常的字符串或数组或集合的元素个数。
        /// </summary>
        public int CurrentCount
        {
            get;
            private set;
        }

        /// <summary>
        /// 字符串或数组或集合的元素个数应该大于此值。
        /// </summary>
        public int GreaterThan
        {
            get
            {
                return _greaterThan;
            }
            private set
            {
                _greaterThan = value;
            }
        }

        /// <summary>
        /// 字符串或数组或集合的元素个数应该小于此值。
        /// </summary>
        public int LessThan
        {
            get
            {
                return _lessThan;
            }
            private set
            {
                _lessThan = value;
            }
        }

        /// <summary>
        /// 引发当前异常的字符串或数组或集合。
        /// </summary>
        public object SourceObject
        {
            get;
            private set;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            GetObjectData(info, context);
        }

        /// <summary>
        /// 返回表示当前异常的字符串。
        /// </summary>
        /// <returns>描述该异常的字符串。</returns>
        public override string ToString()
        {
            if (LessThan > -1)
            {
                return "当前字符串或数组或集合的个数为：" + CurrentCount + "，但应小于 " + LessThan + "。";
            }
            if (GreaterThan > -1)
            {
                return "当前字符串或数组或集合的个数为：" + CurrentCount + "，但应大于 " + GreaterThan + "。";
            }
            return base.ToString();
        }

        internal static JsonCountException CreateGreaterThanException(IEnumerable source, int greaterThan
            )
        {

            return new JsonCountException
            {
                SourceObject = source,
                CurrentCount = GetCount(source),
                GreaterThan = greaterThan
            };
        }

        internal static JsonCountException CreateLessThanException(IEnumerable source, int lessThan)
        {
            return new JsonCountException
            {
                SourceObject = source,
                CurrentCount = GetCount(source),
                LessThan = lessThan
            };
        }

        private static int GetCount(IEnumerable source)
        {
            var enumerator = source.GetEnumerator();
            var count = 0;
            while (enumerator.MoveNext())
            {
                count++;
            }
            return count;
        }
    }
}