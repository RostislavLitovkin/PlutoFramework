using PlutoFramework.Model;
using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Mnemonics;

public partial class MnemonicsPage : PageTemplate
{

    /// <summary>
    /// Intended for use with `KeysModel.GetMnemonicsOrPrivateKeyAsync()`
    /// </summary>
	public MnemonicsPage(string? secret)
	{
        InitializeComponent();

        var viewModel = new MnemonicsPageViewModel();

        viewModel.AccountType = (AccountType)Enum.Parse(typeof(AccountType), Preferences.Get(PreferencesModel.ACCOUNT_TYPE, AccountType.None.ToString()));

        viewModel.Mnemonics = secret ?? "Mnemonics are not available for your account.";

        if (viewModel.AccountType == AccountType.Json)
        {
            viewModel.Mnemonics = "Mnemonics are not available for your account.";
        }

        BindingContext = viewModel;
    }
}
