using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Error;
using PlutoFramework.Components.Sumsub;
using PlutoFramework.Model;
using PlutoFramework.Model.Sumsub;

namespace PlutoFramework.Components.Xcavate
{
    public partial class UserTypeSelectionViewModel : ObservableObject
    {
        private bool loading = false;
        [RelayCommand]
        public async Task SelectDeveloperAsync()
        {
            if (loading)
            {
                return;
            }

            loading = true;
            var token = CancellationToken.None;

            await PermissionsModel.RequestCameraPermissionAsync();

            var applicant = new Applicant
            {
                ApplicantIdentifiers = new ApplicantIdentifiers
                {
                    Email = "ahojky email",
                    Phone = "ahojky phone",
                },
                totalInSeconds = 600,
                UserId = $"USER_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}",
                LevelName = "csharp-verification-test"
            };

            try
            {
                var accessToken = await SumsubModel.GenerateWebSDKAccessTokenAsync(applicant, token);

                Console.WriteLine("Trying to navigate to the page");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                await Application.Current.MainPage.Navigation.PushAsync(new SumsubWebSDKPage(accessToken ?? "", applicant));
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                Console.WriteLine("Navigation done");
            }
            catch (Exception ex)
            {
                Console.WriteLine("UserTypeSelectionPage error:");

                // Most likely bad internet connection

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                await Application.Current.MainPage.Navigation.PushAsync(new BadInternetConnectionPage());
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }

            loading = false;
        }
    }
}
