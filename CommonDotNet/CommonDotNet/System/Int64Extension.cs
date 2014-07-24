// ReSharper disable CheckNamespace
namespace System
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// Int64 扩展类。
    /// </summary>
    public static class Int64Extension
    {
        /// <summary>
        /// 指示当前 64 位有符号整数是否为质数。
        /// </summary>
        /// <param name="num">64 位有符号整数。</param>
        /// <returns>是否为质数。</returns>
        public static bool IsPrime(this long num)
        {
            if (num <= 1)
            {
                return false;
            }
            if ((num & 1) == 0)
            {
                // 等价于 num % 2==0。
                return false;
            }
            for (long temp = 3; temp < Math.Sqrt(num); temp += 2)
            {
                if (num % temp == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}