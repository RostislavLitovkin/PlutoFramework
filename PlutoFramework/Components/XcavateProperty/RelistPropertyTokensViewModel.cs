using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.AssetSelect;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Components.TransactionAnalyzer;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using PlutoFramework.Model.Currency;
using PlutoFramework.Model.Xcavate;
using System.Numerics;
using UniqueryPlus.Metadata;
using UniqueryPlus.Nfts;

namespace PlutoFramework.Components.XcavateProperty
{
    public partial class RelistPropertyTokensViewModel : ObservableObject, IPopup, ISetToDefault
    {
        [ObservableProperty]
        private XcavateMetadata? metadata = null;

        [ObservableProperty]
        private NftMarketplaceDetails? nftMarketplaceDetails = null;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(MaxValue))]
        private uint tokensOwned = 0;

        public string MaxValue => TokensOwned.ToString();

        [ObservableProperty]
        private bool isVisible = false;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ContinueButtonState))]
        [NotifyPropertyChangedFor(nameof(PriceTotal))]
        private string tokens = "";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ContinueButtonState))]
        [NotifyPropertyChangedFor(nameof(PriceTotal))]
        private string pricePerToken = "";

        public string PriceTotal
        {
            get
            {
                if (!uint.TryParse(Tokens, out var parsedTokens)
                    || parsedTokens <= 0
                    || parsedTokens > TokensOwned
                    || !uint.TryParse(PricePerToken, out var parsedPrice)
                    || parsedPrice <= 0)
                {
                    return "-";
                }

                var usd = parsedTokens * parsedPrice;
                return ((double)usd).ToCurrencyString();
            }
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ContinueButtonState))]
        private string errorMessage = "";

        public ButtonStateEnum ContinueButtonState => ErrorMessage == "" && Tokens != "" && PricePerToken != "" ? ButtonStateEnum.Enabled : ButtonStateEnum.Disabled;

        private EndpointEnum endpointKey = EndpointEnum.None;

        public EndpointEnum EndpointKey
        {
            get => endpointKey;
            set
            {
                endpointKey = value;

                var assetSelectButtonViewModel = DependencyService.Get<AssetSelectButtonViewModel>();
                assetSelectButtonViewModel.ChangeAllowedAssets(PropertyMarketplaceModel.GetAcceptedAssets(value), checkOwnership: false);
            }
        }

        public void SetToDefault()
        {
            IsVisible = false;

            PricePerToken = "";
            Tokens = "";
            ErrorMessage = "";
            TokensOwned = 0;
            Metadata = null;
            NftMarketplaceDetails = null;
            EndpointKey = EndpointEnum.None;
        }

        [RelayCommand]
        public void Cancel() => SetToDefault();

        [RelayCommand]
        public async Task ContinueAsync()
        {
            try
            {
                var token = CancellationToken.None;

                var assetSelectButtonViewModel = DependencyService.Get<AssetSelectButtonViewModel>();


                if (NftMarketplaceDetails is null)
                {
                    return;
                }

                uint parsedTokens;
                if (!uint.TryParse(Tokens, out parsedTokens))
                {
                    return;
                }

                decimal parsedPricePerToken;
                if (!decimal.TryParse(PricePerToken, out parsedPricePerToken))
                {
                    return;
                }

                BigInteger actualPricePerToken = (BigInteger)(parsedPricePerToken * (decimal)Math.Pow(10, assetSelectButtonViewModel.Decimals));

                var client = await SubstrateClientModel.GetOrAddSubstrateClientAsync(EndpointKey, token);

                var method = PropertyMarketplaceModel.RelistPropertyTokens(EndpointKey, NftMarketplaceDetails.Region, NftMarketplaceDetails.AssetId, parsedTokens, actualPricePerToken, assetSelectButtonViewModel.SelectedAssetKey);

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
            catch (Exception ex)
            {
                Console.WriteLine($"Error during ContinueAsync: {ex.Message}");
                ErrorMessage = "An error occurred while processing your request.";
            }

        }
        [RelayCommand]
        public void FormChanged()
        {
            OnPropertyChanged(nameof(PriceTotal));

            if (Tokens == "" || PricePerToken == "")
            {
                ErrorMessage = "";

                return;
            }

            uint parsedTokens;
            if (!uint.TryParse(Tokens, out parsedTokens))
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

            uint pricePerToken;
            if (!uint.TryParse(PricePerToken, out pricePerToken))
            {
                ErrorMessage = "Price per token is not valid number";

                return;
            }

            if (pricePerToken < 1)
            {
                ErrorMessage = "Price per token must be greater than 0";
                return;
            }

            ErrorMessage = "";
        }
    }
}
