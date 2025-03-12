using System.Numerics;

namespace PlutoFramework.Components.Nft;

public partial class CollectionStatsView : ContentView
{
    public static readonly BindableProperty DateOfCreationProperty = BindableProperty.Create(
        nameof(DateOfCreation), typeof(DateTime), typeof(CollectionStatsView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (CollectionStatsView)bindable;

            control.dateOfCreationAttribute.Value = ((DateTime)newValue).ToShortDateString();
            control.dateOfCreationAttribute.IsVisible = true;
        });

    public static readonly BindableProperty TransferableProperty = BindableProperty.Create(
        nameof(Transferable), typeof(bool), typeof(CollectionStatsView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (CollectionStatsView)bindable;

            control.transferableAttribute.Value = ((bool)newValue).ToString();
            control.immutableAttribute.IsVisible = true;
        });
    public static readonly BindableProperty ImmutableProperty = BindableProperty.Create(
        nameof(Immutable), typeof(bool), typeof(CollectionStatsView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (CollectionStatsView)bindable;

            control.immutableAttribute.Value = ((bool)newValue).ToString();
            control.immutableAttribute.IsVisible = true;
        });
    public CollectionStatsView()
	{
		InitializeComponent();
	}
    public DateTime DateOfCreation
    {
        get => (DateTime)GetValue(DateOfCreationProperty);
        set => SetValue(DateOfCreationProperty, value);
    }
    public bool Transferable
    {
        get => (bool)GetValue(TransferableProperty);
        set => SetValue(TransferableProperty, value);
    }
    public bool Immutable
    {
        get => (bool)GetValue(ImmutableProperty);
        set => SetValue(ImmutableProperty, value);
    }
}