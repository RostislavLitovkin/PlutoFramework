using XcavatePaseo.NetApi.Generated;
using XcavatePaseo.NetApi.Generated.Storage;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.Numerics;
using XcavatePaseo.NetApi.Generated.Model.pallet_nfts.types;
using XcavatePaseo.NetApi.Generated.Model.sp_core.crypto;
using UniqueryPlus.Collections;
using Substrate.NetApi.Model.Extrinsics;
using XcavatePaseo.NetApi.Generated.Model.sp_runtime.multiaddress;
using UniqueryPlus.Metadata;
using System.Text.Json;
using XcavatePaseo.NetApi.Generated.Model.pallet_nft_marketplace.pallet;
using Nethereum.Util;

namespace UniqueryPlus.Nfts
{
    public record XcavatePaseoNftsPalletNftFull : XcavatePaseoNftsPalletNft, INftSellable, INftBuyable
    {
        private SubstrateClientExt client;
        public required BigInteger? Price { get; set; }
        public required bool IsForSale { get; set; }

        public XcavatePaseoNftsPalletNftFull(SubstrateClientExt client) : base(client)
        {
            this.client = client;
        }

        public Method Sell(BigInteger price)
        {
            var whitelisted_buyer = new BaseOpt<EnumMultiAddress>();
            return NftsCalls.SetPrice(new U32((uint)CollectionId), new U32((uint)Id), new BaseOpt<U128>(new U128(price)), whitelisted_buyer);
        }
        public Method Buy()
        {
            return NftsCalls.BuyItem(new U32((uint)CollectionId), new U32((uint)Id), new U128(Price ?? 0));
        }
    }
    public record XcavatePaseoNftsPalletNft : INftXcavateBase, INftBase, INftTransferable, INftBurnable, INftMarketPrice, INftFractionalization, INftXcavateMetadata, INftXcavateNftMarketplace, INftXcavateOngoingObjectListing
    {
        private SubstrateClientExt client;
        public NftTypeEnum Type => NftTypeEnum.XcavatePaseo;
        public BigInteger CollectionId { get; set; }
        public BigInteger Id { get; set; }
        public required string Owner { get; set; }
        public NftMarketplaceDetails? NftMarketplaceDetails { get; set; }
        
        public XcavateOngoingObjectListingDetails? OngoingObjectListingDetails { get; set; }
        public MetadataBase? Metadata { get; set; }
        public XcavateMetadata? XcavateMetadata { get; set; }
        public XcavatePaseoNftsPalletNft(SubstrateClientExt client)
        {
            this.client = client;
        }
        public Task<ICollectionBase> GetCollectionAsync(CancellationToken token) => XcavatePaseoCollectionModel.GetCollectionNftsPalletByCollectionIdAsync(client, (uint)CollectionId, token);

        public bool IsTransferable { get; set; } = true;

        public Method Transfer(string recipientAddress)
        {
            var accountId = new AccountId32();
            accountId.Create(Utils.GetPublicKeyFrom(recipientAddress));

            var multiAddress = new EnumMultiAddress();
            multiAddress.Create(MultiAddress.Id, accountId);

            return NftsCalls.Transfer(new U32((uint)CollectionId), new U32((uint)Id), multiAddress);
        }
        public async Task<BigInteger> NftToAssetAsync(CancellationToken token)
        {
            var details = await client.NftFractionalizationStorage.NftToAsset(new BaseTuple<U32, U32>(new U32((uint)CollectionId), new U32((uint)Id)), null, token);

            return details.Asset.Value;
        }
        public bool IsBurnable { get; set; } = true;
        public Method Burn() => NftsCalls.Burn(new U32((uint)CollectionId), new U32((uint)Id));
        public async Task<BigInteger?> GetMarketPriceAsync(CancellationToken token)
        {
            var speckClient = Indexers.GetSpeckClient();

            var collectionStats = await speckClient.GetCollectionStats.ExecuteAsync(CollectionId.ToString(), token).ConfigureAwait(false);

            //collectionStats.EnsureNoErrors();
            if (collectionStats is null || collectionStats.Errors.Count > 0)
            {
                return null;
            }

            return collectionStats.Data?.CollectionEntityById?.HighestSale is not null ? BigInteger.Parse(collectionStats.Data.CollectionEntityById.HighestSale ?? "Should not happen") : null;
        }

