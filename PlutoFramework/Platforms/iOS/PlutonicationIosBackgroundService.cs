using PlutoFramework.Model;
using UIKit;

namespace PlutoFramework.Platforms.iOS
{
    /// <summary>
    /// Source: https://stackoverflow.com/questions/71259615/how-to-create-a-background-service-in-net-maui
    /// </summary>
    public class PlutonicationIosBackgroundService
    {
        nint _taskId;
        CancellationTokenSource _cts;
        public bool isStarted = false;

        public async Task StartAsync()
        {
            _cts = new CancellationTokenSource();
            _taskId = UIApplication.SharedApplication.BeginBackgroundTask("com.xcavate.realxmarket.plutonication", OnExpiration);

            try
            {
                await PlutonicationModel.AcceptConnectionAsync();
            }
            catch (OperationCanceledException)
            {
                // Handle exception
            }
            finally
            {
                // Stop Plutonication
            }

            var time = UIApplication.SharedApplication.BackgroundTimeRemaining;

            // Does this mean that it will never stop? :D
            // UIApplication.SharedApplication.EndBackgroundTask(_taskId);

        }

        public void Stop()
        {
            isStarted = false;
            _cts.Cancel();
        }

        void OnExpiration()
        {
            UIApplication.SharedApplication.EndBackgroundTask(_taskId);
        }
    }
}
