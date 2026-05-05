    using System.Text.Json;
    using PlutoFrameworkCore.PushNotificationServices.Api.ApiEndpoints;
    using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

    namespace PlutoFramework.Model.DeviceSecureStorage;

    public class PushNotificationsSecureStorageService : IPushNotificationsSecureStorage
    {
        private const string KeyDeviceId = "device_id";
        private const string KeyAuthTokenPair = "auth_token_pair";
        private const string KeyIsRegistered = "device_registered";
        private const string KeyFcmTokenExpired = "fcm_token_expired";
        
        private const string InstallInitializedKey = "install_initialized";
        
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        };
        
        public async Task EnsurePerInstallIsolationAsync()
        {
            if (!Preferences.Default.ContainsKey(InstallInitializedKey))
            {
                await WipeAllAsync();

                Preferences.Default.Set(InstallInitializedKey, true);
            }
        }
        
        public async Task SaveDeviceIdAsync(string uuid)
        {
            await SecureStorage.Default.SetAsync(KeyDeviceId, uuid);
        }
        
        public async Task<string?> GetDeviceIdAsync()
        {
            try
            {
                return await SecureStorage.Default.GetAsync(KeyDeviceId);
            }
            catch
            {
                return null;
            }
        }

        public async Task SaveAuthTokenPairAsync(TokenPair pair)
        {
            var json = JsonSerializer.Serialize(pair, JsonOptions);
            await SecureStorage.Default.SetAsync(KeyAuthTokenPair, json);
        }
        
        public async Task<TokenPair?> GetAuthTokenPairAsync()
        {
            try
            {
                var json = await SecureStorage.Default.GetAsync(KeyAuthTokenPair);
                return json is null ? null : JsonSerializer.Deserialize<TokenPair>(json, JsonOptions);
            }
            catch
            {
                return null;
            }
        }
        
        public async Task SaveIsRegisteredAsync(bool registered)
        {
            await SecureStorage.Default.SetAsync(KeyIsRegistered, registered.ToString());
        }
        
        public async Task<bool?> GetIsRegisteredAsync()
        {
            try
            {
                var value = await SecureStorage.Default.GetAsync(KeyIsRegistered);
                return bool.TryParse(value, out var result) ? result : null;
            }
            catch
            {
                return null;
            }
        }
        
        public async Task SaveFcmTokenExpiredAsync(bool expired)
        {
            await SecureStorage.Default.SetAsync(KeyFcmTokenExpired, expired.ToString());
        }
        
        public async Task<bool?> GetFcmTokenExpiredAsync()
        {
            try
            {
                var value = await SecureStorage.Default.GetAsync(KeyFcmTokenExpired);
                return bool.TryParse(value, out var result) ? result : null;
            }
            catch
            {
                return null;
            }
        }
        
        private static async Task WipeAllAsync()
        {
            try
            {
                SecureStorage.Default.Remove(KeyDeviceId);
                SecureStorage.Default.Remove(KeyAuthTokenPair);
                SecureStorage.Default.Remove(KeyIsRegistered);
                SecureStorage.Default.Remove(KeyFcmTokenExpired);
            }
            catch
            {
                // Intentionally ignore
            }

            await Task.CompletedTask;
        }
    }