        public async Task<INftBase> GetFullAsync(CancellationToken token)
        {
            var price = await XcavatePaseoNftModel.GetNftPriceNftsPalletAsync(client, (uint)CollectionId, (uint)Id, token).ConfigureAwait(false);

            return new XcavatePaseoNftsPalletNftFull(client)
            {
                Owner = Owner,
                CollectionId = CollectionId,
                Id = Id,
                Metadata = Metadata,
                Price = price,
                IsForSale = price.HasValue,
            };
        }
    }
    public class XcavatePaseoNftModel
    {

        public static Task<RecursiveReturn<INftBase>> GetNftsNftsPalletAsync(SubstrateClientExt client, List<(U32, U32)> nftIds, string lastKey, CancellationToken token)
        {
            var keyPrefixLength = 66;

            var idKeys = nftIds.Select(id => NftsStorage.ItemParams(new BaseTuple<U32, U32>(id.Item1, id.Item2)).Substring(keyPrefixLength));

            return GetNftsNftsPalletByIdKeysAsync(client, idKeys, lastKey, token);
        }
        internal static async Task<INftBase?> GetNftNftsPalletByIdAsync(SubstrateClientExt client, uint collectionId, uint id, CancellationToken token)
        {
            var keyPrefix = Utils.HexToByteArray(NftsStorage.ItemParams(new BaseTuple<U32, U32>(new U32(collectionId), new U32(id))));

            var fullKeys = await client.State.GetKeysPagedAsync(keyPrefix, 1, null, string.Empty, token).ConfigureAwait(false);

            // No nfts found
            if (fullKeys == null || !fullKeys.Any())
            {
                return null;
            }

            // Filter only the CollectionId and NftId keys
            var idKeys = fullKeys.Select(p => p.ToString().Substring(Constants.BASE_STORAGE_KEY_LENGTH));

            return (await GetNftsNftsPalletByIdKeysAsync(client, idKeys, fullKeys.Last().ToString(), token).ConfigureAwait(false)).Items.First();
        }
        internal static async Task<RecursiveReturn<INftBase>> GetNftsNftsPalletInCollectionAsync(SubstrateClientExt client, uint collectionId, uint limit, byte[]? lastKey, CancellationToken token)
        {
            // 0x + Twox64 pallet + Twox64 storage + Blake2_128Concat U32
            var keyPrefixLength = 106;

            var keyPrefix = Utils.HexToByteArray(NftsStorage.ItemParams(new BaseTuple<U32, U32>(new U32(collectionId), new U32(0))).Substring(0, keyPrefixLength));

            var fullKeys = await client.State.GetKeysPagedAsync(keyPrefix, limit, lastKey, string.Empty, token).ConfigureAwait(false);

            // No more nfts found
            if (fullKeys == null || !fullKeys.Any())
            {
                return new RecursiveReturn<INftBase>
                {
                    Items = [],
                    LastKey = lastKey,
                };
            }

            var baseStoragePrefixLength = 66;

            // Filter only the CollectionId and NftId keys
            var idKeys = fullKeys.Select(p => p.ToString().Substring(baseStoragePrefixLength));

            return await GetNftsNftsPalletByIdKeysAsync(client, idKeys, fullKeys.Last().ToString(), token).ConfigureAwait(false);
        }

        internal static async Task<RecursiveReturn<INftBase>> GetNftsNftsPalletOwnedByAsync(SubstrateClientExt client, string owner, uint limit, byte[]? lastKey, CancellationToken token)
        {
            var accountId32 = new AccountId32();
            accountId32.Create(Utils.GetPublicKeyFrom(owner));

            // 0x + Twox64 pallet + Twox64 storage + Blake2_128Concat accountId32
            var keyPrefixLength = 162;

            var keyPrefix = Utils.HexToByteArray(NftsStorage.AccountParams(new BaseTuple<AccountId32, U32, U32>(accountId32, new U32(0), new U32(0))).Substring(0, keyPrefixLength));

            var fullKeys = await client.State.GetKeysPagedAsync(keyPrefix, limit, lastKey, string.Empty, token).ConfigureAwait(false);

            // No more nfts found
            if (fullKeys == null || !fullKeys.Any())
            {
                return new RecursiveReturn<INftBase>
                {
                    Items = [],
                    LastKey = lastKey,
                };
            }

            // Filter only the nft Id keys
            var idKeys = fullKeys.Select(p => p.ToString().Substring(keyPrefixLength));

            return await GetNftsNftsPalletByIdKeysAsync(client, idKeys, fullKeys.Last().ToString(), token).ConfigureAwait(false);
        }

