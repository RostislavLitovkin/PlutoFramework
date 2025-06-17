using Microsoft.Maui.Storage;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Components.Xcavate;
using PlutoFramework.Model;
using Substrate.NET.Wallet;

namespace PlutoFramework.View;

public partial class SetupPasswordPage : ContentPage
{
    public required Func<Task> Navigation;

    private bool clicked = false;
    public SetupPasswordPage()
    {
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var accountType = (AccountType)Enum.Parse(typeof(AccountType), Preferences.Get(PreferencesModel.ACCOUNT_TYPE, AccountType.None.ToString()));

        if (accountType == AccountType.Json && SecureStorage.GetAsync(PreferencesModel.PASSWORD) is not null)
        {
            Application.Current.MainPage = new XcavateAppShell();
        }
    }

    private async void ContinueToMainPageClicked(System.Object sender, System.EventArgs e)
    {
        if (clicked)
        {
            return;
        }

        clicked = true;

        await SecureStorage.Default.SetAsync(
            PreferencesModel.PASSWORD,
            passwordEntry.Text
        );

        Preferences.Set(PreferencesModel.SHOW_WELCOME_SCREEN, false);

        await KeysModel.RegisterBiometricAuthenticationAsync();

        await Navigation.Invoke();

        clicked = false;
    }

    private void OnEyeballClicked(object sender, TappedEventArgs e)
    {
        passwordEntry.IsPassword = !passwordEntry.IsPassword;

        eyeball.IsVisible = passwordEntry.IsPassword;
        eyeballSlash.IsVisible = !passwordEntry.IsPassword;
    }

    private async void OnEnterPressedAsync(object sender, EventArgs e)
    {
        var entry = (Entry)sender;
        if (entry.IsSoftInputShowing())
            await entry.HideSoftInputAsync(System.Threading.CancellationToken.None);
    }

    private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName != "Text")
        {
            return;
        }

        if (WordManager.Create().WithMinimumLength(6).WithMaximumLength(20).IsValid(((Entry)sender).Text))
        {
            lengthRequirementLabel.TextColor = Colors.Green;
        }
        else
        {
            lengthRequirementLabel.TextColor = Colors.DarkRed;
        }

        if (WordManager.Create().Should().AtLeastOneLowercase().IsValid(((Entry)sender).Text))
        {
            lowercaseRequirementLabel.TextColor = Colors.Green;
        }
        else
        {
            lowercaseRequirementLabel.TextColor = Colors.DarkRed;
        }

        if (WordManager.Create().Should().AtLeastOneUppercase().IsValid(((Entry)sender).Text))
        {
            uppercaseRequirementLabel.TextColor = Colors.Green;
        }
        else
        {
            uppercaseRequirementLabel.TextColor = Colors.DarkRed;
        }

        if (WordManager.Create().Should().AtLeastOneDigit().IsValid(((Entry)sender).Text))
        {
            numberRequirementLabel.TextColor = Colors.Green;
        }
        else
        {
            numberRequirementLabel.TextColor = Colors.DarkRed;
        }

        continueButton.ButtonState = WordManager.Create().WithMinimumLength(6).WithMaximumLength(20).Should()
            .AtLeastOneDigit()
            .Should()
            .AtLeastOneLowercase()
            .Should()
            .AtLeastOneUppercase().IsValid(((Entry)sender).Text) ? ButtonStateEnum.Enabled : ButtonStateEnum.Disabled;

    }
}
