using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Model;

namespace PlutoFramework.Components.HydraDX
{
	public partial class DCAViewModel : ObservableObject
	{
		[ObservableProperty]
		private ObservableCollection<DCAOrderInfo> orders = new ObservableCollection<DCAOrderInfo>();

		[ObservableProperty]
		private string loading;

		public DCAViewModel()
		{
			loading = "Loading";
        }

		public async Task GetDCAAsync(Hydration.NetApi.Generated.SubstrateClientExt client, CancellationToken token)
		{
            Loading = "Loading";
            List<DCAOrderInfo> infos = new List<DCAOrderInfo>();

            var positions = await Model.HydraDX.DCAModel.GetDCAPositionsAsync(client, KeysModel.GetSubstrateKey(), token);

            if (positions.Count() == 0)
            {
                Loading = "None";
                return;
            }

            foreach (var position in positions)
            {
                infos.Add(new DCAOrderInfo
                {
                    Amount = String.Format(DefaultAppConfiguration.CURRENCY_FORMAT, position.Amount),
                    FromSymbol = position.FromSymbol,
                    ToSymbol = position.ToSymbol,
                    Time = position.RemainingDays > 0 ? position.RemainingDays + " Days" : position.RemainingHours + " Hours",
                });
            }

            Orders = new ObservableCollection<DCAOrderInfo>(infos);

            Loading = "";
        }
	}

	public class DCAOrderInfo
	{
		public string Amount { get; set; }
        public string FromSymbol { get; set; }
        public string ToSymbol { get; set; }
        public string Time { get; set; }
    }
}

