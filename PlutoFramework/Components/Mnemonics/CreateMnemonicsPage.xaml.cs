using PlutoFramework.Model;
using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Mnemonics;

public partial class CreateMnemonicsPage : PageTemplate
{
    public CreateMnemonicsPage(CreateMnemonicsViewModel viewModel)
    {
        InitializeComponent();

        string mnemonics = MnemonicsModel.GenerateMnemonics();

        var account = MnemonicsModel.GetAccountFromMnemonics(mnemonics);

        viewModel.Mnemonics = mnemonics;
        viewModel.Address = account.Value;

        BindingContext = viewModel;
    }
}