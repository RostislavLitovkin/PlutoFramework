﻿using Substrate.NetApi.Model.Types.Primitive;
using XcavatePaseo.NetApi.Generated;
using UniqueryPlus;
using Substrate.NetApi;
using XcavatePaseo.NetApi.Generated.Storage;
using XcavatePaseo.NetApi.Generated.Model.pallet_nft_marketplace.pallet;
using UniqueryPlus.Nfts;
using Substrate.NetApi.Model.Extrinsics;
using XcavatePaseo.NetApi.Generated.Model.sp_core.crypto;
using Substrate.NetApi.Model.Types.Base;
using NftKey = (UniqueryPlus.NftTypeEnum, System.Numerics.BigInteger, System.Numerics.BigInteger);
using System.ComponentModel;
using AssetKey = (PlutoFramework.Constants.EndpointEnum, PlutoFramework.Types.AssetPallet, System.Numerics.BigInteger);
using PlutoFramework.Constants;
using PlutoFramework.Types;
using System.Numerics;
using XcavatePaseo.NetApi.Generated.Model.pallet_nft_marketplace.types;

namespace PlutoFramework.Model.Xcavate
{
    public record PropertyTokenOwnershipInfo : INotifyPropertyChanged
    {
        public NftKey? Key => NftBase is not null ? (NftBase.Type, NftBase.CollectionId, NftBase.Id) : null;
        public required uint Amount { get; set; }

        private bool favourite = false;
        public bool Favourite
        {
            get => favourite;
            set
            {
                if (favourite != value)
                {
                    favourite = value;
                    OnPropertyChanged(nameof(Favourite));
                }
            }
        }

        public required INftBase NftBase { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }

    public enum XcavatePropertyOperation
    {
        // Has to be there due to binding
        None,

        Buy
    }

    public record PropertyTokenOwnershipChangeInfo : PropertyTokenOwnershipInfo
    {
        public required XcavatePropertyOperation Operation { get; set; }
    }

    public class PropertyMarketplaceModel
    {
        public static IEnumerable<AssetKey> GetAcceptedAssets(EndpointEnum endpointKey) => endpointKey switch
        {
            EndpointEnum.XcavatePaseo => new NftMarketplaceConstants().AcceptedAssets().Value.Select(u32 => (EndpointEnum.XcavatePaseo, AssetPallet.Assets, new BigInteger(u32.Value))),
            _ => [],
        };

        public static Method BuyPropertyTokens(EndpointEnum endpointKey, uint listingId, uint amount, AssetKey paymentAsset) => endpointKey switch
        {
            EndpointEnum.XcavatePaseo => NftMarketplaceCalls.BuyToken(new U32(listingId), new U32(amount), new U32((uint)paymentAsset.Item3)),
            _ => throw new NotImplementedException($"BuyPropertyTokens not implemented for {endpointKey}"),
        };

        public static Method RelistPropertyTokens(EndpointEnum endpointKey, uint regionId, uint assetId, uint amount, BigInteger pricePerToken, AssetKey paymentAsset) => endpointKey switch
        {
            EndpointEnum.XcavatePaseo => NftMarketplaceCalls.RelistToken(new U32(regionId), new U32(assetId), new U128(pricePerToken), new U32(amount)),
            _ => throw new NotImplementedException($"RelistPropertyTokens not implemented for {endpointKey}"),
        };

        public static async Task<RecursiveReturn<PropertyTokenOwnershipInfo>> GetPropertiesOwnedByAsync(SubstrateClientExt client, string address, uint limit, byte[]? lastKey, CancellationToken token)
        {
            Console.WriteLine($"Finding properties owned by {address}.");

            // 0x + Twox64 pallet + Twox64 storage + Blake2_128Concat accountId32
            var keyPrefixLength = 162;

            var accountId = new AccountId32();
            accountId.Create(Utils.GetPublicKeyFrom(address));

            var keyPrefix = Utils.HexToByteArray(NftMarketplaceStorage.TokenOwnerParams(new BaseTuple<AccountId32, U32>(accountId, new U32(0))).Substring(0, keyPrefixLength));

            var fullKeys = await client.State.GetKeysPagedAsync(keyPrefix, limit, lastKey, string.Empty, token).ConfigureAwait(false);

            // No more nfts found
            if (fullKeys == null || !fullKeys.Any())
            {
                return new RecursiveReturn<PropertyTokenOwnershipInfo>
                {
                    Items = [],
                    LastKey = lastKey,
                };
            }

            var idKeys = fullKeys.Select(p => p.ToString().Substring(keyPrefixLength));

            var storageChangeSets = await client.State.GetQueryStorageAtAsync(fullKeys.Select(p => Utils.HexToByteArray(p.ToString())).ToList(), string.Empty, token).ConfigureAwait(false);

            var tokenOwnerDetails = new List<TokenOwnerDetails>();

            foreach (var change in storageChangeSets.First().Changes)
            {
                if (change[1] == null)
                {
                    continue;
                }

                var details = new TokenOwnerDetails();
                details.Create(change[1]);

                tokenOwnerDetails.Add(details);

                // Combine the amount owned with the rest of the property details
            };

            var propertyAssetDetails = await GetPropertyAssetDetailsAsync(client, idKeys, lastKey, token);

            return new RecursiveReturn<PropertyTokenOwnershipInfo>
            {
                Items = propertyAssetDetails.Items.Zip(tokenOwnerDetails, (propertyDetails, ownerDetails) => new PropertyTokenOwnershipInfo
                {
                    Amount = ownerDetails.TokenAmount,
                    NftBase = propertyDetails,
                    Favourite = false, // Is filled later

                }),
                LastKey = Utils.HexToByteArray(fullKeys.Last().ToString())
            };
        }

