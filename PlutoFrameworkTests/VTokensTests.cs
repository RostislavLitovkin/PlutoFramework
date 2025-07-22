using System.Numerics;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using PlutoFramework.Model.AjunaExt;

namespace PlutoFrameworkTests
{
	public class VTokensTestsss
	{
        [Test]
        public async Task VTokensRedeem()
        {
            Endpoint endpoint = PlutoFramework.Constants.Endpoints.GetEndpointDictionary[EndpointEnum.Bifrost];

            string bestWebSecket = await WebSocketModel.GetFastestWebSocketAsync(endpoint.URLs);

            var client = new SubstrateClientExt(
                        endpoint,
                        new Uri(bestWebSecket),
                        Substrate.NetApi.Model.Extrinsics.ChargeTransactionPayment.Default());

            await client.ConnectAndLoadMetadataAsync();

            BigInteger redeemAmount = await VTokenModel.VDotToDot((BifrostPolkadot.NetApi.Generated.SubstrateClientExt)client.SubstrateClient, new BigInteger(10000000000), CancellationToken.None);

            Console.WriteLine((double)redeemAmount / 10000000000);
        }
	}
}

