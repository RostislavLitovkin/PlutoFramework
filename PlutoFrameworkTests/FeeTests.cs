using PlutoFramework.Constants;
using PlutoFramework.Model;
using PlutoFramework.Model.AjunaExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoFrameworkTests
{
    internal class FeeTests
    {
        static string substrateAddress = "5CaUEtkTHmVM9aQ6XwiPkKcGscaKKxo5Zy2bCp2sRSXCevRf";

        static SubstrateClientExt client;

        [SetUp]
        public async Task SetupAsync()
        {
            Endpoint hdxEndpoint = PlutoFramework.Constants.Endpoints.GetEndpointDictionary[EndpointEnum.Polkadot];

            client = new SubstrateClientExt(
                    hdxEndpoint,
                        new Uri(hdxEndpoint.URLs[0]),
                        Substrate.NetApi.Model.Extrinsics.ChargeTransactionPayment.Default());

            await client.ConnectAndLoadMetadataAsync();
        }

        [Test]
        public async Task GetNativeTransferFeeAsync()
        {
            var fee = await FeeModel.GetNativeTransferFeeAsync(client);

            Assert.Greater(fee.Amount, 0);
        }
    }
}
