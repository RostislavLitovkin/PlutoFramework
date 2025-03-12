using PlutoFramework.Model.Constants;
using PlutoFramework.Model.Xcavate;
using SQLite;
using System.Text.Json;

namespace PlutoFramework.Model.SQLite
{
    public record XcavateUserDatabaseItem
    {
        [PrimaryKey]
        public int Key { get; set; } = 0;
        public UserRoleEnum Role { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? SerializedDeveloperStats { get; set; }
        public string? SerializedProfilePicture { get; set; }
        public string? SerializedProfileBackground { get; set; }
        public long? AccountCreatedAt { get; set; }

        public static implicit operator XcavateUser(XcavateUserDatabaseItem item)
        {
            return new XcavateUser
            {
                ProfilePicture = XcavateFileModel.GetSavedProfilePicture(),
                ProfileBackground = XcavateFileModel.GetSavedProfileBackground(),
                Role = item.Role,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber,
                DeveloperStats = item.SerializedDeveloperStats is null ? null : JsonSerializer.Deserialize<DeveloperStats>(item.SerializedDeveloperStats),
                AccountCreatedAt = item.AccountCreatedAt is null ? null : new DateTime(item.AccountCreatedAt ?? 0)
            };
        }
    }

    public static class XcavateUserDatabase
    {
        public static XcavateUserDatabaseItem ToDatabaseItem(this XcavateUser user)
        {
            return new XcavateUserDatabaseItem
            {
                AccountCreatedAt = user.AccountCreatedAt?.Ticks,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Role = user.Role,
                SerializedDeveloperStats = user.DeveloperStats is null ? null : JsonSerializer.Serialize(user.DeveloperStats),
            };
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private static SQLiteAsyncConnection Database; // Is never null after InitAsync
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private static async Task InitAsync()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "XcavateSQLite.db3"), SQLiteConstants.XcavateDatabaseFlags);
            var result = await Database.CreateTableAsync<XcavateUserDatabaseItem>().ConfigureAwait(false);
        }

        public static async Task<XcavateUser?> GetUserInformationAsync()
        {
            await InitAsync().ConfigureAwait(false);

            var item = await Database.FindAsync<XcavateUserDatabaseItem>(0).ConfigureAwait(false);
            if (item is null)
            {
                return null;
            }
            return item;
        }

        public static async Task<int> SaveUserInformationAsync(XcavateUser item)
        {
            var databaseItem = item.ToDatabaseItem();

            await InitAsync().ConfigureAwait(false);

            var exists = (await Database.FindAsync<XcavateUserDatabaseItem>(0).ConfigureAwait(false)) is not null;

            if (exists)
            {
                return await Database.UpdateAsync(databaseItem).ConfigureAwait(false);
            }
            else
            {
                return await Database.InsertAsync(databaseItem).ConfigureAwait(false);
            }
        }
    }
}
