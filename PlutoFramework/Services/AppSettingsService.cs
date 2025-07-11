using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace PlutoFramework.Services
{
    internal static class AppSettingsService
    {
        internal static MauiAppBuilder AddAppSettings(this MauiAppBuilder builder, string appNamespace)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{appNamespace}.appsettings.json");
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            if (stream is null)
            {
                return builder;
            }

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            builder.Configuration.AddConfiguration(configuration);

            return builder;
        }
    }
}
