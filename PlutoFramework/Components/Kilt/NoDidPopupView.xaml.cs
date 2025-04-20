namespace PlutoFramework.Components.Kilt
{
    public partial class NoDidPopupView : ContentView
    {
        public NoDidPopupView()
        {
            InitializeComponent();

            BindingContext = DependencyService.Get<NoDidPopupViewModel>();
        }
    }
}