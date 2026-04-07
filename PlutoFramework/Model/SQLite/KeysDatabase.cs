using PlutoFramework.Model.Constants;
using PlutoFrameworkCore.Keys;
using SQLite;
using System.Text.Json;

namespace PlutoFramework.Model.SQLite
{
    public record KeysDatabaseItem
    {
        [PrimaryKey]
        public string Key { get; set; } = "";

        public string Serialized { get; set; } = "";

        public static implicit operator GenericLockedKey(KeysDatabaseItem item)
        {
            return JsonSerializer.Deserialize<GenericLockedKey>(item.Serialized)!;
        }
    }

    public static class KeysDatabase
    {
        private static KeysDatabaseItem ToDatabaseItem(this GenericLockedKey wrapper) => new KeysDatabaseItem
        {
            Key = $"{wrapper.Type}-{wrapper.PublicKey}",
            Serialized = JsonSerializer.Serialize(wrapper),
        };

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private static SQLiteAsyncConnection Database; // Is never null after InitAsync
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private static async Task InitAsync()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "KeysSQLite.db3"), SQLiteConstants.KeysDatabaseFlags);
            var result = await Database.CreateTableAsync<KeysDatabaseItem>().ConfigureAwait(false);
        }

        public static async Task<IEnumerable<GenericLockedKey>> GetAllKeysAsync()
        {
            await InitAsync().ConfigureAwait(false);
            return (await Database.Table<KeysDatabaseItem>().ToListAsync().ConfigureAwait(false)).Select(p => (GenericLockedKey)p);
        }

        public static async Task<int> SaveKeyAsync(GenericLockedKey item)
        {
            var databaseItem = item.ToDatabaseItem();

            await InitAsync().ConfigureAwait(false);

            var exists = (await Database.FindAsync<KeysDatabaseItem>(databaseItem.Key).ConfigureAwait(false)) is not null;

            if (exists)
            {
                return await Database.UpdateAsync(databaseItem).ConfigureAwait(false);
            }
            else
            {
                return await Database.InsertAsync(databaseItem).ConfigureAwait(false);
            }
        }

        public static async Task DeleteKeyAsync(GenericLockedKey item)
        {
            var databaseItem = item.ToDatabaseItem();
            await InitAsync().ConfigureAwait(false);
            await Database.DeleteAsync<KeysDatabaseItem>(databaseItem.Key).ConfigureAwait(false);
        }

        public static async Task DeleteAllAsync()
        {
            await InitAsync().ConfigureAwait(false);
            await Database.DeleteAllAsync<KeysDatabaseItem>().ConfigureAwait(false);
        }
    }
}
