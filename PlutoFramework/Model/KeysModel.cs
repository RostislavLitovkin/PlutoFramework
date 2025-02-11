using Substrate.NetApi;
using Substrate.NetApi.Model.Types;
using Polkadot.NetApi.Generated.Model.sp_core.crypto;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Substrate.NET.Wallet;
using Substrate.NET.Schnorrkel.Keys;
using PlutoFramework.Components.Password;

namespace PlutoFramework.Model
{
    public enum AccountType
    {
        None,
        Mnemonic,
        PrivateKey,
        Json,
    }
    public class KeysModel
    {
        // Can change with future updates to substrate
        private const ExpandMode DEFAULT_EXPAND_MODE = ExpandMode.Ed25519;
        public static async Task GenerateNewAccountAsync(string password)
        {
            string mnemonics = MnemonicsModel.GenerateMnemonics();

            await GenerateNewAccountAsync(mnemonics, password);
        }

        private static async Task RegisterBiometricAuthenticationAsync()
        {
            Preferences.Set(PreferencesModel.BIOMETRICS_ENABLED, false);

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

        public static async Task GenerateNewAccountAsync(string mnemonics, string password, string accountVariant = "")
        {
            await RegisterBiometricAuthenticationAsync();

            Account account = MnemonicsModel.GetAccountFromMnemonics(mnemonics);

            if (accountVariant.StartsWith("kilt"))
            {
                Preferences.Set(
                     PreferencesModel.PUBLIC_KEY + accountVariant,
                     $"did:kilt:{Utils.GetAddressFrom(Utils.GetPublicKeyFrom(account.Value), 38)}"
                );
            }
            else
            {
                Preferences.Set(
                     PreferencesModel.PUBLIC_KEY + accountVariant,
                     account.Value
                );
            }

            await SecureStorage.Default.SetAsync(
                PreferencesModel.MNEMONICS + accountVariant,
                 mnemonics
            );

            await SecureStorage.Default.SetAsync(
                PreferencesModel.PASSWORD,
                password
            );

            Preferences.Set(PreferencesModel.PRIVATE_KEY_EXPAND_MODE + accountVariant, (int)DEFAULT_EXPAND_MODE);

            Preferences.Set(PreferencesModel.ACCOUNT_TYPE + accountVariant, AccountType.Mnemonic.ToString());
        }

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

            Preferences.Set(PreferencesModel.PRIVATE_KEY_EXPAND_MODE + accountVariant, (int)ExpandMode.Ed25519);

            Preferences.Set(PreferencesModel.ACCOUNT_TYPE + accountVariant, AccountType.PrivateKey.ToString());
        }

        public static async Task GenerateNewAccountFromJsonAsync(string json, string accountVariant = "")
        {
            var viewModel = DependencyService.Get<EnterPasswordPopupViewModel>();

            viewModel.IsVisible = true;

            string correctPassword = "";
            string publicKey = "";

            for (int i = 0; i < 5; i++)
            {
                var password = await viewModel.EnteredPassword.Task;

                if (password is null)
                {
                    return;
                }

                Wallet wallet = MnemonicsModel.ImportJson(json, password);

                if (wallet.IsUnlocked)
                {
                    correctPassword = password.ToString();
                    publicKey = wallet.Account.Value;

                    viewModel.SetToDefault();

                    break;
                }

                viewModel.ErrorIsVisible = true;

                viewModel.EnteredPassword = new();

                if (i == 4)
                {
                    viewModel.SetToDefault();
                    throw new Exception("Failed to authenticate");
                }
            }

            Preferences.Set(
                 PreferencesModel.PUBLIC_KEY + accountVariant,
                 publicKey
            );

            await SecureStorage.Default.SetAsync(
                PreferencesModel.PASSWORD + accountVariant,
                correctPassword
            );

            await SecureStorage.Default.SetAsync(
                 PreferencesModel.JSON_ACCOUNT + accountVariant,
                 json
            );

            Preferences.Set(PreferencesModel.ACCOUNT_TYPE + accountVariant, AccountType.Json.ToString());
        }

        public static string GetSubstrateKey(string accountVariant = "")
        {
            // publicKey should be always saved
            return Preferences.Get(PreferencesModel.PUBLIC_KEY + accountVariant, "Error - no pubKey");
        }

        public static string GetPublicKey()
        {
            // publicKey should be always saved
            var array = GetPublicKeyBytes();
            return Utils.Bytes2HexString(array);
        }

        public static byte[] GetPublicKeyBytes()
        {
            // publicKey should be always saved
            return Utils.GetPublicKeyFrom(GetSubstrateKey());
        }

