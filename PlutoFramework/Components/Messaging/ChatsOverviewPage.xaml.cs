using System.Collections.ObjectModel;
using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Messaging;

public partial class ChatsOverviewPage : PageTemplate
{
    public ObservableCollection<ChatItem> Chats { get; } = new();
    
    private void AddChat(string title, string state, string time, bool isApproved)
    {
        var resources = Application.Current?.Resources;
        var positive = resources?["Positive"] as Color ?? Colors.Green;
        var negative = resources?["Negative"] as Color ?? Colors.Red;
        
        Chats.Add(new ChatItem
        {
            Title = title,
            State = state,
            Time = time,
            IsApproved = isApproved ? "Approved" :  "Rejected",
            IsApprovedColor = isApproved ? positive : negative,
            IsApprovedBgColor = (isApproved ? positive : negative).WithAlpha(0.15f)
        });
    }
    
    public ChatsOverviewPage()
    {
        InitializeComponent();
        
        BindingContext = this;
        
        AddChat("Monthly performance reports", "Pending Legal Sign-off", "5:02 AM", true);
        AddChat("Monthly performance reports", "Pending Legal Sign-off", "5:02 AM", false);
        
        AddChat("Monthly performance reports", "Pending Legal Sign-off", "5:02 AM", true);
        AddChat("Monthly performance reports", "Pending Legal Sign-off", "5:02 AM", false);
        AddChat("Monthly performance reports", "Pending Legal Sign-off", "5:02 AM", true);
        AddChat("Monthly performance reports", "Pending Legal Sign-off", "5:02 AM", false);
        AddChat("Monthly performance reports", "Pending Legal Sign-off", "5:02 AM", true);
        AddChat("Monthly performance reports", "Pending Legal Sign-off", "5:02 AM", false);
        AddChat("Monthly performance reports", "Pending Legal Sign-off", "5:02 AM", true);
        AddChat("Monthly performance reports", "Pending Legal Sign-off", "5:02 AM", false);
        AddChat("Monthly performance reports", "Pending Legal Sign-off", "5:02 AM", true);
        AddChat("Monthly performance reports", "Pending Legal Sign-off", "5:02 AM", false);
    }
}