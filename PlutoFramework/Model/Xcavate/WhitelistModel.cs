using XcavatePaseo.NetApi.Generated.Model.sp_core.crypto;
using Substrate.NetApi;
using XcavatePaseo.NetApi.Generated;

namespace PlutoFramework.Model.Xcavate
{
    public class WhitelistModel
    {
        public static async Task<VerificationEnum> IsWhitelistedAsync(SubstrateClientExt client, string address, CancellationToken token)
        {
            var accountId = new AccountId32();
            accountId.Create(Utils.GetPublicKeyFrom(address));

            var whitelisted = await client.XcavateWhitelistStorage.WhitelistedAccounts(accountId, "", token);

            return whitelisted?.Value switch
            {
                true => VerificationEnum.Verified,
                false => VerificationEnum.Rejected,
                null => VerificationEnum.Pending,
            };
        }
    }
}
