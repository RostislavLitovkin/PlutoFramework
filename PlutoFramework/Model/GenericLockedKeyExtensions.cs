using PlutoFramework.Model.SQLite;
using PlutoFrameworkCore;
using PlutoFrameworkCore.Keys;

namespace PlutoFramework.Model
{
    public static class GenericLockedKeyExtensions
    {
        public static Task RemoveAsync(this GenericLockedKey key)
        {
            PlutoConfigurationModel.SecureStorage.Remove(key.SecretStorageKey);

            if (key.PasswordStorageKey != PreferencesModel.PASSWORD)
            {
                PlutoConfigurationModel.SecureStorage.Remove(key.PasswordStorageKey);
            }

            return KeysDatabase.DeleteKeyAsync(key);
        }
    }
}
