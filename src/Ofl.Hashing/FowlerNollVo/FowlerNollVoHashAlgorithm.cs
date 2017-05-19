//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Numerics;
//using System.Text;

//namespace Ofl.Hashing.FowlerNollVo
//{
//    public class FowlerNollVoHashAlgorithm : IHashAlgorithm
//    {
//        #region Constructor

//        public FowlerNollVoHashAlgorithm(int hashSize)
//        {
//            // Validate parameters.

//        }

//        #endregion

//        #region Instance state.

//        private readonly BigInteger _prime;

//        private readonly BigInteger _offset;

//        private BigInteger? _current;

//        #endregion

//        #region IHashAlgorithm implementation.

//        public IReadOnlyCollection<byte> ComputeHash(Stream stream)
//        {
//            // Validate parameters.
//            if (stream == null) throw new ArgumentNullException(nameof(stream));

//            // The bytes for the hash.
//        }

//        public int HashSize
//        {
//            get { throw new NotImplementedException(); }
//        }

//        public void TransformBlock(byte[] bytes, int offset, int count)
//        {
//            // Create the array segment.
//            // NOTE: This validates parameters.
//            var segment = new ArraySegment<byte>(bytes, offset, count);

//            // The current hash.
//            BigInteger currentHash = _current ?? _offset;

//            // Aggregate.
//            currentHash = segment.Aggregate(currentHash, (current, b) => (current ^ b) * _prime);
//        }

//        public IReadOnlyCollection<byte> GetRunningHash()
//        {
//            throw new NotImplementedException();
//        }

//        #endregion

//        #region IDisposable implementation.

//        public void Dispose()
//        {
//            // Call the overload and
//            // suppress finalization.
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }

//        protected virtual void Dispose(bool disposing)
//        {
//            // Dispose of unmanaged resources here.

//            // If not disposing, get out.
//            if (!disposing) return;

//            // Dispose of IDisposable implementations.
//        }

//        ~FowlerNollVoHashAlgorithm()
//        {
//            // Call the overload, not disposing.
//            Dispose(false);
//        }

//        #endregion
//    }
//}
