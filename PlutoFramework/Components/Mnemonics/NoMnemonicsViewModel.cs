
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;

namespace PlutoFramework.Components.Mnemonics
{
    public partial class NoMnemonicsViewModel : ObservableObject
    {
        public Func<Task> Navigation = Shell.Current.Navigation.PopToRootAsync;

        [RelayCommand]
        public Task ImportAccountAsync() => NavigationModel.PushAsync(new EnterMnemonicsPage(
            new EnterMnemonicsViewModel
            {
                Navigation = Navigation,
            }
        ));

        [RelayCommand]
        public Task CreateAccountAsync() => NavigationModel.PushAsync(
            new CreateMnemonicsPage(
                new CreateMnemonicsViewModel
                {
                    Navigation = Navigation,
                }
            )
        );
    }
}
