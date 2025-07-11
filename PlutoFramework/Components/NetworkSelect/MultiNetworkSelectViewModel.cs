using PlutoFramework.Constants;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using PlutoFramework.Model;

namespace PlutoFramework.Components.NetworkSelect
{
    public partial class MultiNetworkSelectViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<NetworkSelectInfo> networkInfos = new ObservableCollection<NetworkSelectInfo>();

        public Dictionary<EndpointEnum, NetworkSelectInfo> NetworkInfoDict = new Dictionary<EndpointEnum, NetworkSelectInfo>();

        public EndpointEnum? SelectedKey { get; set; }

        [ObservableProperty]
        private bool clicked;

        /// <summary>
        /// Also called in the BasePageViewModel
        /// </summary>
        public void ChangeSelectedEndpoints(IEnumerable<EndpointEnum> selectedEndpointKeys)
        {
            foreach (var key in selectedEndpointKeys)
            {
                if (NetworkInfoDict.ContainsKey(key))
                {
                    continue;
                }

                Endpoint endpoint = EndpointsModel.GetEndpoint(key);
                NetworkInfoDict.Add(key, new NetworkSelectInfo
                {
                    EndpointKey = key,
                    ShowName = false,
                    IsSelected = false,
                    Name = endpoint.Name,
                    Icon = endpoint.Icon,
                    DarkIcon = endpoint.DarkIcon,
                    EndpointConnectionStatus = EndpointConnectionStatus.Loading,
                });
            }

            // Set the first endpoint of the group to be the "main" client
            if (!(SelectedKey.HasValue && NetworkInfoDict.ContainsKey(SelectedKey.Value)))
            {
                SelectFirst();
            }

            UpdateNetworkInfos();
        }

        public EndpointEnum SelectFirst()
        {
            var firstNetwork = NetworkInfoDict.First();

            firstNetwork.Value.IsSelected = true;
            firstNetwork.Value.ShowName = true;

            SelectedKey = firstNetwork.Key;

            return firstNetwork.Key;
        }

        public void SelectEndpoint(EndpointEnum selectedEndpointKey)
        {
            if (SelectedKey is not null)
            {
                NetworkInfoDict[SelectedKey.Value].ShowName = false;
                NetworkInfoDict[SelectedKey.Value].IsSelected = false;
            }

            SelectedKey = selectedEndpointKey;

            NetworkInfoDict[selectedEndpointKey].ShowName = true;
            NetworkInfoDict[selectedEndpointKey].IsSelected = true;

            UpdateNetworkInfos();
        }

        public void UpdateNetworkInfos()
        {

            var networkInfos = new ObservableCollection<NetworkSelectInfo>();
            foreach (var info in NetworkInfoDict.Values)
            {
                networkInfos.Add(new NetworkSelectInfo
                {
                    ShowName = info.ShowName,
                    Name = info.Name,
                    Icon = info.Icon,
                    EndpointKey = info.EndpointKey,
                    DarkIcon = info.DarkIcon,
                    EndpointConnectionStatus = info.EndpointConnectionStatus,
                    IsSelected = info.IsSelected,
                });
            }

            NetworkInfos = networkInfos;

            Console.WriteLine("Updated network infos");
        }
    }
}

