using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model.SQLite;
namespace PlutoFramework.Components.Xcavate
{
    public partial class QuestionnaireFailedPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string text = "";

        [RelayCommand]
        public async Task CancelAsync()
        {
            await SQLiteModel.DeleteAllDatabasesAsync();

            await Shell.Current.Navigation.PopToRootAsync();
        }
    }
}
