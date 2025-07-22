using PlutoFramework.Model;
using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Kilt
{
    public partial class CreateNewDidPage : PageTemplate
    {
        public CreateNewDidPage(CreateNewDidViewModel viewModel)
        {
            InitializeComponent();

            string mnemonics = MnemonicsModel.GenerateMnemonics();

            var account = MnemonicsModel.GetAccountFromMnemonics(mnemonics);

            viewModel.Mnemonics = mnemonics;
            viewModel.Did = account.ToDidAddress();

            BindingContext = viewModel;
        }
    }
}

