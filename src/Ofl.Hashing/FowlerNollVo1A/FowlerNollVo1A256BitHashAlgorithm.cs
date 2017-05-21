using System.Numerics;

namespace Ofl.Hashing.FowlerNollVo1A
{
    public class FowlerNollVo1A256BitHashAlgorithm : FowlerNollVo1ABigIntegerHashAlgorithm
    {
        #region Constructor

        public FowlerNollVo1A256BitHashAlgorithm() : base(
            new FowlerNollVo1ABigIntegerHashAlgorithmParameters(256,
                BigInteger.Parse("100029257958052580907070968620625704837092796014241193945225284501741471925557"),
                BigInteger.Parse("374144419156711147060143317175368453031918731002211")))
        { }

        #endregion
    }
}
