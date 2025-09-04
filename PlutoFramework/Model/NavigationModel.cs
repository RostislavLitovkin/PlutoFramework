

using PlutoFramework.Components.Account;
using PlutoFramework.Components.Balance;
using PlutoFramework.Components.MessagePopup;
using PlutoFramework.Components.Mnemonics;
using PlutoFramework.Components.TransferView;
using PlutoFramework.Components.UniversalScannerView;
using PlutoFramework.Components.Vault;
using Plutonication;

namespace PlutoFramework.Model
{
    public class NavigationModel
    {
        public static Func<Task> NavigateToKYC { get; set; } = () => Task.FromResult(0);
        public static Func<Task> NavigateAfterAccountCreation { get; set; } = NavigateToKYC;
        public static Func<Task> NavigateToUserPageAsync { get; set; } = () => Task.FromResult(0);
        public static async Task NavigateToMnemonicsPageAsync()
        {
            if (!RequirementsModel.CheckAccountExists())
            {
                var noAccountPopupViewModel = DependencyService.Get<NoAccountPopupViewModel>();

                noAccountPopupViewModel.IsVisible = true;

                return;
            }

            try
            {
                var secret = await KeysModel.GetMnemonicsOrPrivateKeyAsync();

                await Shell.Current.Navigation.PushAsync(new MnemonicsPage(secret));
            }
            catch
            {
                // Failed to authenticate
            }
        }

        public static async Task NavigateToBalancesPageAsync()
        {
            Console.WriteLine("NavigateToBalancesPageAsync called");

            if (!RequirementsModel.CheckAccountExists())
            {
                return;
            }

            await Shell.Current.Navigation.PushAsync(new BalancePage());
        }

        public static Func<Task> NavigateToSettingsPageAsync { get; set; } = () => Task.FromResult(0);

        public static async Task NavigateToQrScannerPageAsync()
        {
            if (!RequirementsModel.CheckAccountExists())
            {
                return;
            }

            await Shell.Current.Navigation.PushAsync(new UniversalScannerPage
            {
                OnScannedMethod = OnScanned
            });
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

                        CustomLayoutModel.SaveLayout(scannedValue);
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
}
