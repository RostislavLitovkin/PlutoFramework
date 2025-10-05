using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

using Tab = PlutoFramework.Components.Tabs.Tab;

namespace PlutoFramework.Components.Notifications
{
    public partial class NotificationsPageViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SelectedFilter))]
        [NotifyPropertyChangedFor(nameof(Notifications))]
        private ObservableCollection<Tab> tabs = new ObservableCollection<Tab>(
            new List<NotificationType>([NotificationType.All, NotificationType.Announcement, NotificationType.System])
                .Select(filter => new Tab
                {
                    Title = filter switch
                    {
                        NotificationType.All => "All",
                        NotificationType.Announcement => "Announcements",
                        NotificationType.System => "System",
                        _ => "Unknown"
                    },
                    IsSelected = filter == NotificationType.All,
                    Value = filter
                })
            );

        public NotificationType SelectedFilter => (NotificationType)Tabs.FirstOrDefault(
            tab => tab.IsSelected,
            new Tab { IsSelected = true, Title = "All", Value = NotificationType.All }
        ).Value;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Notifications))]
        private List<Notification> allNotifications = new List<Notification>([
            new Notification
            {
                Title = "New property minted",
                Message = "You have minted a new property and has been added to your drafts while awaiting verification of documents",
                Date = DateTime.Now,
                Type = NotificationType.System,
                WasRead = false,
            },
            new Notification
            {
                Title = "Long message test",
                Message = "Very very long something very long text here this one will be super duper long that nobody will ever believe that somebody can write such a long and useless sentence. Do you believe now",
                Date = DateTime.Now,
                Type = NotificationType.Announcement,
                WasRead = true,
            },
            new Notification
            {
                Title = "New property minted",
                Message = "You have minted a new property and has been added to your drafts while awaiting verification of documents",
                Date = new DateTime(DateTime.Now.Subtract(new DateTime(((long)10000)*3600*24)).Ticks),
                Type = NotificationType.System,
                WasRead = false,
            }]);

        public ObservableCollection<Notification> Notifications => new ObservableCollection<Notification>(
            AllNotifications.Where(n => n.Type == SelectedFilter || SelectedFilter == NotificationType.All)
        );

        [RelayCommand]
        public void SelectTab(object parameter)
        {
            Console.WriteLine("Select tab");

            var filter = parameter as NotificationType?;

            if (filter == SelectedFilter)
                return;


            Tabs = new ObservableCollection<Tab>(Tabs.Select(tab =>
            {
                return new Tab
                {
                    Title = tab.Title,
                    Value = tab.Value,
                    IsSelected = (NotificationType)tab.Value == filter
                };
            }));
        }
    }
}
