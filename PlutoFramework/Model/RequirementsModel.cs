using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using PlutoFramework.Components.Account;
using PlutoFramework.Components.Kilt;
using PlutoFramework.Components.Password;
using PlutoFramework.Components.Xcavate;
using PlutoFramework.Constants;
using PlutoFramework.Model.SQLite;
using PlutoFramework.Model.Sumsub;
using PlutoFramework.Model.Xcavate;
using PlutoFrameworkCore.Xcavate;
using XcavatePaseo.NetApi.Generated;

namespace PlutoFramework.Model
{
    public record AuthenticationResult
    {
        public required string Password { get; set; }
        public required bool Value { get; set; }
    }

    public class RequirementsModel
    {
        public static Task<bool> CheckRequirementsAsync()
        {
            return CheckRequirementsAsync(CancellationToken.None);
        }

        public static async Task<bool> CheckRequirementsAsync(CancellationToken token)
        {
            if (!CheckAccountExists())
            {
                return false;
            }

            if (!CheckDidExists())
            {
                return false;
            }

            #region Sumsub
            var address = KeysModel.GetSubstrateKey();

            var sumsubSecrets = SumsubSecretModel.GetSecrets();

            var applicantData = await SumsubModel.GetApplicantDataAsync(
                address,
                sumsubSecrets.SecretKey,
                sumsubSecrets.AppToken,
                token
            );

            if (applicantData is null)
            {
                var userProfileNotCreatedPopupViewModel = DependencyService.Get<UserProfileNotCreatedPopupViewModel>();

                userProfileNotCreatedPopupViewModel.IsVisible = true;

                return false;
            }
            #endregion

            #region Whitelist
            var xcavateClient = await SubstrateClientModel.GetOrAddSubstrateClientAsync(EndpointEnum.XcavatePaseo, token);

            var user = await XcavateUserDatabase.GetUserInformationAsync();

            if (user is null)
            {
                return false;
            }

            var verification = await WhitelistModel.IsWhitelistedAsync((SubstrateClientExt)xcavateClient.SubstrateClient, user.Role.ToWhitelistRole(), address, CancellationToken.None);

            switch(verification)
            {
                case VerificationEnum.Verified:

                    break;

                default:

                    var notWhitelistedPopupViewModel = DependencyService.Get<NotWhitelistedPopupViewModel>();

                    notWhitelistedPopupViewModel.IsVisible = true;

                    return false;
            }

            #endregion

            return true;
        }

        public static bool CheckAccountExists()
        {
            if (!KeysModel.HasSubstrateKey())
            {
                var noAccountPopupViewModel = DependencyService.Get<NoAccountPopupViewModel>();

                noAccountPopupViewModel.IsVisible = true;

                return false;
            }

            return true;
        }

        public static bool CheckDidExists()
        {
            if (!KeysModel.HasSubstrateKey(accountVariant: "kilt1"))
            {
                var noDidPopupViewModel = DependencyService.Get<NoDidPopupViewModel>();

                noDidPopupViewModel.IsVisible = true;

                return false;
            }

            return true;
        }

        public static async Task<AuthenticationResult> CheckAuthenticationAsync(string passwordStorageKey = PreferencesModel.PASSWORD)
        {
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

            var correctPassword = await SecureStorage.Default.GetAsync(passwordStorageKey).ConfigureAwait(false) ?? throw new ArgumentNullException("Password was not setup");

            if (!result.Authenticated || result.Status == FingerprintAuthenticationResultStatus.Denied)
            {
                var viewModel = DependencyService.Get<EnterPasswordPopupViewModel>();

                viewModel.IsVisible = true;

                for (int i = 0; i < 5; i++)
                {
                    var password = await viewModel.EnteredPassword.Task;

                    viewModel.EnteredPassword = new();

                    if (password is null)
                    {
                        viewModel.SetToDefault();
                        throw new Exception("Failed to authenticate");
                    }

                    if (password == correctPassword)
                    {
                        viewModel.SetToDefault();

                        return new AuthenticationResult
                        {
                            Value = true,
                            Password = correctPassword,
                        };
                    }

                    viewModel.ErrorIsVisible = true;

                    if (i == 4)
                    {
                        viewModel.SetToDefault();

                        return new AuthenticationResult
                        {
                            Value = false,
                            Password = "-",
                        };
                    }
                }
            }

            return new AuthenticationResult
            {
                Value = true,
                Password = correctPassword,
            };
        }
    }
}
