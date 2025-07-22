using PlutoFramework.Constants;
using PlutoFramework.Model.OpenGov;
using Polkadot.NetApi.Generated.Model.pallet_bounties;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoFrameworkTests
{
    public class OpenGovBountyTests
    {
        static PlutoFramework.Model.AjunaExt.SubstrateClientExt client;

        [SetUp]
        public async Task SetupAsync()
        {
            Endpoint endpoint = Endpoints.GetEndpointDictionary[EndpointEnum.Polkadot];

            client = new PlutoFramework.Model.AjunaExt.SubstrateClientExt(
                endpoint,
                new Uri(endpoint.URLs[0]),
                Substrate.NetApi.Model.Extrinsics.ChargeTransactionPayment.Default());

            await client.ConnectAndLoadMetadataAsync();
        }

        [Test]
        public static async Task RawBountyDataAsync() {
            Console.WriteLine("> STARTED <");
            var data = BountyModel.GetRawBountyDataAsync((Polkadot.NetApi.Generated.SubstrateClientExt)client.SubstrateClient);
            var enumerator = data.GetAsyncEnumerator();
            while (await enumerator.MoveNextAsync()) {
                Console.WriteLine(enumerator.Current);
            }
            Console.WriteLine("> FINISHED <");
        }
    }
}
