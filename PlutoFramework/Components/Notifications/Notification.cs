namespace PlutoFramework.Components.Notifications
{
    public enum NotificationType
    {
        None,

        All,

        System,
        Announcement,
    }

    public record Notification
    {
        public required string Title { get; set; }
        public string? Message { get; set; }
        public required DateTime Date { get; set; }
        public NotificationType Type { get; set; } = NotificationType.None;
        public required bool WasRead { get; set; }
        public bool WasNotRead => !WasRead;
    }
}
