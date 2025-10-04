using CommunityToolkit.Maui.Alerts;
using PlutoFramework.Components.Kilt;
using PlutoFramework.Components.Mnemonics;
using PlutoFramework.Model;
using PlutoFramework.Model.SQLite;
using PlutoFrameworkCore.Keys;

namespace PlutoFramework.Components.Keys;

public partial class NewKeyView : ContentView
{
    public static readonly BindableProperty KeyTypeProperty = BindableProperty.Create(
        nameof(KeyType),
        typeof(KeyTypeEnum),
        typeof(NewKeyView),
        null,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (NewKeyView)bindable;

            if (newValue == null)
            {
                return;
            }

            var keyType = (KeyTypeEnum)newValue;

            control.nameLabelText.Text = keyType.GetName();

            _ = control.ChangeButtonsIfKeyExistsAsync();
        });

    public NewKeyView()
    {
        InitializeComponent();
    }

    public KeyTypeEnum KeyType
    {
        get => (KeyTypeEnum)GetValue(KeyTypeProperty);
        set => SetValue(KeyTypeProperty, value);
    }
    
    private async Task ChangeButtonsIfKeyExistsAsync()
    {
        if (!await CheckKeyExistsAsync(disableToast: true))
        {
            return;
        }

        import.Opacity = 0.3;
        plus.Opacity = 0.3;
    }

    private async Task<bool> CheckKeyExistsAsync(bool disableToast = false)
    {
        var allSavedKeys = await KeysDatabase.GetAllKeysAsync();

        var keyIsPolkadotType = KeyType == KeyTypeEnum.Sr25519 || KeyType == KeyTypeEnum.PolkadotJson;

        if (allSavedKeys.Where(key => key.Type == KeyType ||
            (keyIsPolkadotType && (key.Type == KeyTypeEnum.Sr25519 || key.Type == KeyTypeEnum.PolkadotJson))).Any())
        {
            if (keyIsPolkadotType && !disableToast)
            {
                var toast = Toast.Make($"{KeyType.GetName()} already exists.");
                await toast.Show();
            }
            else if (!disableToast)
            {
                var toast = Toast.Make($"{KeyType.GetName()} already exists.");
                await toast.Show();
            }

            return true;
        }

        return false;
    }
    private async void OnAddClicked(object sender, TappedEventArgs e)
    {
        if (await CheckKeyExistsAsync())
        {
            return;
        }

        switch (KeyType)
        {
            case KeyTypeEnum.Sr25519:
            case KeyTypeEnum.PolkadotJson:
                await KeysModel.GenerateNewAccountAsync();

                var sr25519toast = Toast.Make($"{KeyType.GetName()} created successfully.");
                await sr25519toast.Show();

                break;
            case KeyTypeEnum.Did:
                await KeysModel.GenerateNewDidAsync();

                var didToast = Toast.Make($"{KeyType.GetName()} created successfully.");
                await didToast.Show();

                break;
            case KeyTypeEnum.EncryptionX25519:
                await KeysModel.GenerateNewEncryptionX25519KeyAsync();

                var encryptionX25519Toast = Toast.Make($"{KeyType.GetName()} created successfully.");
                await encryptionX25519Toast.Show();

                break;
            default:
                var toast = Toast.Make($"Creating {KeyType.GetName()} keys is not supported yet.");
                await toast.Show();
                break;
        }

        await ChangeButtonsIfKeyExistsAsync();
    }
    private async void OnImportClicked(object sender, TappedEventArgs e)
    {
        if (await CheckKeyExistsAsync())
        {
            import.Opacity = 0.3;
            plus.Opacity = 0.3;

            return;
        };

        switch (KeyType)
        {
            case KeyTypeEnum.Sr25519:
                await Shell.Current.Navigation.PushAsync(new EnterMnemonicsPage(new EnterMnemonicsViewModel {
                    Navigation = Shell.Current.Navigation.PopAsync,
                }));

                break;

            case KeyTypeEnum.PolkadotJson:
                await KeysModel.ImportJsonKeyAsync();

                break;

            case KeyTypeEnum.Did:
                await Shell.Current.Navigation.PushAsync(new ImportDidPage(new ImportDidViewModel
                {
                    Navigation = Shell.Current.Navigation.PopAsync,
                }));

                break;

            case KeyTypeEnum.EncryptionX25519:
                await Shell.Current.Navigation.PushAsync(new ImportEncryptionX25519KeyPage(new ImportEncryptionX25519KeyPageViewModel
                {
                    Navigation = Shell.Current.Navigation.PopAsync,
                }));

                break;

            default:
                var toast = Toast.Make($"Importing {KeyType.GetName()} keys is not supported yet.");
                await toast.Show();

                break;
        }
    }
}