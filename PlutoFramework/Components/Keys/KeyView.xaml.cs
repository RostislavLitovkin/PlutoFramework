using PlutoFrameworkCore.Keys;

namespace PlutoFramework.Components.Keys;

public partial class KeyView : ContentView
{
    public static readonly BindableProperty KeyProperty = BindableProperty.Create(
        nameof(Key),
        typeof(GenericLockedKey),
        typeof(KeyView),
        string.Empty,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (KeyView)bindable;

            var key = (GenericLockedKey)newValue;

            control.nameLabel.Text = key.Name;

            // TODO icon etc
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
        Page navigation = Key.Type switch
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
}
}