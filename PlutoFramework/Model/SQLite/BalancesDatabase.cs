using PlutoFramework.Model.Constants;
using SQLite;
using System.Text.Json;
using PlutoFramework.Types;

namespace PlutoFramework.Model.SQLite
{
    public record AssetDatabaseItem
    {
        [PrimaryKey]
        [Unique]
        public string Key { get; set; } = "";
        public string Serialized { get; set; } = "";

        public static implicit operator Asset(AssetDatabaseItem item)
        {
            var asset = JsonSerializer.Deserialize<Asset>(item.Serialized);

            return asset;
        }
    }

    public class BalancesDatabaseSaver : IBalancesDatabaseSaver
    {
        public Task<int> SaveBalanceAsync(Asset asset)
        {
            return BalancesDatabase.SaveBalanceAsync(asset);
        }
    }

    public static class BalancesDatabase
    {
        private static AssetDatabaseItem ToDatabaseItem(this Asset asset) => new AssetDatabaseItem
        {
            Key = $"{asset.Endpoint.Key}-{asset.Pallet}-{asset.AssetId}",
            Serialized = JsonSerializer.Serialize(asset),
        };

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private static SQLiteAsyncConnection Database; // Is never null after InitAsync
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private static async Task InitAsync()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "BalancesSQLite.db3"), SQLiteConstants.BalancesDatabaseFlags);

            var result = await Database.CreateTableAsync<AssetDatabaseItem>().ConfigureAwait(false);
        }

        public static async Task<IEnumerable<Asset>> GetBalancesAsync()
        {
            await InitAsync().ConfigureAwait(false);
            return (await Database.Table<AssetDatabaseItem>().ToListAsync().ConfigureAwait(false)).Select(p => (Asset)p);
        }

        public static async Task<int> SaveBalanceAsync(Asset asset)
        {
            var databaseItem = asset.ToDatabaseItem();

            await InitAsync().ConfigureAwait(false);

            var exists = (await Database.FindAsync<AssetDatabaseItem>(databaseItem.Key).ConfigureAwait(false)) is not null;

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

            await Database.DeleteAllAsync<AssetDatabaseItem>();
        }
    }
}
