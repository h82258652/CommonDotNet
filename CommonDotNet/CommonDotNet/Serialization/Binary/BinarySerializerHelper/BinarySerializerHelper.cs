using System.Runtime.Serialization.Formatters.Binary;

namespace Common.Serialization.Binary
{
    /// <summary>
    /// BinarySerializer 帮助类。
    /// </summary>
    public static partial class BinarySerializeHelper
    {
        private static readonly BinaryFormatter Bf = new BinaryFormatter();
    }
}
