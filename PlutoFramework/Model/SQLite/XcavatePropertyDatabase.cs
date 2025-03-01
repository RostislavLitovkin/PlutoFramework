using PlutoFramework.Model.Constants;
using PlutoFramework.Model.Xcavate;
using SQLite;
using System.Text.Json;
using UniqueryPlus.Metadata;

namespace PlutoFramework.Model.SQLite
{
    public record XcavatePropertyDatabaseItem
    {
        [PrimaryKey]
        public int Key { get; set; } = 0;
        public string ImageFileNamesSerialized { get; set; } = "[]";
        public string PropertyName { get; set; } = "";

        public static implicit operator XcavateMetadata (XcavatePropertyDatabaseItem item)
        {
            return new XcavateMetadata
            {
                Images = JsonSerializer.Deserialize<string[]>(item.ImageFileNamesSerialized)?.ToList() ?? [],
                PropertyName = item.PropertyName,
            };
        }
    }
    public static class XcavatePropertyDatabase
    {
        public static XcavatePropertyDatabaseItem ToDatabaseItem(this XcavateMetadata property)
        {
            return new XcavatePropertyDatabaseItem
            {
                ImageFileNamesSerialized = JsonSerializer.Serialize(property.Images),
                PropertyName = property.PropertyName
            };
        }
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

        public static async Task<XcavateMetadata?> GetPropertyAsync()
        {
            await InitAsync().ConfigureAwait(false);

            var item = await Database.FindAsync<XcavatePropertyDatabaseItem>(0).ConfigureAwait(false);
            if (item is null)
            {
                return null;
            }
            return item;
        }

        public static async Task<int> SavePropertyAsync(XcavateMetadata property)
        {
            var databaseItem = property.ToDatabaseItem();

            await InitAsync().ConfigureAwait(false);

            var exists = (await Database.FindAsync<XcavatePropertyDatabaseItem>(0).ConfigureAwait(false)) is not null;

            if (exists)
            {
                Console.WriteLine("Updated database item: " + databaseItem.PropertyName);
                return await Database.UpdateAsync(databaseItem).ConfigureAwait(false);
            }
            else
            {
                return await Database.InsertAsync(databaseItem).ConfigureAwait(false);
            }
        }

        public static async Task DeletePropertyAsync()
        {
            await InitAsync().ConfigureAwait(false);

            await Database.DeleteAllAsync<XcavatePropertyDatabaseItem>();
        }
    }
}
