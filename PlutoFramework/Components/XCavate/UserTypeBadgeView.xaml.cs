using PlutoFramework.Model.XCavate;

namespace PlutoFramework.Components.XCavate;

public partial class UserTypeBadgeView : ContentView
{
	public static readonly BindableProperty UserRoleProperty = BindableProperty.Create(
        nameof(UserRole), typeof(UserRoleEnum), typeof(UserTypeBadgeView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (UserTypeBadgeView)bindable;

            control.roleLabel.Text = ((UserRoleEnum)newValue).ToString();

            switch ((UserRoleEnum)newValue)
            {
                case UserRoleEnum.Developer:
                    control.border.BackgroundColor = Color.FromArgb("#1A457461");
                    control.roleLabel.TextColor = Color.FromArgb("#457461");
                    break;
                case UserRoleEnum.Investor:
                    control.border.BackgroundColor = Color.FromArgb("#1ADC7DA6");
                    control.roleLabel.TextColor = Color.FromArgb("#DC7DA6");
                    break;
                case UserRoleEnum.LettingAgent:
                    control.border.BackgroundColor = Color.FromArgb("#1A9678AE");
                    control.roleLabel.TextColor = Color.FromArgb("#9678AE");

                    control.roleLabel.Text = "Letting agent";
                    break;
                default:
                    control.border.BackgroundColor = Color.FromArgb("#1A888888");
                    break;
            }
        });
    public UserTypeBadgeView()
	{
		InitializeComponent();
	}

    public UserRoleEnum UserRole
    {
        get => (UserRoleEnum)GetValue(UserRoleProperty);

        set => SetValue(UserRoleProperty, value);
    }
}