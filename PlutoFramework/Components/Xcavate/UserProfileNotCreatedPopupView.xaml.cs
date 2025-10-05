namespace PlutoFramework.Components.Xcavate
{
    public partial class UserProfileNotCreatedPopupView : ContentView
    {
        public UserProfileNotCreatedPopupView()
        {
            InitializeComponent();

            BindingContext = DependencyService.Get<UserProfileNotCreatedPopupViewModel>();
        }
    }
}