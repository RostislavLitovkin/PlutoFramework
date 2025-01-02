using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PlutoFramework.Components.ChangeLayoutRequest
{
	public partial class ChangeLayoutRequestViewModel : ObservableObject
	{
		[ObservableProperty]
		private bool isVisible;

		public ChangeLayoutRequestViewModel()
		{
			isVisible = false;
		}

		
	}
}

