using PlutoFramework.Model.Sumsub;
using System.Web;

namespace PlutoFramework.Components.Sumsub
{
    public partial class SumsubWebSDKPage : ContentPage
    {
        private Func<Task> navigation;
        public SumsubWebSDKPage(string accessToken, Applicant applicant, Func<Task> navigation)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Shell.SetNavBarIsVisible(this, false);

            InitializeComponent();

            var topNavigationBarHeight = (double)Application.Current.Resources["TopNavigationBarHeight"];

            webView.Margin = new Thickness(0, topNavigationBarHeight, 0, 0);

            webView.Source = new HtmlWebViewSource
            {
                Html = @"
<html>

<head>
  <meta name='viewport' content='width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no'>
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
            
            const temp = window.location.href;

            window.location.href = ""https://google.com/?myoperation=completed"";

            //window.location.href = temp + ""?myoperation=completed"";
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

    function updateUrl() {
        window.location.href = ""/someRandomPageDoesntMatter?myoperation=completed"";
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

            this.navigation = navigation;
        }

        private bool navigated = false;
        private async void OnNavigating(object sender, WebNavigatingEventArgs e)
        {
            Uri uri = new Uri(e.Url);
            var queryParams = HttpUtility.ParseQueryString(uri.Query);

            // Check if the 'registrationId' query parameter exists
            string operation = queryParams.Get("myoperation");

            Console.WriteLine("myoperation: " + operation);

            if (operation == "completed")
            {
                if (navigated)
                {
                    return;
                }

                navigated = true;

                await navigation.Invoke();
                //Application.Current.MainPage = new XcavateAppShell();
            }
        }
    }
}