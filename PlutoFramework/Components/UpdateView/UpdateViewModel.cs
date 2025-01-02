using System;
using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Model;

namespace PlutoFramework.Components.UpdateView
{
	public partial class UpdateViewModel : ObservableObject
	{
		[ObservableProperty]
		private bool isVisible;

		public UpdateViewModel()
		{
			isVisible = false;
		}

		public async Task CheckLatestVersionAsync(string url, CancellationToken token)
		{
            int currentBuild = int.Parse(AppInfo.Current.BuildString);

			var plutoWalletVersion = await VersionModel.GetLatestVersionInfoAsync(url, token);

			if (plutoWalletVersion is null)
			{
				return;
			}

			Console.WriteLine("Versions: " + plutoWalletVersion.Version + " > " + currentBuild);

            IsVisible = plutoWalletVersion.Version > currentBuild;
        }
    }
}

