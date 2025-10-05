using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model.SQLite;

namespace PlutoFramework.Components.Xcavate
{
    public partial class QuestionnaireWarningPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string text = "";

        [ObservableProperty]
        private Func<Task> navigation = () => Task.FromResult(0);

        [RelayCommand]
        public async Task ContinueAsync()
        {
            await Shell.Current.Navigation.PushAsync(
                new QuestionnairePassPage(
                    new QuestionnairePassPageViewModel
                    {
                        Text = "Thanks for passing our questionnaire, please accept our privacy, terms & agreement to start investing.",
                        Navigation = Navigation,
                    }
                )
            );
        }

        [RelayCommand]
        public async Task CancelAsync()
        {
            await SQLiteModel.DeleteAllDatabasesAsync();

            await Shell.Current.Navigation.PopToRootAsync();
        }
    }
}
