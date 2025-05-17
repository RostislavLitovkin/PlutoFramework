using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Components.DAppConnectionView;
using PlutoFramework.Components.Extrinsic;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using PlutoFramework.Model.AjunaExt;
using PlutoFramework.Model.Xcavate;
using PlutoFramework.Types;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types;
using System.Collections.ObjectModel;
using AssetKey = (PlutoFramework.Constants.EndpointEnum, PlutoFramework.Types.AssetPallet, System.Numerics.BigInteger);
using NftKey = (UniqueryPlus.NftTypeEnum, System.Numerics.BigInteger, System.Numerics.BigInteger);
using XcavatePropertyKey = (PlutoFramework.Constants.EndpointEnum, uint);

namespace PlutoFramework.Components.TransactionAnalyzer
{
    public partial class TransactionAnalyzerConfirmationViewModel : ObservableObject, IPopup, ISetToDefault
    {
        [ObservableProperty]
        private ObservableCollection<ExtrinsicEvent> extrinsicEvents = new ObservableCollection<ExtrinsicEvent>();

        [ObservableProperty]
        private bool isVisible;

        [ObservableProperty]
        private string dAppName;

        [ObservableProperty]
        private string dAppIcon;

        [ObservableProperty]
        private bool isDAppViewVisible;

        [ObservableProperty]
        private Endpoint endpoint;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ProcessedPalletCallName))]
        private string palletCallName;

        public string ProcessedPalletCallName => DefaultAppConfiguration.TRANSACTION_ANALYZER_PALLET_CALL_NAME_SUBSTITUTION ?? PalletCallName;

        [ObservableProperty]
        private TempPayload payload;


        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ExtrinsicFailedIsVisible))]
        [NotifyPropertyChangedFor(nameof(ProcessedExtrinsicFailedMessage))]
        private string extrinsicFailedMessage = "";

        public string ProcessedExtrinsicFailedMessage => ExtrinsicFailedMessage.Substring(ExtrinsicFailedMessage.IndexOf(':') + 1);

        public bool ExtrinsicFailedIsVisible => ExtrinsicFailedMessage != "";


        [ObservableProperty]
        private ButtonStateEnum confirmButtonState = ButtonStateEnum.Enabled;

        [ObservableProperty]
        private string estimatedFee = "Estimated fee: Loading";

        // Estimated time should be calculated based the client
        [ObservableProperty]
        private string estimatedTime = "Estimated time: 6 sec";

        [ObservableProperty]
        private Func<Task> onConfirm;

        public async Task LoadAsync(SubstrateClientExt client, Method method, bool showDAppView = false, Func<Task>? onConfirm = null, CancellationToken token = default)
        {
            var account = new ChopsticksMockAccount();
            account.Create(KeyType.Sr25519, KeysModel.GetPublicKeyBytes());

            #region Temp
            var extrinsic = await client.GetTempUnCheckedExtrinsicAsync(method, account, lifeTime: 64, token: token);
            #endregion

            await LoadAsync(client, extrinsic, showDAppView, onConfirm);
        }
        public async Task LoadAsync(SubstrateClientExt client, TempUnCheckedExtrinsic unCheckedExtrinsic, bool showDAppView, Func<Task>? onConfirm = null, RuntimeVersion? runtimeVersion = null)
        {
            CancellationToken token = CancellationToken.None;

            OnConfirm = onConfirm is null ? OnConfirmClickedAsync : onConfirm;
            var analyzedOutcomeViewModel = DependencyService.Get<AnalyzedOutcomeViewModel>();

            Method method = unCheckedExtrinsic.Method;

            #region Basic Info
            Endpoint = client.Endpoint;
            Payload = unCheckedExtrinsic.GetPayload(runtimeVersion ?? client.SubstrateClient.RuntimeVersion);

            var dAppConnectionViewModel = DependencyService.Get<DAppConnectionViewModel>();



            if (showDAppView) {
                DAppName = dAppConnectionViewModel.Name;
                DAppIcon = dAppConnectionViewModel.Icon;
                IsDAppViewVisible = dAppConnectionViewModel.IsVisible;
            }
            else
            {
                /// Show just the endpoint
            }

            try
            {
                (var pallet, var call) = PalletCallModel.GetPalletAndCallName(client, method.ModuleIndex, method.CallIndex);

                PalletCallName = pallet + " " + call;
            }
            catch (Exception ex)
            {
                PalletCallName = "Unknown call";
            }
            #endregion

            IsVisible = true;

            #region other awaitable things
            try
            {
                var account = new ChopsticksMockAccount();
                account.Create(KeyType.Sr25519, KeysModel.GetPublicKeyBytes());

                unCheckedExtrinsic.AddPayloadSignature(await account.SignAsync(Payload.Encode()));

                var header = await client.SubstrateClient.Chain.GetHeaderAsync(null, CancellationToken.None);

                var xcmDestinationEndpointKey = XcmModel.IsMethodXcm(client.Endpoint, unCheckedExtrinsic.Method);

                Dictionary<string, Dictionary<AssetKey, Asset>> currencyChanges = new Dictionary<string, Dictionary<AssetKey, Asset>>();
                Dictionary<string, Dictionary<NftKey, NftAssetWrapper>> nftChanges = new Dictionary<string, Dictionary<NftKey, NftAssetWrapper>>();
                Dictionary<string, Dictionary<XcavatePropertyKey, PropertyTokenOwnershipChangeInfo>> xcavatePropertyChanges = new();

                if (xcmDestinationEndpointKey is null)
                {
                    var events = await ChopsticksModel.SimulateCallAsync(client.Endpoint.URLs[0], unCheckedExtrinsic.Encode(), header.Number.Value, account.Value);

                    if (!(events is null))
                    {
                        var extrinsicDetails = await EventsModel.GetExtrinsicEventsForClientAsync(client, extrinsicIndex: events.ExtrinsicIndex, events.Events, blockNumber: 0, CancellationToken.None);

                        ExtrinsicEvents = new ObservableCollection<ExtrinsicEvent>(extrinsicDetails.Events);

                        var extrinsicResult = TransactionAnalyzerModel.GetExtrinsicResult(extrinsicDetails.Events);

                        if (extrinsicResult == ExtrinsicResult.Failed)
                        {
                            ExtrinsicFailedMessage = TransactionAnalyzerModel.GetExtrinsicFailedMessage(extrinsicDetails.Events);
                            ConfirmButtonState = ButtonStateEnum.Warning;
                        }

                        currencyChanges = await TransactionAnalyzerModel.AnalyzeCurrencyChangesInEventsAsync(client, extrinsicDetails.Events, client.Endpoint, CancellationToken.None);

                        nftChanges = await TransactionAnalyzerModel.AnalyzeNftChangesInEventsAsync(client, extrinsicDetails.Events, client.Endpoint, CancellationToken.None);

                        xcavatePropertyChanges = await TransactionAnalyzerModel.AnalyzeXcavatePropertyChangesInEventsAsync(client, extrinsicDetails.Events, client.Endpoint, CancellationToken.None);
                    }
                }
                else
                {
                    var xcmResult = await ChopsticksModel.SimulateXcmCallAsync(
                        client.Endpoint.URLs[0],
                        Endpoints.GetEndpointDictionary[(EndpointEnum)xcmDestinationEndpointKey].URLs[0],
                        unCheckedExtrinsic.Encode()
                    );

                    Console.WriteLine("XCM result received :)");

                    var destionationClient = await SubstrateClientModel.GetOrAddSubstrateClientAsync((EndpointEnum)xcmDestinationEndpointKey, token);

                    if (!(xcmResult is null))
                    {
                        var fromExtrinsicDetails = await EventsModel.GetExtrinsicEventsForClientAsync(client, extrinsicIndex: xcmResult.FromEvents.ExtrinsicIndex, xcmResult.FromEvents.Events, blockNumber: 0, CancellationToken.None);

                        var toExtrinsicDetails = await EventsModel.GetExtrinsicEventsForClientAsync(destionationClient, extrinsicIndex: null, xcmResult.ToEvents.Events, blockNumber: 0, CancellationToken.None);

                        var fromCurrencyChanges = await TransactionAnalyzerModel.AnalyzeCurrencyChangesInEventsAsync(client, fromExtrinsicDetails.Events, client.Endpoint, CancellationToken.None);

                        currencyChanges = await TransactionAnalyzerModel.AnalyzeCurrencyChangesInEventsAsync(destionationClient, toExtrinsicDetails.Events, destionationClient.Endpoint, CancellationToken.None, existingCurrencyChanges: fromCurrencyChanges);

                        var fromNftChanges = await TransactionAnalyzerModel.AnalyzeNftChangesInEventsAsync(client, fromExtrinsicDetails.Events, client.Endpoint, CancellationToken.None);

                        nftChanges = await TransactionAnalyzerModel.AnalyzeNftChangesInEventsAsync(destionationClient, toExtrinsicDetails.Events, destionationClient.Endpoint, CancellationToken.None, existingNftChanges: fromNftChanges);

                        var fromXcavatePropertyChanges = await TransactionAnalyzerModel.AnalyzeXcavatePropertyChangesInEventsAsync(client, fromExtrinsicDetails.Events, client.Endpoint, CancellationToken.None);

                        xcavatePropertyChanges = await TransactionAnalyzerModel.AnalyzeXcavatePropertyChangesInEventsAsync(client, toExtrinsicDetails.Events, client.Endpoint, CancellationToken.None, existingPropertyChanges: fromXcavatePropertyChanges);

                    }
                }
                ;

                analyzedOutcomeViewModel.UpdateAssetChanges(currencyChanges);
                analyzedOutcomeViewModel.UpdateNftChanges(nftChanges);
                await analyzedOutcomeViewModel.UpdateXcavatePropertyChanges(xcavatePropertyChanges);

                analyzedOutcomeViewModel.Loading = "";

                EstimatedFee = FeeModel.GetEstimatedFeeString(currencyChanges.ContainsKey("fee") ? currencyChanges["fee"].First().Value : null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                analyzedOutcomeViewModel.Loading = "Failed";

                EstimatedFee = "Estimated fee: Unknown";
            }
            #endregion
        }

        public static async Task OnConfirmClickedAsync()
        {
            var account = await KeysModel.GetAccountAsync();

            if (account is null)
            {
                return;
            }

            var transactionAnalyzerConfirmationViewModel = DependencyService.Get<TransactionAnalyzerConfirmationViewModel>();

            var clientExt = await Model.SubstrateClientModel.GetOrAddSubstrateClientAsync(transactionAnalyzerConfirmationViewModel.Endpoint.Key, CancellationToken.None);

            try
            {
                string extrinsicId = await clientExt.SubmitExtrinsicAsync(transactionAnalyzerConfirmationViewModel.Payload.Call, account, token: CancellationToken.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed at confirm clicked");
                Console.WriteLine(ex);
            }

            transactionAnalyzerConfirmationViewModel.IsVisible = false;
        }

        public void LoadUnknown(TempUnCheckedExtrinsic unCheckedExtrinsic, RuntimeVersion runtimeVersion, Func<Task> onConfirm)
        {
            OnConfirm = onConfirm;

            var analyzedOutcomeViewModel = DependencyService.Get<AnalyzedOutcomeViewModel>();

            Method method = unCheckedExtrinsic.Method;

            #region Basic Info
            Endpoint = new Endpoint
            {
                Name = "Unknown",
                Key = EndpointEnum.None,
                URLs = new string[1] { "ws://127.0.0.1:8002" },
                Icon = "substrate.png",
                DarkIcon = "substrate.png",
                Unit = "",
                Decimals = 0,
                SS58Prefix = 42,
                ChainType = ChainType.Substrate,
                ParachainId = new ParachainId
                {
                    Relay = RelayChain.Other,
                    Chain = Chain.Solo,
                    Id = null,
                }
            };

            Payload = unCheckedExtrinsic.GetPayload(runtimeVersion);


            var dAppConnectionViewModel = DependencyService.Get<DAppConnectionViewModel>();

            IsDAppViewVisible = dAppConnectionViewModel.IsVisible;

            if (dAppConnectionViewModel.IsVisible)
            {
                DAppName = dAppConnectionViewModel.Name;
                DAppIcon = dAppConnectionViewModel.Icon;
            }
            else
            {
                /// Show just the endpoint
            }

            PalletCallName = "Unknown call";

            analyzedOutcomeViewModel.Loading = "Unknown";

            EstimatedFee = "Estimated fee: Unknown";

            #endregion

            IsVisible = true;
        }

        public void SetToDefault()
        {
            IsVisible = false;
            DAppName = "";
            DAppIcon = "";
            IsDAppViewVisible = false;
            PalletCallName = "";
            Payload = null;
            EstimatedFee = "Estimated fee: Loading";
            EstimatedTime = "Estimated time: 6 sec";
            OnConfirm = null;
            ExtrinsicFailedMessage = "";
            ConfirmButtonState = ButtonStateEnum.Enabled;

            var analyzedOutcomeViewModel = DependencyService.Get<AnalyzedOutcomeViewModel>();
            analyzedOutcomeViewModel.SetToDefault();
        }

        [RelayCommand]
        public async Task ExpandExtrinsicInfoAsync()
        {
            CancellationToken token = CancellationToken.None;

            Console.WriteLine("Clicked on expand extrinsic info");
            var methodUnified = PalletCallModel.GetMethodUnified(await SubstrateClientModel.GetOrAddSubstrateClientAsync(Endpoint.Key, token), Payload.Call);

            var viewModel = new CallDetailViewModel {
                PalletCallName = methodUnified.PalletName + "." + methodUnified.EventName,
                CallParameters = new ObservableCollection<EventParameter>(methodUnified.Parameters),
                Endpoint = Endpoint,
                ExtrinsicEvents = ExtrinsicEvents,
            };

            await Application.Current.MainPage.Navigation.PushAsync(new CallDetailPage(viewModel));
        }
    }
}
