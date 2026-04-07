
using PlutoFramework.Model.SQLite;
using PlutoFramework.Model.Xcavate;

namespace PlutoFramework.Model.Sumsub
{
    public class SumsubUserModel
    {
        public static async Task LoadAndSaveUserInfoAsync(CancellationToken token)
        {
            var address = Model.KeysModel.GetSubstrateKey();

            var secrets = SumsubSecretModel.GetSecrets();

            var applicant = await SumsubModel.GetApplicantDataAsync(
                address,
                secrets.SecretKey,
                secrets.AppToken,
                token
            );

            if (applicant is null)
            {
                return;
            }

            var role = applicant.Review.LevelName switch
            {
                "csharp-verification-developer" => UserRoleEnum.Developer,
                "csharp-verification-investor" => UserRoleEnum.Investor,
                "csharp-verification-letting-agent" => UserRoleEnum.LettingAgent,
                "csharp-verification-lawyer" => UserRoleEnum.Lawyer,
                _ => UserRoleEnum.None,
            };

            var user = new XcavateUser
            {
                ProfilePicture = null,
                ProfileBackground = null,
                Role = role,
                FirstName = "",
                LastName = "",
                Email = applicant.Email,
                PhoneNumber = applicant.Phone,
                AccountCreatedAt = applicant.CreatedAtDateTime
            };

            await XcavateUserDatabase.SaveUserInformationAsync(user);
        }
    }
}
