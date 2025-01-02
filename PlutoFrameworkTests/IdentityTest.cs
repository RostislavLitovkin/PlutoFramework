
using PlutoFramework.Constants;
using PlutoFramework.Model;
using PlutoFramework.Model.AjunaExt;

namespace PlutoFrameworkTests
{
    internal class IdentityTest
    {
        static string substrateAddress = "5CaUEtkTHmVM9aQ6XwiPkKcGscaKKxo5Zy2bCp2sRSXCevRf";

        static SubstrateClientExt client;

        [SetUp]
        public async Task SetupAsync()
        {
            Endpoint hdxEndpoint = PlutoFramework.Constants.Endpoints.GetEndpointDictionary[EndpointEnum.PolkadotPeople];

            client = new SubstrateClientExt(
                    hdxEndpoint,
                        new Uri(hdxEndpoint.URLs[0]),
                        Substrate.NetApi.Model.Extrinsics.ChargeTransactionPayment.Default());

            await client.ConnectAndLoadMetadataAsync();
        }

        [Test]
        public async Task GetIdentityForAddressAsync()
        {
            var identity = await IdentityModel.GetIdentityForAddressAsync((PolkadotPeople.NetApi.Generated.SubstrateClientExt)client.SubstrateClient, substrateAddress, CancellationToken.None);

            Assert.That(identity.DisplayName == "Rosta");
            Assert.That(identity.FinalJudgement, Is.EqualTo(Judgement.Reasonable));

        }
    }
}
