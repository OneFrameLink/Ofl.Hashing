using System;
using System.Collections.Generic;
using System.IO;

namespace Ofl.Hashing
{
    public interface IHashAlgorithm : IDisposable
    {
        int HashSize { get; }

        void TransformBlock(byte[] bytes, int offset, int count);

        IReadOnlyCollection<byte> GetRunningHash();
    }
}
