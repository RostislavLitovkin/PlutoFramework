using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.AssetSelect;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Components.TransactionAnalyzer;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using PlutoFramework.Model.Currency;
using PlutoFramework.Model.Xcavate;
using UniqueryPlus.Metadata;
using UniqueryPlus.Nfts;

namespace PlutoFramework.Components.XcavateProperty
{
    public partial class BuyPropertyTokensViewModel : ObservableObject, IPopup, ISetToDefault
    {
        [ObservableProperty]
        private PropertyMetadata? metadata;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(MaxValue))]
        private NftMarketplaceDetails? nftMarketplaceDetails;

        [ObservableProperty]
        private bool isVisible = false;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ContinueButtonState))]
        [NotifyPropertyChangedFor(nameof(TokensPrice))]
        [NotifyPropertyChangedFor(nameof(Fees))]
        [NotifyPropertyChangedFor(nameof(PriceTotal))]
        private string tokens = "";

        public string TokensPrice
        {
            get
            {
                int parsedTokens;
                if (!int.TryParse(Tokens, out parsedTokens) || parsedTokens < 1 || parsedTokens > NftMarketplaceDetails?.Listed)
                {
                    return "-";
                }

                decimal usd = parsedTokens * Metadata?.PricePerToken ?? 0;
                return usd.ToCurrencyString();
            }
        }

        public string Fees
        {
            get
            {
                int parsedTokens;
                if (!int.TryParse(Tokens, out parsedTokens) || parsedTokens < 1 || parsedTokens > NftMarketplaceDetails?.Listed)
                {
                    return "-";
                }

                var usd = (decimal)0.01 * (decimal)parsedTokens * Metadata?.PricePerToken ?? 0;
                return usd.ToCurrencyString();
            }
        }

        public string PriceTotal
        {
            get
            {
                int parsedTokens;
                if (!int.TryParse(Tokens, out parsedTokens) || parsedTokens < 1 || parsedTokens > NftMarketplaceDetails?.Listed)
                {
                    return "-";
                }

                var usd = (decimal)1.01 * (decimal)parsedTokens * Metadata?.PricePerToken ?? 0;
                return usd.ToCurrencyString();
            }
        }

        public string MaxValue => NftMarketplaceDetails?.Listed.ToString() ?? "";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ContinueButtonState))]
        [NotifyPropertyChangedFor(nameof(ErrorIsVisible))]
        private string errorMessage = "";

        public bool ErrorIsVisible => ErrorMessage != "";

        public ButtonStateEnum ContinueButtonState => ErrorMessage == "" && Tokens != "" ? ButtonStateEnum.Enabled : ButtonStateEnum.Disabled;

        private EndpointEnum endpointKey;

        public EndpointEnum EndpointKey
        {
            get => endpointKey;
            set
            {
                endpointKey = value;

                var assetSelectButtonViewModel = DependencyService.Get<AssetSelectButtonViewModel>();
                assetSelectButtonViewModel.ChangeAllowedAssets(PropertyMarketplaceModel.GetAcceptedAssets(value));
            }
        }

        public void SetToDefault()
        {
            IsVisible = false;
            Tokens = "";
            ErrorMessage = "";
            Metadata = null;
            NftMarketplaceDetails = null;
            EndpointKey = EndpointEnum.None;
        }

        [RelayCommand]
        public void Cancel() => SetToDefault();

        [RelayCommand]
        public async Task ContinueAsync()
        {
            var token = CancellationToken.None;

            if (NftMarketplaceDetails is null)
            {
                return;
            }

            uint parsedTokens;
            if (!uint.TryParse(Tokens, out parsedTokens))
            {
                return;
            }

            var client = await SubstrateClientModel.GetOrAddSubstrateClientAsync(EndpointKey, token);

            var assetSelectButtonViewModel = DependencyService.Get<AssetSelectButtonViewModel>();

            var method = PropertyMarketplaceModel.BuyPropertyTokens(EndpointKey, NftMarketplaceDetails.AssetId, parsedTokens, assetSelectButtonViewModel.SelectedAssetKey);

            // Submitting the extrinsic
            var transactionAnalyzerConfirmationViewModel = DependencyService.Get<TransactionAnalyzerConfirmationViewModel>();

            Task load = transactionAnalyzerConfirmationViewModel.LoadAsync(
                client, // PlutoFrameworkSubstrateClient
                method,
                showDAppView: false,
                token: token
            );

            SetToDefault();
        }

        [RelayCommand]
        public async Task FormChangedAsync()
        {
            if (Tokens == "")
            {
                ErrorMessage = "";

                return;
            }

            int parsedTokens;
            if (!int.TryParse(Tokens, out parsedTokens))
            {

                ErrorMessage = "Tokens is not valid number";

                return;
            }

            if (parsedTokens < 1)
            {
                ErrorMessage = "Tokens must be greater than 0";

                return;
            }

            if (parsedTokens > NftMarketplaceDetails?.Listed)
            {
                ErrorMessage = $"Tokens must be less than {NftMarketplaceDetails.Listed}";

                return;
            }

            ErrorMessage = "";
        }
    }
}
