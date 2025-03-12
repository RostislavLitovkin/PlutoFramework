namespace PlutoFramework.Components.Balance;

public partial class AssetAmountView : ContentView
{
    public static readonly BindableProperty AmountProperty = BindableProperty.Create(
        nameof(Amount), typeof(string), typeof(AssetAmountView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (AssetAmountView)bindable;

            control.amountLabel.Text = (string)newValue;
        });

    public static readonly BindableProperty SymbolProperty = BindableProperty.Create(
        nameof(Symbol), typeof(string), typeof(AssetAmountView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (AssetAmountView)bindable;

            control.symbolLabel.Text = (string)newValue;
        });

    public static readonly BindableProperty ChainIconProperty = BindableProperty.Create(
        nameof(ChainIcon), typeof(string), typeof(AssetAmountView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (AssetAmountView)bindable;

            control.chainIcon.Source = (string)newValue;
        });

    public static readonly BindableProperty UsdValueProperty = BindableProperty.Create(
        nameof(UsdValue), typeof(string), typeof(AssetAmountView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (AssetAmountView)bindable;

            control.usdLabel.Text = (string)newValue;
        });

    public static readonly BindableProperty IsFrozenProperty = BindableProperty.Create(
        nameof(IsFrozen), typeof(bool), typeof(AssetAmountView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (AssetAmountView)bindable;

            control.frozenImage.IsVisible = (bool)newValue;
        });

    public static readonly BindableProperty IsReservedProperty = BindableProperty.Create(
        nameof(IsReserved), typeof(bool), typeof(AssetAmountView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (AssetAmountView)bindable;

            control.lockImage.IsVisible = (bool)newValue;
        });

    public static readonly BindableProperty UsdColorProperty = BindableProperty.Create(
            nameof(UsdColor), typeof(Color), typeof(AssetAmountView),
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                var control = (AssetAmountView)bindable;

                control.usdLabel.TextColor = (Color)newValue;

                //control.shadow.Brush = (Color)newValue;

                //control.border.Stroke = (Color)newValue;
                //control.border.StrokeThickness = 1;
            });

    public AssetAmountView()
    {
        InitializeComponent();
    }

    public string Amount
    {
        get => (string)GetValue(AmountProperty);

        set => SetValue(AmountProperty, value);
    }
    public string Symbol
    {
        get => (string)GetValue(SymbolProperty);

        set => SetValue(SymbolProperty, value);
    }
    public string ChainIcon
    {
        get => (string)GetValue(ChainIconProperty);

        set => SetValue(ChainIconProperty, value);
    }
    public string UsdValue
    {
        get => (string)GetValue(UsdValueProperty);

        set => SetValue(UsdValueProperty, value);
    }
    public bool IsFrozen
    {
        get => (bool)GetValue(IsFrozenProperty);

        set => SetValue(IsFrozenProperty, value);
    }
    public bool IsReserved
    {
        get => (bool)GetValue(IsReservedProperty);

        set => SetValue(IsReservedProperty, value);
    }
    public Color UsdColor
    {
        get => (Color)GetValue(UsdColorProperty);

        set => SetValue(UsdColorProperty, value);
    }
}
