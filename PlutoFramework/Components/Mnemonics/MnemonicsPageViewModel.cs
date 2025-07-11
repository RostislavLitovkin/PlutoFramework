using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Substrate.NetApi.Model.Types;
using Substrate.NET.Wallet.Keyring;
using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Maui.Alerts;
using PlutoFramework.Model;
using PlutoFramework.Components.Buttons;

namespace PlutoFramework.Components.Mnemonics;
public partial class MnemonicsPageViewModel : ObservableObject
{

    [ObservableProperty]
    private string mnemonics = "";

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(MnemonicsTitle))]
    [NotifyPropertyChangedFor(nameof(ExportJsonButtonState))]
    private AccountType accountType = AccountType.Mnemonic;

    public string MnemonicsTitle => AccountType switch
    {
        AccountType.Mnemonic => "Mnemonics:",
        AccountType.PrivateKey => "Private key:",
        _ => "Mnemonics:"
    };

    public ButtonStateEnum ExportJsonButtonState => AccountType == AccountType.PrivateKey ? Components.Buttons.ButtonStateEnum.Disabled : Components.Buttons.ButtonStateEnum.Enabled;

    [RelayCommand]
#pragma warning disable CS8602 // Dereference of a possibly null reference.
    public Task GoToEnterMnemonicsAsync() => Application.Current.MainPage.Navigation.PushAsync(new EnterMnemonicsPage(new EnterMnemonicsViewModel
    {
        Navigation = () => Shell.Current.GoToAsync("../..")
    }));

    [RelayCommand]
    public Task GoToMnemonicsExplanationAsync() => Application.Current.MainPage.Navigation.PushAsync(new MnemonicsExplanationPage());
#pragma warning restore CS8602 // Dereference of a possibly null reference.

    [RelayCommand]
    public async Task ExportJsonAsync()
    {
        var token = CancellationToken.None;

        var accountType = (AccountType)Enum.Parse(typeof(AccountType), Preferences.Get(PreferencesModel.ACCOUNT_TYPE, AccountType.None.ToString()));

        try
        {
            var secret = await Model.KeysModel.GetMnemonicsOrPrivateKeyAsync();

            if (secret == null)
            {
                return;
            }

            if (accountType == AccountType.Json)
            {
                await SaveJsonAsync(secret, token);

                return;
            }
        }
        catch
        {
            // Authentication failed
        }

        if (accountType != AccountType.Mnemonic)
        {
            return;
        }

        if (Mnemonics is null || Mnemonics == "")
        {
            return;
        }

        var keyring = new Keyring();
        var wallet = keyring.AddFromMnemonic(Mnemonics, new Meta() { Name = $"{AppInfo.Current.Name} account" }, KeyType.Sr25519);

        var json = wallet.ToJson($"{AppInfo.Current.Name} account", await SecureStorage.Default.GetAsync(PreferencesModel.PASSWORD));

        await SaveJsonAsync(json, token);
    }

    /// <summary>
    /// Source: https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/essentials/file-saver?tabs=macos 
    /// </summary>
    private static async Task SaveJsonAsync(string json, CancellationToken token)
    {
        using var stream = new MemoryStream(System.Text.Encoding.Default.GetBytes(json));
        var fileSaverResult = await FileSaver.Default.SaveAsync($"{AppInfo.Current.Name}.json", stream, token);

        if (fileSaverResult.IsSuccessful)
        {
            await Toast.Make($"Mnemonics successfully exported.").Show(token);
        }
        else
        {
            await Toast.Make($"Failed to export.").Show(token);
        }
    }
}

