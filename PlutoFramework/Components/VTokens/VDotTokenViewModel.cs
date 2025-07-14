using System.Numerics;
using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Model;
using PlutoFramework.Types;

namespace PlutoFramework.Components.VTokens
{
    public partial class VDotTokenViewModel : ObservableObject
    {
        [ObservableProperty]
        private string conversion;

        [ObservableProperty]
        private string from;

        private BifrostPolkadot.NetApi.Generated.SubstrateClientExt bifrostClient = null;

        public VDotTokenViewModel()
        {
            conversion = "Loading";

            from = "";
        }

        public async Task UpdateConversionRateAsync(PlutoFrameworkSubstrateClient client, CancellationToken token)
        {
            if (client.Endpoint.Key == Constants.EndpointEnum.Bifrost)
            {
                bifrostClient = (BifrostPolkadot.NetApi.Generated.SubstrateClientExt)client.SubstrateClient;
            }

            if (bifrostClient is null)
            {
                return;
            }

            var vdots = Model.AssetsModel.GetAssetsWithSymbol("vDOT").ToList();

            BigInteger vDotsSum = 0;
            foreach (Asset vdot in vdots)
            {
                vDotsSum += (BigInteger)(vdot.Amount * Math.Pow(10, vdot.Decimals));
            }

            if (vDotsSum == 0)
            {
                Conversion = String.Format((string)Application.Current.Resources["CurrencyFormat"], 0) + " DOT";
                From = "From " + String.Format((string)Application.Current.Resources["CurrencyFormat"], 0) + " vDOT";
                return;
            }

            BigInteger dotsEquivalent = await VTokenModel.VDotToDot(bifrostClient, vDotsSum, token);

            Conversion = String.Format((string)Application.Current.Resources["CurrencyFormat"], (double)dotsEquivalent / Math.Pow(10, vdots[0].Decimals)) + " DOT";

            //BigInteger singleVDot = (BigInteger)Math.Pow(10, vdots[0].Decimals);

            //BigInteger dotsEquivalentSingle = await VTokenModel.VDotToDot(bifrostClient, singleVDot, token);

            From = "From " + String.Format((string)Application.Current.Resources["CurrencyFormat"], (double)vDotsSum / Math.Pow(10, vdots[0].Decimals)) + " vDOT";
        }

        public void SetEmpty()
        {
            if (Conversion != "Loading")
            {
                return;
            }

            Conversion = "Failed";
        }
    }
}

