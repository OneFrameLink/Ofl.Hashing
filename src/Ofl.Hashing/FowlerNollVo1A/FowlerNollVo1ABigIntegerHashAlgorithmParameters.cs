using System;
using System.Numerics;

namespace Ofl.Hashing.FowlerNollVo1A
{
    public class FowlerNollVo1ABigIntegerHashAlgorithmParameters
    {
        #region Constructor

        public FowlerNollVo1ABigIntegerHashAlgorithmParameters(int bits, BigInteger offset, BigInteger prime)
        {
            // Validate parameters.
            if (bits <= 0) throw new ArgumentOutOfRangeException(nameof(bits), bits, $"The { nameof(bits) } parameter must be a positive value.");

            // Assign values.
            Bits = bits;
            Offset = offset;
            Prime = prime;
        }

        #endregion

        #region Instance, read-only state.

        public int Bits { get; }

        public BigInteger Offset { get; }

        public BigInteger Prime { get; }

        #endregion
    }
}
