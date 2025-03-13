using PlutoFramework.Model;

namespace PlutoFramework.Components.Kilt
{
    public partial class CreateNewDidPage : ContentPage
    {
        public CreateNewDidPage(CreateNewDidViewModel viewModel)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Shell.SetNavBarIsVisible(this, false);

            InitializeComponent();

            string mnemonics = MnemonicsModel.GenerateMnemonics();

            var account = MnemonicsModel.GetAccountFromMnemonics(mnemonics);

            viewModel.Mnemonics = mnemonics;
            viewModel.Did = account.ToDidAddress();

            BindingContext = viewModel;
        }
    }
}

