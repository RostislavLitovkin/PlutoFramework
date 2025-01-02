

using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Model;
using System.Collections.ObjectModel;

namespace PlutoFramework.Components.Events
{
    public partial class EventItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<EventParameter> parametersList = new ObservableCollection<EventParameter>();
    }
}
