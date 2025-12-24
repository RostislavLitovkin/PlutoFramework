#if IOS || MACCATALYST
using System;
using System.Threading.Tasks;
using Foundation;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Handlers;
using WebKit;

namespace PlutoFramework.Components.WebView;

public partial class PolkadotExtensionWebView
{
    private WKWebView? _nativeWebView;
    private WalletMessageHandler? _messageHandler;

    partial void InitializePlatformBridge(WebViewHandler handler)
    {
        if (handler.PlatformView is not WKWebView platformView)
        {
            return;
        }

        _nativeWebView = platformView;

        _messageHandler?.Dispose();
        _messageHandler = new WalletMessageHandler(this);
        platformView.Configuration.UserContentController.AddScriptMessageHandler(_messageHandler, ScriptInterfaceName);
    }

    partial void DisconnectPlatformBridge()
    {
        if (_nativeWebView is null)
        {
            return;
        }

        if (_messageHandler is not null)
        {
            _nativeWebView.Configuration.UserContentController.RemoveScriptMessageHandler(ScriptInterfaceName);
            _messageHandler.Dispose();
            _messageHandler = null;
        }

        _nativeWebView = null;
    }

    private partial Task DispatchScriptAsync(string script)
    {
        if (_nativeWebView is null)
        {
            return Task.CompletedTask;
        }

        var tcs = new TaskCompletionSource<bool>();

        MainThread.BeginInvokeOnMainThread(() =>
        {
            _nativeWebView.EvaluateJavaScript(script, (result, error) =>
            {
                if (error is not null)
                {
                    tcs.TrySetException(new NSErrorException(error));
                }
                else
                {
                    tcs.TrySetResult(true);
                }
            });
        });

        return tcs.Task;
    }

    private sealed class WalletMessageHandler : NSObject, IWKScriptMessageHandler
    {
        private readonly WeakReference<PolkadotExtensionWebView> _owner;

        public WalletMessageHandler(PolkadotExtensionWebView owner)
        {
            _owner = new(owner);
        }

        public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
        {
            if (!string.Equals(message.Name, ScriptInterfaceName, StringComparison.Ordinal))
            {
                return;
            }

            var raw = message.Body?.ToString();

            if (string.IsNullOrWhiteSpace(raw))
            {
                return;
            }

            if (_owner.TryGetTarget(out var view))
            {
                view.EnqueueWalletRequest(raw);
            }
        }
    }
}
#endif
