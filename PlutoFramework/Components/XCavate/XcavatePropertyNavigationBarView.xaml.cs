namespace PlutoFramework.Components.Xcavate;

public partial class XcavatePropertyNavigationBarView : ContentView
{
    public XcavatePropertyNavigationBarView()
    {
        {
            InitializeComponent();

            BindingContext = DependencyService.Get<XcavatePropertyNavigationBarViewModel>();
        }
    }
}