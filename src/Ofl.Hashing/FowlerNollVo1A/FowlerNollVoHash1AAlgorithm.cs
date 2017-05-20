using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;

namespace Ofl.Hashing.FowlerNollVo1A
{
    public class FowlerNollVoHash1AAlgorithm : IHashAlgorithm
    {
        #region Constructor

        public FowlerNollVoHash1AAlgorithm(FowlerNollVoHash1AAlgorithmParameters parameters)
        {
            // Validate parameters.
            _parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));

            // Assign the values.
        }

        #endregion

        #region Instance state.

        private readonly FowlerNollVoHash1AAlgorithmParameters _parameters;

        private BigInteger? _current;

        #endregion

        #region IHashAlgorithm implementation.

        public int HashSize => _parameters.Bytes;

        public void TransformBlock(byte[] bytes, int offset, int count)
        {
            // Create the array segment.
            // NOTE: This validates parameters.
            var segment = new ArraySegment<byte>(bytes, offset, count);

            // The current hash.
            BigInteger currentHash = _current ?? _parameters.Offset;

            // Aggregate.
            _current = segment.Aggregate(currentHash, (current, b) => ((current ^ b).Unchecked(HashSize) * _parameters.Prime).Unchecked(HashSize));
        }

        public IReadOnlyCollection<byte> GetRunningHash() =>
            _current == null ? null : new ReadOnlyCollection<byte>(_current.Value.ToByteArray());

        #endregion

        #region IDisposable implementation.

        public void Dispose()
        {
            // Call the overload and
            // suppress finalization.
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Dispose of unmanaged resources here.

            // If not disposing, get out.
            if (!disposing) return;

            // Dispose of IDisposable implementations.
        }

        ~FowlerNollVoHash1AAlgorithm()
        {
            // Call the overload, not disposing.
            Dispose(false);
        }

        #endregion
    }
}
