using Newtonsoft.Json;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using PlutoFramework.Model.AjunaExt;
using PlutoFramework.Types;
using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoFrameworkTests
{
    internal class MetadataTests
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
        public async Task GetMethodNamesAsync()
        {
            var method = new Method(5, 3, Utils.HexToByteArray("0x0016b3861912eb2dda98ca3abc80f8b5b01b42c00753222dc5be9373117d2e616f0700e40b5402"));

            (var pallet, var call) = PalletCallModel.GetPalletAndCallName(client, method.ModuleIndex, method.CallIndex);
            Assert.That("Balances" == pallet);
        
            Assert.That("transfer_keep_alive" == call);
        }

        [Test]
        public void GetMetadataVersion()
        {
            Assert.That(14 == client.SubstrateClient.MetaData.Version);
        }
    }
}
