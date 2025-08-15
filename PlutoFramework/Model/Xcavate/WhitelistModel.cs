using XcavatePaseo.NetApi.Generated.Model.sp_core.crypto;
using Substrate.NetApi;
using XcavatePaseo.NetApi.Generated;
using XcavatePaseo.NetApi.Generated.Model.pallet_xcavate_whitelist.pallet;

namespace PlutoFramework.Model.Xcavate
{
    public class WhitelistModel
    {
        public static async Task<VerificationEnum> IsWhitelistedAsync(SubstrateClientExt client, Role role, string address, CancellationToken token)
        {
            var accountId = new AccountId32();
            accountId.Create(Utils.GetPublicKeyFrom(address));

            var roleEnum = new EnumRole();
            roleEnum.Create(role);

            var whitelisted = await client.XcavateWhitelistStorage.AccountRoles(new (accountId, roleEnum), "", token);

            return whitelisted?.Value switch
            {
                null => VerificationEnum.Pending,
                _ => VerificationEnum.Verified,
            };
        }
    }
}
