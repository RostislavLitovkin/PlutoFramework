using Nethereum.Contracts.Standards.ERC20.TokenList;
using PlutoFramework.Constants;
using PlutoFramework.Model.AjunaExt;
using PlutoFramework.Model.XCavate;
using System.Runtime.CompilerServices;
using UniqueryPlus.Nfts;

namespace PlutoFrameworkTests
{
    internal class XcavatePropertyMarketplaceTests
    {
        static SubstrateClientExt client;

        [SetUp]
        public async Task SetupAsync()
        {
            Endpoint endpoint = PlutoFramework.Constants.Endpoints.GetEndpointDictionary[EndpointEnum.XCavatePaseo];

            client = new SubstrateClientExt(
                    endpoint,
                        new Uri(endpoint.URLs[0]),
                        Substrate.NetApi.Model.Extrinsics.ChargeTransactionPayment.Default());

            await client.ConnectAndLoadMetadataAsync();
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            var token = CancellationToken.None;
            uint LIMIT = 4;
            var uniqueryNftEnumerable = PropertyMarketplaceModel.GetPropertiesAsync(
                           (XCavatePaseo.NetApi.Generated.SubstrateClientExt)client.SubstrateClient,
                            limit: LIMIT
                        );

            var uniqueryNftEnumerator = uniqueryNftEnumerable.GetAsyncEnumerator(token);

            for (uint i = 0; i < LIMIT; i++)
            {
                if (uniqueryNftEnumerator != null && await uniqueryNftEnumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    var newNft = PlutoFramework.Model.NftModel.ToNftWrapper(uniqueryNftEnumerator.Current);

                    var property = (XCavatePaseoNftsPalletNft)newNft.NftBase;

                    Console.WriteLine("Property: " + property.XCavateMetadata?.PropertyName + " - " + property.NftMarketplaceDetails?.Listed);

                }
            }



            return;

            var properties = await PropertyMarketplaceModel.GetPropertiesAsync((XCavatePaseo.NetApi.Generated.SubstrateClientExt)client.SubstrateClient, 50, null, CancellationToken.None);

            foreach (XCavatePaseoNftsPalletNft property in properties.Items)
            {
                Console.WriteLine("Property: " + property.XCavateMetadata?.PropertyName + " - " + property.NftMarketplaceDetails?.Listed);
            }
        }
    }
}
