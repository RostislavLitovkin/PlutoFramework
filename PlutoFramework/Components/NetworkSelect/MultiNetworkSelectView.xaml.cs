using PlutoFramework.Components.MessagePopup;
using PlutoFramework.Model;

namespace PlutoFramework.Components.NetworkSelect;

public partial class MultiNetworkSelectView : ContentView
{
	public MultiNetworkSelectView()
	{
        InitializeComponent();

        BindingContext = DependencyService.Get<MultiNetworkSelectViewModel>();
    }

    public bool Clicked { get; set; } = false;

    void OnNetworkClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        try
        {
            if (((NetworkBubbleView)((HorizontalStackLayout)sender).Parent.Parent.Parent).ShowName)
            {
                // Probably do nothing
            }
            else
            {
                var senderBubble = ((NetworkBubbleView)((HorizontalStackLayout)sender).Parent.Parent.Parent);

                _ = SubstrateClientModel.ChangeMainSubstrateClientAsync(senderBubble.EndpointKey, CancellationToken.None);
            }
        }
        catch (Exception ex)
        {
            var messagePopup = DependencyService.Get<MessagePopupViewModel>();

            messagePopup.Title = "MultiNetworkSelectView Error";
            messagePopup.Text = ex.ToString();

            messagePopup.IsVisible = true;
        }
    }

    async void OnOtherNetworksClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        if (Clicked)
        {
            return;
        }

        Clicked = true;
        var popupViewModel = DependencyService.Get<NetworkSelectPopupViewModel>();

        popupViewModel.SetNetworks();

        Clicked = false;
    }
}
