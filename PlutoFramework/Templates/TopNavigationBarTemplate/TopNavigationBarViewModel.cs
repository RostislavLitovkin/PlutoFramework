using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PlutoFramework.Templates.TopNavigationBarTemplate
{
    public partial class TopNavigationBarViewModel : ObservableObject
    {
        [RelayCommand]
        public Task BackAsync() => Application.Current.MainPage.Navigation.PopAsync();
    }
}
