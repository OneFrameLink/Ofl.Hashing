using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Ofl.Hashing
{
    public static class StreamExtensions
    {
        public static readonly int DefaultBufferSize = 4096;

        public static Task<byte[]> ComputeHashAsync(this Stream stream, IHashAlgorithm hashAlgorithm, CancellationToken cancellationToken) =>
            stream.ComputeHashAsync(hashAlgorithm, DefaultBufferSize, cancellationToken);

        public static async Task<byte[]> ComputeHashAsync(this Stream stream, IHashAlgorithm hashAlgorithm, int bufferSize,
            CancellationToken cancellationToken)
        {
            // Validate parameters.
            if (hashAlgorithm == null) throw new ArgumentNullException(nameof(hashAlgorithm));
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (bufferSize <= 0) throw new ArgumentOutOfRangeException(nameof(bufferSize), bufferSize, $"The { nameof(bufferSize) } parameter must be a positive value.");

            // The buffer and copy.
            byte[] buffer = new byte[bufferSize];
            byte[] copy = new byte[bufferSize];

            // The bytes read task.
            Task<int> bytesRead = stream.ReadAsync(buffer, 0, bufferSize, cancellationToken);

            // No bytes read, get out.
            if ((await bytesRead.ConfigureAwait(false)) == 0) return hashAlgorithm.Hash;

            // While there are items to process.
            do
            {
                // Copy the buffer.
                // NOTE: Need to do this because it's a shared resource.
                // If tests show there's a sweet spot between the copy time and hash time < next ReadAsync time,
                // move buffer size accordingly.
                Array.Copy(buffer, copy, bufferSize);

                // Read the next task.
                bytesRead = stream.ReadAsync(buffer, 0, bufferSize, cancellationToken);

                // Hash.
                hashAlgorithm.TransformBlock(copy, 0, bufferSize);

                // Get the next stream immediately.
            } while ((await bytesRead.ConfigureAwait(false)) > 0);

            // Return.
            return hashAlgorithm.Hash;
        }

        public static byte[] ComputeHash(this Stream stream, IHashAlgorithm hashAlgorithm) =>
            stream.ComputeHash(hashAlgorithm, DefaultBufferSize);

        public static byte[] ComputeHash(this Stream stream, IHashAlgorithm hashAlgorithm, int bufferSize)
        {
            // Validate parameters.
            if (hashAlgorithm == null) throw new ArgumentNullException(nameof(hashAlgorithm));
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (bufferSize <= 0) throw new ArgumentOutOfRangeException(nameof(bufferSize), bufferSize, $"The { nameof(bufferSize) } parameter must be a positive value.");

            // The buffer.
            byte[] buffer = new byte[bufferSize];

            // The bytes read.
            int bytesRead;

            // Cycle through the stream.
            while ((bytesRead = stream.Read(buffer, 0, bufferSize)) != 0)
                // Run through the hash.
                hashAlgorithm.TransformBlock(buffer, 0, bytesRead);

            // Return.
            return hashAlgorithm.Hash;
        }
    }
}
