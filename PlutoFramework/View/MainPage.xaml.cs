using Plutonication;
using PlutoFramework.Components.MessagePopup;
using PlutoFramework.Components.NetworkSelect;
using PlutoFramework.Components.Settings;
using PlutoFramework.Components.TransferView;
using PlutoFramework.Components.UniversalScannerView;
using PlutoFramework.Components.Vault;
using PlutoFramework.Model;

namespace PlutoFramework.View;

public partial class MainPage : ContentPage
{
    public static IList<IView> Views => StackLayout?.Children ?? [];
    public static VerticalStackLayout? StackLayout { get; set; }
    public static MultiNetworkSelectView? NetworksView { get; set; }
    public MainPage()
    {
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();

        networksView.IsVisible = Preferences.Get(PreferencesModel.SETTINGS_DISPLAY_NETWORKS, true);

        NetworksView = networksView;

        StackLayout = stackLayout;

        SetupLayout();
    }

    public static void SetupLayout()
    {
        if (StackLayout is null)
        {
            return;
        }

        if (StackLayout.Children.Count() != 0)
        {
            StackLayout.Children.Clear();
        }

        List<IView> views = [];
        try
        {
            views = Model.CustomLayoutModel.ParsePlutoLayout(Model.CustomLayoutModel.DEFAULT_PLUTO_LAYOUT);
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
        try
        {
            var multiNetworkSelectViewModel = DependencyService.Get<MultiNetworkSelectViewModel>();
            multiNetworkSelectViewModel.SetupDefault();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    async void OnQRClicked(System.Object sender, System.EventArgs e)
    {
        if(! AccountModel.CheckRequirements())
        {
            return;
        }

        await Navigation.PushAsync(new UniversalScannerPage
        {
            OnScannedMethod = OnScanned
        });
    }

    async void OnSettingsClicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new SettingsPage());
    }

    public static void OnScanned(System.Object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
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

                    viewModel.GetFeeAsync();

                    viewModel.IsVisible = true;

                    var scannedAddress = e.Results[e.Results.Length - 1].Value;

                    if (scannedAddress.Substring(10).IndexOf(":") != -1)
                    {
                        viewModel.Address = scannedAddress.Substring(10, scannedAddress.Substring(10).IndexOf(":"));
                    }
                    else
                    {
                        viewModel.Address = scannedAddress.Substring(10);
                    }
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

                await Application.Current.MainPage.Navigation.PopAsync();
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