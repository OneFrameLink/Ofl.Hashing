using System;
using System.Linq;
using System.Numerics;

namespace Ofl.Hashing
{
    // TODO: Move this to Ofl.Numerics.
    public static class BigIntegerExtensions
    {
        public static BigInteger Unchecked(this BigInteger value, int bytes)
        {
            // Validate parameters.
            if (bytes <= 0) throw new ArgumentOutOfRangeException(nameof(bytes), bytes, $"The { nameof(bytes) } parameter must be a positive value.");
            // TODO: Needs to be a power of two?

            // SHORTCUT: If value is zero, then just return zero, zero fits in any situation.
            if (value == 0) return value;

            // Get the byte array for the integer.
            byte[] byteArray = value.ToByteArray();

            // If the length of the bytes is less than the bits / 8 then
            // return the big integer.
            if (byteArray.Length <= bytes) return value;

            // Take the last bytes.
            return new BigInteger(byteArray.Take(bytes).ToArray());
        }
    }
}
