
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PlutoFramework.Components.Xcavate
{
    
    public partial class XcavatePropertyNavigationBarViewModel : ObservableObject
    {
        public enum XcavatePropertyNavigationBarSelection
        {
            Details,
            Messages,
            Documents,
            Actions
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(DetailsIsSelected))]
        [NotifyPropertyChangedFor(nameof(MessagesIsSelected))]
        [NotifyPropertyChangedFor(nameof(DocumentsIsSelected))]
        [NotifyPropertyChangedFor(nameof(ActionsIsSelected))]
        private XcavatePropertyNavigationBarSelection selected = XcavatePropertyNavigationBarSelection.Messages;

        public bool DetailsIsSelected => Selected == XcavatePropertyNavigationBarSelection.Details;

        public bool MessagesIsSelected => Selected == XcavatePropertyNavigationBarSelection.Messages;

        public bool DocumentsIsSelected => Selected == XcavatePropertyNavigationBarSelection.Documents;
        
        public bool ActionsIsSelected => Selected == XcavatePropertyNavigationBarSelection.Actions;

        [RelayCommand]
        public async Task SelectDetailsAsync()
        {
            if (DetailsIsSelected)
            {
                return;
            }

            Selected = XcavatePropertyNavigationBarSelection.Details;

            await Shell.Current.GoToAsync("//Details", animate: false);
        }

        [RelayCommand]
        public async Task SelectMessagesAsync()
        {
            if (MessagesIsSelected)
            {
                return;
            }

            Selected = XcavatePropertyNavigationBarSelection.Messages;

            await Shell.Current.GoToAsync("//Messages", animate: false);
        }

        [RelayCommand]
        public async Task SelectDocumentsAsync()
        {
            if (DocumentsIsSelected)
            {
                return;
            }

            Selected = XcavatePropertyNavigationBarSelection.Documents;

            await Shell.Current.GoToAsync("//Documents", animate: false);
        }
        
        [RelayCommand]
        public async Task SelectActionsAsync()
        {
            if (ActionsIsSelected)
            {
                return;
            }

            Selected = XcavatePropertyNavigationBarSelection.Actions;

            await Shell.Current.GoToAsync("//Actions", animate: false);
        }
    }
}