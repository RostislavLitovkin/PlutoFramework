using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Model;

namespace PlutoFramework.Components.AddressView
{
    internal partial class AddressQrCodeViewModel : ObservableObject, IPopup
    {
        [ObservableProperty]
        private string qrAddress;

        private string address;

        public string Address
        {
            get => address;
            set => SetProperty(ref address, value.Substring(0, value.Length / 2) + "\n" + value.Substring(value.Length / 2));
        }

        [ObservableProperty]
        private bool isVisible = false;
    }
}
