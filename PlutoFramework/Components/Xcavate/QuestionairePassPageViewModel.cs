using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;
using PlutoFramework.Model.Xcavate;

namespace PlutoFramework.Components.Xcavate
{
    public partial class QuestionairePassPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string text = "";

        [ObservableProperty]
        private string title = "";

        [ObservableProperty]
        private Func<Task> navigation = () => Task.FromResult(0);

        [RelayCommand]
        public async Task NavigateAsync()
        {
            await QuestionaireModel.AcceptTermsAsync(KeysModel.GetPublicKey());

            await Navigation.Invoke();
        }
       
    }
}
