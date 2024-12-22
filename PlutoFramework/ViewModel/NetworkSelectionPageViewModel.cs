using System;
using PlutoFramework.Constants;
using PlutoFramework.Components.NetworkSelect;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace PlutoFramework.ViewModel
{
    public class OptionsInfo
    {
        // Basically option indexes - I am just probably bad at naming things
        public int[] Groups { get; set; }
    }

	public partial class NetworkSelectionPageViewModel : ObservableObject
	{
        [ObservableProperty]
        private ObservableCollection<OptionsInfo> options = new ObservableCollection<OptionsInfo>();

        public NetworkSelectionPageViewModel()
		{
		}
	}
}

