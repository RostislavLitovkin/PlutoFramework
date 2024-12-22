using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PlutoFramework.Components.Xcm
{
	public partial class XcmTransferViewModel : ObservableObject
    {
		[ObservableProperty]
		private decimal amount; 

		public XcmTransferViewModel()
		{
			amount = 0;
		}
	}
}

