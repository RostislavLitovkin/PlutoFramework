using PlutoFramework.Constants;
using System;
using System.ComponentModel;
namespace PlutoFramework.Components.NetworkSelect
{
    public class NetworkSelectInfo : INotifyPropertyChanged
    {
        public EndpointEnum EndpointKey { get; set; }
        public bool ShowName { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string DarkIcon { get; set; }
        public EndpointConnectionStatus EndpointConnectionStatus { get; set; }


        private bool isSelected;
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public enum EndpointConnectionStatus
{
    None, // This is the ViewModel bug in .net MAUI, it has to be here
    Loading,
    Connected,
    Failed,
}

