using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Substrate.NetApi.Model.Types;
using Substrate.NET.Wallet.Keyring;
using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Maui.Alerts;
using PlutoFramework.Model;
using PlutoFramework.View;
using PlutoFramework.Components.Mnemonics;

namespace PlutoFramework.ViewModel
{
    public partial class MnemonicsViewModel : ObservableObject
    {

        [ObservableProperty]
        private string mnemonics = "";
        [ObservableProperty]
        private string password = "";
        [ObservableProperty]
        private string mnemonicsTitle = "";

        [RelayCommand]
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public Task GoToEnterMnemonicsAsync() => Application.Current.MainPage.Navigation.PushAsync(new EnterMnemonicsPage());

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
}

