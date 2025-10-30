using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

namespace PlutoFrameworkCore.PushNotificationServices.Core.Misc;

public class AppApiConfig : IAppApiConfig
{
    public required string ApiUrl { get; init; }
}