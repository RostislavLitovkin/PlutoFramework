using PlutoFramework.Model.Constants;

namespace PlutoFramework.Components.Balance;

public partial class AssetView : ContentView
{
    public static readonly BindableProperty AssetInfoProperty = BindableProperty.Create(
        nameof(AssetInfo), typeof(AssetInfo), typeof(AssetView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (AssetView)bindable;

            var assetInfo = (AssetInfo)newValue;

            control.assetIcon.Source = Assets.GetAssetIcon(assetInfo.Symbol);

            control.amountLabelText.Text = $"{assetInfo.Amount} {assetInfo.Symbol}";
            control.symbolLabelText.Text = assetInfo.Symbol;

            control.usdLabel.Text = assetInfo.UsdValue;

            control.frozenImage.IsVisible = assetInfo.IsFrozen;
            control.lockImage.IsVisible = assetInfo.IsReserved;
        });

    public AssetView()
	{
		InitializeComponent();
	}

    public AssetInfo AssetInfo
    {
        get => (AssetInfo)GetValue(AssetInfoProperty);
        set => SetValue(AssetInfoProperty, value);
    }

    private async void OnClicked(object sender, TappedEventArgs e)
    {
        var token = CancellationToken.None;
        var viewModel = new AssetDetailViewModel();

        viewModel.AssetInfo = AssetInfo;

        await Navigation.PushAsync(new AssetDetailPage(viewModel));

        await viewModel.LoadAsync(token);
    }
}