

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;
using PlutoFrameworkCore.Keys;
using Substrate.NetApi;

namespace PlutoFramework.Components.Keys
{
    public partial class PolkadotJsonKeyDetailPageViewModel : BaseDetailPageViewModel
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(PolkadotAddress))]
        [NotifyPropertyChangedFor(nameof(QrAddress))]
        private PolkadotJsonKey? unlockedKey;

        public string PolkadotAddress => Utils.GetAddressFrom(Utils.GetPublicKeyFrom(UnlockedKey?.Account.Value), 0);

        public string QrAddress => $"substrate:{PolkadotAddress}:0x91b171bb158e2d3848fa23a9f1c25182fb8e20313b2c1eb49219da7a70ce90c3";

        [RelayCommand]
        public async Task ExportJsonAsync()
        {
            var token = CancellationToken.None;

            if (UnlockedKey is null)
            {
                return;
            }

            await KeysModel.ExportJsonFileAsync(UnlockedKey.Json, token);
        }
    }
}
