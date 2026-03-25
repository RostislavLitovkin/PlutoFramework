using PlutoFrameworkCore;

namespace PlutoFramework.Model
{
    public class PlutoSecureStorage : ISecureStorage, IPlutoSecureStorage
    {
        public async Task<SecretResult> GetWithPasswordAsync(string key, string passwordKey)
        {
            var authentication = await RequirementsModel.CheckAuthenticationAsync(passwordKey);

            if (!authentication.Value)
            {
                return new SecretResult
                {
                    Password = "-",
                    Value = null
                };
            }

            return new SecretResult
            {
                Password = authentication.Password,
                Value = await SecureStorage.Default.GetAsync(key).ConfigureAwait(false)
            };
        }

        public async Task<string?> GetAsync(string key)
        {
            var result = await GetWithPasswordAsync(key, PreferencesModel.PASSWORD);

            return result.Value;
        }


        public bool Remove(string key) => SecureStorage.Default.Remove(key);

        public void RemoveAll() => SecureStorage.Default.RemoveAll();

        public Task SetAsync(string key, string value) => SecureStorage.Default.SetAsync(key, value);
    }
}
