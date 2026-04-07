using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFrameworkCore.Keys;

namespace PlutoFramework.Components.Keys
{
    public partial class EncryptionX25519KeyDetailPageViewModel : BaseDetailPageViewModel
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SecretKey))]
        private EncryptionX25519Key? unlockedKey;
        public string SecretKey => UnlockedKey is not null ? Convert.ToBase64String(UnlockedKey.SecretKey) : "No secret key";

    }
}
