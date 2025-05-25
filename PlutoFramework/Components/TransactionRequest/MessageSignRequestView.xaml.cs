namespace PlutoFramework.Components.TransactionRequest;

public partial class MessageSignRequestView : ContentView
{
	public MessageSignRequestView()
	{
		InitializeComponent();

        BindingContext = DependencyService.Get<MessageSignRequestViewModel>();
    }
}
