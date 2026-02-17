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
    private static PlatformType? current;
    private static IAttestationService? attestationService;

    public static PlatformType Current
    {
        get => current ?? 
               throw new InvalidOperationException("Set Platform.Current before using its value"); 
        set => current = value;
    }

    public static IAttestationService AttestationService
    {
        get => attestationService ?? 
               throw new InvalidOperationException("Set Platform.AttestationService before using its value");
        set => attestationService = value;
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