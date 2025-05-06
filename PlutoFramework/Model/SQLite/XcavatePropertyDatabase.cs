using PlutoFramework.Constants;
using PlutoFramework.Model.Constants;
using SQLite;
using System.Numerics;
using System.Text.Json;
using UniqueryPlus;
using UniqueryPlus.Collections;
using UniqueryPlus.Metadata;
using UniqueryPlus.Nfts;

namespace PlutoFramework.Model.SQLite
{
    public class SavedXcavatePropertyBase : INftXcavateBase
    {
        public XcavateMetadata? XcavateMetadata { get; set; }
        public NftTypeEnum Type { get; set; }
        public BigInteger CollectionId { get; set; }
        public BigInteger Id { get; set; }
        public string Owner { get; set; }
        public MetadataBase Metadata { get; set; }
        public async Task<ICollectionBase> GetCollectionAsync(CancellationToken token)
        {
            var endpointKey = NftModel.GetEndpointKey(Type);

            var client = await SubstrateClientModel.GetOrAddSubstrateClientAsync(endpointKey, token);

            return await UniqueryPlus.Collections.CollectionModel.GetCollectionByCollectionIdAsync(client.SubstrateClient, Type, (uint)CollectionId, token).ConfigureAwait(false);
        }
        public async Task<INftBase> GetFullAsync(CancellationToken token)
        {
            var endpointKey = NftModel.GetEndpointKey(Type);

            var client = await SubstrateClientModel.GetOrAddSubstrateClientAsync(endpointKey, token);

            var nft = await UniqueryPlus.Nfts.NftModel.GetNftByIdAsync(client.SubstrateClient, Type, (uint)CollectionId, (uint)Id, token).ConfigureAwait(false);

            return await nft.GetFullAsync(token);
        }
    }
    public record XcavatePropertyDatabaseItem
    {
        [PrimaryKey]
        [Unique]
        public string Key { get; set; } = "";
        public string SerializedNftBase { get; set; } = "";
        public string SerializedEndpoint { get; set; } = "";
        public bool Favourite { get; set; }

        public static implicit operator NftWrapper(XcavatePropertyDatabaseItem item)
        {
            Console.WriteLine("Serialized saved: ");
            Console.WriteLine(item.Key);
            Console.WriteLine(item.SerializedNftBase);

            var keyValues = item.Key.Split('-');

            if (keyValues.Length != 3)
            {
                throw new Exception("This should not happen");
            }

            var nftBase = JsonSerializer.Deserialize<SavedXcavatePropertyBase>(item.SerializedNftBase);

            nftBase.CollectionId = BigInteger.Parse(keyValues[1]);
            nftBase.Id = BigInteger.Parse(keyValues[2]);

            return new NftWrapper
            {
                NftBase = nftBase,
                Endpoint = JsonSerializer.Deserialize<Endpoint>(item.SerializedEndpoint),
                Favourite = item.Favourite,
            };
        }
    }
    public static class XcavatePropertyDatabase
    {
        private static XcavatePropertyDatabaseItem ToDatabaseItem(this NftWrapper wrapper) => new XcavatePropertyDatabaseItem
        {
            Key = $"{wrapper.Key.Value.Item1}-{wrapper.Key.Value.Item2}-{wrapper.Key.Value.Item3}",
            SerializedNftBase = JsonSerializer.Serialize(((INftXcavateBase)wrapper.NftBase)),
            SerializedEndpoint = JsonSerializer.Serialize(wrapper.Endpoint),
            Favourite = wrapper.Favourite
        };

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private static SQLiteAsyncConnection Database; // Is never null after InitAsync
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private static async Task InitAsync()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "XcavatePropertySQLite.db3"), SQLiteConstants.XcavateDatabaseFlags);
            var result = await Database.CreateTableAsync<XcavatePropertyDatabaseItem>().ConfigureAwait(false);
        }

        public static async Task<IEnumerable<NftWrapper>> GetPropertiesAsync()
        {
            await InitAsync().ConfigureAwait(false);
            return (await Database.Table<XcavatePropertyDatabaseItem>().ToListAsync().ConfigureAwait(false)).Select(p => (NftWrapper)p);
        }

        public static async Task<IEnumerable<NftWrapper>> GetFavouritePropertiesAsync()
        {
            await InitAsync().ConfigureAwait(false);
            return (await Database.Table<XcavatePropertyDatabaseItem>().Where(t => t.Favourite).ToListAsync().ConfigureAwait(false)).Select(p => (NftWrapper)p);
        }

        public static async Task<int> SavePropertyAsync(NftWrapper property)
        {
            Console.WriteLine(JsonSerializer.Serialize((INftXcavateBase)property.NftBase));

            var databaseItem = property.ToDatabaseItem();

            await InitAsync().ConfigureAwait(false);

            var exists = (await Database.FindAsync<XcavatePropertyDatabaseItem>(databaseItem.Key).ConfigureAwait(false)) is not null;

            if (exists)
            {
                return await Database.UpdateAsync(databaseItem).ConfigureAwait(false);
            }
            else
            {
                return await Database.InsertAsync(databaseItem).ConfigureAwait(false);
            }
        }

        public static async Task DeleteAllAsync()
        {
            await InitAsync().ConfigureAwait(false);

            await Database.DeleteAllAsync<XcavatePropertyDatabaseItem>();
        }

        public static async Task<bool> IsPropertyFavouriteAsync(NftTypeEnum type, BigInteger collectionId, BigInteger itemId)
        {
            await InitAsync().ConfigureAwait(false);

            var item = await Database.FindAsync<XcavatePropertyDatabaseItem>($"{type}-{collectionId}-{itemId}").ConfigureAwait(false);

            if (item is null)
            {
                return false;
            }

            return item.Favourite;
        }
    }
}
