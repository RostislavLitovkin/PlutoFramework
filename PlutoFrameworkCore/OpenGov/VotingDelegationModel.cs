using System.Numerics;
using Polkadot.NetApi.Generated;
using Polkadot.NetApi.Generated.Storage;
using Substrate.NET.Wallet.Derivation;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkadot.NetApi.Generated.Model.sp_core.crypto;
using Nethereum.Contracts.Standards.ERC20.TokenList;
using UniqueryPlus.Metadata;
using UniqueryPlus.Nfts;
using UniqueryPlus;
using Polkadot.NetApi.Generated.Model.pallet_conviction_voting.vote;

namespace PlutoFramework.Model.OpenGov
{
    public class VotingDelegationModel
    {
        public static async Task<Dictionary<string, BigInteger>> GetVotingDelegationsAsync(
            SubstrateClientExt client,
            string address,
            CancellationToken token
        )
        {
            // 0x + Twox64 pallet + Twox64 storage + twox64 accountId32
            var keyPrefixLength = 146;

            AccountId32 accountId = new AccountId32();

            accountId.Create(Utils.GetPublicKeyFrom(address));

            var keyPrefix = Utils.HexToByteArray(ConvictionVotingStorage.VotingForParams(new BaseTuple<AccountId32, U16>(accountId, new U16(0))).Substring(0, keyPrefixLength));

            var fullKeys = await client.State.GetKeysPagedAsync(keyPrefix, 1000, null, string.Empty, token).ConfigureAwait(false);

            // No more nfts found
            if (fullKeys == null || !fullKeys.Any())
            {
                return new Dictionary<string, BigInteger>();
            }

            var storageChangeSets = await client.State.GetQueryStorageAtAsync(fullKeys.Select(p => Utils.HexToByteArray(p.ToString())).ToList(), string.Empty, token).ConfigureAwait(false);

            var result = new Dictionary<string, BigInteger>();

            foreach (var change in storageChangeSets.First().Changes)
            {
                if (change[1] == null)
                {
                    continue;
                }

                var voting = new EnumVoting();
                voting.Create(change[1].ToString());

                if (voting.Value != Voting.Delegating)
                {
                    continue;
                }

                var delegating = (Delegating)voting.Value2;

                string delegateAddress = Utils.GetAddressFrom(delegating.Target.Bytes);

                if (result.ContainsKey(delegateAddress))
                {
                    result[delegateAddress] = BigInteger.Max(delegating.Balance.Value, result[delegateAddress]);
                }
                else
                {
                    result.Add(delegateAddress, delegating.Balance.Value);
                }
            }

            return result;
        }
    }
}
