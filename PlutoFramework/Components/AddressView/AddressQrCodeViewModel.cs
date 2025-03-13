using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Model;

namespace PlutoFramework.Components.AddressView
{
    internal partial class AddressQrCodeViewModel : ObservableObject, IPopup
    {
        [ObservableProperty]
        private string qrAddress;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TwoLineAddress))]
        private string address;

        public string TwoLineAddress => Address.Substring(0, Address.Length / 2) + "\n" + Address.Substring(Address.Length / 2);

        [ObservableProperty]
        private bool isVisible = false;
    }
}
