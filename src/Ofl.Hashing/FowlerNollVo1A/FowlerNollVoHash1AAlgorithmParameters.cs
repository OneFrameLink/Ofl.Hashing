using System;
using System.Numerics;

namespace Ofl.Hashing.FowlerNollVo1A
{
    public class FowlerNollVoHash1AAlgorithmParameters
    {
        public FowlerNollVoHash1AAlgorithmParameters(int bytes, BigInteger offset, BigInteger prime)
        {
            // Validate parameters.
            if (bytes <= 0) throw new ArgumentOutOfRangeException(nameof(bytes), bytes, $"The { nameof(bytes) } parameter must be a positive value.");
            
            // Assign values.
            Bytes = bytes;
            Offset = offset;
            Prime = prime;
        }

        public int Bytes { get; }

        public BigInteger Offset { get; }

        public BigInteger Prime { get; }
    }
}
