using Microsoft.Extensions.Configuration;

namespace PlutoFramework.Model.Sumsub
{
    public record SumsubSecretData
    {
        public required string AppToken { get; set; }
        public required string SecretKey { get; set; }
    }
    public class SumsubSecretModel
    {
        public static SumsubSecretData GetSecrets()
        {
            var configuration = MauiAppBuilderExtensions.Services.GetService<IConfiguration>();

            if (configuration == null)
            {
                throw new Exception("Configuration is null");
            }

            var secretKey = configuration.GetValue<string>("SUMSUB_SECRET_KEY");
            var appToken = configuration.GetValue<string>("SUMSUB_APP_TOKEN");

            if (string.IsNullOrEmpty(secretKey) || string.IsNullOrEmpty(appToken))
            {
                throw new Exception("Sumsub keys are not set in appsettings.json");
            }

            return new SumsubSecretData
            {
                AppToken = appToken,
                SecretKey = secretKey
            };
        }
    }
}
