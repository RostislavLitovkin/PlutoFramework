using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PlutoFramework.ViewModel
{
	public partial class SetupPasswordViewModel : ObservableObject
	{
        [ObservableProperty]
        private string password;

        public SetupPasswordViewModel()
        {
            password = "";
        }
    }
}

