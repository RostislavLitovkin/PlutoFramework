namespace PlutoFrameworkCore.PushNotificationServices.Core.Misc;

public enum Platform
{
    Android,
    iOS,
    Other
}

/// <summary>
/// Usage example:
/// <code>
/// Platform platform = Platform.Android;
/// platform.ToStringValue();
/// </code>
/// </summary>
public static class PlatformExtensions
{
    public static string ToStringValue(this Platform platform) => platform switch
    {
        Platform.Android => "android",
        Platform.iOS => "ios",
        Platform.Other => "",
        _ => throw new ArgumentOutOfRangeException(nameof(platform), platform, null) // shouldn't happen
    };
}