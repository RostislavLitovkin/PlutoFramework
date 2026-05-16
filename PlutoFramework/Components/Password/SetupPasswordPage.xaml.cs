using PlutoFramework.Components.Buttons;
using PlutoFramework.Model;
using PlutoFramework.Templates.PageTemplate;
using Substrate.NET.Wallet;

namespace PlutoFramework.Components.Password;

public partial class SetupPasswordPage : PageTemplate
{
    public required Func<Task> Navigation;

    private bool _clicked = false;
    private bool _confirmStep = false;

    public SetupPasswordPage()
    {
        InitializeComponent();
    }

    private async void ContinueToMainPageClicked(System.Object sender, System.EventArgs e)
    {
        if (_clicked) return;
        _clicked = true;

        if (!_confirmStep)
        {
            passwordSection.IsVisible = false;
            confirmSection.IsVisible = true;
            continueButton.ButtonState = ButtonStateEnum.Disabled;
            _confirmStep = true;
            _clicked = false;
            return;
        }

        if (confirmPasswordEntry.Text != passwordEntry.Text)
        {
            passwordMatchLabel.IsVisible = true;
            _clicked = false;
            return;
        }

        await SecureStorage.Default.SetAsync(PreferencesModel.PASSWORD, passwordEntry.Text);
        Preferences.Set(PreferencesModel.SHOW_WELCOME_SCREEN, false);
        await KeysModel.RegisterBiometricAuthenticationAsync();
        await Navigation.Invoke();

        _clicked = false;
    }

    protected override bool OnBackButtonPressed()
    {
        if (_confirmStep)
        {
            confirmSection.IsVisible = false;
            confirmPasswordEntry.Text = string.Empty;
            passwordMatchLabel.IsVisible = false;
            passwordSection.IsVisible = true;
            continueButton.ButtonState = ButtonStateEnum.Enabled;
            _confirmStep = false;
            return true;
        }

        return base.OnBackButtonPressed();
    }

    private void OnEyeballClicked(object sender, TappedEventArgs e)
    {
        passwordEntry.IsPassword = !passwordEntry.IsPassword;
        eyeball.IsVisible = passwordEntry.IsPassword;
        eyeballSlash.IsVisible = !passwordEntry.IsPassword;
    }

    private void OnConfirmEyeballClicked(object sender, TappedEventArgs e)
    {
        confirmPasswordEntry.IsPassword = !confirmPasswordEntry.IsPassword;
        confirmEyeball.IsVisible = confirmPasswordEntry.IsPassword;
        confirmEyeballSlash.IsVisible = !confirmPasswordEntry.IsPassword;
    }

    private async void OnEnterPressedAsync(object sender, EventArgs e)
    {
        var entry = (Entry)sender;
        if (entry.IsSoftInputShowing())
            await entry.HideSoftInputAsync(System.Threading.CancellationToken.None);
    }

    private void OnPasswordPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName != "Text") return;

        var text = ((Entry)sender!).Text;

        lengthRequirementLabel.TextColor = WordManager.Create().WithMinimumLength(6).WithMaximumLength(20).IsValid(text)
            ? Colors.Green : Colors.DarkRed;
        lowercaseRequirementLabel.TextColor = WordManager.Create().Should().AtLeastOneLowercase().IsValid(text)
            ? Colors.Green : Colors.DarkRed;
        uppercaseRequirementLabel.TextColor = WordManager.Create().Should().AtLeastOneUppercase().IsValid(text)
            ? Colors.Green : Colors.DarkRed;
        numberRequirementLabel.TextColor = WordManager.Create().Should().AtLeastOneDigit().IsValid(text)
            ? Colors.Green : Colors.DarkRed;

        continueButton.ButtonState = WordManager.Create()
            .WithMinimumLength(6).WithMaximumLength(20)
            .Should().AtLeastOneDigit()
            .Should().AtLeastOneLowercase()
            .Should().AtLeastOneUppercase()
            .IsValid(text) ? ButtonStateEnum.Enabled : ButtonStateEnum.Disabled;
    }

    private void OnConfirmPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName != "Text") return;

        var text = ((Entry)sender!).Text;
        passwordMatchLabel.IsVisible = false;
        continueButton.ButtonState = !string.IsNullOrEmpty(text)
            ? ButtonStateEnum.Enabled : ButtonStateEnum.Disabled;
    }
}
