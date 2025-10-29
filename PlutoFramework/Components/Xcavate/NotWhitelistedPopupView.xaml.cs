namespace PlutoFramework.Components.Xcavate
{
    public partial class NotWhitelistedPopupView : ContentView
    {
        public NotWhitelistedPopupView()
        {
            InitializeComponent();

            BindingContext = DependencyService.Get<NotWhitelistedPopupViewModel>();
        }
    }
}