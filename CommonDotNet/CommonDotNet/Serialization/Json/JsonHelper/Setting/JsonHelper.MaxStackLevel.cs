using System;

namespace Common.Serialization.Json
{
    public static partial class JsonHelper
    {
        private static int _maxStackLevel = 20;

        public static int MaxStackLevel
        {
            get
            {
                return _maxStackLevel;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", value, "序列化与反序列化最大深度必须大于 0。");
                }
                _maxStackLevel = value;
            }
        }
    }
}
