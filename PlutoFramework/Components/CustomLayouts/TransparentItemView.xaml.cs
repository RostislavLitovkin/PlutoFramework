namespace PlutoFramework.Components.CustomLayouts;

public partial class TransparentItemView : ContentView
{
    public static readonly BindableProperty TextProperty = BindableProperty.Create(
  nameof(Text), typeof(string), typeof(TransparentItemView),
  defaultBindingMode: BindingMode.TwoWay,
  propertyChanging: (bindable, oldValue, newValue) =>
  {
      var control = (TransparentItemView)bindable;

      control.item.Text = (string)newValue;
  });
    public TransparentItemView()
	{
		InitializeComponent();
	}

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
}