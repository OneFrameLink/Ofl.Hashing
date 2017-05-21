using System.Numerics;

namespace Ofl.Hashing.FowlerNollVo1A
{
    public class FowlerNollVo1A512BitHashAlgorithm : FowlerNollVo1ABigIntegerHashAlgorithm
    {
        #region Constructor

        public FowlerNollVo1A512BitHashAlgorithm() : base(
            new FowlerNollVo1ABigIntegerHashAlgorithmParameters(512,
                BigInteger.Parse("9659303129496669498009435400716310466090418745672637896108374329434462657994582932197716438449813051892206539805784495328239340083876191928701583869517785"),
                BigInteger.Parse("35835915874844867368919076489095108449946327955754392558399825615420669938882575126094039892345713852759")))
        { }

        #endregion
    }
}
