using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Model;
using PlutoFramework.Model.Xcavate;

namespace PlutoFramework.Components.Xcavate
{
    public partial class QuestionnairePassPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool agreed = false;

        public ButtonStateEnum ContinueButtonState => Agreed ? ButtonStateEnum.Enabled : ButtonStateEnum.Disabled;

        [ObservableProperty]
        private string text = "";

        [ObservableProperty]
        private Func<Task> navigation = () => Task.FromResult(0);

        [RelayCommand]
        public async Task NavigateAsync()
        {
            await QuestionnaireModel.AcceptTermsAsync(KeysModel.GetPublicKey());

            await Navigation.Invoke();
        }
       
    }
}
