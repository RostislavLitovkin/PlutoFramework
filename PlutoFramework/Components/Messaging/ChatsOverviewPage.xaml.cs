using System.Collections.ObjectModel;
using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Messaging;

public partial class ChatsOverviewPage : PageTemplate
{
    public ObservableCollection<ChatItem> Chats { get; } = new();
    public ChatsOverviewPage()
    {
        InitializeComponent();
    }
}