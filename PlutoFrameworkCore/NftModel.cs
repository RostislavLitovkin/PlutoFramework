
using PlutoFramework.Constants;
using PlutoFramework.Model;
using PlutoFramework.Types;
using System.Numerics;
using UniqueryPlus;
using UniqueryPlus.Nfts;

namespace PlutoFrameworkCore
{
    public static class NftModel
    {
        public static NftWrapper ToNftWrapper(INftBase nft)
        {
            if (nft.Metadata is not null && nft.Metadata.Image is null)
            {
                nft.Metadata.Image = "noimage.png";
            }
            return new NftWrapper
            {
                NftBase = nft,
                Endpoint = Endpoints.GetEndpointDictionary[GetEndpointKey(nft.Type)]
            };
        }

        public static EndpointEnum GetEndpointKey(NftTypeEnum nftType) => nftType switch
        {
            NftTypeEnum.PolkadotAssetHub_NftsPallet => EndpointEnum.PolkadotAssetHub,
            NftTypeEnum.KusamaAssetHub_NftsPallet => EndpointEnum.KusamaAssetHub,
            NftTypeEnum.Unique => EndpointEnum.Unique,
            NftTypeEnum.Opal => EndpointEnum.Opal,
            NftTypeEnum.Mythos => EndpointEnum.Mythos,
            NftTypeEnum.XcavatePaseo => EndpointEnum.XcavatePaseo,
            _ => throw new NotImplementedException(),
        };
        public static async Task<NftAssetWrapper> ToNftNativeAssetWrapperAsync(INftBase nft, Endpoint endpoint, CancellationToken token)
        {
            var nftWrapper = ToNftWrapper(nft);

            BigInteger? price = nft is INftMarketPrice ?
                    await ((INftMarketPrice)nft).GetMarketPriceAsync(token) : null;

            return new NftAssetWrapper
            {
                NftBase = nft,
                Endpoint = Endpoints.GetEndpointDictionary[GetEndpointKey(nft.Type)],
                AssetPrice = (price is not null || price != 0) ? new Asset
                {
                    Amount = (double)(price ?? 1) / Math.Pow(10, endpoint.Decimals),
                    Pallet = AssetPallet.Native,
                    Symbol = endpoint.Unit,
                    ChainIcon = endpoint.Icon,
                    DarkChainIcon = endpoint.DarkIcon,
                    AssetId = 0,
                    Endpoint = endpoint,
                    Decimals = endpoint.Decimals
                } : null,
                Operation = NftOperation.None,
            };
        }

    }
}
