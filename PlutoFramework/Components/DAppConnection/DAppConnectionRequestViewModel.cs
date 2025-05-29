using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plutonication;
using PlutoFramework.Model;

#if ANDROID26_0_OR_GREATER
using PlutoFramework.Platforms.Android;
using Android.Content;
#endif


namespace PlutoFramework.Components.DAppConnection
{
    public partial class DAppConnectionRequestViewModel : ObservableObject, IPopup, ISetToDefault
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string icon;

        [ObservableProperty]
        private string url;

        [ObservableProperty]
        private string key;

        [ObservableProperty]
        private string plutoLayout;

        [ObservableProperty]
        private bool isVisible;

        [ObservableProperty]
        private bool requestViewIsVisible;

        [ObservableProperty]
        private bool connectionStatusIsVisible;

        [ObservableProperty]
        private bool connecting;

        [ObservableProperty]
        private bool connected;

        [ObservableProperty]
        private bool confirming;

        [ObservableProperty]
        private bool confirmed;

        [ObservableProperty]
        private string connectionStatusText;

        [ObservableProperty]
        private AccessCredentials accessCredentials;

        public DAppConnectionRequestViewModel()
        {
            SetToDefault();
        }

        public void SetToDefault()
        {
            RequestViewIsVisible = true;
            ConnectionStatusIsVisible = false;
            IsVisible = false;
            Connecting = false;
            Connected = false;
            Confirming = false;
            Confirmed = false;
            ConnectionStatusText = "Connecting";
        }


        public void Show()
        {
            RequestViewIsVisible = true;
            ConnectionStatusIsVisible = false;
            IsVisible = true;
            Connecting = false;
            Connected = false;
            Confirming = false;
            Confirmed = false;
            ConnectionStatusText = "Connecting";
        }

        [RelayCommand]
        public async Task AcceptAsync()
        {
#if ANDROID29_0_OR_GREATER
        PermissionStatus status = await Permissions.RequestAsync<NotificationPermission>();

        if (status == PermissionStatus.Granted)
        {
            var mainActivity = Microsoft.Maui.ApplicationModel.Platform.CurrentActivity;
            Intent serviceIntent = new Intent(mainActivity, typeof(PlutonicationAndroidForegroundService));

            mainActivity.StartForegroundService(serviceIntent);
        }
        else
        {
            await PlutonicationModel.AcceptConnectionAsync();
        }
//#elif IOS10_0_OR_GREATER
        //await AppDelegate.PlutonicationService.StartAsync();
#else

            await PlutonicationModel.AcceptConnectionAsync();
#endif
        }

        [RelayCommand]
        public void Reject()
        {
            DAppConnectionViewModel dAppViewModel = DependencyService.Get<DAppConnectionViewModel>();
            dAppViewModel.SetConnectionState(DAppConnectionStateEnum.Rejected);

            IsVisible = false;
        }

        [RelayCommand]
        public void Dismiss()
        {
            IsVisible = false;
        }
    }
}
