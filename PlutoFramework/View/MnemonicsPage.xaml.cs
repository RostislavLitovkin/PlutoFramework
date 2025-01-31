using CommunityToolkit.Maui.Storage;
using PlutoFramework.Model;
using PlutoFramework.Components.Mnemonics;
using Substrate.NET.Schnorrkel.Keys;
using Substrate.NET.Wallet.Keyring;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;

namespace PlutoFramework.View;

public partial class MnemonicsPage : ContentPage
{

    /// <summary>
    /// Intended for use with `KeysModel.GetMnemonicsOrPrivateKeyAsync()`
    /// </summary>
	public MnemonicsPage(string? secret)
	{
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();

        var accountType = (AccountType)Enum.Parse(typeof(AccountType), Preferences.Get(PreferencesModel.ACCOUNT_TYPE, AccountType.None.ToString()));

        viewModel.Title = accountType switch
        {
            AccountType.Mnemonic => "Mnemonics:",
            AccountType.PrivateKey => "Private key:",
            _ => "Mnemonics:"
        };

        exportJsonButton.ButtonState = accountType == AccountType.PrivateKey ? Components.Buttons.ButtonStateEnum.Disabled : Components.Buttons.ButtonStateEnum.Enabled;

        viewModel.Mnemonics = secret ?? "Mnemonics are not available for your account.";
        if (accountType == AccountType.Json)
        {
            viewModel.Mnemonics = "Mnemonics are not available for your account.";
        }
	}

	private async void GoToEnterMnemonics(System.Object sender, System.EventArgs e)
    {
		await Navigation.PushAsync(new EnterMnemonicsPage());
    }
    private async void OnMnemonicsExplanationClicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new MnemonicsExplanationPage());
    }
}
