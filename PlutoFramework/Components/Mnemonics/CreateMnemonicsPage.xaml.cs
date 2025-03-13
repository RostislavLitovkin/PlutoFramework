using PlutoFramework.Model;

namespace PlutoFramework.Components.Mnemonics;

public partial class CreateMnemonicsPage : ContentPage
{
    public CreateMnemonicsPage(CreateMnemonicsViewModel viewModel)
    {
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();

        string mnemonics = MnemonicsModel.GenerateMnemonics();

        var account = MnemonicsModel.GetAccountFromMnemonics(mnemonics);

        viewModel.Mnemonics = mnemonics;
        viewModel.Address = account.Value;

        BindingContext = viewModel;
    }
}