using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.NetworkSelect;

namespace PlutoFramework.Components.AssetSelect;

public partial class AssetSelectView : ContentView
{

    public static readonly BindableProperty UpdateCommandProperty = BindableProperty.Create(
        nameof(UpdateCommand), typeof(IRelayCommand), typeof(AssetSelectView),
        defaultBindingMode: BindingMode.TwoWay);
    public IRelayCommand UpdateCommand
    {
        get => (IRelayCommand)GetValue(UpdateCommandProperty);
        set => SetValue(UpdateCommandProperty, value);
    }
    public AssetSelectView()
	{
		InitializeComponent();

        BindingContext = DependencyService.Get<AssetSelectViewModel>();
    }

    async void OnClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        var assetSelector = (AssetSelectorView)sender;


        // Hide the AssetSelectView
        var assetSelectViewModel = DependencyService.Get<AssetSelectViewModel>();

        assetSelectViewModel.IsVisible = false;

        var networkingViewModel = DependencyService.Get<MultiNetworkSelectViewModel>();
        foreach (NetworkSelectInfo info in networkingViewModel.NetworkInfos)
        {
            if (info.Name == assetSelector.Endpoint.Name && !info.ShowName)
            {
                // Change the network if not selected
                // This line also updates the fee
                networkingViewModel.Select(assetSelector.Endpoint.Key);
            }
        }

        var assetSelectButtonViewModel = DependencyService.Get<AssetSelectButtonViewModel>();
        assetSelectButtonViewModel.ChainIcon = Application.Current.UserAppTheme == AppTheme.Light ? assetSelector.Endpoint.Icon : assetSelector.Endpoint.DarkIcon;
        assetSelectButtonViewModel.Symbol = assetSelector.Symbol;
        assetSelectButtonViewModel.SelectedAssetKey = (assetSelector.Endpoint.Key, assetSelector.Pallet, assetSelector.AssetId);
        assetSelectButtonViewModel.Decimals = assetSelector.Decimals;

        var assetInputViewModel = DependencyService.Get<AssetInputViewModel>();
        assetInputViewModel.CurrencyChanged(assetSelector.Symbol);

        // Update the fee
        //var transferViewModel = DependencyService.Get<TransferViewModel>();
        //await transferViewModel.GetFeeAsync();

        if (UpdateCommand is not null)
        {
            UpdateCommand.Execute(null);
        }

        Console.WriteLine("Selected: " + assetSelectButtonViewModel.SelectedAssetKey);
    }
}
