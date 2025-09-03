using FFImageLoading.Maui;
using Microcharts.Maui;
using PlutoFramework.Components.Account;
using PlutoFramework.Components.AddressView;
using PlutoFramework.Components.AssetSelect;
using PlutoFramework.Components.AzeroId;
using PlutoFramework.Components.CalamarView;
using PlutoFramework.Components.ChangeLayoutRequest;
using PlutoFramework.Components.CustomLayouts;
using PlutoFramework.Components.DAppConnection;
using PlutoFramework.Components.Extrinsic;
using PlutoFramework.Components.Fee;
using PlutoFramework.Components.Kilt;
using PlutoFramework.Components.Loading;
using PlutoFramework.Components.MessagePopup;
using PlutoFramework.Components.Mnemonics;
using PlutoFramework.Components.NavigationBar;
using PlutoFramework.Components.NetworkSelect;
using PlutoFramework.Components.Nft;
using PlutoFramework.Components.Password;
using PlutoFramework.Components.Staking;
using PlutoFramework.Components.Sumsub;
using PlutoFramework.Components.TransactionAnalyzer;
using PlutoFramework.Components.TransactionRequest;
using PlutoFramework.Components.TransferView;
using PlutoFramework.Components.Vault;
using PlutoFramework.Components.VTokens;
using PlutoFramework.Components.Xcavate;
using PlutoFramework.Components.XcavateProperty;
using PlutoFramework.Components.Xcm;
using PlutoFramework.Model;
using PlutoFramework.Model.SQLite;
using Xe.AcrylicView;
using ZXing.Net.Maui.Controls;



#if ANDROID26_0_OR_GREATER
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using PlutoFramework.Platforms.Android;
#endif

namespace PlutoFramework
{
    public static class MauiAppBuilderExtensions
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public static IServiceProvider Services { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        public static MauiAppBuilder UsePlutoFramework(this MauiAppBuilder builder)
        {
            builder
                .UseAcrylicView()
                .UseFFImageLoading()
                .UseMicrocharts()
                .UseBarcodeReader()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("dmsans.ttf", "XcavateFont");
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fontawesome-webfont.ttf", "FontAwesome");
                    fonts.AddFont("Exodar-Outline.ttf", "Exodar");
                    fonts.AddFont("FontOver.ttf", "FontOver");
                    fonts.AddFont("sourcecode.ttf", "SourceCode");
                    fonts.AddFont("samsungone700.ttf", "SamsungOne");
                    fonts.AddFont("unboundedbold.ttf", "UnboundedBold");
                });

            //https://stackoverflow.com/questions/76547461/how-to-remove-the-outline-of-entry-control-in-maui-ios
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("SetUpEntry", (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
#elif IOS || MACCATALYST

                //remove outline
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
  
#endif
            });

            AssetsModel.DatabaseSaver = new BalancesDatabaseSaver();

            CustomizeWebViewHandler();

            DependencyService.Register<TransferViewModel>();

            DependencyService.Register<DAppConnectionRequestViewModel>();

            DependencyService.Register<MessagePopupViewModel>();

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

            DependencyService.Register<NoAccountPopupViewModel>();

            DependencyService.Register<NoDidPopupViewModel>();

            DependencyService.Register<NoKYCPopupViewModel>();

            DependencyService.Register<XcavatePropertyMarketplaceViewModel>();

            DependencyService.Register<FullPageLoadingViewModel>();

            DependencyService.Register<OwnedPropertiesListViewModel>();

            DependencyService.Register<RelistPropertyTokensViewModel>();

            DependencyService.Register<XcavateNavigationBarViewModel>();

            DependencyService.Register<NotWhitelistedPopupViewModel>();

            return builder;
        }

        /// <summary>
        /// https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/webview?view=net-maui-9.0&pivots=devices-android#handle-permissions-on-android
        /// </summary>
        private static void CustomizeWebViewHandler()
        {
#if ANDROID26_0_OR_GREATER
        Microsoft.Maui.Handlers.WebViewHandler.Mapper.ModifyMapping(
            nameof(Android.Webkit.WebView.WebChromeClient),
            (handler, view, args) => handler.PlatformView.SetWebChromeClient(new WebChromeClientWithPermissions(handler)));
#endif
        }
    }


}
