using System;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using PlutoFramework.Model.AjunaExt;

namespace PlutoFrameworkTests
{
	public class DIDModelTests
	{
        static SubstrateClientExt client;

        [SetUp]
        public async Task SetupAsync()
        {
            Endpoint endpoint = PlutoFramework.Constants.Endpoints.GetEndpointDictionary[EndpointEnum.Kilt];

            client = new SubstrateClientExt(
                    endpoint,
                        new Uri("ws://127.0.0.1:8000"),
                        Substrate.NetApi.Model.Extrinsics.ChargeTransactionPayment.Default());

            await client.ConnectAndLoadMetadataAsync();

            Console.WriteLine("Setup done");

        }

        [Test]
        public async Task CreateDidAsync()
        {
            try
            {
                var account = MnemonicsModel.GetAccountFromMnemonics("//Alice");
                var did = MnemonicsModel.GetAccountFromMnemonics("//AliceDid");

                var createDidTx = DidModel.Create(account, did);

                await client.SubmitExtrinsicAsync(createDidTx, account, new TaskCompletionSource<string?>(), (s, x) => { });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

