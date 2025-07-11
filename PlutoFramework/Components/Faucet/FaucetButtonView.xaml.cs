using PlutoFramework.Constants;
using PlutoFramework.Model;

namespace PlutoFramework.Components.Faucet;

public partial class FaucetButtonView : ContentView, ISetEmptyView
{
	private EndpointEnum endpoint;
	public FaucetButtonView(EndpointEnum endpoint)
	{
		InitializeComponent();

        this.endpoint = endpoint;
        string wsUrl = Endpoints.GetEndpointDictionary[endpoint].URLs.First();

		BindingContext = new FaucetButtonViewModel(wsUrl);
	}

	public void SetEmpty()
	{


        var viewModel = (FaucetButtonViewModel)BindingContext;
		var assetsDict = AssetsModel.AssetsDict;

		var keyNative = (endpoint, Types.AssetPallet.Native, 0);
		var keyUsdt = (endpoint, Types.AssetPallet.Assets, 1984);
		var keyUsdc = (endpoint, Types.AssetPallet.Assets, 1337);

        if ((assetsDict.ContainsKey(keyNative) && assetsDict[keyNative].Amount == 0) ||
            (assetsDict.ContainsKey(keyUsdt) && assetsDict[keyUsdt].Amount == 0) ||
            (assetsDict.ContainsKey(keyUsdc) && assetsDict[keyUsdc].Amount == 0))
		{
			viewModel.IsVisible = true;
		}
    }
}