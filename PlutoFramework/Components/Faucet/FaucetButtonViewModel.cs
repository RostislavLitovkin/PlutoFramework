using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Model;
using PlutoFramework.Model.Faucet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PlutoFramework.Components.Faucet
{
    public partial class FaucetButtonViewModel : ObservableObject
    {
        [ObservableProperty]
        private ButtonStateEnum buttonState = ButtonStateEnum.Enabled;
        [ObservableProperty]
        private string text = "Airdrop Test Tokens";
        [ObservableProperty]
        private bool isVisible = false;
        private string WebSocketUrl { get;  init; }
        public FaucetButtonViewModel(string wsUrl)
        { 
            WebSocketUrl = wsUrl;
        }

        [RelayCommand]
        public async Task AirdropAsync()
        {
            ButtonState = ButtonStateEnum.Disabled;
            Text = "Airdropping ...";
            
            var key = KeysModel.GetSubstrateKey();
            HttpStatusCode status = await FaucetApiModel.PostRequestAsync(WebSocketUrl, key);

            if (status == HttpStatusCode.OK)
            {
                Text = "Airdropped";
            }
            else
            {
                Text = "Something went wrong";
            }
        }
    }
}
