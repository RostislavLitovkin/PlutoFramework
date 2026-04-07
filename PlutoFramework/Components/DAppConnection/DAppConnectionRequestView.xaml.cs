namespace PlutoFramework.Components.DAppConnection;

public partial class DAppConnectionRequestView : ContentView
{
    public DAppConnectionRequestView()
    {
        InitializeComponent();

        BindingContext = DependencyService.Get<DAppConnectionRequestViewModel>();
    }
}