
using PlutoFramework.Components.TransferView;

namespace PlutoFramework.Components.AssetSelect;

public enum EntrySelectedEnum
{
    None,
    Amount,
    Usd
}

public partial class AssetInputView : ContentView
{
    private EntrySelectedEnum entrySelected = EntrySelectedEnum.None;

    public static readonly BindableProperty CardWidthProperty = BindableProperty.Create(
        nameof(CardWidth), typeof(int), typeof(AssetInputView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) => {
            var control = (AssetInputView)bindable;

            var width = (int)newValue - 10;
            control.usdGrid.WidthRequest = width;
            control.amountGrid.WidthRequest = width;
        });

    public static readonly BindableProperty AmountProperty = BindableProperty.Create(
        nameof(Amount), typeof(string), typeof(AssetInputView),
        defaultBindingMode: BindingMode.TwoWay);


    public AssetInputView()
    {
        InitializeComponent();

        BindingContext = DependencyService.Get<AssetInputViewModel>();
    }

    public int CardWidth
    {
        get => (int)GetValue(CardWidthProperty);
        set => SetValue(CardWidthProperty, value);
    }

    public string Amount
    {
        get => (string)GetValue(AmountProperty);
        set => SetValue(AmountProperty, value);
    }

    private void AmountEntryChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (entrySelected != EntrySelectedEnum.Amount)
        {
            return;
        }

        if (e.PropertyName != "Text")
        {
            return;
        }

        var transferViewModel = DependencyService.Get<TransferViewModel>();

        if (transferViewModel.IsVisible)
        {
            transferViewModel.Amount = ((Entry)sender).Text;
        }

        var viewModel = DependencyService.Get<AssetInputViewModel>();

        viewModel.CalculateUsdValue();


        /// 2 way binding did not work for some reason
        //Amount = ((Entry)sender).Text;
    }

    private void UsdAmountEntryChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (entrySelected != EntrySelectedEnum.Usd)
        {
            return;
        }

        if (e.PropertyName != "Text")
        {
            return;
        }

        var viewModel = DependencyService.Get<AssetInputViewModel>();

        viewModel.CalculateCurrencyAmount();
    }

    private void OnAmountEntryFocused(object sender, FocusEventArgs e)
    {
        entrySelected = EntrySelectedEnum.Amount;
    }

    private void OnUsdEntryFocused(object sender, FocusEventArgs e)
    {
        entrySelected = EntrySelectedEnum.Usd;
    }
}