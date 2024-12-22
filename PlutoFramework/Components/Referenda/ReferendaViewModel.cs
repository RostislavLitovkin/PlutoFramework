using System;
using System.Collections.ObjectModel;
using System.Numerics;
using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using PlutoFramework.Model.SubSquare;

namespace PlutoFramework.Components.Referenda
{
	public partial class ReferendaViewModel : ObservableObject
	{
		[ObservableProperty]
		private ObservableCollection<ReferendumInfo> referenda = new ObservableCollection<ReferendumInfo>();

		[ObservableProperty]
		private string loading;

		public ReferendaViewModel()
		{
			loading = "Loading";
		}

		public void UpdateReferenda()
		{
            if (Referenda.Count() == ReferendumModel.Referenda.Values.Count())
			{
				return;
			}

			Loading = "";

            Referenda = new ObservableCollection<ReferendumInfo>(ReferendumModel.Referenda.Values);
		}

		public void NoReferenda()
		{
			if (Referenda.Count() != 0)
			{
				return;
			}

			Loading = "No votes casted";
		}
	}
}

