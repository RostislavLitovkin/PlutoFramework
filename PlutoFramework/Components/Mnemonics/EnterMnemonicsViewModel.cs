using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;

namespace PlutoFramework.Components.Mnemonics
{
    public partial class EnterMnemonicsViewModel : ObservableObject
    {
        public required Func<Task> Navigation;

        [ObservableProperty]
        private bool incorrectMnemonicsEntered = false;

        [ObservableProperty]
        private string mnemonics = "";

        [ObservableProperty]
        private string privateKey = "";

        public bool UsePrivateKeyIsVisible => Preferences.Get(PreferencesModel.SETTINGS_ALLOW_PRIVATE_KEY, false);

        [RelayCommand]
        public async Task ContinueWithMnemonicsAsync()
        {
            try
            {
                await Model.KeysModel.GenerateNewAccountAsync(
                    Mnemonics,
                    accountVariant: ""
                );

                await Navigation.Invoke();
            }
            catch
            {
                IncorrectMnemonicsEntered = true;
            }
        }

        [RelayCommand]
        public async Task ContinueWithPrivateKeyAsync()
        {
            await Model.KeysModel.GenerateNewAccountFromPrivateKeyAsync(PrivateKey);

            await Navigation.Invoke();
        }

        [RelayCommand]
        public async Task ImportJsonAsync()
        {
            var jsonType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                { DevicePlatform.iOS, new[] { "public.json" } }, // UTType values
                { DevicePlatform.Android, new[] { "application/json" } }, // MIME type
                { DevicePlatform.WinUI, new[] { ".json" } }, // file extension
                { DevicePlatform.Tizen, new[] { "*/*" } },
                { DevicePlatform.macOS, new[] { "public.json" } }, // UTType values
                });

            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Import json account",
                FileTypes = jsonType,
            });

            if (result is null || !result.FileName.Contains(".json"))
                return;

            using var jsonStream = await result.OpenReadAsync();

            string json = StreamToString(jsonStream);

            try
            {
                await KeysModel.GenerateNewAccountFromJsonAsync(json);
            }
            catch
            {
                return;
            }

            await Navigation.Invoke();
        }

        public static string StreamToString(Stream stream)
        {
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
