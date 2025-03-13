namespace PlutoFramework.Components.Mnemonics
{
    public partial class NoMnemonicsPage : ContentPage
    {
        public NoMnemonicsPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Shell.SetNavBarIsVisible(this, false);

            InitializeComponent();

            BindingContext = new NoMnemonicsViewModel(); 
        }

        public NoMnemonicsPage(NoMnemonicsViewModel viewModel)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Shell.SetNavBarIsVisible(this, false);

            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}