using CommunityToolkit.Mvvm.Input;

namespace PlutoFramework.Components.Tabs
{
    public record Tab
    {
        public required string Title { get; set; }
        public required bool IsSelected { get; set; }
        public required object Value { get; set; }
    }
}
