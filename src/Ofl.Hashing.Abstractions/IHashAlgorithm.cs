namespace Ofl.Hashing
{
    public interface IHashAlgorithm
    {
        int HashSize { get; }

        void TransformBlock(byte[] bytes, int offset, int count);

        byte[] Hash { get; }
    }
}
