namespace PlutoFrameworkCore.PushNotificationServices.Core.Background;

public record BackgroundJob
{
    public string Type { get; set; } = string.Empty;
    public string Payload { get; set; } = string.Empty;
}