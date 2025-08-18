﻿using PlutoFramework.Constants;
using SQLite;
using System.Numerics;
using Uniquery;
using UniqueryPlus;
using UniqueryPlus.Collections;
using UniqueryPlus.External;
using UniqueryPlus.Metadata;
using UniqueryPlus.Nfts;
using CollectionKey = (UniqueryPlus.NftTypeEnum, System.Numerics.BigInteger);

namespace PlutoFramework.Model
{
    public class MockCollection : ICollectionBase, IKodaLink
    {
        public NftTypeEnum Type => NftTypeEnum.PolkadotAssetHub_NftsPallet;
        public required BigInteger CollectionId { get; set; }
        public required string Owner { get; set; }
        public required uint NftCount { get; set; }
        public MetadataBase? Metadata { get; set; }
        public string KodaLink => $"https://koda.art/ahp/collection/{CollectionId}";
        public async Task<IEnumerable<INftBase>> GetNftsAsync(uint limit, byte[]? lastKey = null, CancellationToken token = default)
        {
            List<INftBase> nfts = new List<INftBase>();
            for (int i = 0; i < limit; i++){
                nfts.Add(NftModel.GetMockNft());
            }

            return nfts;
        }

        public async Task<IEnumerable<INftBase>> GetNftsOwnedByAsync(string owner, uint limit, byte[]? lastKey, CancellationToken token)
        {
            return await GetNftsAsync(limit, lastKey, token);
        }

        public async Task<ICollectionBase> GetFullAsync(CancellationToken token)
        {
            return this;
        }
    }

    public class CollectionWrapper
    {
        public CollectionKey? Key => CollectionBase is not null ? (CollectionBase.Type, CollectionBase.CollectionId) : null;
        public ICollectionBase? CollectionBase { get; set; }
        public string[] NftImages { get; set; } = [];
        public Endpoint? Endpoint { get; set; }
        public bool Favourite { get; set; } = false;
        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj is not CollectionWrapper)
            {
                return false;
            }

            var objNft = (CollectionWrapper)obj;

            return (objNft.CollectionBase?.Metadata?.Name == this.CollectionBase?.Metadata?.Name &&
                objNft.CollectionBase?.Metadata?.Description == this.CollectionBase?.Metadata?.Description &&
                objNft.CollectionBase?.Metadata?.Image == this.CollectionBase?.Metadata?.Image &&
                objNft.Endpoint?.Key == this.Endpoint?.Key);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(CollectionBase?.Metadata?.Name, CollectionBase?.Metadata?.Description, CollectionBase?.Metadata?.Image, Endpoint?.Key);
        }
        public override string ToString()
        {
            return this.CollectionBase?.Metadata?.Name + " - " + this.CollectionBase?.Metadata?.Image;
        }
    }
    public class CollectionModel
    {
        public static ICollectionBase GetMockCollection(
            string name = "Mock Collection",
            uint nftCount = 5
        )
        {
            Random random = new Random();

            int digits = random.Next(1, 9);

            return new MockCollection
            {
                CollectionId = random.Next((int)Math.Pow(10, digits)),
                NftCount = nftCount,
                Metadata = new MetadataBase
                {
                    Name = name,
                    Description = "Welcome, this is a mock collection to test the UI for Collection views even without an internet connection. Yes, it is pretty handy!",
                    Image = "darkbackground2.png",
                },
                Owner = "5EU6EyEq6RhqYed1gCYyQRVttdy6FC9yAtUUGzPe3gfpFX8y"
            };
        }

        public static ICollectionBase GetLoadingCollection(
            string name = "Loading",
            uint nftCount = 1
        )
        {
            Random random = new Random();

            int digits = random.Next(1, 9);

            return new MockCollection
            {
                CollectionId = random.Next((int)Math.Pow(10, digits)),
                NftCount = nftCount,
                Metadata = new MetadataBase
                {
                    Name = name,
                    Description = "Loading",
                    Image = "imageloading.png",
                },
                Owner = "Loading"
            };
        }

        public static async Task<CollectionWrapper> ToCollectionWrapperAsync(ICollectionBase collection, CancellationToken token)
        {
            if (collection.Metadata is not null && collection.Metadata.Image is null)
            {
                collection.Metadata.Image = "noimage.png";
            }

            return new CollectionWrapper
            {
                Endpoint = Endpoints.GetEndpointDictionary[PlutoFrameworkCore.NftModel.GetEndpointKey(collection.Type)],
                NftImages = (await collection.GetNftsAsync(Math.Min(3, collection.NftCount), null, token)).Select(nft => nft.Metadata?.Image ?? "noimage.png").ToArray(),
                CollectionBase = collection,
            };
        }
    }
}