        internal static async Task<RecursiveReturn<INftBase>> GetNftsNftsPalletInCollectionOwnedByAsync(SubstrateClientExt client, uint collectionId, string owner, uint limit, byte[]? lastKey, CancellationToken token)
        {
            var accountId32 = new AccountId32();
            accountId32.Create(Utils.GetPublicKeyFrom(owner));

            // 0x + Twox64 pallet + Twox64 storage + Blake2_128Concat accountId32 + Blake2_128Concat collectionId
            var keyPrefixLength = 202;

            var keyPrefix = Utils.HexToByteArray(NftsStorage.AccountParams(new BaseTuple<AccountId32, U32, U32>(accountId32, new U32(collectionId), new U32(0))).Substring(0, keyPrefixLength));

            var fullKeys = await client.State.GetKeysPagedAsync(keyPrefix, limit, lastKey, string.Empty, token).ConfigureAwait(false);

            // No more nfts found
            if (fullKeys == null || !fullKeys.Any())
            {
                return new RecursiveReturn<INftBase>
                {
                    Items = [],
                    LastKey = lastKey,
                };
            }

            // 0x + Twox64 pallet + Twox64 storage + Blake2_128Concat accountId32
            var baseStoragePrefixLength = 162;

            // Filter only the nft Id keys
            var idKeys = fullKeys.Select(p => p.ToString().Substring(baseStoragePrefixLength));

            return await GetNftsNftsPalletByIdKeysAsync(client, idKeys, fullKeys.Last().ToString(), token).ConfigureAwait(false);
        }

        internal static Task<RecursiveReturn<INftBase>> GetNftsNftsPalletByIdKeysAsync(SubstrateClientExt client, IEnumerable<string> idKeys, string lastKey, CancellationToken token)
        {
            return GetNftsNftsPalletByIdKeysAsync(client, idKeys, Utils.HexToByteArray(lastKey), token);
        }
        internal static async Task<RecursiveReturn<INftBase>> GetNftsNftsPalletByIdKeysAsync(SubstrateClientExt client, IEnumerable<string> nftIdKeys, byte[] lastKey, CancellationToken token)
        {
            var ids = nftIdKeys.Select(ids => (Helpers.GetBigIntegerFromBlake2_128Concat(ids.Substring(0, 40)), Helpers.GetBigIntegerFromBlake2_128Concat(ids.Substring(40, 40))));

            var nftDetails = await GetNftDetailsNftsPalletByIdKeysAsync(client, nftIdKeys, token).ConfigureAwait(false);

            var nftMetadatas = await GetNftMetadataNftsPalletByIdKeysAsync(client, nftIdKeys, token).ConfigureAwait(false);

            var nftMarketplaceDetails = await GetNftMarketplaceDetailsAsync(client, nftIdKeys, token).ConfigureAwait(false);

            var ongoingObjectDetails = await GetOngoingObjectListingDetailsAsync(client, nftIdKeys, token).ConfigureAwait(false);

            return new RecursiveReturn<INftBase>
            {
                Items = ids.Zip(nftDetails, ((BigInteger, BigInteger) ids, ItemDetails? details) => details switch
                {
                    // Should never be null
                    null => new XcavatePaseoNftsPalletNft(client)
                    {
                        CollectionId = ids.Item1,
                        Owner = "Unknown",
                        Id = ids.Item2,
                    },
                    _ => new XcavatePaseoNftsPalletNft(client)
                    {
                        CollectionId = ids.Item1,
                        Owner = Utils.GetAddressFrom(details.Owner.Encode()),
                        Id = ids.Item2,
                    }
                }).Zip(nftMetadatas, (XcavatePaseoNftsPalletNft nft, (MetadataBase Metadata, XcavateMetadata XcavateMetadata)? metadata) =>
                {
                    if (metadata.HasValue)
                    {
                        nft.Metadata = metadata.Value.Metadata;
                        nft.XcavateMetadata = metadata.Value.XcavateMetadata;
                    }
                    return nft;
                }).Zip(nftMarketplaceDetails, (XcavatePaseoNftsPalletNft nft, NftMarketplaceDetails? details) =>
                {
                    if (details is not null) {
                        nft.NftMarketplaceDetails = details;
                    }

                    return nft;
                }).Zip(ongoingObjectDetails, (XcavatePaseoNftsPalletNft nft, XcavateOngoingObjectListingDetails? details) =>
                {
                    if (details is not null)
                    {
                        nft.OngoingObjectListingDetails = details;
                    }

                    return nft;
                }),
                LastKey = lastKey
            };
        }

