using System;
using PlutoWallet.Model;
using PlutoWallet.Constants;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PlutoWallet.Components.CalamarView
{
	public partial class CalamarViewModel : ObservableObject
	{
		[ObservableProperty]
		private string webAddress;
	}
}

