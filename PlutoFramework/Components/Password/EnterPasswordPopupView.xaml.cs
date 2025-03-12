namespace PlutoFramework.Components.Password;

public partial class EnterPasswordPopupView : ContentView
{
	public EnterPasswordPopupView()
	{
		InitializeComponent();

        BindingContext = DependencyService.Get<EnterPasswordPopupViewModel>();
    }
    void OnPasswordChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        ((EnterPasswordPopupViewModel)BindingContext).ErrorIsVisible = false;
    }
}