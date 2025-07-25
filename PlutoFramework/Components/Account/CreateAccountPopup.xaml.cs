using PlutoFramework.Components.Buttons;
using Substrate.NET.Wallet;

namespace PlutoFramework.Components.Account;

public partial class CreateAccountPopup : ContentView
{
    public CreateAccountPopup()
    {
        InitializeComponent();

        BindingContext = DependencyService.Get<CreateAccountPopupModel>();
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

        ((CreateAccountPopupModel)BindingContext).ContinueButtonState = WordManager.Create().WithMinimumLength(6).WithMaximumLength(20).Should()
            .AtLeastOneDigit()
            .Should()
            .AtLeastOneLowercase()
            .Should()
            .AtLeastOneUppercase().IsValid(((Entry)sender).Text) ? ButtonStateEnum.Enabled : ButtonStateEnum.Disabled;

    }
}