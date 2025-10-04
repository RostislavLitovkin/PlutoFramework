using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PlutoFramework.Components.Keys
{
    public partial class ImportEncryptionX25519KeyPageViewModel : ObservableObject
    {
        public required Func<Task> Navigation;

        [ObservableProperty]
        private bool incorrectSecretKeyEntered = false;

        [ObservableProperty]
        private string secretKey = "";

        [RelayCommand]
        public async Task ContinueAsync()
        {
            try
            {
                var secretKeyBytes = Convert.FromBase64String(SecretKey);

                if (secretKeyBytes.Length != 32)
                {
                    throw new FormatException("Invalid key length");
                }

                await Model.KeysModel.SaveEncryptionX25519KeyAsync(
                    secretKeyBytes
                );

                await Navigation.Invoke();
            }
            catch
            {
                IncorrectSecretKeyEntered = true;
            }
        }
    }
}
