using System.Collections.ObjectModel;
using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Messaging;

public partial class MessagingOverviewPage : PageTemplate
{
	public ObservableCollection<Message> Messages { get; } = new();
	
	public MessagingOverviewPage()
	{
        InitializeComponent();
        
        ScrollView.Rotation = 180;
        ScrollView.VerticalScrollBarVisibility = ScrollBarVisibility.Never;
        ScrollView.Padding = new Thickness(ScrollView.Padding.Right, ScrollView.Padding.Bottom, 
	        ScrollView.Padding.Left, ScrollView.Padding.Top);
        
        BindingContext = this;
        
        // Temporary mock msgs
        AddIncoming("Lorem ipsum", "dolor sit amet, consectetur adipiscing elit. Donec luctus ligula eu" +
                                   " erat malesuada, vitae scelerisque libero fermentum. Nunc pellentesque ac enim a" +
                                   " semper. Ut malesuada, eros quis malesuada efficitur, lectus ante euismod neque," +
                                   " eget ultricies augue augue in nulla. Interdum et malesuada fames ac ante ipsum" +
                                   " primis in faucibus. Pellentesque eleifend turpis sit amet mi sollicitudin" +
                                   " sagittis ac eget nisi. Sed lectus augue, iaculis id congue eleifend, vulputate" +
                                   " quis eros. Nunc porttitor diam congue, rutrum odio a, vehicula felis. Suspendisse" +
                                   " commodo congue enim. Phasellus auctor neque vitae lorem ornare, vitae consequat" +
                                   " sem convallis. Vestibulum in erat sit amet tortor condimentum mattis id quis ex." +
                                   " Donec vel rhoncus odio. Aenean nunc ex, iaculis sed nunc at, scelerisque imperdiet" +
                                   " ex. Pellentesque sed augue viverra, fermentum arcu eu, placerat orci." +
                                   " Pellentesque ullamcorper auctor tortor a tristique.",
                                   "Aug 5, 2025, 10:16 AM", null);
        AddStatus("A new document has been added");
        AddOutgoing("qwdadwa awdawd aa dw gaawfd awd dawrfaw", "Aug 5, 2025, 12:34 PM");
        AddIncoming("Short", "in", "Aug 5, 2025, 12:34 PM", null);
        AddStatus("Short");
        AddOutgoing("out", "Aug 5, 2025, 12:34 PM");
        AddStatus("Super super super super super super super super super long");
        AddIncoming("Lorem ipsum", "dolor sit amet, consectetur adipiscing elit. Donec luctus ligula eu" +
                                   " erat malesuada, vitae scelerisque libero fermentum. Nunc pellentesque ac enim a" +
                                   " semper. Ut malesuada, eros quis malesuada efficitur, lectus ante euismod neque," +
                                   " eget ultricies augue augue in nulla. Interdum et malesuada fames ac ante ipsum" +
                                   " primis in faucibus. Pellentesque eleifend turpis sit amet mi sollicitudin" +
                                   " sagittis ac eget nisi. Sed lectus augue, iaculis id congue eleifend, vulputate" +
                                   " quis eros. Nunc porttitor diam congue, rutrum odio a, vehicula felis. Suspendisse" +
                                   " commodo congue enim. Phasellus auctor neque vitae lorem ornare, vitae consequat" +
                                   " sem convallis. Vestibulum in erat sit amet tortor condimentum mattis id quis ex." +
                                   " Donec vel rhoncus odio. Aenean nunc ex, iaculis sed nunc at, scelerisque imperdiet" +
                                   " ex. Pellentesque sed augue viverra, fermentum arcu eu, placerat orci." +
                                   " Pellentesque ullamcorper auctor tortor a tristique.",
	        "Aug 5, 2025, 10:16 AM", null);
	}
	
	private void AddMessage(string text, Message.MessageType type, string? sender, string? timestamp, Color? msgColor)
	{
		Messages.Add(new Message
		{
			Text = text,
			Type = type,
			Sender = sender,
			Timestamp = timestamp,
			MsgColor = msgColor ?? Application.Current.Resources["X-LEAFGREEN"] as Color
		});
	}

	public void AddIncoming(string sender, string text, string timestamp, Color? msgColor)
	{
		AddMessage(text, Message.MessageType.Incoming, sender, timestamp, msgColor);
	}

	public void AddOutgoing(string text, string timestamp)
	{
		AddMessage(text, Message.MessageType.Outgoing, null, timestamp, null);
	}

	public void AddStatus(string text)
	{
		AddMessage(text, Message.MessageType.Status, null, null, null);
	}
}