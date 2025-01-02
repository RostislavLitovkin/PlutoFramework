using System;
using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Components.WebView;

namespace PlutoFramework.Components.Staking
{
	public partial class StakingDashboardViewModel : ObservableObject
	{
		private const int EXTRA_HEIGHT = 35;

		[ObservableProperty]
		private double heightRequest;

		private ContentView content;
		public ContentView Content
		{
			get => content;
			set {
				SetProperty(ref content, value);
				HeightRequest = value.HeightRequest + EXTRA_HEIGHT;
			}
		}

		public StakingDashboardViewModel()
		{
			// The name `Content` with capital C is on purpose
			Content = new StakingEntryView();
		}
	}
}

