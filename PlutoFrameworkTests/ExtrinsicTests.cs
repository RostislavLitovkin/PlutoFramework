using PlutoFramework.Constants;
using PlutoFramework.Model;
using Substrate.NetApi.Model.Extrinsics;

namespace PlutoFrameworkTests
{
    internal class ExtrinsicTests
    {
        [Test]
        public async Task GetJsonMethodAsync()
        {
            var endpoint = PlutoFramework.Constants.Endpoints.GetEndpointDictionary[EndpointEnum.Opal];

            string bestWebSecket = await WebSocketModel.GetFastestWebSocketAsync(endpoint.URLs);

            var client = new PlutoFramework.Model.AjunaExt.SubstrateClientExt(
                        endpoint,
                        new Uri(bestWebSecket),
                        Substrate.NetApi.Model.Extrinsics.ChargeTransactionPayment.Default());

            await client.ConnectAndLoadMetadataAsync();

            var method = new Method(30, 3, Substrate.NetApi.Utils.HexToByteArray("0x006a4e76d530fa715a95388b889ad33c1665062c3dec9bf0aca3a9e4ff45781e4817000010632d5ec76b05"));

            var methodUnified = PalletCallModel.GetMethodUnified(client, method);

            

            Console.WriteLine($"{methodUnified.EventName} - {methodUnified.EventName}");
            foreach(var parameter in methodUnified.Parameters)
            {
                Console.WriteLine($"   {parameter.Name} - {parameter.Value}");
            }
        }
    }
}
