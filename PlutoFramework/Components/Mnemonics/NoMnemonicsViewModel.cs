
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.View;
using PlutoFramework.ViewModel;

namespace PlutoFramework.Components.Mnemonics
{
    public partial class NoMnemonicsViewModel : ObservableObject
    {
        public Func<Task> Navigation = () => Shell.Current.GoToAsync("../..");

        [RelayCommand]
        public Task ImportAccountAsync() => Application.Current.MainPage.Navigation.PushAsync(new EnterMnemonicsPage(
            new EnterMnemonicsViewModel
            {
                Navigation = Navigation,
            }
        ));

        [RelayCommand]
        public Task CreateAccountAsync() => Application.Current.MainPage.Navigation.PushAsync(
            new CreateMnemonicsPage(
                new CreateMnemonicsViewModel
                {
                    Navigation = Navigation,
                }
            )
        );
    }
}
