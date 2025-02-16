using PlutoFramework.Model.Sumsub;
using System.Web;

namespace PlutoFramework.Components.Sumsub
{
    public partial class SumsubWebSDKPage : ContentPage
    {
        public SumsubWebSDKPage(string accessToken, Applicant applicant)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Shell.SetNavBarIsVisible(this, false);

            InitializeComponent();

            webView.Source = new HtmlWebViewSource
            {
                Html = @"
<html>

<head>
  <script src=""https://static.sumsub.com/idensic/static/sns-websdk-builder.js""></script>
</head>

<body>
  <div id=""sumsub-websdk-container""></div>

  <script>
    /**
     * @param accessToken - access token that you generated on the backend
     * @param applicantEmail - applicant email (not required)
     * @param applicantPhone - applicant phone (not required)
     * @param customI18nMessages - customized locale messages for current session (not required)
     */
    function launchWebSdk(accessToken, applicantEmail, applicantPhone, customI18nMessages) {
      let snsWebSdkInstance = snsWebSdk
        .init(
          accessToken,
          // token update callback, must return Promise
          // Access token expired
          // get a new one and pass it to the callback to re-initiate the WebSDK
          () => this.getNewAccessToken()
        )
        .withConf({
          lang: ""en"", //language of WebSDK texts and comments (ISO 639-1 format)
          email: applicantEmail,
          phone: applicantPhone,
          theme: ""dark"" | ""light"",
        })
        .withOptions({ addViewportTag: false, adaptIframeHeight: true })
        // see below what kind of messages WebSDK generates
        .on(""idCheck.onStepCompleted"", (payload) => {
          console.log(""onStepCompleted"", payload);
        })
        .on(""idCheck.onApplicantSubmitted"", (payload) => {
            console.log(""onApplicantSubmitted"", payload);
            window.location.href = ""/someRandomPageDoesntMatter?operation=completed"";
        })
        .on(""idCheck.onError"", (error) => {
          console.log(""onError"", error);
        })
        .build();

      // you are ready to go:
      // just launch the WebSDK by providing the container element for it
      snsWebSdkInstance.launch(""#sumsub-websdk-container"");
    }

    function getNewAccessToken() {
      return Promise.resolve(""ahojky""); // get a new token from your backend
    }

    launchWebSdk(
        """ + accessToken + @""",
        """ + applicant.ApplicantIdentifiers.Email + @""",
        """ + applicant.ApplicantIdentifiers.Phone + @"""
    )
  </script>
</body>

</html>
                "
            };
        }

        private async void OnNavigated(object sender, WebNavigatedEventArgs e)
        {
            Uri uri = new Uri(e.Url);
            var queryParams = HttpUtility.ParseQueryString(uri.Query);

            // Check if the 'registrationId' query parameter exists
            string operation = queryParams.Get("operation");

            if (operation == "completed")
            {
                await Navigation.PushAsync(new VerificationCompletedPage());
            }
        }
    }
}