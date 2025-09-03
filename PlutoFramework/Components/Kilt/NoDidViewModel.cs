
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;

namespace PlutoFramework.Components.Kilt
{
    public partial class NoDidViewModel : ObservableObject
    {
        [RelayCommand]
        public Task ImportDidAsync() => Shell.Current.Navigation.PushAsync(new ImportDidPage());

        [RelayCommand]
        public async Task CreateDidAsync()
        {
            await Model.KeysModel.GenerateNewAccountAsync(accountVariant: "kilt1");

            await NavigationModel.NavigateAfterAccountCreation.Invoke();
        }
    }
}