        internal static async Task<IEnumerable<ItemDetails?>> GetNftDetailsNftsPalletByIdKeysAsync(SubstrateClientExt client, IEnumerable<string> idKeys, CancellationToken token)
        {
            // 0x + Twox64 pallet + Twox64 storage
            var keyPrefixLength = 66;

            var keyPrefix = NftsStorage.ItemParams(new BaseTuple<U32, U32>(new U32(0), new U32(0))).Substring(0, keyPrefixLength);

            var nftDetailsKeys = idKeys.Select(idKey => Utils.HexToByteArray(keyPrefix + idKey));

            var storageChangeSets = await client.State.GetQueryStorageAtAsync(nftDetailsKeys.ToList(), string.Empty, token).ConfigureAwait(false);

            return storageChangeSets.First().Changes.Select(change =>
            {
                if (change[1] == null)
                {
                    return null;
                }

                var details = new ItemDetails();
                details.Create(change[1]);

                return details;
            });
        }

        internal static async Task<List<NftMarketplaceDetails?>> GetNftMarketplaceDetailsAsync(SubstrateClientExt client, IEnumerable<string> idKeys, CancellationToken token)
        {
            // 0x + Twox64 pallet + Twox64 storage
            var keyPrefixLength = 66;

            var keyPrefix = NftMarketplaceStorage.RegisteredNftDetailsParams(new BaseTuple<U32, U32>(new U32(0), new U32(0))).Substring(0, keyPrefixLength);

            var nftKeys = idKeys.Select(idKey => Utils.HexToByteArray(keyPrefix + idKey));
            var storageChangeSets = await client.State.GetQueryStorageAtAsync(nftKeys.ToList(), string.Empty, token).ConfigureAwait(false);

            var details = new List<NftMarketplaceDetails?>();

            foreach (var change in storageChangeSets.First().Changes)
            {
                if (change[1] == null)
                {
                    details.Add(null);
                    continue;
                }

                var nftDetails = new NftDetails();
                nftDetails.Create(change[1]);

                details.Add(new NftMarketplaceDetails
                {
                    SpvCreated = nftDetails.SpvCreated,
                    AssetId = nftDetails.AssetId.Value,
                    Region = nftDetails.Region.Value,
                    Location = Helpers.VecU8ToString(nftDetails.Location.Value.Value),
                });
            }

            var listedTokensKeys = details.Select(d => d is null ? [] : Utils.HexToByteArray(NftMarketplaceStorage.ListedTokenParams(new U32(d.AssetId))));

            var listedTokensStorageChangeSets = await client.State.GetQueryStorageAtAsync(listedTokensKeys.ToList(), string.Empty, token).ConfigureAwait(false);

            var changes = listedTokensStorageChangeSets.First().Changes;

            for(int i = 0; i < changes.Count(); i++)
            {
                var change = changes[i];
                if (change[1] == null)
                {
                    continue;
                }

                var listed = new U32();
                listed.Create(change[1]);

                var detail = details[i];
                if (detail is not null)
                {
                    detail.Listed = listed;
                }
            }

            return details;
        }

