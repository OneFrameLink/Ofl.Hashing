using System;
using System.Numerics;
using Xunit;

namespace Ofl.Hashing.Tests
{
    public class BigIntegerExtensons
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(10)]
        [InlineData(100)]
        public void Test_Unchecked_Positive(int iterations)
        {
            // Seed the big int and the int.
            int intValue = Int32.MaxValue;
            BigInteger bigint = intValue;

            // Allow overflow.
            unchecked
            {
                // Loop.
                for (int index = 0; index < iterations; ++index)
                {
                    // Add two and int 32 min.
                    intValue += 2;
                    bigint = (bigint + new BigInteger(2)).Unchecked(4);

                    // Possible overflow.
                    Assert.Equal(intValue, bigint);

                    // Definite overflow.
                    intValue += Int32.MaxValue;
                    bigint = (bigint + new BigInteger(Int32.MaxValue)).Unchecked(4);

                    // Assert.
                    Assert.Equal(intValue, bigint);
                }
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(10)]
        [InlineData(100)]
        public void Test_Unchecked_Negative(int iterations)
        {
            // Seed the big int and the int.
            int intValue = Int32.MinValue;
            BigInteger bigint = intValue;

            // Allow overflow.
            unchecked
            {
                // Loop.
                for (int index = 0; index < iterations; ++index)
                {
                    // Add two and int 32 min.
                    intValue -= 2;
                    bigint = (bigint - new BigInteger(2)).Unchecked(4);

                    // Possible overflow.
                    Assert.Equal(intValue, bigint);

                    // Definite overflow.
                    intValue -= Int32.MaxValue;
                    bigint = (bigint - new BigInteger(Int32.MaxValue)).Unchecked(4);

                    // Assert.
                    Assert.Equal(intValue, bigint);
                }
            }
        }
    }
}
