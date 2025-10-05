using System;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using PlutoFramework.Model.AjunaExt;
using PlutoFrameworkCore;
using PlutoFrameworkCore.AssetDidComm;
using Substrate.NetApi;

namespace PlutoFrameworkTests
{
    public class DidModelTests
    {
        static SubstrateClientExt client;

        [SetUp]
        public async Task SetupAsync()
        {
            Endpoint endpoint = PlutoFramework.Constants.Endpoints.GetEndpointDictionary[EndpointEnum.Kilt];

            client = new SubstrateClientExt(
                    endpoint,
                        new Uri(endpoint.URLs[0]),
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

                var createDidTx = DidModel.Create(account.Value, did);

                await client.SubmitExtrinsicAsync(createDidTx, account, (s, x) => { });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [Test]
        public async Task SponsorCreateAsync()
        {
            var account = MnemonicsModel.GetAccountFromMnemonics("//Pluto");
            var did = MnemonicsModel.GetAccountFromMnemonics("//PlutoDid");

            Console.WriteLine($"Account: {account.Value}");
            Console.WriteLine($"Did: {did.Value}");


            var encryptionKey = X25519Model.GenerateX25519KeyPair();

            Console.WriteLine($"Encryption key: {Utils.Bytes2HexString(encryptionKey.PublicKey).ToLower()}");

            var createDidTx = DidModel.Create("4sQR3dfZrrxobV69jQmLvArxyUto5eJtmyc2f9xs1Hc4quu3", did, encryptionKey.PublicKey);

            var result = await DidSponsoringModel.SponsorDidTxAsync(createDidTx, CancellationToken.None);

            Assert.That(result);
        }
    }
}

