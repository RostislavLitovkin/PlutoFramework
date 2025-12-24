using Chaos.NaCl;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;
using Substrate.NET.Schnorrkel;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi;
using PlutoFramework.Components.Buttons;

namespace PlutoFramework.Components.WebView
{
    public partial class WebSignRawPopupViewModel : ObservableObject, IPopup, ISetToDefault
    {
        public TaskCompletionSource<byte[]>? SignatureTask { get; set; } = null;

        [ObservableProperty]
        private string signButtonText = "Sign";

        [ObservableProperty]
        private ButtonStateEnum signButtonState = ButtonStateEnum.Enabled;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(MessageString))]
        [NotifyPropertyChangedFor(nameof(MessageDecodedString))]
        private Plutonication.RawMessage? message = null;

        public string MessageString => Message is not null ? Message.data : "IDK";

        public string MessageDecodedString => Message is not null ? System.Text.Encoding.UTF8.GetString(Utils.HexToByteArray(Message.data)) : "";

        [ObservableProperty]
        private bool isVisible;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ErrorIsVisible))]
        private string errorText = "";

        public bool ErrorIsVisible => !string.IsNullOrEmpty(ErrorText);

        public WebSignRawPopupViewModel()
        {
            SetToDefault();
        }

        [RelayCommand]
        public async Task SignAsync()
        {
            SignButtonText = "Signing";
            SignButtonState = ButtonStateEnum.Disabled;

            try
            {
                byte[] msg = Utils.HexToByteArray(Message.data);

                var account = await Model.KeysModel.GetAccountAsync();
                if (account is null)
                {
                    return;
                }

                if (msg.Length > 256) msg = HashExtension.Blake2(msg, 256);

                byte[] signature;
                switch (account.KeyType)
                {
                    case KeyType.Ed25519:
                        signature = Ed25519.Sign(msg, account.PrivateKey);
                        break;

                    case KeyType.Sr25519:
                        signature = Sr25519v091.SignSimple(account.Bytes, account.PrivateKey, msg);
                        break;

                    default:
                        throw new Exception($"Unknown key type found '{account.KeyType}'.");
                }

                if (SignatureTask == null)
                {
                    return;
                }

                SignatureTask.SetResult(signature);

                // Hide this layout
                IsVisible = false;
            }
            catch (Exception ex)
            {
                ErrorText = ex.Message;
            }
            finally
            {
                SignButtonText = "Sign";
                SignButtonState = ButtonStateEnum.Enabled;
            }
        }

        [RelayCommand]
        public void Reject()
        {
            IsVisible = false;
        }

        public void SetToDefault()
        {
            ErrorText = "";
            IsVisible = false;
            Message = null;
            SignButtonText = "Sign";
            SignButtonState = ButtonStateEnum.Enabled;
        }
    }
}

