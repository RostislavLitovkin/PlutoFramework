using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Model;
using System.Collections.ObjectModel;

namespace PlutoFramework.Components.Events
{
    public partial class EventsListViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ExtrinsicEvent> extrinsicEvents = new ObservableCollection<ExtrinsicEvent>();
    }
}
