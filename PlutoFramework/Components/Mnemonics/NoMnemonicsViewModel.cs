
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PlutoFramework.Components.Mnemonics
{
    public partial class NoMnemonicsViewModel : ObservableObject
    {
        public Func<Task> Navigation = Shell.Current.Navigation.PopToRootAsync;

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
