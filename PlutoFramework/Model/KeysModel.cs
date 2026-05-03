extern alias bc26;
using bc26::Org.BouncyCastle.Crypto.Parameters;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using PlutoFramework.Components.Password;
using PlutoFramework.Model.SQLite;
using PlutoFrameworkCore;
using PlutoFrameworkCore.AssetDidComm;
using PlutoFrameworkCore.Keys;
using Polkadot.NetApi.Generated.Model.sp_core.crypto;
using Substrate.NET.Schnorrkel.Keys;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types;

namespace PlutoFramework.Model
{
    public enum AccountType
    {
        None,
        Mnemonic,
        PrivateKey,
        Json,
    }
    public static class KeysModel
    {
        // Can change with future updates to substrate
        private const ExpandMode DEFAULT_EXPAND_MODE = ExpandMode.Ed25519;
        public static Task GenerateNewAccountAsync()
        {
            string mnemonics = MnemonicsModel.GenerateMnemonics();

            return SaveSr25519KeyAsync(mnemonics);
        }

        public static Task GenerateNewDidAsync()
        {
            string mnemonics = MnemonicsModel.GenerateMnemonics();

            return SaveDidKeyAsync(mnemonics);
        }
        public static Task GenerateNewEncryptionX25519KeyAsync()
        {
            var keyPair = X25519Model.GenerateX25519KeyPair();

            return SaveEncryptionX25519KeyAsync(keyPair.PrivateKey);
        }
        public static async Task RegisterBiometricAuthenticationAsync()
        {
            if (Preferences.Get(PreferencesModel.BIOMETRICS_ENABLED, false))
            {
                return;
            }

            try
            {
                // Set biometrics
                for (int i = 0; i < 5; i++)
                {
                    var request = new AuthenticationRequestConfiguration("Biometric verification", "..");

                    var result = await CrossFingerprint.Current.AuthenticateAsync(request);

                    if (result.Authenticated)
                    {
                        // Fingerprint set, perhaps do with it something in the future

                        Preferences.Set(PreferencesModel.BIOMETRICS_ENABLED, true);

                        break;
                    }
                }
            }
            catch
            {
                // throws exception if Authentication is not awailable
                // Instead, just password will be used
            }
        }

        public static async Task SaveSr25519KeyAsync(string mnemonics)
        {
            Account account = MnemonicsModel.GetAccountFromMnemonics(mnemonics);

            Preferences.Set(
                PreferencesModel.PUBLIC_KEY,
                account.Value
            );

            // Just get and use the same main password without asking the user again
            var password = await SecureStorage.Default.GetAsync(PreferencesModel.PASSWORD);

            await KeysModel.SaveKeyAsync(
                publicKey: account.Value,
                secret: mnemonics,
                password: password!,
                type: KeyTypeEnum.Sr25519
            );
        }

        public static async Task SaveDidKeyAsync(string mnemonics)
        {
            Account account = MnemonicsModel.GetAccountFromMnemonics(mnemonics);

            // Just get and use the same main password without asking the user again
            var password = await SecureStorage.Default.GetAsync(PreferencesModel.PASSWORD);

            await KeysModel.SaveKeyAsync(
                publicKey: account.Value,
                secret: mnemonics,
                password: password!,
                type: KeyTypeEnum.Did
            );
        }

        [Obsolete("For migration purposes only")]
        public static async Task GenerateNewAccountFromPrivateKeyAsync(string privateKey, string accountVariant = "")
        {
            var miniSecret = new MiniSecret(Utils.HexToByteArray(privateKey), ExpandMode.Ed25519);

            Account account = Account.Build(
                KeyType.Sr25519,
                miniSecret.ExpandToSecret().ToEd25519Bytes(),
                miniSecret.GetPair().Public.Key
            );

            await SecureStorage.Default.SetAsync(
                 PreferencesModel.PRIVATE_KEY + accountVariant,
                 privateKey
            );

            Preferences.Set(
                 PreferencesModel.PUBLIC_KEY + accountVariant,
                 account.Value
            );
        }

