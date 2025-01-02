using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using System.Collections.ObjectModel;

namespace PlutoFramework.Components.Extrinsic
{
    public partial class CallDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private string palletCallName;

        [ObservableProperty]
        private Endpoint endpoint;

        [ObservableProperty]
        private ObservableCollection<EventParameter> callParameters = new ObservableCollection<EventParameter>();

        [ObservableProperty]
        private ObservableCollection<ExtrinsicEvent> extrinsicEvents = new ObservableCollection<ExtrinsicEvent>();
    }
}
