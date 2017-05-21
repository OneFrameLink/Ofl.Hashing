using System.Numerics;

namespace Ofl.Hashing.FowlerNollVo1A
{
    public class FowlerNollVo1A128BitHashAlgorithm : FowlerNollVo1ABigIntegerHashAlgorithm
    {
        #region Constructor

        public FowlerNollVo1A128BitHashAlgorithm() : base(
            new FowlerNollVo1ABigIntegerHashAlgorithmParameters(128,
                BigInteger.Parse("144066263297769815596495629667062367629"),
                BigInteger.Parse("309485009821345068724781371")))
        { }

        #endregion
    }
}
