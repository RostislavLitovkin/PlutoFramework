using System;
using Substrate.NetApi.Model.Types.Base;
using PlutoFramework.Constants;
using PlutoFramework.Components.Events;
using System.Numerics;
using System.ComponentModel;

namespace PlutoFramework.Components.Extrinsic
{
	public class ExtrinsicInfo : INotifyPropertyChanged
	{
		public string ExtrinsicId { get; set; }

        private ExtrinsicStatusEnum status;
        public ExtrinsicStatusEnum Status
        {
            get => status;
            set { status = value; OnPropertyChanged(nameof(Status)); }
        }
		public TaskCompletionSource<EventsListViewModel> EventsListViewModel { get; set; } = new TaskCompletionSource<EventsListViewModel>();
        public Endpoint Endpoint { get; set; }
		public Hash Hash { get; set; }
		public string CallName { get; set; }
        public BigInteger BlockNumber { get; set; }
        public uint? ExtrinsicIndex { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

