using Substrate.NetApi.Model.Extrinsics;
using System.Numerics;

namespace UniqueryPlus.Nfts
{
    public interface INftBaseNestable : INftBase, INftNestable;
    public interface INftNestable
    {
        Task<IEnumerable<NestedNftWrapper<INftBaseNestable>>> GetNestedNftsAsync(CancellationToken token);
        Task<INftBase?> GetParentNftAsync(CancellationToken token);
        bool HasParentNft { get; }
        Method Nest(BigInteger collectionId, BigInteger id);
        Method UnNest(string receiverAddress);
    }

    public record NestedNftWrapper<NftType> where NftType : INftBaseNestable
    { 
        public required NftType NftBase { get; init; }
        public required uint Depth { get; init; }
    }
}
