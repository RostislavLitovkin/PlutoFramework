using PlutoFramework.Constants;
using PlutoFramework.Model.AjunaExt;
using PlutoFramework.Model.Xcavate;
using UniqueryPlus.Nfts;

namespace PlutoFrameworkTests
{
    internal class XcavatePropertyMarketplaceTests
    {
        static SubstrateClientExt client;

        [SetUp]
        public async Task SetupAsync()
        {
            Endpoint endpoint = PlutoFramework.Constants.Endpoints.GetEndpointDictionary[EndpointEnum.XcavatePaseo];

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
            uint LIMIT = 20;
            var uniqueryNftEnumerable = PropertyMarketplaceModel.GetPropertiesAsync(
                           (XcavatePaseo.NetApi.Generated.SubstrateClientExt)client.SubstrateClient,
                           limit: LIMIT
                           );

            var uniqueryNftEnumerator = uniqueryNftEnumerable.GetAsyncEnumerator(token);

            for (uint i = 0; i < 100; i++)
            {
                if (uniqueryNftEnumerator != null && await uniqueryNftEnumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    /*var newNft = PlutoFramework.Model.NftModel.ToNftWrapper(uniqueryNftEnumerator.Current);

                    var property = (XcavatePaseoNftsPalletNft)newNft.NftBase;

                    Console.WriteLine("Property: " + property?.XcavateMetadata?.PropertyName + " - " + property?.XcavateMetadata?.Files?.FirstOrDefault());*/

                }
            }

            return;

            var properties = await PropertyMarketplaceModel.GetPropertiesAsync((XcavatePaseo.NetApi.Generated.SubstrateClientExt)client.SubstrateClient, 50, null, CancellationToken.None);

            foreach (XcavatePaseoNftsPalletNft property in properties.Items)
            {
                Console.WriteLine("Property: " + property.XcavateMetadata?.PropertyName + " - " + property.OngoingObjectListingDetails.ListedTokens);
            }
        }

        [Test]
        public async Task GetXcavatePropertyByIdAsync()
        {
            var nft = await PropertyMarketplaceModel.GetPropertyByIdAsync((XcavatePaseo.NetApi.Generated.SubstrateClientExt)client.SubstrateClient, 0, CancellationToken.None);

            var property = (XcavatePaseoNftsPalletNft)nft;

            Console.WriteLine("Property: " + property?.XcavateMetadata?.PropertyName + " - " + property?.XcavateMetadata?.Files?.FirstOrDefault());
        }

        [Test]
        public async Task GetIndexedPropertiesAsync()
        {
            var token = CancellationToken.None;
            uint LIMIT = 4;
            var uniqueryNftEnumerable = PropertyMarketplaceModel.GetIndexedPropertiesForSaleAsync(
                           (XcavatePaseo.NetApi.Generated.SubstrateClientExt)client.SubstrateClient,
                            limit: LIMIT
                        );

            var uniqueryNftEnumerator = uniqueryNftEnumerable.GetAsyncEnumerator(token);

            for (uint i = 0; i < 100; i++)
            {
                if (uniqueryNftEnumerator != null && await uniqueryNftEnumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    /*var newNft = PlutoFramework.Model.NftModel.ToNftWrapper(uniqueryNftEnumerator.Current);

                    var property = (XcavatePaseoNftsPalletNft)newNft.NftBase;

                    Console.WriteLine("Property: " + property?.XcavateMetadata?.PropertyName + " - " + property?.XcavateMetadata?.Files?.FirstOrDefault());*/
                }
            }



            return;

            var properties = await XcavateSubqueryModel.GetPropertiesForSaleAsync((XcavatePaseo.NetApi.Generated.SubstrateClientExt)client.SubstrateClient, 50, 0, CancellationToken.None);

            foreach (XcavatePaseoNftsPalletNft property in properties)
            {
                Console.WriteLine("Property: " + property.XcavateMetadata?.PropertyName + " - " + property.Owner);
            }
        }

        [Test]
        [TestCase("5Hn2P1N9fCLRyquktu8PZD1kR5p8mnFrTbHcTCNGUsVLJryf")]
        public async Task GetPropertyTokensOwnedByAsync(string address)
        {
            var token = CancellationToken.None;
            uint LIMIT = 4;
            var uniqueryNftEnumerable = PropertyMarketplaceModel.GetPropertiesOwnedByAsync(
                           (XcavatePaseo.NetApi.Generated.SubstrateClientExt)client.SubstrateClient,
                           address,
                           limit: LIMIT
                       );

            var uniqueryNftEnumerator = uniqueryNftEnumerable.GetAsyncEnumerator(token);

            for (uint i = 0; i < 100; i++)
            {
                if (uniqueryNftEnumerator != null && await uniqueryNftEnumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    /*PropertyTokenOwnershipInfo info = uniqueryNftEnumerator.Current;
                    var newNft = PlutoFramework.Model.NftModel.ToNftWrapper(info.NftBase);

                    var property = (XcavatePaseoNftsPalletNft)newNft.NftBase;

                    Console.WriteLine("Property: " + property?.XcavateMetadata?.PropertyName + " - " + property?.XcavateMetadata?.Files?.FirstOrDefault());
                    Console.WriteLine($"Token amount: {info.Amount}");*/
                }
            }
        }


    }
}
