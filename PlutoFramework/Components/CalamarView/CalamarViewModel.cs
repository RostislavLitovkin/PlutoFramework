using System;
using PlutoFramework.Model;
using PlutoFramework.Constants;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PlutoFramework.Components.CalamarView
{
	public partial class CalamarViewModel : ObservableObject
	{
		[ObservableProperty]
		private string webAddress;
	}
}

