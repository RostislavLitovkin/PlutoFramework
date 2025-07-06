using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.NetworkSelect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoFramework.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isRefreshing = false;

        [RelayCommand]
        public async Task RefreshAsync()
        {
            IsRefreshing = true;

            var multiNetworkSelectViewModel = DependencyService.Get<MultiNetworkSelectViewModel>();
            multiNetworkSelectViewModel.SetupDefault();

            await Task.Delay(5000);

            IsRefreshing = false;
        }
    }
}
