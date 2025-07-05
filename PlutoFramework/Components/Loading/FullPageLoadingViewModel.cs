using CommunityToolkit.Mvvm.ComponentModel;

namespace PlutoFramework.Components.Loading
{
    public partial class FullPageLoadingViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isVisible = false;
    }
}
