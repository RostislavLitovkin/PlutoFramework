
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PlutoFramework.Components.Kilt
{
    public partial class NoDidViewModel : ObservableObject
    {
        public Func<Task> Navigation = () => Shell.Current.GoToAsync("../..");

        [RelayCommand]
        public Task ImportDidAsync() => Application.Current.MainPage.Navigation.PushAsync(new ImportDidPage(
           new ImportDidViewModel
           {
               Navigation = Navigation,
           }
        ));

        [RelayCommand]
        public Task CreateDidAsync() => Application.Current.MainPage.Navigation.PushAsync(new CreateNewDidPage(
            new CreateNewDidViewModel {
                Navigation = Navigation,
            }
        ));
    }
}
