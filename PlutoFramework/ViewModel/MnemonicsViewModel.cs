using CommunityToolkit.Mvvm.ComponentModel;

namespace PlutoFramework.ViewModel
{
    public partial class MnemonicsViewModel : ObservableObject //, INotifyPropertyChanged
    {
       
        [ObservableProperty]
        private string mnemonics;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string title;

        public MnemonicsViewModel()
        {

        }
    }
}

