using System;

namespace Ofl.Hashing.FowlerNollVo1A
{
    public class FowlerNollVo1A32BitHashAlgorithm : IHashAlgorithm
    {
        #region State.

        private const uint Prime = 16777619;

        private const uint Offset = 2166136261;

        private uint? _current;

        #endregion

        #region IHashAlgorithm implementation.

        public int HashSize => 64;

        public void TransformBlock(byte[] bytes, int offset, int count)
        {
            // Create the array segment.
            // NOTE: This validates parameters.
            var segment = new ArraySegment<byte>(bytes, offset, count);

            // The current hash.
            uint current = _current ?? Offset;

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
