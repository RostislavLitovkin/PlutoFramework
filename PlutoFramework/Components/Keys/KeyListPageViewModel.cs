using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Model.SQLite;
using PlutoFrameworkCore.Keys;
using System.Collections.ObjectModel;

namespace PlutoFramework.Components.Keys
{
    public partial class KeyListPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<GenericLockedKey> keys = new ObservableCollection<GenericLockedKey>();

        public KeyListPageViewModel()
        {
            // Load keys from storage or service
            _ = LoadKeysAsync();
        }

        private async Task LoadKeysAsync()
        {
            var keys = await KeysDatabase.GetAllKeysAsync();

            Keys = new ObservableCollection<GenericLockedKey>(keys);
        }
    }
}
