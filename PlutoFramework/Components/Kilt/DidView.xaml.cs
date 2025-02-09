using PlutoFramework.Components.AddressView;

namespace PlutoFramework.Components.Kilt;

public partial class DidView : ContentView
{
    public static readonly BindableProperty DidProperty = BindableProperty.Create(
        nameof(Did), typeof(string), typeof(DidView),
        defaultValue: string.Empty,
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (DidView)bindable;

            control.addressLabel.Text = (string)newValue;

            if (string.IsNullOrEmpty((string)newValue))
            {
                control.addressLabel.Text = "None";
            }
            else
            {
                control.verificationImage.IsVisible = true;
            }
        });

    public static readonly BindableProperty VerificationProperty = BindableProperty.Create(
        nameof(Verification), typeof(DidVerificationEnum), typeof(DidView),
        defaultValue: DidVerificationEnum.Light,
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (DidView)bindable;

            var verification = (DidVerificationEnum)newValue;

            if (verification == DidVerificationEnum.None)
            {
                return;
            }
            
            if (verification == DidVerificationEnum.Light)
            {
                return;
            }

            if (verification == DidVerificationEnum.Full)
            {
                control.verificationImage.Source = "chaingreen.png";
            }
        });

    public DidView()
    {
        InitializeComponent();
    }

    public string Did
    {
        get => (string)GetValue(DidProperty);

        set => SetValue(DidProperty, value);
    }

    public DidVerificationEnum Verification
    {
        get => (DidVerificationEnum)GetValue(VerificationProperty);

        set => SetValue(VerificationProperty, value);
    }
    private async void OnTapped(System.Object sender, System.EventArgs e)
    {
        var did = (string)GetValue(DidProperty);
        if (string.IsNullOrEmpty(did))
            return;

        await CopyAddress.CopyToClipboardAsync(did);
    }
}