using PlutoFramework.Model.Xcavate;

namespace PlutoFramework.Components.Xcavate;

public partial class TeamMemberView : ContentView
{
    public static readonly BindableProperty UserProperty = BindableProperty.Create(
        nameof(User), typeof(XcavateCompanyUser), typeof(TeamMemberView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
        });
    public TeamMemberView()
	{
		InitializeComponent();
	}

    public XcavateCompanyUser User
    {
        get => (XcavateCompanyUser)GetValue(UserProperty);
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