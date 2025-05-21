using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using Substrate.NetApi;
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
        [NotifyPropertyChangedFor(nameof(EncodedCallText))]
        private byte[] encodedCall = [];

        public string EncodedCallText => Utils.Bytes2HexString(EncodedCall);

        [ObservableProperty]
        private ObservableCollection<EventParameter> callParameters = new ObservableCollection<EventParameter>();

        [ObservableProperty]
        private ObservableCollection<ExtrinsicEvent> extrinsicEvents = new ObservableCollection<ExtrinsicEvent>();
    }
}
