using CommunityToolkit.Mvvm.ComponentModel;

namespace PlutoFramework.ViewModel
{
    public partial class EnterMnemonicsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string mnemonics = "";

        [ObservableProperty]
        private string privateKey = "";
    }
}
