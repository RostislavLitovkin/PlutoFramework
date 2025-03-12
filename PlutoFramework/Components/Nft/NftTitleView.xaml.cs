using PlutoFramework.Constants;
using PlutoFramework.Model;

namespace PlutoFramework.Components.Nft;

public partial class NftTitleView : ContentView
{
    public static readonly BindableProperty EndpointProperty = BindableProperty.Create(
        nameof(Endpoint), typeof(Endpoint), typeof(NftTitleView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) => {
            var control = (NftTitleView)bindable;

            control.networkBubble.Name = ((Endpoint)newValue).Name;
            control.networkBubble.EndpointKey = ((Endpoint)newValue).Key;
        });

    public static readonly BindableProperty KodadotUnlockableUrlProperty = BindableProperty.Create(
        nameof(KodadotUnlockableUrl), typeof(string), typeof(NftTitleView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) => {
            var control = (NftTitleView)bindable;
            if(((string?)newValue) is not null)
            {
                control.kodadotUnlockableButton.IsVisible = true;
            }
        });

    public static readonly BindableProperty AzeroIdReservedUntilProperty = BindableProperty.Create(
        nameof(AzeroIdReservedUntil), typeof(string), typeof(NftTitleView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) => {
            var control = (NftTitleView)bindable;

            control.reservedUntilLabel.IsVisible = true;

            control.reservedUntilLabel.Text = (string)newValue;
        });

    public NftTitleView()
	{
		InitializeComponent();
	}

    public string KodadotUnlockableUrl
    {
        get => (string?)GetValue(KodadotUnlockableUrlProperty);

        set => SetValue(KodadotUnlockableUrlProperty, value);
    }

    public string AzeroIdReservedUntil
    {
        get => (string)GetValue(AzeroIdReservedUntilProperty);

        set => SetValue(AzeroIdReservedUntilProperty, value);
    }

    public Endpoint Endpoint
    {
        get => (Endpoint)GetValue(EndpointProperty);

        set => SetValue(EndpointProperty, value);
    }

    async void ClaimPhysicalDropClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        if (KodadotUnlockableUrl is null)
        {
            return;
        }
            await Navigation.PushAsync(new WebView.WebViewPage(KodadotUnlockableUrl));
        
    }
}
