using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PlutoFramework.Components.NavigationBar
{
	public partial class NavigationBarViewModel : ObservableObject
    {
		[ObservableProperty]
		private FontAttributes nftsFontAttributes;

        [ObservableProperty]
        private FontAttributes homeFontAttributes;

        public NavigationBarViewModel()
		{
			homeFontAttributes = FontAttributes.Bold;
			nftsFontAttributes = FontAttributes.None;
        }
	}
}

