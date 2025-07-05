namespace PlutoFramework.Components.XcavateProperty
{
    public partial class RelistPropertyTokensView : ContentView
    {
        public RelistPropertyTokensView()
        {
            InitializeComponent();

            BindingContext = DependencyService.Get<RelistPropertyTokensViewModel>();
        }
    }
}