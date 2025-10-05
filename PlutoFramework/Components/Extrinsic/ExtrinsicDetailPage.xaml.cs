using PlutoFramework.Components.Events;
using PlutoFramework.Components.WebView;
using PlutoFramework.Constants;
using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Extrinsic;

public partial class ExtrinsicDetailPage : PageTemplate
{
    private Endpoint endpoint;
    private string blockNumberExtrinsicIndex;
	public ExtrinsicDetailPage(EventsListViewModel eventsListModel, Endpoint endpoint, string blockNumberExtrinsicIndex)
	{
        InitializeComponent();

        eventsListView.BindingContext = eventsListModel;

        this.endpoint  = endpoint;
        this.blockNumberExtrinsicIndex = blockNumberExtrinsicIndex;

        subscanButton.IsVisible = endpoint.SubscanChainName != null;
    }

    private async void OnOpenSubscanClicked(object sender, TappedEventArgs e)
    {
        if (endpoint.SubscanChainName is null)
        {
            return;
        }

        await Navigation.PushAsync(new WebViewPage($"https://{endpoint.SubscanChainName}.{Constants.Subscan.SUBSCAN_URL}/extrinsic/{blockNumberExtrinsicIndex}"));
    }
}