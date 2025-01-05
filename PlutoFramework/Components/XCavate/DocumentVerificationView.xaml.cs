using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model.XCavate;

namespace PlutoFramework.Components.XCavate;

public partial class DocumentVerificationView : ContentView
{
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
    nameof(Title), typeof(string), typeof(DocumentVerificationView),
    string.Empty, BindingMode.OneWay,
    propertyChanged: (bindable, oldValue, newValue) =>
    {
        var control = (DocumentVerificationView)bindable;
        control.titleLabel.Text = (string)newValue;
    });

    public static readonly BindableProperty ValueProperty = BindableProperty.Create(
        nameof(Value), typeof(VerificationEnum), typeof(DocumentVerificationView),
        VerificationEnum.None, BindingMode.OneWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (DocumentVerificationView)bindable;
            control.valueLabel.Text = ((VerificationEnum)newValue).ToString();

            switch ((VerificationEnum)newValue)
            {
                case VerificationEnum.Pending:
                    control.valueLabel.TextColor = Color.FromArgb("#FFA500");
                    break;
                case VerificationEnum.Verified:
                    control.valueLabel.TextColor = Color.FromArgb("#457461");
                    break;
                case VerificationEnum.Rejected:
                    control.valueLabel.TextColor = Color.FromArgb("#FF0000");
                    break;
            }
        });
    public static readonly BindableProperty ViewCommandProperty = BindableProperty.Create(
        nameof(ViewCommand), typeof(IAsyncRelayCommand), typeof(DocumentVerificationView),
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (DocumentVerificationView)bindable;
            control.tapGestureRecognizer.Command = (IAsyncRelayCommand)newValue;
        });
    public DocumentVerificationView()
	{
		InitializeComponent();
	}

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    public VerificationEnum Value
    {
        get => (VerificationEnum)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public IAsyncRelayCommand ViewCommand
    {
        get => (IAsyncRelayCommand)GetValue(ViewCommandProperty);
        set => SetValue(ViewCommandProperty, value);
    }
}