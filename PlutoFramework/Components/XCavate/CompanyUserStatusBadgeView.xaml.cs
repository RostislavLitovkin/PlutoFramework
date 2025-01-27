using PlutoFramework.Model.XCavate;

namespace PlutoFramework.Components.XCavate;

public partial class CompanyUserStatusBadgeView : ContentView
{
    public static readonly BindableProperty CompanyUserStatusProperty = BindableProperty.Create(
        nameof(CompanyUserStatus), typeof(CompanyUserStatusEnum), typeof(CompanyUserStatusBadgeView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (CompanyUserStatusBadgeView)bindable;

            control.roleLabel.Text = ((CompanyUserStatusEnum)newValue).ToString();

            switch ((CompanyUserStatusEnum)newValue)
            {
                case CompanyUserStatusEnum.Active:
                    control.border.BackgroundColor = Color.FromArgb("#1A78B36E");
                    control.roleLabel.TextColor = Color.FromArgb("#78B36E");
                    break;
                case CompanyUserStatusEnum.Invited:
                    control.border.BackgroundColor = Color.FromArgb("#1ADC7DA6");
                    control.roleLabel.TextColor = Color.FromArgb("#DC7DA6");
                    break;
                default:
                    control.border.BackgroundColor = Color.FromArgb("#1A888888");
                    break;
            }
        });
    public CompanyUserStatusBadgeView()
    {
        InitializeComponent();
    }

    public CompanyUserStatusEnum CompanyUserStatus
    {
        get => (CompanyUserStatusEnum)GetValue(CompanyUserStatusProperty);

        set => SetValue(CompanyUserStatusProperty, value);
    }
}