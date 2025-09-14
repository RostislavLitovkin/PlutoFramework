using Nethereum.JsonRpc.Client;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using PlutoFramework.Model.AjunaExt;
using PlutoFramework.Model.Faucet;
using PlutoFrameworkCore.AssetDidComm;
using Substrate.NET.Schnorrkel.Keys;
using Substrate.NetApi.Extensions;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Primitive;
using System.Text;
using System.Text.Json;

namespace PlutoFrameworkTests
{
    internal class AssetDidCommTests
    {
        private Account managerAccount;

        private Account adminAccount;

        private Account adminDid;

        private X25519KeyPair adminEncryptionKey;

        private Account contributorAccount;

        private Account contributorDid;

        private X25519KeyPair contributorEncryptionKey;

        private SubstrateClientExt xcavateClient;

        private U128 namespaceId = new U128(System.Numerics.BigInteger.Parse("118467395502928470279229231494082048490"));

        [SetUp]
        public async Task SetupAsync()
        {
            var keyring = new Substrate.NET.Wallet.Keyring.Keyring();

            managerAccount = keyring.AddFromUri("//manager", default, KeyType.Sr25519).Account;

            adminAccount = keyring.AddFromUri("//admin", default, KeyType.Sr25519).Account;

            adminDid = keyring.AddFromUri("//admindid", default, KeyType.Sr25519).Account;

            adminEncryptionKey = new X25519KeyPair
            {
                PublicKey = Convert.FromBase64String("yV6OB+8mZfsVl0GppmhJ7yHy4muaek8y7x3aEjhUsxQ="),
                PrivateKey = Convert.FromBase64String("kKLaH5T2QQzFHxwMh3PohJFRJREx/iGjcyWzxgUzEYw="),
            };

            contributorAccount = keyring.AddFromUri("//contributor", default, KeyType.Sr25519).Account;

            contributorDid = keyring.AddFromUri("//contributordid", default, KeyType.Sr25519).Account;

            adminEncryptionKey = new X25519KeyPair
            {
                PublicKey = Convert.FromBase64String("Ng3bK/jBbxtTw86gE2W9rDnaH8dFxpjaCALirMkq3Vg="),
                PrivateKey = Convert.FromBase64String("w65Bfiuh3tNt9GkFUsenlIml1T5Mxk4Z09Ou+rcfAV8="),
            };

            Endpoint endpoint = PlutoFramework.Constants.Endpoints.GetEndpointDictionary[EndpointEnum.XcavatePaseo];

            xcavateClient = new SubstrateClientExt(
                    endpoint,
                        new Uri(endpoint.URLs[0]),
                        Substrate.NetApi.Model.Extrinsics.ChargeTransactionPayment.Default());

            await xcavateClient.ConnectAndLoadMetadataAsync();
        }

        [Test]
        public async Task AirdropAsync()
        {
            var WS_URL = "wss://fraa-flashbox-4659-rpc.a.stagenet.tanssi.network";

            //var status = await FaucetApiModel.PostRequestAsync(WS_URL, managerAccount.Value);

            //Console.WriteLine(status);

            // var status = await FaucetApiModel.PostRequestAsync(WS_URL, adminAccount.Value);

            // Console.WriteLine(status);

            var status = await FaucetApiModel.PostRequestAsync(WS_URL, contributorAccount.Value);

            Console.WriteLine(status);
        }


        [Test]
        public async Task WriteMessageAsync()
        {
            Random random = new Random();

            var num = random.Next();

            await AssetDidCommModel.WriteMessageAsync(new U128(0), new U128(0), $"C sharp test {num}", tag: "message");
        }


        [Test]
        public async Task CreateNamespaceAndBucketAsync()
        {
            var (createNamespace, namespaceId) = AssetDidCommModel.CreateNamespace(new AssetDidCommNamespaceInput { Name = "Csharp e2e test" });

            await xcavateClient.SubmitExtrinsicAsync(createNamespace, managerAccount, (x, y) => { });

            await Task.Delay(6000);

            var createBucket = AssetDidCommModel.CreateBucket(namespaceId, new AssetDidCommBucketInput { Name = "Csharp e2e test bucket" });

            await xcavateClient.SubmitExtrinsicAsync(createBucket, managerAccount, (x, y) => { });

            await Task.Delay(6000);
        }

        [Test]
        public async Task GetBucketIdsAsync()
        {
            var buckets = await AssetDidCommModel.GetAllBucketsInNamespaceAsync((XcavatePaseo.NetApi.Generated.SubstrateClientExt)xcavateClient.SubstrateClient, namespaceId, 10, null, CancellationToken.None);

            foreach (var bucket in buckets.Items)
            {
                Console.WriteLine($"BucketId: {bucket.BucketId.Value}, BucketName: {bucket.Name}");
            }
        }
    }
}
