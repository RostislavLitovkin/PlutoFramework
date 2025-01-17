﻿using XCavatePaseo.NetApi.Generated;
using XCavatePaseo.NetApi.Generated.Storage;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.Numerics;
using XCavatePaseo.NetApi.Generated.Model.pallet_nfts.types;
using XCavatePaseo.NetApi.Generated.Model.sp_core.crypto;
using UniqueryPlus.Collections;
using Substrate.NetApi.Model.Extrinsics;
using XCavatePaseo.NetApi.Generated.Model.sp_runtime.multiaddress;
using UniqueryPlus.Metadata;
using System.Text.Json;
using XCavatePaseo.NetApi.Generated.Model.pallet_nft_marketplace.pallet;
using System.Collections;
using Nethereum.Util;

namespace UniqueryPlus.Nfts
{
    public record XCavatePaseoNftsPalletNftFull : XCavatePaseoNftsPalletNft, INftSellable, INftBuyable
    {
        private SubstrateClientExt client;
        public required BigInteger? Price { get; set; }
        public required bool IsForSale { get; set; }

        public XCavatePaseoNftsPalletNftFull(SubstrateClientExt client) : base(client)
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
    public record XCavatePaseoNftsPalletNft : INftBase, INftTransferable, INftBurnable, INftMarketPrice, INftFractionalization, INftXCavateMetadata, INftXcavateNftMarketplace
    {
        private SubstrateClientExt client;
        public NftTypeEnum Type => NftTypeEnum.XCavatePaseo;
        public BigInteger CollectionId { get; set; }
        public BigInteger Id { get; set; }
        public required string Owner { get; set; }
        public NftMarketplaceDetails? NftMarketplaceDetails { get; set; }
        public MetadataBase? Metadata { get; set; }
        public XCavateMetadata? XCavateMetadata { get; set; }
        public XCavatePaseoNftsPalletNft(SubstrateClientExt client)
        {
            this.client = client;
        }
        public Task<ICollectionBase> GetCollectionAsync(CancellationToken token) => XCavatePaseoCollectionModel.GetCollectionNftsPalletByCollectionIdAsync(client, (uint)CollectionId, token);

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
            var price = await XCavatePaseoNftModel.GetNftPriceNftsPalletAsync(client, (uint)CollectionId, (uint)Id, token).ConfigureAwait(false);

            return new XCavatePaseoNftsPalletNftFull(client)
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
    public class XCavatePaseoNftModel
    {

        public static Task<RecursiveReturn<INftBase>> GetNftsNftsPalletAsync(SubstrateClientExt client, List<(U32, U32)> nftIds, string lastKey, CancellationToken token)
        {
            var idKeys = nftIds.Select(id => NftsStorage.ItemParams(new BaseTuple<U32, U32>(id.Item1, id.Item2)).Substring(66));

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
        internal static async Task<RecursiveReturn<INftBase>> GetNftsNftsPalletByIdKeysAsync(SubstrateClientExt client, IEnumerable<string> idKeys, byte[] lastKey, CancellationToken token)
        {
            var ids = idKeys.Select(ids => (Helpers.GetBigIntegerFromBlake2_128Concat(ids.Substring(0, 40)), Helpers.GetBigIntegerFromBlake2_128Concat(ids.Substring(40, 40))));

            var nftDetails = await GetNftDetailsNftsPalletByIdKeysAsync(client, idKeys, token).ConfigureAwait(false);

            var nftMetadatas = await GetNftMetadataNftsPalletByIdKeysAsync(client, idKeys, token).ConfigureAwait(false);

           var nftMarketplaceDetails = await GetNftMarketplaceDetailsAsync(client, idKeys, token).ConfigureAwait(false);

            return new RecursiveReturn<INftBase>
            {
                Items = ids.Zip(nftDetails, ((BigInteger, BigInteger) ids, ItemDetails? details) => details switch
                {
                    // Should never be null
                    null => new XCavatePaseoNftsPalletNft(client)
                    {
                        CollectionId = ids.Item1,
                        Owner = "Unknown",
                        Id = ids.Item2,
                    },
                    _ => new XCavatePaseoNftsPalletNft(client)
                    {
                        CollectionId = ids.Item1,
                        Owner = Utils.GetAddressFrom(details.Owner.Encode()),
                        Id = ids.Item2,
                    }
                }).Zip(nftMetadatas, (XCavatePaseoNftsPalletNft nft, (MetadataBase Metadata, XCavateMetadata XCavateMetadata)? metadata) =>
                {
                    if (metadata.HasValue)
                    {
                        nft.Metadata = metadata.Value.Metadata;
                        nft.XCavateMetadata = metadata.Value.XCavateMetadata;
                    }
                    return nft;
                }).Zip(nftMarketplaceDetails, (XCavatePaseoNftsPalletNft nft, NftMarketplaceDetails? details) =>
                {
                    if (details is not null) {
                        nft.NftMarketplaceDetails = details;
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
                    Location = Helpers.VecU8ToString(nftDetails.Location.Value),
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


        internal static async Task<IEnumerable<(MetadataBase Metadata, XCavateMetadata XCavateMetadata)?>> GetNftMetadataNftsPalletByIdKeysAsync(SubstrateClientExt client, IEnumerable<string> idKeys, CancellationToken token)
        {
            // 0x + Twox64 pallet + Twox64 storage
            var keyPrefixLength = 66;

            var keyPrefix = NftsStorage.ItemMetadataOfParams(new BaseTuple<U32, U32>(new U32(0), new U32(0))).Substring(0, keyPrefixLength);

            var nftMetadataKeys = idKeys.Select(idKey => Utils.HexToByteArray(keyPrefix + idKey));
            var storageChangeSets = await client.State.GetQueryStorageAtAsync(nftMetadataKeys.ToList(), string.Empty, token).ConfigureAwait(false);

            var metadatas = new List<(MetadataBase Metadata, XCavateMetadata XCavateMetadata)?>();

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

                    Console.WriteLine(metadataJson);

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    XCavateMetadata? xCavateMetadata = JsonSerializer.Deserialize<XCavateMetadata>(metadataJson, options);

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
                    //Console.WriteLine(e);
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