        public static async Task SaveJsonKeyAsync(string json)
        {
            var viewModel = DependencyService.Get<EnterPasswordPopupViewModel>();

            viewModel.IsVisible = true;

            string correctPassword = "";
            string publicKey = "";

            for (int i = 0; i < 5; i++)
            {
                var password = await viewModel.EnteredPassword.Task;

                viewModel.EnteredPassword = new();

                if (password is null)
                {
                    return;
                }

                var wallet = MnemonicsModel.ImportJson(json, password);

                if (wallet is null)
                {
                    continue;
                }

                if (wallet.IsUnlocked)
                {
                    correctPassword = password;
                    publicKey = wallet.Account.Value;

                    viewModel.SetToDefault();

                    break;
                }

                viewModel.ErrorIsVisible = true;

                if (i == 4)
                {
                    viewModel.SetToDefault();
                    throw new Exception("Failed to authenticate");
                }
            }

            Preferences.Set(
                 PreferencesModel.PUBLIC_KEY,
                 publicKey
            );

            await SecureStorage.Default.SetAsync(
                PreferencesModel.PASSWORD,
                correctPassword
            );

            await KeysModel.SaveKeyAsync(
                publicKey: publicKey,
                secret: json,
                password: correctPassword,
                type: KeyTypeEnum.PolkadotJson
            );
        }

        public static async Task SaveEncryptionX25519KeyAsync(byte[] privateKey)
        {
            var key = new X25519PrivateKeyParameters(privateKey);

            var publicKey = key.GeneratePublicKey();

            // Just get and use the same main password without asking the user again
            var password = await SecureStorage.Default.GetAsync(PreferencesModel.PASSWORD);

            await KeysModel.SaveKeyAsync(
                publicKey: Convert.ToBase64String(publicKey.GetEncoded()),
                secret: Convert.ToBase64String(privateKey),
                password: password!,
                type: KeyTypeEnum.EncryptionX25519
            );
        }

