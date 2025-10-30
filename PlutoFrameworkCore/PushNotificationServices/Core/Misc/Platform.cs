using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

namespace PlutoFrameworkCore.PushNotificationServices.Core.Misc;

public enum PlatformType
{
    Other,
    Android,
    iOS
}

public static class Platform
{
    private static PlatformType? _current;
    private static IAttestationService? _attestationService;

    public static PlatformType Current
    {
        get => _current ?? 
               throw new Exception("[PlutoNotifications] Error: Set Platform.Current before using it's value"); 
        set => _current = value;
    }

    public static IAttestationService AttestationService
    {
        get => _attestationService ?? 
               throw new Exception("[PlutoNotifications] Error: Set Platform.AttestationService before using it's value");
        set => _attestationService = value;
    }
    
    public static string ToStringValue(this PlatformType platform)
    {
        return platform switch
        {
            PlatformType.Android => "android",
            PlatformType.iOS => "ios",
            _ => string.Empty
        };
    }
}