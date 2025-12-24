#if ANDROID
using System;
using System.Threading.Tasks;
using Android.Webkit;
using Java.Interop;
using Microsoft.Maui.Handlers;

namespace PlutoFramework.Components.WebView;

public partial class PolkadotExtensionWebView
{
    private Android.Webkit.WebView? _nativeWebView;
    private WalletJavascriptInterface? _javascriptInterface;

    partial void InitializePlatformBridge(WebViewHandler handler)
    {
        if (handler.PlatformView is not Android.Webkit.WebView platformView)
        {
            return;
        }

        _nativeWebView = platformView;

        _javascriptInterface?.Dispose();
        _javascriptInterface = new WalletJavascriptInterface(this);
        platformView.AddJavascriptInterface(_javascriptInterface, ScriptInterfaceName);
    }

    partial void DisconnectPlatformBridge()
    {
        if (_nativeWebView is not null)
        {
            try
            {
                _nativeWebView.RemoveJavascriptInterface(ScriptInterfaceName);
            }
            catch
            {
                // Ignored — RemoveJavascriptInterface is not available on older APIs
            }
        }

        _javascriptInterface?.Dispose();
        _javascriptInterface = null;
        _nativeWebView = null;
    }

    private partial Task DispatchScriptAsync(string script)
    {
        if (_nativeWebView is null)
        {
            return Task.CompletedTask;
        }

        var tcs = new TaskCompletionSource<bool>();

        _nativeWebView.Post(new Java.Lang.Runnable(() =>
        {
            try
            {
                _nativeWebView.EvaluateJavascript(script, null);
                tcs.TrySetResult(true);
            }
            catch (Exception ex)
            {
                tcs.TrySetException(ex);
            }
        }));

        return tcs.Task;
    }

    private sealed class WalletJavascriptInterface : Java.Lang.Object
    {
        private readonly WeakReference<PolkadotExtensionWebView> _owner;

        public WalletJavascriptInterface(PolkadotExtensionWebView owner)
        {
            _owner = new(owner);
        }

        [JavascriptInterface]
        [Export("walletCall")]
        public void WalletCall(string json)
        {
            if (_owner.TryGetTarget(out var view))
            {
                view.EnqueueWalletRequest(json);
            }
        }
    }
}
#endif
