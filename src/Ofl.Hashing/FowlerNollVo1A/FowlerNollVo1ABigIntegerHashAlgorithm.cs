using System;
using System.Linq;
using System.Numerics;

namespace Ofl.Hashing.FowlerNollVo1A
{
    public abstract class FowlerNollVo1ABigIntegerHashAlgorithm : IHashAlgorithm
    {
        #region Constructor

        protected FowlerNollVo1ABigIntegerHashAlgorithm(FowlerNollVo1ABigIntegerHashAlgorithmParameters parameters)
        {
            // Validate parameters.
            _parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }

        #endregion

        #region Instance state.

        private readonly FowlerNollVo1ABigIntegerHashAlgorithmParameters _parameters;

        private BigInteger? _current;

        #endregion

        #region IHashAlgorithm implementation.

        public int HashSize => _parameters.Bits;

        public void TransformBlock(byte[] bytes, int offset, int count)
        {
            // Create the array segment.
            // NOTE: This validates parameters.
            var segment = new ArraySegment<byte>(bytes, offset, count);

            // The current hash.
            BigInteger currentHash = _current ?? _parameters.Offset;

            // The bytes.
            int size = HashSize / 8;

            // Aggregate.
            _current = segment.Aggregate(currentHash, (current, b) => ((current ^ b).Unchecked(size) * _parameters.Prime).Unchecked(size));
        }

        public byte[] Hash => _current?.ToByteArray();

        #endregion
    }
}
