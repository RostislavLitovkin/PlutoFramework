namespace PlutoFramework.Components.TransactionAnalyzer;

public partial class ExtrinsicErrorView : ContentView
{
    public static readonly BindableProperty ErrorMessageProperty = BindableProperty.Create(
        nameof(ErrorMessage), typeof(string), typeof(ExtrinsicErrorView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (ExtrinsicErrorView)bindable;
            control.errorLabelText.Text = (string)newValue;
        });
    public ExtrinsicErrorView()
	{
		InitializeComponent();
	}
    public string ErrorMessage
    {
        get => (string)GetValue(ErrorMessageProperty);
        set => SetValue(ErrorMessageProperty, value);
    }
}