using CommunityToolkit.Maui.Alerts;
using PlutoFrameworkCore.Keys;

namespace PlutoFramework.Components.Keys;

public partial class KeyView : ContentView
{
    public static readonly BindableProperty KeyProperty = BindableProperty.Create(
        nameof(Key),
        typeof(GenericLockedKey),
        typeof(KeyView),
        null,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (KeyView)bindable;

            if (newValue == null)
            {
                return;
            }

            var key = (GenericLockedKey)newValue;

            control.nameLabel.Text = key.Type.GetName();

            control.publicKeyLabel.Text = key.PublicKey;

            control.descriptionLabel.Text = key.Type switch
            {
                KeyTypeEnum.EncryptionX25519 => "Used for AssetDidComm message encryption key",
                KeyTypeEnum.PolkadotJson => "Your main Polkadot account key",
                KeyTypeEnum.Sr25519 => "Your main Polkadot account key",
                KeyTypeEnum.Did => "Decentralised Identifiers powered by Kilt",
                _ => "",
            };

            // TODO icon
        });
    public KeyView()
    {
        InitializeComponent();
    }

    public GenericLockedKey Key
    {
        get => (GenericLockedKey)GetValue(KeyProperty);
        set => SetValue(KeyProperty, value);
    }

    private async void OnClicked(object sender, TappedEventArgs e)
    {
        try
        {
            Page page = Key.Type switch
            {
                KeyTypeEnum.Sr25519 => new Sr25519KeyDetailPage(new Sr25519KeyDetailPageViewModel
                {
                    LockedKey = Key,
                    UnlockedKey = await Key.ToSr25519KeyAsync(),
                }),
                KeyTypeEnum.PolkadotJson => new PolkadotJsonKeyDetailPage(new PolkadotJsonKeyDetailPageViewModel
                {
                    LockedKey = Key,
                    UnlockedKey = await Key.ToPolkadotJsonKeyAsync(),
                }),
                KeyTypeEnum.Did => new DidKeyDetailPage(new DidKeyDetailPageViewModel
                {
                    LockedKey = Key,
                    UnlockedKey = await Key.ToDidKeyAsync(),
                }),
                KeyTypeEnum.EncryptionX25519 => new EncryptionX25519KeyDetailPage(new EncryptionX25519KeyDetailPageViewModel
                {
                    LockedKey = Key,
                    UnlockedKey = await Key.ToEncryptionX25519KeyAsync(),
                }),
                _ => throw new Exception($"Key {Key.Type} type is missing."),
            };

            await Shell.Current.Navigation.PushAsync(page);
        }
        catch
        {
            Console.WriteLine("Json content: ");
            Console.WriteLine(await SecureStorage.Default.GetAsync(Key.SecretStorageKey));

            Console.WriteLine(Key.PasswordStorageKey);
            Console.WriteLine(await SecureStorage.Default.GetAsync(Key.PasswordStorageKey));

            var toast = Toast.Make("Could not open the key");
            await toast.Show();
        }
    }
}