        public static async Task<string?> GetMnemonicsOrPrivateKeyAsync(string accountVariant = "")
        {
            var accountType = (AccountType)Enum.Parse(typeof(AccountType), Preferences.Get(PreferencesModel.ACCOUNT_TYPE + accountVariant, AccountType.None.ToString()));

            var biometricsEnabled = Preferences.Get(PreferencesModel.BIOMETRICS_ENABLED, false);

            var request = new AuthenticationRequestConfiguration("Biometric verification", "..");
            FingerprintAuthenticationResult result;

            if (biometricsEnabled)
            {
                result = await CrossFingerprint.Current.AuthenticateAsync(request).ConfigureAwait(false);
            }
            else
            {
                result = new FingerprintAuthenticationResult
                {
                    Status = FingerprintAuthenticationResultStatus.Denied,
                };
            }

            if (!result.Authenticated)
            {

                var viewModel = DependencyService.Get<EnterPasswordPopupViewModel>();

                viewModel.IsVisible = true;

                var correctPassword = await SecureStorage.Default.GetAsync(PreferencesModel.PASSWORD).ConfigureAwait(false) ?? throw new ArgumentNullException("Password was not setup");

                for (int i = 0; i < 5; i++)
                {
                    var password = await viewModel.EnteredPassword.Task;

                    if (password is null)
                    {
                        viewModel.SetToDefault();
                        throw new Exception("Failed to authenticate");
                    }

                    if (password == correctPassword)
                    {
                        viewModel.SetToDefault();

                        break;
                    }

                    viewModel.ErrorIsVisible = true;

                    viewModel.EnteredPassword = new();

                    if (i == 4)
                    {
                        viewModel.SetToDefault();
                        throw new Exception("Failed to authenticate");
                    }
                }
            }

            return accountType switch {
                AccountType.Mnemonic => await SecureStorage.Default.GetAsync(PreferencesModel.MNEMONICS + accountVariant).ConfigureAwait(false),
                AccountType.PrivateKey => await SecureStorage.Default.GetAsync(PreferencesModel.PRIVATE_KEY + accountVariant).ConfigureAwait(false),
                AccountType.Json => await SecureStorage.Default.GetAsync(PreferencesModel.JSON_ACCOUNT + accountVariant).ConfigureAwait(false),
                _ => null
            };
        }

        public static async Task<Account?> GetAccountAsync(string accountVariant = "")
        {
            var expandMode = Preferences.Get(PreferencesModel.PRIVATE_KEY_EXPAND_MODE + accountVariant, (int)DEFAULT_EXPAND_MODE) switch
            {
                0 => ExpandMode.Uniform,
                1 => ExpandMode.Ed25519,
                _ => DEFAULT_EXPAND_MODE,
            };

            try
            {
                var secret = await GetMnemonicsOrPrivateKeyAsync();

                if (secret is null)
                {
                    return null;
                }

                var accountType = (AccountType)Enum.Parse(typeof(AccountType), Preferences.Get(PreferencesModel.ACCOUNT_TYPE + accountVariant, AccountType.None.ToString()));

                return accountType switch
                {
                    AccountType.Mnemonic => MnemonicsModel.GetAccountFromMnemonics(secret),
                    AccountType.PrivateKey => GetAccountFromPrivateKey(secret, expandMode),
                    AccountType.Json => GetAccountFromJson(secret, await SecureStorage.Default.GetAsync(PreferencesModel.PASSWORD).ConfigureAwait(false) ?? ""),
                    _ => null
                };
            }
            catch
            {
                return null;
            }
        }

        private static Account GetAccountFromPrivateKey(string secret, ExpandMode expandMode)
        {
            var miniSecret = new MiniSecret(Utils.HexToByteArray(secret), expandMode);

            return Account.Build(
                KeyType.Sr25519,
                miniSecret.ExpandToSecret().ToEd25519Bytes(),
                miniSecret.GetPair().Public.Key);
        }
        private static Account? GetAccountFromJson(string json, string password)
        {
            var keyring = new Substrate.NET.Wallet.Keyring.Keyring();

            var wallet = keyring.AddFromJson(json);

            if(!wallet.Unlock(password))
            {
                return null;
            }

            return wallet.Account;
        }
        public static AccountId32 GetAccountId32()
        {
            var accountId = new AccountId32();
            accountId.Create(GetPublicKeyBytes());

            return accountId;
        }

        public static void RemoveAccount(string accountVariant = "")
        {
            Preferences.Remove(PreferencesModel.PUBLIC_KEY + accountVariant);
            Preferences.Remove(PreferencesModel.PRIVATE_KEY_EXPAND_MODE + accountVariant);
            SecureStorage.Default.Remove(PreferencesModel.PRIVATE_KEY + accountVariant);
            SecureStorage.Default.Remove(PreferencesModel.MNEMONICS + accountVariant);
            SecureStorage.Default.Remove(PreferencesModel.JSON_ACCOUNT + accountVariant);
            Preferences.Remove(PreferencesModel.ACCOUNT_TYPE + accountVariant);
        }
    }
}

