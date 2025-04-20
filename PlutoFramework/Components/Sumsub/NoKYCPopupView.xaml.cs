namespace PlutoFramework.Components.Sumsub
{
    public partial class NoKYCPopupView : ContentView
    {
        public NoKYCPopupView()
        {
            InitializeComponent();

            BindingContext = DependencyService.Get<NoKYCPopupViewModel>();
        }
    }
}