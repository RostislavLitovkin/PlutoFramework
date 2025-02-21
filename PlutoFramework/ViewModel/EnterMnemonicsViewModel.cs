using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;
using PlutoFramework.View;

namespace PlutoFramework.ViewModel
{
    public partial class EnterMnemonicsViewModel : ObservableObject
    {
        public required Func<Task> Navigation;

        [ObservableProperty]
        private string mnemonics = "";

        [ObservableProperty]
        private string privateKey = "";

        public bool UsePrivateKeyIsVisible => Preferences.Get(PreferencesModel.SETTINGS_ALLOW_PRIVATE_KEY, false);

        [RelayCommand]
        public async Task ContinueWithMnemonicsAsync()
        {
            await Model.KeysModel.GenerateNewAccountAsync(
                Mnemonics,
                null
            );

            MainPage.SetupLayout();

            await Navigation.Invoke();
        }

        [RelayCommand]
        public async Task ContinueWithPrivateKeyAsync()
        {
            await Model.KeysModel.GenerateNewAccountFromPrivateKeyAsync(PrivateKey);

            MainPage.SetupLayout();

            await Navigation.Invoke();
        }

        [RelayCommand]
        public async Task ImportJsonAsync()
        {
            var jsonType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                { DevicePlatform.iOS, new[] { "json" } }, // UTType values
                { DevicePlatform.Android, new[] { "application/json" } }, // MIME type
                { DevicePlatform.WinUI, new[] { ".json" } }, // file extension
                { DevicePlatform.Tizen, new[] { "*/*" } },
                { DevicePlatform.macOS, new[] { "json" } }, // UTType values
                });

            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Import json",
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

            MainPage.SetupLayout();

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
