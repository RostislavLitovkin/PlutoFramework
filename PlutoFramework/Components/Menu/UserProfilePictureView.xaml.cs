using PlutoFramework.Model.Constants;
using PlutoFramework.Model.Xcavate;

namespace PlutoFramework.Components.Menu;

public partial class UserProfilePictureView : ContentView
{
	private bool hasProfilePicture = false;
	public static readonly BindableProperty AddressProperty = 
		BindableProperty.Create(nameof(Address), typeof(string), typeof(UserProfilePictureView), default(string),
			propertyChanged: (bindable, oldValue, newValue) =>
			{
				var control = (UserProfilePictureView)bindable;

				if (control.hasProfilePicture || newValue == null)
				{
					Console.WriteLine("Has profile picture or new value is null");
                    return;
				}

				control.image.Source = ImageSource.FromUri(new Uri($"{PlutoExpress.PLUTO_EXPRESS_API_URL}/avatars/{(string)newValue}.png"));
            });
    public UserProfilePictureView()
	{
		InitializeComponent();

		var profilePicture = XcavateFileModel.GetSavedProfilePicture();

		if (profilePicture is not null) {
			Console.WriteLine("Has profile picture");

			image.Source = profilePicture;
			hasProfilePicture = true;
        }
    }

	public string Address
	{
		get => (string)GetValue(AddressProperty);
		set => SetValue(AddressProperty, value);
    }
}