using System;

namespace Ofl.Hashing.FowlerNollVo1A
{
    public class FowlerNollVo1A64BitHashAlgorithm : IHashAlgorithm
    {
        #region State.

        private const ulong Prime = 1099511628211;

        private const ulong Offset = 14695981039346656037;

        private ulong? _current;

        #endregion

        #region IHashAlgorithm implementation.

        public int HashSize => 64;

        public void TransformBlock(byte[] bytes, int offset, int count)
        {
            // Create the array segment.
            // NOTE: This validates parameters.
            var segment = new ArraySegment<byte>(bytes, offset, count);

            // The current hash.
            ulong current = _current ?? Offset;

            // The bytes.
            int size = HashSize / 8;

            // Unchecked.
            unchecked
            {
                // Loop.
                for (int i = offset; i < offset + count; ++i)
                    // XOR then multiply.
                    current = (current ^ bytes[i]) * Prime;
            }

            // Set the value.
            _current = current;
        }

        public byte[] Hash => _current == null ? null : BitConverter.GetBytes(_current.Value);

        #endregion
    }
}
