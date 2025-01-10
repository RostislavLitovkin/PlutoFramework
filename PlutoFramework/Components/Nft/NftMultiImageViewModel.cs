using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace PlutoFramework.Components.Nft
{
    public partial class NftMultiImageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string mainImageSource;

        [ObservableProperty]
        private ObservableCollection<string> imageSources = new ObservableCollection<string>();
    }
}
