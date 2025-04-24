using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using PlutoFramework.Model.OpenGov;
using Substrate.NetApi;

namespace PlutoFramework.Components.OpenGov
{
    public partial class VotingDelegationViewModel : ObservableObject
    {
        [ObservableProperty]
        private int nameFontSize;

        [ObservableProperty]
        private string name;

        private string delegationAddress = "";

        [ObservableProperty]
        private bool polkadotPeopleConnected = false;

        [ObservableProperty]
        private string verificationIcon;

        [ObservableProperty]
        private bool verificationIconIsVisible;

        public VotingDelegationViewModel()
        {
            nameFontSize = 25;

            name = "Loading";

            verificationIconIsVisible = false;
        }

        public async Task GetVotingDelegationAsync(Polkadot.NetApi.Generated.SubstrateClientExt client, string address, CancellationToken token)
        {
            var votingDelegations = await VotingDelegationModel.GetVotingDelegationsAsync(client, address, token);

            if (votingDelegations.Count() == 0)
            {
                Name = "None";

                return;
            }

            string sustrateAddress = votingDelegations.Keys.First();

            string polkadotAddress = Utils.GetAddressFrom(Utils.GetPublicKeyFrom(sustrateAddress), 0);

            NameFontSize = 10;

            Name = polkadotAddress;

            delegationAddress = sustrateAddress;

            if (!PolkadotPeopleConnected)
            {
                return;
            }

            var polkadotPeopleSubstrateClient = await SubstrateClientModel.GetOrAddSubstrateClientAsync(EndpointEnum.PolkadotPeople, token);

            await GetIdentityAsync((PolkadotPeople.NetApi.Generated.SubstrateClientExt)polkadotPeopleSubstrateClient.SubstrateClient, token);
        }

        public async Task GetIdentityAsync(PolkadotPeople.NetApi.Generated.SubstrateClientExt client, CancellationToken token)
        {
            if (delegationAddress == "")
            {
                return;
            }

            VerificationIconIsVisible = false;

            var identity = await IdentityModel.GetIdentityForAddressAsync(client, delegationAddress, token);

            if (identity == null)
            {
                return;
            }

            NameFontSize = 25;

            Name = identity.DisplayName;
            VerificationIconIsVisible = true;

            switch (identity.FinalJudgement)
            {
                case Judgement.Unknown:
                    if (Application.Current.RequestedTheme == AppTheme.Light)
                    {
                        VerificationIcon = "unknownblack.png";
                    }
                    else
                    {
                        VerificationIcon = "unknownwhite.png";
                    }
                    break;
                case Judgement.LowQuality:
                    if (Application.Current.RequestedTheme == AppTheme.Light)
                    {
                        VerificationIcon = "unknownblack.png";
                    }
                    else
                    {
                        VerificationIcon = "unknownwhite.png";
                    }
                    break;
                case Judgement.OutOfDate:
                    if (Application.Current.RequestedTheme == AppTheme.Light)
                    {
                        VerificationIcon = "unknownblack.png";
                    }
                    else
                    {
                        VerificationIcon = "unknownwhite.png";
                    }
                    break;
                case Judgement.Reasonable:
                    VerificationIcon = "greentick.png";
                    break;
                case Judgement.KnownGood:
                    VerificationIcon = "greentick.png";
                    break;
                case Judgement.Erroneous:
                    VerificationIcon = "redallert.png";
                    break;
            }
        }

        public void SetEmpty()
        {
            if (Name != "Loading")
            {
                return;
            }

            Name = "None";
        }
    }
}
