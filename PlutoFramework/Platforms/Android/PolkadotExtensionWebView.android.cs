#if ANDROID
using System;
using System.Threading.Tasks;
using Android.Views;
using Android.Webkit;
using Java.Interop;
using Microsoft.Maui.Handlers;

namespace PlutoFramework.Components.WebView;

public partial class PolkadotExtensionWebView
{
    private Android.Webkit.WebView? _nativeWebView;
    private WalletJavascriptInterface? _javascriptInterface;
    private ScrollChangedListener? _scrollListener;

    partial void InitializePlatformBridge(WebViewHandler handler)
    {
        if (handler.PlatformView is not Android.Webkit.WebView platformView)
        {
            return;
        }

        _nativeWebView = platformView;

        AttachScrollListener(platformView);

        _javascriptInterface?.Dispose();
        _javascriptInterface = new WalletJavascriptInterface(this);
        platformView.AddJavascriptInterface(_javascriptInterface, ScriptInterfaceName);
    }

    partial void DisconnectPlatformBridge()
    {
        DetachScrollListener();

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

    private void AttachScrollListener(Android.Webkit.WebView platformView)
    {
        DetachScrollListener();

        if (platformView.ViewTreeObserver?.IsAlive != true)
        {
            return;
        }

        var listener = new ScrollChangedListener(this, platformView);
        platformView.ViewTreeObserver.AddOnScrollChangedListener(listener);
        _scrollListener = listener;
    }

    private void DetachScrollListener()
    {
        if (_nativeWebView?.ViewTreeObserver?.IsAlive == true && _scrollListener is not null)
        {
            _nativeWebView.ViewTreeObserver.RemoveOnScrollChangedListener(_scrollListener);
        }

        _scrollListener?.Dispose();
        _scrollListener = null;
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

    private sealed class ScrollChangedListener : Java.Lang.Object, ViewTreeObserver.IOnScrollChangedListener
    {
        private readonly WeakReference<PolkadotExtensionWebView> _owner;
        private readonly WeakReference<Android.Webkit.WebView> _nativeWebView;

        public ScrollChangedListener(PolkadotExtensionWebView owner, Android.Webkit.WebView nativeWebView)
        {
            _owner = new(owner);
            _nativeWebView = new(nativeWebView);
        }

        public void OnScrollChanged()
        {
            if (_owner.TryGetTarget(out var owner) && _nativeWebView.TryGetTarget(out var native))
            {
                owner.RaiseScrolled(native.ScrollX, native.ScrollY);
            }
        }
    }
}
#endif
