using CommunityToolkit.Mvvm.ComponentModel;

namespace PlutoFramework.Components.AddressView
{
    public partial class ChainAddressViewModel : ObservableObject
    {
        [ObservableProperty]
        private string address;

        [ObservableProperty]
        private string qrAddress;

        [ObservableProperty]
        private string chainAddressName;

        [ObservableProperty]
        private bool isVisible;

        public ChainAddressViewModel()
        {
            qrAddress = "Loading";
            address = "Loading";
            chainAddressName = "";
            isVisible = true;
        }
    }
}