        public static async Task ImportJsonKeyAsync()
        {
            var jsonType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                { DevicePlatform.iOS, new[] { "public.json" } }, // UTType values
                { DevicePlatform.Android, new[] { "application/json" } }, // MIME type
                { DevicePlatform.WinUI, new[] { ".json" } }, // file extension
                { DevicePlatform.Tizen, new[] { "*/*" } },
                { DevicePlatform.macOS, new[] { "public.json" } }, // UTType values
                });

            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Import json account",
                FileTypes = jsonType,
            });

            if (result is null || !result.FileName.Contains(".json"))
                return;

            using var jsonStream = await result.OpenReadAsync();

            string json = StreamToString(jsonStream);

            try
            {
                await KeysModel.SaveJsonKeyAsync(json);

                await PlutoConfigurationModel.AfterAccountImportAsync();

                var toast = Toast.Make($"JSON key imported successfully.");
                await toast.Show();
            }
            catch
            {
                var toast = Toast.Make($"Failed to import JSON key.");
                await toast.Show();
            }
        }

        private static string StreamToString(Stream stream)
        {
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
        public static bool HasSubstrateKey()
        {
            return Preferences.ContainsKey(PreferencesModel.PUBLIC_KEY);
        }

        public static string GetSubstrateKey()
        {
            return Preferences.Get(PreferencesModel.PUBLIC_KEY, "Substrate key does not exist");
        }

        public static async Task<string> GetDidAddressAsync(CancellationToken token)
        {
            var dids = await KeysDatabase.GetAllKeysOfTypeAsync(KeyTypeEnum.Did);

            if (!dids.Any())
            {
                throw new Exception("Did key not found");
            }

            var did = dids.First();

            return did.PublicKey;
        }

        public static string GetPublicKey()
        {
            var array = GetPublicKeyBytes();
            return Utils.Bytes2HexString(array);
        }

        public static byte[] GetPublicKeyBytes()
        {
            return Utils.GetPublicKeyFrom(GetSubstrateKey());
        }

        public static async Task<Account?> GetAccountAsync()
        {
            var accounts = await KeysDatabase.GetAllKeysOfTypeAsync(KeyTypeEnum.Sr25519, KeyTypeEnum.PolkadotJson);

            if (!accounts.Any())
            {
                return null;
            }

            var accountLockedKey = accounts.First();

            try
            {
                var accountKey = await accountLockedKey.ToSr25519KeyAsync();

                return accountKey.Account;
            }
            catch
            {
                return null;
            }
        }

        public static async Task<Account?> GetDidAsync()
        {
            var accounts = await KeysDatabase.GetAllKeysOfTypeAsync(KeyTypeEnum.Did);

            if (!accounts.Any())
            {
                return null;
            }

            var accountLockedKey = accounts.First();

            try
            {
                var accountKey = await accountLockedKey.ToDidKeyAsync();

                return accountKey.Account;
            }
            catch
            {
                return null;
            }
        }

        public static async Task<EncryptionX25519Key?> GetX25519KeyAsync()
        {
            var accounts = await KeysDatabase.GetAllKeysOfTypeAsync(KeyTypeEnum.Did);

            if (!accounts.Any())
            {
                return null;
            }

            var accountLockedKey = accounts.First();

            try
            {
                return await accountLockedKey.ToEncryptionX25519KeyAsync();
            }
            catch
            {
                return null;
            }
        }

        public static AccountId32 GetAccountId32()
        {
            var accountId = new AccountId32();
            accountId.Create(GetPublicKeyBytes());

            return accountId;
        }

        /// <summary>
        /// Source: https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/essentials/file-saver?tabs=macos 
        /// </summary>
        public static async Task ExportJsonFileAsync(string json, CancellationToken token)
        {
            using var stream = new MemoryStream(System.Text.Encoding.Default.GetBytes(json));
            var fileSaverResult = await FileSaver.Default.SaveAsync($"{AppInfo.Current.Name.ToLower()}.json", stream, token);

            if (fileSaverResult.IsSuccessful)
            {
                await Toast.Make($"Mnemonics successfully exported.").Show(token);
            }
            else
            {
                await Toast.Make($"Failed to export.").Show(token);
            }
        }

        public static Task<IEnumerable<GenericLockedKey>> GetKeysOfTypeAsync(KeyTypeEnum type) => KeysDatabase.GetAllKeysOfTypeAsync(type);

        public static async Task<GenericLockedKey?> GetKeyOfTypeAsync(KeyTypeEnum type) => (await KeysDatabase.GetAllKeysOfTypeAsync(type)).FirstOrDefault();

        public static void RemoveAccount(string accountVariant = "")
        {
            Preferences.Remove(PreferencesModel.PUBLIC_KEY + accountVariant);
            Preferences.Remove(PreferencesModel.PRIVATE_KEY_EXPAND_MODE + accountVariant);
            SecureStorage.Default.Remove(PreferencesModel.PRIVATE_KEY + accountVariant);
            SecureStorage.Default.Remove(PreferencesModel.MNEMONICS + accountVariant);
            SecureStorage.Default.Remove(PreferencesModel.JSON_ACCOUNT + accountVariant);
            SecureStorage.Default.Remove(PreferencesModel.PASSWORD + accountVariant);
        }

        public static Task SaveKeyAsync(
            string publicKey,
            string secret,
            string password,
            KeyTypeEnum type
        )
        {
            var secretStorageKey = $"secret-{publicKey}";
            var passwordStorageKey = $"password-{publicKey}";

            var lockedKey = new GenericLockedKey
            {
                Type = type,
                PublicKey = publicKey,
                SecretStorageKey = secretStorageKey,
                PasswordStorageKey = passwordStorageKey,
            };

            return Task.WhenAll(
                SecureStorage.SetAsync(secretStorageKey, secret),
                SecureStorage.SetAsync(passwordStorageKey, password),
                KeysDatabase.SaveKeyAsync(lockedKey)
            );
        }

        public static async Task TempConvertMainKeysIntoDbAsync()
        {
            // Keys are saved in DB, no need to convert them twice
            if ((await KeysDatabase.GetAllKeysAsync()).Any())
            {
                return;
            }

            if (Preferences.ContainsKey(PreferencesModel.PUBLIC_KEY))
            {
                var accountType = (AccountType)Enum.Parse(typeof(AccountType), Preferences.Get("accountType", AccountType.None.ToString()));

                if (accountType == AccountType.Mnemonic)
                {
                    var substrateKey = Preferences.Get(PreferencesModel.PUBLIC_KEY, "");
                    var mnemonics = await SecureStorage.Default.GetAsync(PreferencesModel.MNEMONICS);
                    var password = await SecureStorage.Default.GetAsync(PreferencesModel.PASSWORD);

                    await SaveKeyAsync(
                        publicKey: substrateKey,
                        secret: mnemonics!,
                        password: password!,
                        type: KeyTypeEnum.Sr25519
                    );
                }

                if (accountType == AccountType.Json)
                {
                    var substrateKey = Preferences.Get(PreferencesModel.PUBLIC_KEY, "");
                    var json = await SecureStorage.Default.GetAsync(PreferencesModel.JSON_ACCOUNT);
                    var password = await SecureStorage.Default.GetAsync(PreferencesModel.PASSWORD);

                    await SaveKeyAsync(
                        publicKey: substrateKey,
                        secret: json!,
                        password: password!,
                        type: KeyTypeEnum.PolkadotJson
                    );
                }
            }
        }
    }
}

