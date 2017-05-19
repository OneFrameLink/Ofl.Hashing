using System;
using System.Collections.Generic;
using System.IO;

namespace Ofl.Hashing
{
    public static class HashAlgorithmExtensions
    {
        public static IReadOnlyCollection<byte> ComputeHash(this IHashAlgorithm hashAlgorithm, byte[] bytes) =>
            hashAlgorithm.ComputeHash(new ArraySegment<byte>(bytes));

        public static IReadOnlyCollection<byte> ComputeHash(this IHashAlgorithm hashAlgorithm, ArraySegment<byte> bytes) =>
            hashAlgorithm.ComputeHash(bytes.Array, bytes.Offset, bytes.Count);

        public static IReadOnlyCollection<byte> ComputeHash(this IHashAlgorithm hashAlgorithm, byte[] bytes, int index, int count)
        {
            // Validate parameters.
            if (hashAlgorithm == null) throw new ArgumentNullException(nameof(hashAlgorithm));
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));

            throw new NotImplementedException();

            // Create the memory stream.
            using (var stream = new MemoryStream(bytes, index, count))
                // Call the hash algorithm.
                //return hashAlgorithm.ComputeHash(stream);
                ;
        }
    }
}
