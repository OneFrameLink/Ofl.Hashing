using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ofl.Hashing
{
    public static class AsyncEnumerableExtensions
    {
        public static async Task<byte[]> ComputeHashAsync(this IAsyncEnumerable<byte> enumerable,
            IHashAlgorithm hashAlgorithm, CancellationToken cancellationToken)
        {
            // Validate parameters.
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            if (hashAlgorithm == null) throw new ArgumentNullException(nameof(hashAlgorithm));

            // Get the enumerator.
            using (IAsyncEnumerator<byte> enumerator = enumerable.GetEnumerator())
            {
                // The moved task.
                Task<bool> movedTask = enumerator.MoveNext(cancellationToken);

                // If it wasn't moved, get out.
                if (!(await movedTask.ConfigureAwait(false))) return hashAlgorithm.Hash;

                // A buffer.
                byte[] buffer = new byte[1];

                // While there's stuff to process.
                do
                {
                    // Get the current value.
                    buffer[0] = enumerator.Current;

                    // Move to the next immediately.
                    movedTask = enumerator.MoveNext(cancellationToken);

                    // Process in the meantime.
                    hashAlgorithm.TransformBlock(buffer, 0, buffer.Length);
                } while (!(await movedTask.ConfigureAwait(false)));

                // Return the hash.
                return hashAlgorithm.Hash;
            }
        }
    }
}
