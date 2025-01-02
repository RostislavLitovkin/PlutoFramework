using System;
using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Model.AzeroId;
using PlutoFramework.Model;
using PlutoFramework.Model.AjunaExt;
using AzeroIdResolver;

namespace PlutoFramework.Components.AzeroId
{
	public partial class AzeroPrimaryNameViewModel : ObservableObject
	{
		[ObservableProperty]
		private string primaryName;

		[ObservableProperty]
		private string tld;

		[ObservableProperty]
		private string reservedUntil;

		[ObservableProperty]
		private bool reservedUntilIsVisible;

		public AzeroPrimaryNameViewModel()
		{
			primaryName = "Loading";
			reservedUntilIsVisible = false;
		}

		public async Task GetPrimaryName(PlutoFrameworkSubstrateClient client)
		{
			
		}
	}
}

