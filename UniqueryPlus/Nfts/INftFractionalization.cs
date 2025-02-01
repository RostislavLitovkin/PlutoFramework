using System.Numerics;

namespace UniqueryPlus.Nfts
{
    public interface INftFractionalization
    {
        public Task<BigInteger> NftToAssetAsync(CancellationToken token);
    }
}