        internal static async Task<List<XcavateOngoingObjectListingDetails?>> GetOngoingObjectListingDetailsAsync(SubstrateClientExt client, IEnumerable<string> idKeys, CancellationToken token)
        {
            // 0x + Twox64 pallet + Twox64 storage
            var keyPrefixLength = 66;

            var keyPrefix = NftMarketplaceStorage.OngoingObjectListingParams(new U32(0)).Substring(0, keyPrefixLength);

            var nftKeys = idKeys.Select(idKey => Utils.HexToByteArray(keyPrefix + idKey.Substring(40, 40)));
            var storageChangeSets = await client.State.GetQueryStorageAtAsync(nftKeys.ToList(), string.Empty, token).ConfigureAwait(false);

            var details = new List<XcavateOngoingObjectListingDetails?>();

            foreach (var change in storageChangeSets.First().Changes)
            {
                if (change[1] == null)
                {
                    details.Add(null);
                    continue;
                }

                var nftDetails = new XcavatePaseo.NetApi.Generated.Model.pallet_nft_marketplace.types.NftListingDetails();
                nftDetails.Create(change[1]);

                details.Add(new XcavateOngoingObjectListingDetails
                {
                    RealEstateDeveloper = Utils.GetAddressFrom(nftDetails.RealEstateDeveloper.Encode()),
                    TaxPaidByDeveloper = nftDetails.TaxPaidByDeveloper,
                    ListingExpiry = nftDetails.ListingExpiry.Value
                });
            }

            return details;
        }


        internal static async Task<IEnumerable<(MetadataBase Metadata, XcavateMetadata XcavateMetadata)?>> GetNftMetadataNftsPalletByIdKeysAsync(SubstrateClientExt client, IEnumerable<string> idKeys, CancellationToken token)
        {
            // 0x + Twox64 pallet + Twox64 storage
            var keyPrefixLength = 66;

            var keyPrefix = NftsStorage.ItemMetadataOfParams(new BaseTuple<U32, U32>(new U32(0), new U32(0))).Substring(0, keyPrefixLength);

            var nftMetadataKeys = idKeys.Select(idKey => Utils.HexToByteArray(keyPrefix + idKey));
            var storageChangeSets = await client.State.GetQueryStorageAtAsync(nftMetadataKeys.ToList(), string.Empty, token).ConfigureAwait(false);

            var metadatas = new List<(MetadataBase Metadata, XcavateMetadata XcavateMetadata)?>();

            foreach (var change in storageChangeSets.First().Changes)
            {
                if (change[1] == null)
                {
                    metadatas.Add(null);
                    continue;
                }

                var nftMetadata = new ItemMetadata();
                nftMetadata.Create(change[1]);

                try
                {
                    int p = 0;
                    CompactInteger compactInteger = CompactInteger.Decode(nftMetadata.Data.Value.Bytes, ref p);

                    string metadataJson = System.Text.Encoding.UTF8.GetString(nftMetadata.Data.Value.Bytes.Slice(p));

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    Console.WriteLine(metadataJson);

                    XcavateMetadata? xCavateMetadata = JsonSerializer.Deserialize<XcavateMetadata>(metadataJson, options);

                    if (xCavateMetadata == null)
                    {
                        metadatas.Add(null);
                        continue;
                    }

                    var metadata = new MetadataBase
                    {
                        Name = xCavateMetadata.PropertyName,
                        Description = xCavateMetadata.PropertyDescription,
                        //Image = xCavateMetadata
                    };

                    metadatas.Add((metadata, xCavateMetadata));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Metadata exception:");

                    Console.WriteLine(e);
                    metadatas.Add(null);
                }
            };

            return metadatas;
        }

        internal static async Task<BigInteger?> GetNftPriceNftsPalletAsync(SubstrateClientExt client, uint collectionId, uint id, CancellationToken token)
        {
            var price = await client.NftsStorage.ItemPriceOf(new BaseTuple<U32, U32>(new U32(collectionId), new U32(id)), null, token).ConfigureAwait(false);

            if (price is null)
            {
                return null;
            }

            if (((BaseOpt<AccountId32>)price.Value[1]).OptionFlag)
            {
                return null;
            }

            return (U128)price.Value[0];
        }
    }
}
