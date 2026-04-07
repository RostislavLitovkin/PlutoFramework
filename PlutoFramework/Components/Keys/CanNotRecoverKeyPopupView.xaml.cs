namespace PlutoFramework.Components.Keys
{
    public partial class CanNotRecoverKeyPopupView : ContentView
    {
        public CanNotRecoverKeyPopupView()
        {
            InitializeComponent();

            BindingContext = DependencyService.Get<CanNotRecoverKeyPopupViewModel>();
        }
    }
}