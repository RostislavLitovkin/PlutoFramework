using PlutoFramework.Components.Account;
using PlutoFramework.Components.Kilt;
using PlutoFramework.Model.Sumsub;

namespace PlutoFramework.Model
{
    public class AccountModel
    {
        public static bool CheckRequirements()
        {
            if (!KeysModel.HasSubstrateKey())
            {
                var noAccountPopupViewModel = DependencyService.Get<NoAccountPopupModel>();

                noAccountPopupViewModel.IsVisible = true;

                return false;
            }

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
