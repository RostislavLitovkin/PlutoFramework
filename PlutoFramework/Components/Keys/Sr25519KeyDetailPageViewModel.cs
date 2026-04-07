using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;
using PlutoFrameworkCore.Keys;
using Substrate.NET.Wallet.Keyring;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types;

namespace PlutoFramework.Components.Keys
{
    public partial class Sr25519KeyDetailPageViewModel : BaseDetailPageViewModel
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Mnemonics))]
        [NotifyPropertyChangedFor(nameof(PolkadotAddress))]
        [NotifyPropertyChangedFor(nameof(QrAddress))]
        private Sr25519Key? unlockedKey;

        public string Mnemonics => UnlockedKey?.Mnemonics ?? "No mnemonics";

        public string PolkadotAddress => Utils.GetAddressFrom(Utils.GetPublicKeyFrom(UnlockedKey?.Account.Value), 0);

        public string QrAddress => $"substrate:{PolkadotAddress}:0x91b171bb158e2d3848fa23a9f1c25182fb8e20313b2c1eb49219da7a70ce90c3";

        [RelayCommand]
        public async Task ExportJsonAsync()
        {
            var token = CancellationToken.None;

            if (UnlockedKey?.Mnemonics is null || UnlockedKey?.Mnemonics == "")
            {
                return;
            }

            var keyring = new Keyring();
            var wallet = keyring.AddFromMnemonic(UnlockedKey?.Mnemonics, new Meta() { Name = $"{AppInfo.Current.Name} account" }, KeyType.Sr25519);

            var json = wallet.ToJson($"{AppInfo.Current.Name} account", await SecureStorage.Default.GetAsync(PreferencesModel.PASSWORD));

            await KeysModel.ExportJsonFileAsync(json, token);
        }
    }
}
