namespace PlutoFrameworkCore.PushNotificationServices.Core.Utils;

public static class RetryHelper
{
    public static async Task RunWithRetryAsync(
        Func<Task> action,
        int maxAttempts = 5,
        TimeSpan? initialDelay = null,
        double backoffFactor = 2.0,
        Func<Exception, bool>? isTransient = null,
        Action<Exception, int>? onError = null)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(maxAttempts, 1);

        var delay = initialDelay ?? TimeSpan.FromSeconds(5);

        for (var attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                await action();
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PlutoNotifications] Attempt {attempt}: failed");
                if (attempt >= maxAttempts || (isTransient != null && !isTransient(ex)))
                    throw;

                onError?.Invoke(ex, attempt);

                await Task.Delay(delay);
                delay = TimeSpan.FromMilliseconds(delay.TotalMilliseconds * backoffFactor);
            }
        }
    }
}