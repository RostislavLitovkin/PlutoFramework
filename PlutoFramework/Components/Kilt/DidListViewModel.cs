using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace PlutoFramework.Components.Kilt
{
    public partial class DidListViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> dids = new ObservableCollection<string>();
    }
}
