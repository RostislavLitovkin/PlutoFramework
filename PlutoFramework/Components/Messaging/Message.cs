namespace PlutoFramework.Components.Messaging;

public record Message
{
    public enum MessageType
    {
        Incoming,
        Outgoing,
        Status
    }
    
    public required string Text { get; set; }
    public required MessageType Type { get; set; }
    public string? Sender { get; set; }
    public string? Timestamp { get; set; }
    public Color? MsgColor { get; set; }
}