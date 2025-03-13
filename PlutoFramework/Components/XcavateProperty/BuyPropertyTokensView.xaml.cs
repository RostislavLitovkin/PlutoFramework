namespace PlutoFramework.Components.XcavateProperty
{
    public partial class BuyPropertyTokensView : ContentView
    {
        public BuyPropertyTokensView()
        {
            InitializeComponent();

            BindingContext = DependencyService.Get<BuyPropertyTokensViewModel>();
        }
    }
}