namespace PlutoFramework.Components.Card;

public partial class TextCard : Card
{
    public static readonly BindableProperty FormattedTextProperty = BindableProperty.Create(
    nameof(FormattedText), typeof(FormattedString), typeof(TextCard),
    defaultBindingMode: BindingMode.TwoWay,
    propertyChanging: (bindable, oldValue, newValue) =>
    {
        var control = (TextCard)bindable;
        control.label.FormattedText = (FormattedString)newValue;
    });

    public TextCard()
	{
		InitializeComponent();
	}

    public FormattedString FormattedText
    {
        get => (FormattedString)GetValue(FormattedTextProperty);
        set => SetValue(FormattedTextProperty, value);
    }
}