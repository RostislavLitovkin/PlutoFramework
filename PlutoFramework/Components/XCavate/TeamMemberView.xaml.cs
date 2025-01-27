using PlutoFramework.Model.XCavate;

namespace PlutoFramework.Components.XCavate;

public partial class TeamMemberView : ContentView
{
    public static readonly BindableProperty UserProperty = BindableProperty.Create(
        nameof(User), typeof(XCavateCompanyUser), typeof(TeamMemberView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
        });
    public TeamMemberView()
	{
		InitializeComponent();
	}

    public XCavateCompanyUser User
    {
        get => (XCavateCompanyUser)GetValue(UserProperty);
        set => SetValue(UserProperty, value);
    }

    private async void OnClicked(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new UserProfilePage(new UserProfileViewModel
        {
            CanEdit = false,
            User = User
        }));
    }
}