        public static async Task<RecursiveReturn<INftBase>> GetPropertiesAsync(SubstrateClientExt client, uint limit, byte[]? lastKey, CancellationToken token)
        {
            // 0x + Twox64 pallet + Twox64 storage + Blake2_128Concat U32
            var keyPrefixLength = 66;

            var keyPrefix = Utils.HexToByteArray(NftMarketplaceStorage.AssetIdDetailsParams(new U32(0)).Substring(0, keyPrefixLength));

            var fullKeys = await client.State.GetKeysPagedAsync(keyPrefix, limit, lastKey, string.Empty, token).ConfigureAwait(false);

            Console.WriteLine("Keys found: " + fullKeys.Count());

            // No more nfts found
            if (fullKeys == null || !fullKeys.Any())
            {
                return new RecursiveReturn<INftBase>
                {
                    Items = [],
                    LastKey = lastKey,
                };
            }

            var idKeys = fullKeys.Select(p => p.ToString().Substring(keyPrefixLength));

            return await GetPropertyAssetDetailsAsync(client, idKeys, lastKey, token);
        }

        public static async Task<RecursiveReturn<INftBase>> GetPropertyAssetDetailsAsync(SubstrateClientExt client, IEnumerable<string> propertyIds, byte[]? lastKey, CancellationToken token)
        {
            var keyPrefixLength = 66;

            var keyPrefix = NftMarketplaceStorage.AssetIdDetailsParams(new U32(0)).Substring(0, keyPrefixLength);

            var fullKeys = propertyIds.Select(id => keyPrefix + id);

            var storageChangeSets = await client.State.GetQueryStorageAtAsync(fullKeys.Select(p => Utils.HexToByteArray(p.ToString())).ToList(), string.Empty, token).ConfigureAwait(false);

            var nftIds = new List<(U32, U32)>();

            foreach (var change in storageChangeSets.First().Changes)
            {
                try
                {
                    if (change[1] == null)
                    {
                        continue;
                    }

                    var details = new AssetDetails();
                    details.Create(change[1]);

                    var propertyId = change[0];

                    nftIds.Add((details.CollectionId, details.ItemId));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while processing property details: " + ex.Message);
                }
            }

            var listingIdKeys = fullKeys.Select(key => key.Substring(keyPrefixLength));

            return await XcavatePaseoNftModel.GetNftsNftsPalletAsync(client, nftIds, fullKeys.Last().ToString(), token).ConfigureAwait(false);
        }

        public static async Task<INftBase> GetPropertyByIdAsync(SubstrateClientExt client, uint propertyId, CancellationToken token)
        {
            // 0x + Twox64 pallet + Twox64 storage + Blake2_128Concat U32
            var keyPrefixLength = 66;

            string[] idKeys = [NftMarketplaceStorage.AssetIdDetailsParams(new U32(propertyId)).Substring(keyPrefixLength)];

            var propertyDetails = await GetPropertyAssetDetailsAsync(client, idKeys, null, token);

            if (propertyDetails.Items.Count() == 0)
            {
                throw new Exception("Unexpected failure");
            }

            return propertyDetails.Items.First();
        }

        public static IAsyncEnumerable<INftBase> GetPropertiesAsync(
            SubstrateClientExt client,
            uint limit = 25
        )
        {
            return RecursionHelper.ToIAsyncEnumerableAsync(
                [client],
                (SubstrateClient client, NftTypeEnum _type, byte[]? lastKey, CancellationToken token) => GetPropertiesAsync((SubstrateClientExt)client, limit, lastKey, token),
                limit
            );
        }

        public static IAsyncEnumerable<PropertyTokenOwnershipInfo> GetPropertiesOwnedByAsync(
            SubstrateClientExt client,
            string owner,
            uint limit = 25
        )
        {
            return RecursionHelper.ToIAsyncEnumerableAsync(
                [client],
                (SubstrateClient client, NftTypeEnum _type, byte[]? lastKey, CancellationToken token) => GetPropertiesOwnedByAsync((SubstrateClientExt)client, owner, limit, lastKey, token),
                limit
            );
        }

        public static IAsyncEnumerable<INftBase> GetIndexedPropertiesForSaleAsync(
            SubstrateClientExt client,
            uint limit = 25
        )
        {
            return RecursionHelper.ToIAsyncEnumerableAsync(
                [client],
                (SubstrateClient client, NftTypeEnum _type, int limit, int offset, CancellationToken token) => XcavateSubqueryModel.GetPropertiesForSaleAsync((SubstrateClientExt)client, limit, offset, token),
                (int)limit
            );
        }
    }
}
