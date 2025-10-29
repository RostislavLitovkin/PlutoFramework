using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.WebView;

namespace PlutoFramework.Components.XcavateProperty;

public partial class PropertyTitleWithInfoView : ContentView
{
	public static readonly BindableProperty TitleProperty =
		BindableProperty.Create(nameof(Title), typeof(string), typeof(PropertyTitleWithInfoView), default(string),
			propertyChanged: (bindable, oldValue, newValue) =>
			{
				var control = (PropertyTitleWithInfoView)bindable;
				control.text.Text = (string)newValue;
            });

	public static readonly BindableProperty CommandProperty =
		BindableProperty.Create(nameof(Command), typeof(IAsyncRelayCommand), typeof(PropertyTitleWithInfoView),
			default(IAsyncRelayCommand), propertyChanged: (bindable, oldValue, newValue) =>
			{
				var control = (PropertyTitleWithInfoView)bindable;
				control.tapGestureRecognizer.Command = (IAsyncRelayCommand)newValue;
				control.infoImage.IsVisible = newValue != null;
			});
	
    public PropertyTitleWithInfoView()
	{
		InitializeComponent();
	}
	public string Title
	{
		get => (string)GetValue(TitleProperty);
		set => SetValue(TitleProperty, value);
	}
    public IAsyncRelayCommand Command
	{
		get => (IAsyncRelayCommand)GetValue(CommandProperty);
		set => SetValue(CommandProperty, value);
	}
}