    using System.Text.Json;
    using PlutoFrameworkCore.PushNotificationServices.Api.ApiEndpoints;
    using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

    namespace PlutoFramework.Model.DeviceSecureStorage;

    public class PushNotificationsSecureStorageService : IPushNotificationsSecureStorage
    {
        private const string KeyUuid = "installation_uuid";
        private const string KeyAuthTokenPair = "auth_token_pair";
        
        private const string KeyIsRegistered = "device_registered";
        private const string KeyFcmTokenExpired = "fcm_token_expired";
        
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        };
        
        public async Task SaveUUIDAsync(string uuid)
        {
            await SecureStorage.Default.SetAsync(KeyUuid, uuid);
        }
        
        public async Task<string?> GetUUIDAsync()
        {
            try
            {
                return await SecureStorage.Default.GetAsync(KeyUuid);
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
        
        public async Task SaveFCMTokenExpiredAsync(bool expired)
        {
            await SecureStorage.Default.SetAsync(KeyFcmTokenExpired, expired.ToString());
        }
        
        public async Task<bool?> GetFCMTokenExpiredAsync()
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
    }