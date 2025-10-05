using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Notifications;

public partial class NotificationsPage : PageTemplate
{
	public NotificationsPage()
	{
		InitializeComponent();

		BindingContext = new NotificationsPageViewModel();
    }
}