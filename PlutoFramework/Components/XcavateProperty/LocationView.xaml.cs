namespace PlutoFramework.Components.XcavateProperty;

public partial class LocationView : ContentView
{
    public static readonly BindableProperty LocationNameProperty = BindableProperty.Create(
       nameof(LocationName), typeof(string), typeof(LocationView),
       defaultBindingMode: BindingMode.TwoWay,
       propertyChanging: (bindable, oldValue, newValue) =>
       {
           var control = (LocationView)bindable;

           control.locationNameLabel.Text = (string)newValue;
       });
    public LocationView()
	{
		InitializeComponent();
	}

    public string LocationName
    {
        get => (string)GetValue(LocationNameProperty);
        set => SetValue(LocationNameProperty, value);
    }
}