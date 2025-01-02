using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PlutoFramework.Components.Staking
{
	public partial class StakingRegistrationRequestViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isVisible;

        public StakingRegistrationRequestViewModel()
		{
            isVisible = false;
		}
	}
}

