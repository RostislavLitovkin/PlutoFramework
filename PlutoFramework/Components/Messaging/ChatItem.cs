namespace PlutoFramework.Components.Messaging;

public record ChatItem
{
    public required string Title { get; set; }
    public required string State { get; set; }
    public required string Time { get; set; }
    public required string IsApproved { get; set; }
    public required Color IsApprovedColor { get; set; }
}