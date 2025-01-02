namespace PlutoFramework.Components.CustomLayouts;

public partial class ItemView : ContentView
{
    public static readonly BindableProperty TextProperty = BindableProperty.Create(
      nameof(Text), typeof(string), typeof(ItemView),
      defaultBindingMode: BindingMode.TwoWay,
      propertyChanging: (bindable, oldValue, newValue) =>
      {
          var control = (ItemView)bindable;

          control.label.Text = (string)newValue;
      });

    public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
      nameof(TextColor), typeof(Color), typeof(ItemView),
      defaultBindingMode: BindingMode.TwoWay,
      propertyChanging: (bindable, oldValue, newValue) =>
      {
          var control = (ItemView)bindable;

          control.label.TextColor = (Color)newValue;
      });

    public static readonly BindableProperty IsTransparentProperty = BindableProperty.Create(
      nameof(IsTransparent), typeof(bool), typeof(ErrorItemView),
      defaultBindingMode: BindingMode.TwoWay,
      propertyChanging: (bindable, oldValue, newValue) =>
      {
          var control = (ItemView)bindable;

          control.card.IsTransparent = (bool)newValue;
      });

    public static readonly BindableProperty ColorProperty = BindableProperty.Create(
      nameof(Color), typeof(Color), typeof(ItemView),
      defaultBindingMode: BindingMode.TwoWay,
      propertyChanging: (bindable, oldValue, newValue) =>
      {
          var control = (ItemView)bindable;

          control.card.Color = (Color)newValue;
      });
    public ItemView()
	{
		InitializeComponent();
	}
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }
    public bool IsTransparent
    {
        get => (bool)GetValue(IsTransparentProperty);
        set => SetValue(IsTransparentProperty, value);
    }
    public Color Color
    {
        get => (Color)GetValue(ColorProperty);
        set => SetValue(ColorProperty, value);
    }
}