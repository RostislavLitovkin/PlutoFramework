using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Mnemonics;
using PlutoFramework.Model;
using PlutoFrameworkCore.Keys;

namespace PlutoFramework.Components.Keys
{
    public partial class BaseDetailPageViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(PublicKey))]

        private GenericLockedKey? lockedKey;

        public string PublicKey => LockedKey?.PublicKey ?? "None";

        [RelayCommand]
        public Task GoToMnemonicsExplanationAsync() => Shell.Current.Navigation.PushAsync(new MnemonicsExplanationPage());

        [RelayCommand]
        public async Task DeleteKeyAsync()
        {
            var token = CancellationToken.None;

            var authentication = await RequirementsModel.CheckAuthenticationAsync();

            if (!authentication.Value)
            {
                return;
            }

            if (LockedKey is null)
            {
                return;
            }

            await LockedKey.RemoveAsync();
        }
    }
}
