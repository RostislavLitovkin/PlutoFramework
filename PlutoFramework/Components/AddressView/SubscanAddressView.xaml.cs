using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.WebView;
using WebSocketSharp;

namespace PlutoFramework.Components.AddressView;

public partial class SubscanAddressView : ContentView
{
    public static readonly BindableProperty AddressProperty = BindableProperty.Create(
        nameof(Address), typeof(string), typeof(SubscanAddressView));

    public static readonly BindableProperty AddressTextProperty = BindableProperty.Create(
        nameof(AddressText), typeof(string), typeof(SubscanAddressView),
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (SubscanAddressView)bindable;
            var address = (string)newValue;

            control.addressLabel.Text = address;
        });

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title), typeof(string), typeof(SubscanAddressView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (SubscanAddressView)bindable;
            control.titleLabel.Text = (string)newValue;
        });

    public SubscanAddressView()
    {
        InitializeComponent();
    }

    public string Address
    {
        get => (string)GetValue(AddressProperty);
        set => SetValue(AddressProperty, value);
    }

    public string AddressText
    {
        get => (string)GetValue(AddressTextProperty);
        set => SetValue(AddressTextProperty, value);
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    private async void OnCopyTapped(object sender, TappedEventArgs e)
    {
        await CopyAddress.CopyToClipboardAsync(Address);
    }

    private async void OnSubscanTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new ExtensionWebViewPage($"https://www.subscan.io/account/{Address}"));
    }
}