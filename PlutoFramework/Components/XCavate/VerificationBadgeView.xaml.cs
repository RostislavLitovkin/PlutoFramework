using PlutoFramework.Model.Xcavate;

namespace PlutoFramework.Components.Xcavate;

public partial class VerificationBadgeView : ContentView
{
    public static readonly BindableProperty ValueProperty = BindableProperty.Create(
        nameof(Value), typeof(VerificationEnum), typeof(VerificationBadgeView),
        VerificationEnum.None, BindingMode.OneWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (VerificationBadgeView)bindable;
            control.valueLabel.Text = ((VerificationEnum)newValue).ToString();

            switch ((VerificationEnum)newValue)
            {
                case VerificationEnum.None:
                    control.valueLabel.TextColor = Color.FromArgb("#4E4E4E");
                    break;

                case VerificationEnum.Loading:
                    control.valueLabel.TextColor = Color.FromArgb("#4E4E4E");
                    break;

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
    public VerificationBadgeView()
	{
		InitializeComponent();
	}
    public VerificationEnum Value
    {
        get => (VerificationEnum)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
}