using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Components.TransactionAnalyzer;
using PlutoFramework.Model;
using PlutoFramework.Model.Xcavate;
using UniqueryPlus.Metadata;
using UniqueryPlus.Nfts;

namespace PlutoFramework.Components.XcavateProperty
{
    public partial class BuyPropertyTokensViewModel : ObservableObject, IPopup, ISetToDefault
    {
        [ObservableProperty]
        private XcavateMetadata? metadata;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(MaxValue))]
        private NftMarketplaceDetails? nftMarketplaceDetails;

        [ObservableProperty]
        private bool isVisible = false;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ContinueButtonState))]
        private string tokens = "";
        public string MaxValue => NftMarketplaceDetails?.Listed.ToString() ?? "";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ContinueButtonState))]
        private string errorMessage = "";

        public ButtonStateEnum ContinueButtonState => ErrorMessage == "" && Tokens != "" ? ButtonStateEnum.Enabled : ButtonStateEnum.Disabled;

        public void SetToDefault()
        {
            IsVisible = false;
            Tokens = "";
            ErrorMessage = "";
            Metadata = null;
            NftMarketplaceDetails = null;
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

            var client = await SubstrateClientModel.GetOrAddSubstrateClientAsync(Constants.EndpointEnum.XcavatePaseo, token);

            var method = PropertyMarketplaceModel.BuyPropertyTokens(NftMarketplaceDetails.AssetId, parsedTokens);

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
