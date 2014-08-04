using System.Numerics;

// ReSharper disable CheckNamespace
namespace System
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// Random 帮助类。
    /// </summary>
    public static class RandomHelper
    {
        private static readonly RandomExtensions Rand = new RandomExtensions();

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限的值）。maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的带符号大整数，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public static BigInteger NextBigInteger(BigInteger maxValue)
        {
            return Rand.NextBigInteger(maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的带符号大整数，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        public static BigInteger NextBigInteger(BigInteger minValue, BigInteger maxValue)
        {
            return Rand.NextBigInteger(minValue, maxValue);
        }

        /// <summary>
        /// 返回随机真假。
        /// </summary>
        /// <returns>真或假。</returns>
        public static bool NextBoolean()
        {
            return Rand.NextBoolean();
        } 
        
        /// <summary>
        /// 返回随机字节。
        /// </summary>
        /// <returns>小于 MaxValue 的无符号 8 位整数。</returns>
        public static byte NextByte()
        {
            return Rand.NextByte();
        }

        /// <summary>
        /// 返回一个小于所指定最大值的字节。
        /// </summary>
        /// <param name="maxValue">要生成的随机字节的上限（随机字节不能取该上限值）。</param>
        /// <returns>小于 maxValue 的无符号 8 位整数，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        public static byte NextByte(byte maxValue)
        {
            return Rand.NextByte(maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机字节。
        /// </summary>
        /// <param name="minValue">返回的随机字节的下界（随机字节可取该下界值）。</param>
        /// <param name="maxValue">返回的随机字节的上界（随机字节不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的无符号 8 位整数，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        public static byte NextByte(byte minValue, byte maxValue)
        {
            return Rand.NextByte(minValue, maxValue);
        }

        /// <summary>
        /// 用随机数填充指定字节数组的元素。
        /// </summary>
        /// <param name="buffer">包含随机数的字节数组。</param>
        /// <exception cref="System.ArgumentNullException"><c>buffer</c> 为 null。</exception>
        public static void NextBytes(byte[] buffer)
        {
            Rand.NextBytes(buffer);
        }

        /// <summary>
        /// 获取指定长度的用随机数填充的字节数组。
        /// </summary>
        /// <param name="length">字节数组的长度。</param>
        /// <returns>用随机数填充的字节数组。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>length</c> 小于 0。</exception>
        public static byte[] NextBytes(int length)
        {
            return Rand.NextBytes(length);
        }

        /// <summary>
        /// 返回一个随机汉字。
        /// </summary>
        /// <returns>一个随机汉字。</returns>
        public static char NextChinese()
        {
            return Rand.NextChinese();
        }

        /// <summary>
        /// 返回指定个数的随机汉字。
        /// </summary>
        /// <param name="count">随机汉字的个数。</param>
        /// <returns>指定个数的随机汉字。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>length</c> 小于 0。</exception>
        public static string NextChinese(int count)
        {
            return Rand.NextChinese(count);
        }

        /// <summary>
        /// 返回随机时间。
        /// </summary>
        /// <returns>随机时间。</returns>
        public static DateTime NextDateTime()
        {
            return Rand.NextDateTime();
        }

        /// <summary>
        /// 返回指定时间范围内的随机一个时间。
        /// </summary>
        /// <param name="minValue">起始时间。</param>
        /// <param name="maxValue">结束时间。</param>
        /// <returns>起始时间与结束时间之间的随机一个时间。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        public static DateTime NextDateTime(DateTime minValue, DateTime maxValue)
        {
            return Rand.NextDateTime(minValue, maxValue);
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>返回一个非负随机的 Decimal。</returns>
        public static decimal NextDecimal()
        {
            return Rand.NextDecimal();
        }

        /// <summary>
        /// 返回随机数。
        /// </summary>
        /// <param name="containNegative">是否包含负数。</param>
        /// <returns>返回一个随机的 Decimal。</returns>
        public static decimal NextDecimal(bool containNegative)
        {
            return Rand.NextDecimal(containNegative);
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限制）。maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 Decimal，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public static decimal NextDecimal(decimal maxValue)
        {
            return Rand.NextDecimal(maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 Decimal，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        public static decimal NextDecimal(decimal minValue, decimal maxValue)
        {
            return Rand.NextDecimal(minValue, maxValue);
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 System.Double.MaxValue 的双精度浮点数。</returns>
        public static double NextDouble()
        {
            return Rand.NextDouble();
        }

        /// <summary>
        /// 返回随机数。
        /// </summary>
        /// <param name="containNegative">是否包含负数。</param>
        /// <returns>返回一个随机的双精度浮点数。</returns>
        public static double NextDouble(bool containNegative)
        {
            return Rand.NextDouble(containNegative);
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的双精度浮点数，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public static double NextDouble(double maxValue)
        {
            return Rand.NextDouble(maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的双精度浮点数，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        public static double NextDouble(double minValue, double maxValue)
        {
            return Rand.NextDouble(minValue, maxValue);
        }

        /// <summary>
        /// 返回枚举类型中随机一个枚举值。
        /// </summary>
        /// <typeparam name="T">可枚举类型。</typeparam>
        /// <returns>其中一个枚举值。</returns>
        /// <exception cref="System.InvalidOperationException"><c>T</c> 不是枚举类型。</exception>
        [CLSCompliant(false)]
        public static T NextEnum<T>() where T : struct,  IComparable, IFormattable, IConvertible
        {
            return Rand.NextEnum<T>();
        }

        /// <summary>
        /// 返回枚举类型中随机一个枚举值。
        /// </summary>
        /// <param name="type">可枚举类型。</param>
        /// <returns>其中一个枚举值。</returns>
        /// <exception cref="System.ArgumentNullException"><c>type</c> 为 null。</exception>
        /// <exception cref="System.InvalidOperationException"><c>type</c> 不是枚举类型。</exception>
        public static Enum NextEnum(Type type)
        {
            return Rand.NextEnum(type);
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 System.Int16.MaxValue 的 16 位带符号整数。</returns>
        public static short NextInt16()
        {
            return Rand.NextInt16();
        }

        /// <summary>
        /// 返回随机数。
        /// </summary>
        /// <param name="containNegative">是否包含负数。</param>
        /// <returns>返回一个随机的 16 位带符号整数。</returns>
        public static short NextInt16(bool containNegative)
        {
            return Rand.NextInt16(containNegative);
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限的值）。maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 16 位带符号整数，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public static short NextInt16(short maxValue)
        {
            return Rand.NextInt16(maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 16 位带符号整数，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        public static short NextInt16(short minValue, short maxValue)
        {
            return Rand.NextInt16(minValue, maxValue);
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 System.Int32.MaxValue 的 32 位带符号整数。</returns>
        public static int NextInt32()
        {
            return Rand.NextInt32();
        }

        /// <summary>
        /// 返回随机数。
        /// </summary>
        /// <param name="containNegative">是否包含负数。</param>
        /// <returns>返回一个随机的 32 位带符号整数。</returns>
        public static int NextInt32(bool containNegative)
        {
            return Rand.NextInt32(containNegative);
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限的值）。maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 32 位带符号整数，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public static int NextInt32(int maxValue)
        {
            return Rand.NextInt32(maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 32 位带符号整数，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        public static int NextInt32(int minValue, int maxValue)
        {
            return Rand.NextInt32(minValue, maxValue);
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 System.Int64.MaxValue 的 64 位带符号整数。</returns>
        public static long NextInt64()
        {
            return Rand.NextInt64();
        }

        /// <summary>
        /// 返回随机数。
        /// </summary>
        /// <param name="containNegative">是否包含负数。</param>
        /// <returns>返回一个随机的 64 位带符号整数。</returns>
        public static long NextInt64(bool containNegative)
        {
            return Rand.NextInt64(containNegative);
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。 maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 64 位带符号整数，即：返回值的范围通常包括零但不包括 maxValue。 不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public static long NextInt64(long maxValue)
        {
            return Rand.NextInt64(maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 64 位带符号整数，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        public static long NextInt64(long minValue, long maxValue)
        {
            return Rand.NextInt64(minValue, maxValue);
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>返回一个非负随机的 SByte。</returns>
        [CLSCompliant(false)]
        public static sbyte NextSByte()
        {
            return Rand.NextSByte();
        }

        /// <summary>
        /// 返回随机数。
        /// </summary>
        /// <param name="containNegative">是否包含负数。</param>
        /// <returns>返回一个随机的 SByte。</returns>
        [CLSCompliant(false)]
        public static sbyte NextSByte(bool containNegative)
        {
            return Rand.NextSByte(containNegative);
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 SByte，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        [CLSCompliant(false)]
        public static sbyte NextSByte(sbyte maxValue)
        {
            return Rand.NextSByte(maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 SByte，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        [CLSCompliant(false)]
        public static sbyte NextSByte(sbyte minValue, sbyte maxValue)
        {
            return Rand.NextSByte(minValue, maxValue);
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 System.Single.MaxValue 的单精度浮点数。</returns>
        public static float NextSingle()
        {
            return Rand.NextSingle();
        }

        /// <summary>
        /// 返回随机数。
        /// </summary>
        /// <param name="containNegative">是否包含负数。</param>
        /// <returns>返回一个随机的单精度浮点数。</returns>
        public static float NextSingle(bool containNegative)
        {
            return Rand.NextSingle(containNegative);
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的单精度浮点数，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public static float NextSingle(float maxValue)
        {
            return Rand.NextSingle(maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的单精度浮点数，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        public static float NextSingle(float minValue, float maxValue)
        {
            return Rand.NextSingle(minValue, maxValue);
        }

        /// <summary>
        /// 从字符串数组中随机返回一个字符串。
        /// </summary>
        /// <param name="strs">字符串数组。</param>
        /// <returns>字符串数组中随机一个字符串。</returns>
        /// <exception cref="System.ArgumentNullException"><c>strs</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>strs</c> 的元素个数为零。</exception>
        public static string NextString(params string[] strs)
        {
            return Rand.NextString(strs);
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 MaxValue 的 16 位无符号整数。</returns>
        [CLSCompliant(false)]
        public static ushort NextUInt16()
        {
            return Rand.NextUInt16();
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 16 位无符号整数，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        [CLSCompliant(false)]
        public static ushort NextUInt16(ushort maxValue)
        {
            return Rand.NextUInt16(maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 16 位无符号整数，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        [CLSCompliant(false)]
        public static ushort NextUInt16(ushort minValue, ushort maxValue)
        {
            return Rand.NextUInt16(minValue, maxValue);
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 MaxValue 的 32 位无符号整数。</returns>
        [CLSCompliant(false)]
        public static uint NextUInt32()
        {
            return Rand.NextUInt32();
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 32 位无符号整数，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        [CLSCompliant(false)]
        public static uint NextUInt32(uint maxValue)
        {
            return Rand.NextUInt32(maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 32 位无符号整数，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        [CLSCompliant(false)]
        public static uint NextUInt32(uint minValue, uint maxValue)
        {
            return Rand.NextUInt32(minValue, maxValue);
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 MaxValue 的 64 位无符号长整数。</returns>
        [CLSCompliant(false)]
        public static ulong NextUInt64()
        {
            return Rand.NextUInt64();
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 64 位无符号长整数，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        [CLSCompliant(false)]
        public static ulong NextUInt64(ulong maxValue)
        {
            return Rand.NextUInt64(maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 64 位无符号长整数，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        [CLSCompliant(false)]
        public static ulong NextUInt64(ulong minValue, ulong maxValue)
        {
            return Rand.NextUInt64(minValue, maxValue);
        }
    }
}