using System.Globalization;
using System.Numerics;
using System.Text;

// ReSharper disable CheckNamespace
namespace System
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// Random 扩展类。
    /// </summary>
    public class RandomExtensions : Random
    {
        /// <summary>
        /// 使用与时间相关的默认种子值，初始化 System.RandomExtension 类的新实例。
        /// </summary>
        public RandomExtensions()
        {
        }

        /// <summary>
        /// 使用指定的种子值初始化 System.RandomExtension 类的新实例。
        /// </summary>
        /// <param name="seed">用来计算伪随机数序列起始值的数字。 如果指定的是负数，则使用其绝对值。</param>
        public RandomExtensions(int seed)
            : base(seed)
        {
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限的值）。maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的带符号大整数，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public BigInteger NextBigInteger(BigInteger maxValue)
        {
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException("maxValue", "maxValue 必须大于或等于零。");
            }
            return NextBigInteger(0, maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的带符号大整数，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        public BigInteger NextBigInteger(BigInteger minValue, BigInteger maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue", "“minValue”不能大于 maxValue。");
            }
            if (minValue == maxValue)
            {
                return minValue;
            }
            var range = maxValue - minValue;
            var samle = Sample();
            if (samle.Equals(0.0))
            {
                return minValue;
            }
            return minValue + range / new BigInteger(1.0 / samle);
        }

        /// <summary>
        /// 返回随机真假。
        /// </summary>
        /// <returns>真或假。</returns>
        public bool NextBoolean()
        {
            return Next(2) == 0;
        }

        /// <summary>
        /// 返回随机字节。
        /// </summary>
        /// <returns>小于 MaxValue 的无符号 8 位整数。</returns>
        public byte NextByte()
        {
            var buffer = new byte[1];
            NextBytes(buffer);
            return buffer[0];
        }

        /// <summary>
        /// 返回一个小于所指定最大值的字节。
        /// </summary>
        /// <param name="maxValue">要生成的随机字节的上限（随机字节不能取该上限值）。</param>
        /// <returns>小于 maxValue 的无符号 8 位整数，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        public byte NextByte(byte maxValue)
        {
            return (byte)Next(maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机字节。
        /// </summary>
        /// <param name="minValue">返回的随机字节的下界（随机字节可取该下界值）。</param>
        /// <param name="maxValue">返回的随机字节的上界（随机字节不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的无符号 8 位整数，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        public byte NextByte(byte minValue, byte maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue", "“minValue”不能大于 maxValue。");
            }
            if (minValue == maxValue)
            {
                return minValue;
            }
            return (byte)Next(minValue, maxValue);
        }

        /// <summary>
        /// 用随机数填充指定字节数组的元素。
        /// </summary>
        /// <param name="buffer">包含随机数的字节数组。</param>
        /// <exception cref="System.ArgumentNullException"><c>buffer</c> 为 null。</exception>
        public override void NextBytes(byte[] buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer", "值不能为 null。");
            }
            base.NextBytes(buffer);
        }

        /// <summary>
        /// 获取指定长度的用随机数填充的字节数组。
        /// </summary>
        /// <param name="length">字节数组的长度。</param>
        /// <returns>用随机数填充的字节数组。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>length</c> 小于 0。</exception>
        public byte[] NextBytes(int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length", "返回随机数组的长度不能小于零。");
            }
            var buffer = new byte[length];
            NextBytes(buffer);
            return buffer;
        }

        /// <summary>
        /// 用随机数填充指定字节数组的元素。
        /// </summary>
        /// <param name="buffer">包含随机数的字节数组。</param>
        public void NextBytesSafely(byte[] buffer)
        {
            if (buffer != null)
            {
                NextBytes(buffer);
            }
        }

        /// <summary>
        /// 返回一个随机汉字。
        /// </summary>
        /// <returns>一个随机汉字。</returns>
        public char NextChinese()
        {
            var gb2312 = Encoding.GetEncoding("gb2312");

            var r1 = Next(11, 14);
            var r2 = r1 == 13 ? Next(0, 7) : Next(0, 16);
            var r3 = Next(10, 16);
            var r4 = r3 == 10 ? Next(1, 16) : r3 == 15 ? Next(0, 15) : Next(0, 16);

            var sr1 = r1.ToString("X", CultureInfo.InvariantCulture);
            var sr2 = r2.ToString("X", CultureInfo.InvariantCulture);
            var sr3 = r3.ToString("X", CultureInfo.InvariantCulture);
            var sr4 = r4.ToString("X", CultureInfo.InvariantCulture);

            var b1 = Convert.ToByte(sr1 + sr2, 16);
            var b2 = Convert.ToByte(sr3 + sr4, 16);

            return gb2312.GetString(new[] { b1, b2 }, 0, 2)[0];
        }

        /// <summary>
        /// 返回指定个数的随机汉字。
        /// </summary>
        /// <param name="count">随机汉字的个数。</param>
        /// <returns>指定个数的随机汉字。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>length</c> 小于 0。</exception>
        public string NextChinese(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", "count 不能小于零。");
            }
            if (count == 0)
            {
                return string.Empty;
            }
            var sb = new StringBuilder(count);
            for (var i = 0; i < count; i++)
            {
                sb.Append(NextChinese());
            }
            return sb.ToString();
        }

        /// <summary>
        /// 返回随机时间。
        /// </summary>
        /// <returns>随机时间。</returns>
        public DateTime NextDateTime()
        {
            return NextDateTime(DateTime.MinValue, DateTime.MaxValue);
        }

        /// <summary>
        /// 返回指定时间范围内的随机一个时间。
        /// </summary>
        /// <param name="minValue">起始时间。</param>
        /// <param name="maxValue">结束时间。</param>
        /// <returns>起始时间与结束时间之间的随机一个时间。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        public DateTime NextDateTime(DateTime minValue, DateTime maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue", "“minValue”不能大于 maxValue。");
            }
            return minValue == maxValue ? minValue : new DateTime(NextInt64(minValue.Ticks, maxValue.Ticks));
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>返回一个非负随机的 Decimal。</returns>
        public decimal NextDecimal()
        {
            return NextDecimal(false);
        }

        /// <summary>
        /// 返回随机数。
        /// </summary>
        /// <param name="containNegative">是否包含负数。</param>
        /// <returns>返回一个随机的 Decimal。</returns>
        public decimal NextDecimal(bool containNegative)
        {
            var buffer = new byte[4];
            // 96 位整数的低 32 位。
            NextBytes(buffer);
            var lo = BitConverter.ToInt32(buffer, 0);
            // 96 位整数的中间 32 位。
            NextBytes(buffer);
            var mid = BitConverter.ToInt32(buffer, 0);
            // 96 位整数的高 32 位。
            NextBytes(buffer);
            var hi = BitConverter.ToInt32(buffer, 0);
            // 正或负。
            var isNegative = containNegative && Next(2) == 0;
            // 10 的指数（0 到 28 之间）。
            var scale = (byte)Next(29);
            return new decimal(lo, mid, hi, isNegative, scale);
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限制）。maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 Decimal，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public decimal NextDecimal(decimal maxValue)
        {
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException("maxValue", "maxValue 必须大于或等于零。");
            }
            return NextDecimal(0, maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 Decimal，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        public decimal NextDecimal(decimal minValue, decimal maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue", "“minValue”不能大于 maxValue。");
            }
            if (minValue == maxValue)
            {
                return minValue;
            }
            var mid = maxValue / 2 + minValue / 2;
            var leftOrRight = NextBoolean();
            if (leftOrRight)
            {
                var range = mid - minValue;
                return minValue + ((decimal)Sample()) * range;
            }
            else
            {
                var range = maxValue - mid;
                return mid + ((decimal)Sample()) * range;
            }
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 System.Double.MaxValue 的双精度浮点数。</returns>
        public override double NextDouble()
        {
            return Sample() * double.MaxValue;
        }

        /// <summary>
        /// 返回随机数。
        /// </summary>
        /// <param name="containNegative">是否包含负数。</param>
        /// <returns>返回一个随机的双精度浮点数。</returns>
        public double NextDouble(bool containNegative)
        {
            if (containNegative == false)
            {
                return NextDouble();
            }
            var negative = NextBoolean() ? 1.0 : -1.0;
            return NextDouble() * negative;
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的双精度浮点数，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public double NextDouble(double maxValue)
        {
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException("maxValue", "maxValue 必须大于或等于零。");
            }
            return Sample() * maxValue;
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的双精度浮点数，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        public double NextDouble(double minValue, double maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue", "“minValue”不能大于 maxValue。");
            }
            var mid = maxValue / 2 + minValue / 2;
            var leftOrRight = NextBoolean();
            if (leftOrRight)
            {
                var range = mid - minValue;
                return minValue + Sample() * range;
            }
            else
            {
                var range = maxValue - mid;
                return mid + Sample() * range;
            }
        }

        /// <summary>
        /// 返回枚举类型中随机一个枚举值。
        /// </summary>
        /// <typeparam name="T">可枚举类型。</typeparam>
        /// <returns>其中一个枚举值。</returns>
        /// <exception cref="System.InvalidOperationException"><c>T</c> 不是枚举类型。</exception>
        [CLSCompliant(false)]
        public T NextEnum<T>() where T : struct,  IComparable, IFormattable, IConvertible
        {
            var type = typeof(T);
            if (type.IsEnum == false)
            {
                throw new InvalidOperationException(type.Name + "不是可枚举类型。");
            }
            return (T)(object)NextEnum(type);
        }

        /// <summary>
        /// 返回枚举类型中随机一个枚举值。
        /// </summary>
        /// <param name="type">可枚举类型。</param>
        /// <returns>其中一个枚举值。</returns>
        /// <exception cref="System.ArgumentNullException"><c>type</c> 为 null。</exception>
        /// <exception cref="System.InvalidOperationException"><c>type</c> 不是枚举类型。</exception>
        public Enum NextEnum(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type", "随机的枚举类型不能为空。");
            }
            if (type.IsEnum == false)
            {
                throw new InvalidOperationException(type.Name + " 不是可枚举类型。");
            }
            var array = Enum.GetValues(type);
            var index = Next(array.GetLowerBound(0), array.GetUpperBound(0) + 1);
            return (Enum)array.GetValue(index);
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 System.Int16.MaxValue 的 16 位带符号整数。</returns>
        public short NextInt16()
        {
            return (short)Next(short.MaxValue);
        }

        /// <summary>
        /// 返回随机数。
        /// </summary>
        /// <param name="containNegative">是否包含负数。</param>
        /// <returns>返回一个随机的 16 位带符号整数。</returns>
        public short NextInt16(bool containNegative)
        {
            if (containNegative)
            {
                return (short)Next(short.MinValue, short.MaxValue);
            }
            return NextInt16();
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限的值）。maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 16 位带符号整数，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public short NextInt16(short maxValue)
        {
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException("maxValue", "maxValue 必须大于或等于零。");
            }
            return (short)Next(maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 16 位带符号整数，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        public short NextInt16(short minValue, short maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue", "“minValue”不能大于 maxValue。");
            }
            if (minValue == maxValue)
            {
                return minValue;
            }
            return (short)Next(minValue, maxValue);
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 System.Int32.MaxValue 的 32 位带符号整数。</returns>
        public int NextInt32()
        {
            return Next();
        }

        /// <summary>
        /// 返回随机数。
        /// </summary>
        /// <param name="containNegative">是否包含负数。</param>
        /// <returns>返回一个随机的 32 位带符号整数。</returns>
        public int NextInt32(bool containNegative)
        {
            return containNegative ? Next(int.MinValue, int.MaxValue) : Next();
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限的值）。maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 32 位带符号整数，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public int NextInt32(int maxValue)
        {
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException("maxValue", "maxValue 必须大于或等于零。");
            }
            return Next(maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 32 位带符号整数，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        public int NextInt32(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue", "“minValue”不能大于 maxValue。");
            }
            return Next(minValue, maxValue);
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 System.Int64.MaxValue 的 64 位带符号整数。</returns>
        public long NextInt64()
        {
            return (long)Sample() * long.MaxValue;
        }

        /// <summary>
        /// 返回随机数。
        /// </summary>
        /// <param name="containNegative">是否包含负数。</param>
        /// <returns>返回一个随机的 64 位带符号整数。</returns>
        public long NextInt64(bool containNegative)
        {
            if (containNegative == false)
            {
                return NextInt64();
            }
            var negative = NextBoolean() ? 1L : -1L;
            return NextInt64() * negative;
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。 maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 64 位带符号整数，即：返回值的范围通常包括零但不包括 maxValue。 不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public long NextInt64(long maxValue)
        {
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException("maxValue", "maxValue 必须大于或等于零。");
            }
            return (long)Sample() * maxValue;
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 64 位带符号整数，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        public long NextInt64(long minValue, long maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue", "“minValue”不能大于 maxValue。");
            }
            if (minValue == maxValue)
            {
                return minValue;
            }
            if ((minValue >= 0 && maxValue >= 0) || (minValue <= 0 && maxValue <= 0))
            {
                var range = maxValue - minValue;
                return minValue + (long)(Sample() * range);
            }
            else
            {
                var dMinValue = (double)minValue;
                var dMaxValue = (double)maxValue;
                var range = dMaxValue - dMinValue;
                return (long)(dMinValue + Sample() * range);
            }
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>返回一个非负随机的 SByte。</returns>
        [CLSCompliant(false)]
        public sbyte NextSByte()
        {
            return (sbyte)Next(sbyte.MaxValue);
        }

        /// <summary>
        /// 返回随机数。
        /// </summary>
        /// <param name="containNegative">是否包含负数。</param>
        /// <returns>返回一个随机的 SByte。</returns>
        [CLSCompliant(false)]
        public sbyte NextSByte(bool containNegative)
        {
            if (containNegative)
            {
                return (sbyte)Next(sbyte.MinValue, sbyte.MaxValue);
            }
            return NextSByte();
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 SByte，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        [CLSCompliant(false)]
        public sbyte NextSByte(sbyte maxValue)
        {
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException("maxValue", "maxValue 必须大于或等于零。");
            }
            return (sbyte)Next(maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 SByte，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        [CLSCompliant(false)]
        public sbyte NextSByte(sbyte minValue, sbyte maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue", "“minValue”不能大于 maxValue。");
            }
            return (sbyte)Next(minValue, maxValue);
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 System.Single.MaxValue 的单精度浮点数。</returns>
        public float NextSingle()
        {
            return (float)NextDouble(float.MaxValue);
        }

        /// <summary>
        /// 返回随机数。
        /// </summary>
        /// <param name="containNegative">是否包含负数。</param>
        /// <returns>返回一个随机的单精度浮点数。</returns>
        public float NextSingle(bool containNegative)
        {
            return containNegative ? NextSingle(float.MinValue, float.MaxValue) : NextSingle();
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的单精度浮点数，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public float NextSingle(float maxValue)
        {
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException("maxValue", "maxValue 必须大于或等于零。");
            }
            return (float)NextDouble(maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的单精度浮点数，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        public float NextSingle(float minValue, float maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue", "“minValue”不能大于 maxValue。");
            }
            return (float)NextDouble(minValue, maxValue);
        }

        /// <summary>
        /// 从字符串数组中随机返回一个字符串。
        /// </summary>
        /// <param name="strs">字符串数组。</param>
        /// <returns>字符串数组中随机一个字符串。</returns>
        /// <exception cref="System.ArgumentNullException"><c>strs</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>strs</c> 的元素个数为零。</exception>
        public string NextString(params string[] strs)
        {
            if (strs == null)
            {
                throw new ArgumentNullException("strs", "字符串数组为空。");
            }
            if (strs.Length == 0)
            {
                throw new ArgumentException("字符串数组元素个数为零。", "strs");
            }
            return strs[Next(strs.Length)];
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 MaxValue 的 16 位无符号整数。</returns>
        [CLSCompliant(false)]
        public ushort NextUInt16()
        {
            return NextUInt16(ushort.MaxValue);
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 16 位无符号整数，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        [CLSCompliant(false)]
        public ushort NextUInt16(ushort maxValue)
        {
            return NextUInt16(0, maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 16 位无符号整数，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        [CLSCompliant(false)]
        public ushort NextUInt16(ushort minValue, ushort maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue", "“minValue”不能大于 maxValue。");
            }
            return (ushort)NextDouble(minValue, maxValue);
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 MaxValue 的 32 位无符号整数。</returns>
        [CLSCompliant(false)]
        public uint NextUInt32()
        {
            return NextUInt32(uint.MaxValue);
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 32 位无符号整数，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        [CLSCompliant(false)]
        public uint NextUInt32(uint maxValue)
        {
            return NextUInt32(0, maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 32 位无符号整数，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        [CLSCompliant(false)]
        public uint NextUInt32(uint minValue, uint maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue", "“minValue”不能大于 maxValue。");
            }
            return (uint)NextDouble(minValue, maxValue);
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 MaxValue 的 64 位无符号长整数。</returns>
        [CLSCompliant(false)]
        public ulong NextUInt64()
        {
            return NextUInt64(ulong.MaxValue);
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 64 位无符号长整数，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        [CLSCompliant(false)]
        public ulong NextUInt64(ulong maxValue)
        {
            return NextUInt64(0, maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 64 位无符号长整数，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        [CLSCompliant(false)]
        public ulong NextUInt64(ulong minValue, ulong maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue", "“minValue”不能大于 maxValue。");
            }
            return (ulong)NextDouble(minValue, maxValue);
        }
    }
}