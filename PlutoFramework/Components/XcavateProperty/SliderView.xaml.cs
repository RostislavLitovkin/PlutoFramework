using CommunityToolkit.Mvvm.Input;

namespace PlutoFramework.Components.XcavateProperty;

public partial class SliderView : ContentView
{
    public static readonly BindableProperty PercentageProperty = BindableProperty.Create(
       nameof(Percentage), typeof(double), typeof(SliderView),
       defaultBindingMode: BindingMode.TwoWay,
       propertyChanging: (bindable, oldValue, newValue) => {
           var control = (SliderView)bindable;

           AbsoluteLayout.SetLayoutBounds(control.bar, new Rect(0, 0.5, (double)newValue, 5));

           AbsoluteLayout.SetLayoutBounds(control.thumb, new Rect((double)newValue, 0.5, 20, 20));

       });

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
       nameof(Title), typeof(string), typeof(SliderView),
       defaultBindingMode: BindingMode.TwoWay,
       propertyChanging: (bindable, oldValue, newValue) => {
           var control = (SliderView)bindable;

           control.titleView.Title = (string)newValue;
       });

    public static readonly BindableProperty MinimumTitleProperty = BindableProperty.Create(
       nameof(MinimumTitle), typeof(string), typeof(SliderView),
       defaultBindingMode: BindingMode.TwoWay,
       propertyChanging: (bindable, oldValue, newValue) => {
           var control = (SliderView)bindable;

           control.minimumLabel.Text = (string)newValue;
       });

    public static readonly BindableProperty MaximumTitleProperty = BindableProperty.Create(
      nameof(MaximumTitle), typeof(string), typeof(SliderView),
      defaultBindingMode: BindingMode.TwoWay,
      propertyChanging: (bindable, oldValue, newValue) => {
          var control = (SliderView)bindable;

          control.maximumLabel.Text = (string)newValue;
      });

    public static readonly BindableProperty InfoCommandProperty = BindableProperty.Create(
       nameof(InfoCommand), typeof(IAsyncRelayCommand), typeof(SliderView),
       defaultBindingMode: BindingMode.TwoWay,
       propertyChanging: (bindable, oldValue, newValue) => {
           var control = (SliderView)bindable;
           control.titleView.Command = (IAsyncRelayCommand)newValue;
       });
    public SliderView()
	{
		InitializeComponent();
	}

    public double Percentage
    {
        get => (double)GetValue(PercentageProperty);
        set => SetValue(PercentageProperty, value);
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string MinimumTitle
    {
        get => (string)GetValue(MinimumTitleProperty);
        set => SetValue(MinimumTitleProperty, value);
    }

    public string MaximumTitle
    {
        get => (string)GetValue(MaximumTitleProperty);
        set => SetValue(MaximumTitleProperty, value);
    }
    public IAsyncRelayCommand InfoCommand
    {
        get => (IAsyncRelayCommand)GetValue(InfoCommandProperty);
        set => SetValue(InfoCommandProperty, value);
    }
}
