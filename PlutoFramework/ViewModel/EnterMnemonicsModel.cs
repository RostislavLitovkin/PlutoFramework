using CommunityToolkit.Mvvm.ComponentModel;

namespace PlutoFramework.ViewModel
{
    public partial class EnterMnemonicsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string privateKey;

        [ObservableProperty]
        private string mnemonics;

        public EnterMnemonicsViewModel()
        {

        }
    }
}
