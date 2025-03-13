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

        viewModel.AccountType = (AccountType)Enum.Parse(typeof(AccountType), Preferences.Get(PreferencesModel.ACCOUNT_TYPE, AccountType.None.ToString()));

        viewModel.Mnemonics = secret ?? "Mnemonics are not available for your account.";

        if (viewModel.AccountType == AccountType.Json)
        {
            viewModel.Mnemonics = "Mnemonics are not available for your account.";
        }
	}
}
