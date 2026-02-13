using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;

namespace PlutoFramework.Components.WebView
{
    public partial class DAppWebViewConnectionRequestPopupViewModel : ObservableObject, IPopup, ISetToDefault
    {
        private TaskCompletionSource<bool> completionSource = new TaskCompletionSource<bool>();

        [ObservableProperty]
        private string name = "";

        [ObservableProperty]
        private ImageSource icon = "";

        [ObservableProperty]
        private string url = "";

        [ObservableProperty]
        private bool isVisible = false;

        public DAppWebViewConnectionRequestPopupViewModel()
        {
            SetToDefault();
        }

        public void SetToDefault()
        {
            IsVisible = false;
            Name = "";
            Icon = "";
            Url = "";
        }


        public Task<bool> ShowAsync(DAppInfo dAppInfo)
        {
            Name = dAppInfo.Name;
            Icon = dAppInfo.Icon;
            Url = dAppInfo.Url;
            IsVisible = true;

            completionSource = new TaskCompletionSource<bool>();

            return completionSource.Task;
        }

        [RelayCommand]
        public void Accept()
        {
            completionSource.SetResult(true);

            IsVisible = false;
        }

        [RelayCommand]
        public void Reject()
        {
            completionSource.SetResult(false);

            IsVisible = false;
        }

        [RelayCommand]
        public void Dismiss()
        {
            completionSource.SetResult(false);

            IsVisible = false;
        }
    }
}
