
using CommunityToolkit.Mvvm.ComponentModel;

namespace PlutoFramework.ViewModel
{
    internal partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool scrollIsEnabled;

        public MainViewModel()
        {
            scrollIsEnabled = true;
        }
    }
}
