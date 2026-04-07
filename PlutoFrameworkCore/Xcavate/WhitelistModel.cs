using XcavatePaseo.NetApi.Generated.Model.sp_core.crypto;
using Substrate.NetApi;
using XcavatePaseo.NetApi.Generated;
using XcavatePaseo.NetApi.Generated.Model.pallet_xcavate_whitelist.pallet;
using PlutoFrameworkCore.Xcavate;

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

            try
            {
                var whitelisted = await client.XcavateWhitelistStorage.AccountRoles(new(accountId, roleEnum), null, token);

                Console.WriteLine("Account roles without error");

                return whitelisted switch
                {
                    null => VerificationEnum.Pending,
                    _ => VerificationEnum.Verified,
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking whitelist:");
                Console.WriteLine(ex);

                return VerificationEnum.Pending;
            }
        }
    }
}
