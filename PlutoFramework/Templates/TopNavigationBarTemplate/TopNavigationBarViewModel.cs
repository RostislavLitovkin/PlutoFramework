using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;

namespace PlutoFramework.Templates.TopNavigationBarTemplate
{
    public partial class TopNavigationBarViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool extra1IsVisible = false;

        [ObservableProperty]
        private bool extra2IsVisible = false;

        [RelayCommand]
        public Task BackAsync() => NavigationModel.PopAsync();
    }
}
