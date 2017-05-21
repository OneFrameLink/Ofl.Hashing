using System;
using System.Collections.Generic;

namespace Ofl.Hashing
{
    public static class HashAlgorithmExtensions
    {
        public static int GetHashCode(this IHashAlgorithm hashAlgorithm, params int[] hashCodes) =>
            hashAlgorithm.GetHashCode((IEnumerable<int>) hashCodes);

        public static int GetHashCode(this IHashAlgorithm hashAlgorithm, IEnumerable<int> hashCodes)
        {
            // Validate parameters.
            if (hashAlgorithm == null) throw new ArgumentNullException(nameof(hashAlgorithm));
            if (hashCodes == null) throw new ArgumentNullException(nameof(hashCodes));

            // Cycle through the hashcodes, transforming each block that's returned.
            foreach (int hashCode in hashCodes)
            {
                // Get the bytes.
                // TODO: Use unsafe somehow to remove allocations here.
                byte[] bytes = BitConverter.GetBytes(hashCode);

                // Transform the block.
                hashAlgorithm.TransformBlock(bytes, 0, 4);
            }

            // Return the hash.
            return BitConverter.ToInt32(hashAlgorithm.Hash, 0);
        }

        public static byte[] ComputeHash(this IHashAlgorithm hashAlgorithm, byte[] bytes) =>
            hashAlgorithm.ComputeHash(new ArraySegment<byte>(bytes));

        public static byte[] ComputeHash(this IHashAlgorithm hashAlgorithm, ArraySegment<byte> bytes) =>
            hashAlgorithm.ComputeHash(bytes.Array, bytes.Offset, bytes.Count);

        public static byte[] ComputeHash(this IHashAlgorithm hashAlgorithm, byte[] bytes, int offset, int count)
        {
            // Validate parameters.
            if (hashAlgorithm == null) throw new ArgumentNullException(nameof(hashAlgorithm));
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));

            // Transform the block.
            hashAlgorithm.TransformBlock(bytes, offset, count);

            // Return the hash.
            return hashAlgorithm.Hash;
        }
    }
}
