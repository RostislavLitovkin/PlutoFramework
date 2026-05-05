using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Components.Keys;
using PlutoFramework.Model;
using PlutoFramework.Model.SQLite;
using PlutoFrameworkCore;
using PlutoFrameworkCore.Keys;
using Substrate.NET.Wallet.Keyring;
using Substrate.NetApi.Model.Types;

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
    public Task GoToEnterMnemonicsAsync() => NavigationModel.PushAsync(new EnterMnemonicsPage(new EnterMnemonicsViewModel
    {
        Navigation = () => Shell.Current.GoToAsync("../..")
    }));

    [RelayCommand]
    public Task GoToMnemonicsExplanationAsync() => NavigationModel.PushAsync(new MnemonicsExplanationPage());
#pragma warning restore CS8602 // Dereference of a possibly null reference.

    [RelayCommand]
    public async Task ExportJsonAsync()
    {
        var token = CancellationToken.None;
        var accounts = await KeysDatabase.GetAllKeysOfTypeAsync(KeyTypeEnum.Sr25519, KeyTypeEnum.PolkadotJson);

        if (!accounts.Any())
        {
            return;
        }

        if (!accounts.Any())
        {
            await Toast.Make($"Failed to export.").Show();

            return;
        }

        var accountLockedKey = accounts.First();

        try
        {
            switch (accountLockedKey.Type)
            {
                case KeyTypeEnum.Sr25519:

                    var mnemonics = await accountLockedKey.ToSr25519KeyAsync();

                    var keyring = new Keyring();
                    var wallet = keyring.AddFromMnemonic(Mnemonics, new Meta() { Name = $"account" }, KeyType.Sr25519);

                    var json = wallet.ToJson($"account", await SecureStorage.Default.GetAsync(PreferencesModel.PASSWORD));

                    await ExportJsonAsync(json, token);

                    break;
                case KeyTypeEnum.PolkadotJson:
                    var jsonKey = await accountLockedKey.ToPolkadotJsonKeyAsync();

                    await ExportJsonAsync(jsonKey.Json, token);

                    break;
                default:
                    return;
            }
        }
        catch
        {
            await Toast.Make($"Failed to export.").Show();

            return;
        }
    }

    /// <summary>
    /// Source: https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/essentials/file-saver?tabs=macos 
    /// </summary>
    private static async Task ExportJsonAsync(string json, CancellationToken token)
    {
        using var stream = new MemoryStream(System.Text.Encoding.Default.GetBytes(json));
        var fileSaverResult = await FileSaver.Default.SaveAsync($"{AppInfo.Current.Name.ToLower()}.json", stream, token);

        if (fileSaverResult.IsSuccessful)
        {
            await Toast.Make($"Mnemonics successfully exported.").Show(token);
        }
        else
        {
            await Toast.Make($"Failed to export.").Show(token);
        }
    }


    [RelayCommand]
    public void ForgotKey()
    {
        var popupViewModel = DependencyService.Get<CanNotRecoverKeyPopupViewModel>();

        popupViewModel.ProceedFunc = GenerateNewAccountAsync;

        popupViewModel.IsVisible = true;
    }
    private async Task GenerateNewAccountAsync()
    {
        await SQLiteModel.DeleteAllDatabasesAsync();

        await Model.KeysModel.GenerateNewAccountAsync();

        await PlutoConfigurationModel.AfterAccountImportAsync();
    }
}

