using Nethereum.Contracts.Standards.ERC20.TokenList;
using Newtonsoft.Json.Linq;
using PlutoFramework.Model.SubSquare;
using Polkadot.NetApi.Generated;
using Polkadot.NetApi.Generated.Model.pallet_bounties;
using Polkadot.NetApi.Generated.Storage;
using Substrate.NetApi;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.Modules;
using System.Runtime.CompilerServices;

namespace PlutoFramework.Model.OpenGov
{
    public class BountyModel
    {
        public static async IAsyncEnumerable<Bounty> GetRawBountyDataAsync(SubstrateClientExt client,
                                                                           [EnumeratorCancellation]
                                                                           CancellationToken token = default) {
            const int KEY_PREFIX_LENGTH = 64;
            const int ITEM_LIMIT = 1000;

            var keyPrefix = Utils.HexToByteArray(BountiesStorage.BountiesParams(new U32(0)).Substring(0, KEY_PREFIX_LENGTH + 2)); // +2 for 0x prefix

            byte[]? lastItemKey = null;
            while (true) {
                var itemPage = await client.State.GetKeysPagedAsync(keyPrefix, ITEM_LIMIT, lastItemKey);
                if (itemPage.Last == null || JTokenToByteString(itemPage.Last) == lastItemKey)
                    break;
                else
                    lastItemKey = JTokenToByteString(itemPage.Last);

                var storage = await client.State.GetQueryStorageAtAsync(JArrayToByteStringList(itemPage), String.Empty, token);
                var enumerator = storage.GetEnumerator();

                while (enumerator.MoveNext()) {
                    foreach (var change in enumerator.Current.Changes)
                    {
                        int p = 0;
                        var bounty = new Bounty();
                        bounty.Decode(Utils.HexToByteArray(change[1]), ref p);
                        yield return bounty;
                    }
                }
            }
        }

        private static List<byte[]> JArrayToByteStringList(JArray jArray)
        {
            var byteList = new List<byte[]>();
            foreach (var token in jArray)
            {
                byteList.Add(JTokenToByteString(token));
            }
            return byteList;
        }

        private static byte[] JTokenToByteString(JToken jToken)
        {
            return Utils.HexToByteArray(jToken.ToString());
        }
    }
}
