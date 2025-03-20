using PlutoFramework.Components.ConnectionRequestView;
using PlutoFramework.Components.MessagePopup;
using PlutoFramework.Components.NetworkSelect;
using PlutoFramework.Components.TransactionRequest;
using PlutoFramework.Components.TransferView;
using PlutoFramework.Components.DAppConnectionView;
using PlutoFramework.Components.AddressView;
using PlutoFramework.Components.CalamarView;
using PlutoFramework.Components.Extrinsic;
using PlutoFramework.View;
using PlutoFramework.Components.Staking;
using PlutoFramework.Components.CustomLayouts;
using PlutoFramework.Components.AzeroId;
using PlutoFramework.Components.AssetSelect;
using PlutoFramework.Components.Nft;
using PlutoFramework.Components.Vault;
using PlutoFramework.Components.ChangeLayoutRequest;
using PlutoFramework.Components.NavigationBar;
using PlutoFramework.Components.Fee;
using PlutoFramework.Components.VTokens;
using PlutoFramework.Components.Xcm;
using PlutoFramework.Components.TransactionAnalyzer;
using PlutoFramework.Components.Password;
using PlutoFramework.Model;
using PlutoFramework.Components.Mnemonics;
using PlutoFramework.Components.Xcavate;
using PlutoFramework.Components.XcavateProperty;

namespace PlutoFramework;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        DependencyService.Register<TransferViewModel>();

        DependencyService.Register<ConnectionRequestViewModel>();

        DependencyService.Register<MessagePopupViewModel>();

        DependencyService.Register<TransactionRequestViewModel>();

        DependencyService.Register<AddressQrCodeViewModel>();

        DependencyService.Register<DAppConnectionViewModel>();

        DependencyService.Register<StakingRegistrationRequestViewModel>();

        DependencyService.Register<MultiNetworkSelectViewModel>();

        DependencyService.Register<ChainAddressViewModel>();

        DependencyService.Register<StakingDashboardViewModel>();

        DependencyService.Register<CalamarViewModel>();

        DependencyService.Register<ExtrinsicStatusStackViewModel>();

        DependencyService.Register<ExportPlutoLayoutQRViewModel>();

        DependencyService.Register<CustomItemViewModel>();

        DependencyService.Register<MessageSignRequestViewModel>();

        DependencyService.Register<AzeroPrimaryNameViewModel>();

        DependencyService.Register<AssetSelectViewModel>();

        DependencyService.Register<AssetSelectButtonViewModel>();

        DependencyService.Register<VaultSignViewModel>();

        DependencyService.Register<ChangeLayoutRequestViewModel>();

        DependencyService.Register<NetworkSelectPopupViewModel>();

        DependencyService.Register<NavigationBarViewModel>();

        DependencyService.Register<FeeAssetViewModel>();

        DependencyService.Register<VDotTokenViewModel>();

        DependencyService.Register<XcmTransferViewModel>();

        DependencyService.Register<XcmNetworkSelectPopupViewModel>();

        DependencyService.Register<XcmNetworkSelectViewModel>();

        DependencyService.Register<AnalyzedOutcomeViewModel>();

        DependencyService.Register<TransactionAnalyzerConfirmationViewModel>();

        DependencyService.Register<AssetInputViewModel>();

        DependencyService.Register<NftTransferViewModel>();

        DependencyService.Register<NftSellViewModel>();

        DependencyService.Register<NestNftSelectViewModel>();

        DependencyService.Register<EnterPasswordPopupViewModel>();

        DependencyService.Register<SuccessfulImportPopupViewModel>();

        DependencyService.Register<BuyPropertyTokensViewModel>();

        if (Preferences.ContainsKey(PreferencesModel.PUBLIC_KEY))
        {
            // Set Account type if it did not exist
            if (!Preferences.ContainsKey(PreferencesModel.ACCOUNT_TYPE))
            {
                Preferences.Set(
                    PreferencesModel.ACCOUNT_TYPE,
                    (Preferences.Get(PreferencesModel.USE_PRIVATE_KEY, false) ? AccountType.PrivateKey : AccountType.Mnemonic).ToString()
                );
            };

            MainPage = new AppShell();
        }
        else
        {
            KeysModel.RemoveAccount();

            Preferences.Remove(PreferencesModel.BIOMETRICS_ENABLED);

            MainPage = new OnboardingShell();
        }
    }
}
