using Plutonication;
using PlutoWallet.Components.MessagePopup;
using PlutoWallet.Components.NetworkSelect;
using PlutoWallet.Components.Settings;
using PlutoWallet.Components.TransferView;
using PlutoWallet.Components.UniversalScannerView;
using PlutoWallet.Components.Vault;
using PlutoWallet.Model;
using PlutoWallet.ViewModel;

namespace PlutoWallet.View;

public partial class MainPage : ContentPage
{
    public static IList<IView> Views => StackLayout.Children;
    public static VerticalStackLayout StackLayout { get; set; }
    public MainPage()
    {

        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();

        BindingContext = DependencyService.Get<MainViewModel>();

        StackLayout = stackLayout;

        SetupLayout();
    }

    public static void SetupLayout()
    {
        if (StackLayout.Children.Count() != 0)
        {
            StackLayout.Children.Clear();
        }

        List<IView> views = [];
        try
        {
            views = Model.CustomLayoutModel.ParsePlutoLayout(Preferences.Get(
                "PlutoLayout",
                Model.CustomLayoutModel.DEFAULT_PLUTO_LAYOUT));
        }
        catch
        {
            views = Model.CustomLayoutModel.ParsePlutoLayout(Model.CustomLayoutModel.DEFAULT_PLUTO_LAYOUT);
        }

        foreach (IView view in views)
        {
            ((ContentView)view).Parent = null;
            StackLayout.Children.Add(view);
        }

        // Load
        var multiNetworkSelectViewModel = DependencyService.Get<MultiNetworkSelectViewModel>();
        multiNetworkSelectViewModel.SetupDefault();
    }

    async void OnQRClicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new UniversalScannerPage
        {
            OnScannedMethod = OnScanned
        });
    }

    async void OnSettingsClicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new SettingsPage());
    }

    async void OnScanned(System.Object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
#pragma warning disable VSTHRD101 // Avoid unsupported async delegates
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            if (e.Results.Length <= 0)
            {
                return;
            }

            try
            {
                var scannedValue = e.Results[0].Value;

                // trying to connect to a dApp
                if (scannedValue.Length > 14 && scannedValue.Substring(0, 14) == "plutonication:")
                {
                    AccessCredentials ac = new AccessCredentials(new Uri(scannedValue));

                    PlutonicationModel.ProcessAccessCredentials(ac);
                }
                else if (scannedValue.Length > 13 && scannedValue.Substring(0, 13) == "plutolayout: ")
                {
                    // LATER: check validity

                    Model.CustomLayoutModel.SaveLayout(scannedValue);
                }
                else if (scannedValue.Length > 10 && scannedValue.Substring(0, 10) == "substrate:")
                {
                    var viewModel = DependencyService.Get<TransferViewModel>();

                    viewModel.IsVisible = true;

                    if (scannedValue.Substring(10).IndexOf(":") != -1)
                    {
                        viewModel.Address = scannedValue.Substring(10, scannedValue.Substring(10).IndexOf(":"));
                    }
                    else
                    {
                        viewModel.Address = scannedValue.Substring(10);
                    }

                    viewModel.GetFeeAsync();
                }
                else if (Substrate.NetApi.Utils.Bytes2HexString(e.Results[0].Raw).IndexOf("530102") != -1)
                {
                    var vaultSign = DependencyService.Get<VaultSignViewModel>();

                    await vaultSign.SignExtrinsicAsync("0x" + Substrate.NetApi.Utils.Bytes2HexString(e.Results[0].Raw).Substring(Substrate.NetApi.Utils.Bytes2HexString(e.Results[0].Raw).IndexOf("530102") + 6));
                }
                else
                {
                    var messagePopup = DependencyService.Get<MessagePopupViewModel>();

                    messagePopup.Title = "Unable to read QR code";
                    messagePopup.Text = "The QR code was in incorrect format.";

                    messagePopup.IsVisible = true;
                }

                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {

                // Does not make much sense now...
                return;

                var messagePopup = DependencyService.Get<MessagePopupViewModel>();

                messagePopup.Title = "BasePage Error";
                messagePopup.Text = ex.Message;

                messagePopup.IsVisible = true;
            }
        });
#pragma warning restore VSTHRD101 // Avoid unsupported async delegates
    }
}