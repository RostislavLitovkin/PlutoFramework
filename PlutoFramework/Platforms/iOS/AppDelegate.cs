using Foundation;
using PlutoFramework.Platforms.iOS;
using UIKit;

namespace PlutoFramework;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    public static PlutonicationIosBackgroundService PlutonicationService;
    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
        PlutonicationService = new PlutonicationIosBackgroundService();

        UIApplication.SharedApplication.SetMinimumBackgroundFetchInterval(double.MaxValue);

        // Add any additional setup code here

        return true;
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
