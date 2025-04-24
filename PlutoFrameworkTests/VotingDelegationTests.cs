using PlutoFramework.Constants;
using PlutoFramework.Model;
using PlutoFramework.Model.AjunaExt;
using PlutoFramework.Model.OpenGov;
using Substrate.NetApi;

namespace PlutoFrameworkTests
{
    internal class VotingDelegationTests
    {
        static string substrateAddress = "5CaUEtkTHmVM9aQ6XwiPkKcGscaKKxo5Zy2bCp2sRSXCevRf";

        static SubstrateClientExt client;

        [SetUp]
        public async Task SetupAsync()
        {
            Endpoint endpoint = PlutoFramework.Constants.Endpoints.GetEndpointDictionary[EndpointEnum.Polkadot];

            client = new SubstrateClientExt(
                    endpoint,
                        new Uri(endpoint.URLs[0]),
                        Substrate.NetApi.Model.Extrinsics.ChargeTransactionPayment.Default());

            await client.ConnectAndLoadMetadataAsync();
        }


        [Test]
        public async Task GetVotingDelegationsAsync()
        {
            var votingDelegations = await VotingDelegationModel.GetVotingDelegationsAsync((Polkadot.NetApi.Generated.SubstrateClientExt)client.SubstrateClient, substrateAddress, CancellationToken.None);
            Assert.That(votingDelegations.Count > 0);

            string sustrateAddress = votingDelegations.Keys.First();

            string polkadotAddress = Utils.GetAddressFrom(Utils.GetPublicKeyFrom(sustrateAddress), 0);

            Console.WriteLine(polkadotAddress);

            Console.WriteLine(votingDelegations.Values.First());
        }
    }
}
