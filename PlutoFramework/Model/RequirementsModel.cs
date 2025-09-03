using PlutoFramework.Components.Account;
using PlutoFramework.Components.Kilt;
using PlutoFramework.Components.Xcavate;
using PlutoFramework.Constants;
using PlutoFramework.Model.SQLite;
using PlutoFramework.Model.Sumsub;
using PlutoFramework.Model.Xcavate;
using PlutoFrameworkCore.Xcavate;
using XcavatePaseo.NetApi.Generated;

namespace PlutoFramework.Model
{
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
                await NavigationModel.NavigateToKYC.Invoke();

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
    }
}
