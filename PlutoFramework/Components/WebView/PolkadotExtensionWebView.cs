using Microsoft.Maui.Handlers;
using PlutoFramework.Model;
using System.Diagnostics;
using System.Text.Json;

namespace PlutoFramework.Components.WebView;

public partial class PolkadotExtensionWebView : Microsoft.Maui.Controls.WebView
{
    private const string ScriptInterfaceName = "mauiWallet";

    private uint? tabId = null;

    private readonly PolkadotExtensionWalletBridge _walletBridge = new();

    public event EventHandler<Microsoft.Maui.Controls.ScrolledEventArgs>? Scrolled;

    public PolkadotExtensionWebView()
    {
        Navigated += OnNavigated;
    }

    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();

        if (Handler is WebViewHandler handler)
        {
            InitializePlatformBridge(handler);
        }
        else
        {
            DisconnectPlatformBridge();
        }
    }

    private void OnNavigated(object? sender, WebNavigatedEventArgs e)
    {
        if (e.Result != WebNavigationResult.Success)
        {
            return;
        }

        _ = InjectProviderAsync();
    }

    internal void EnqueueWalletRequest(string requestJson)
    {
        if (string.IsNullOrWhiteSpace(requestJson))
        {
            return;
        }

        _ = ProcessWalletRequestAsync(requestJson);
    }

    private async Task ProcessWalletRequestAsync(string requestJson)
    {
        try
        {
            var responseJson = await _walletBridge.HandleAsync(requestJson).ConfigureAwait(false);
            await DispatchScriptSafeAsync($"window.__mauiWalletDeliver({responseJson});").ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[PlutoWallet] Failed to process wallet request: {ex.Message}");

            var fallback = new
            {
                id = TryExtractId(requestJson),
                error = ex.Message
            };

            var fallbackJson = JsonSerializer.Serialize(fallback, PolkadotExtensionWalletBridge.SerializerOptions);
            await DispatchScriptSafeAsync($"window.__mauiWalletDeliver({fallbackJson});").ConfigureAwait(false);
        }
    }

    private Task InjectProviderAsync()
    {
        if (tabId is null)
        {
            tabId = ExtensionWebViewModel.GetNextTabId();
        }

        ExtensionWebViewModel.TabInfos[tabId.Value] = GetDAppInfo();

        return DispatchScriptSafeAsync(BuildProviderInjectionScript());
    }

    private Task DispatchScriptSafeAsync(string script)
    {
        if (string.IsNullOrWhiteSpace(script) || Handler is null)
        {
            return Task.CompletedTask;
        }

        return DispatchScriptAsync(script);
    }

    private static string? TryExtractId(string json)
    {
        try
        {
            using var doc = JsonDocument.Parse(json);
            if (doc.RootElement.TryGetProperty("id", out var idProperty))
            {
                return idProperty.GetString();
            }
        }
        catch
        {
            // ignored on purpose
        }

        return null;
    }

    private string BuildProviderInjectionScript()
    {
        return @$"(function () {{
    if (window.__plutoWalletInjected) {{ return; }}
    const channel = '{ScriptInterfaceName}';
    if (typeof window === 'undefined' || !window[channel] || !window[channel].walletCall) {{
        console.warn('Pluto wallet bridge is unavailable on this platform.');
        return;
    }}
    window.__plutoWalletInjected = true;
    const pending = {{}};
    window.__mauiWalletDeliver = function (message) {{
        try {{
            var payload = (typeof message === 'string') ? JSON.parse(message) : message;
            if (!payload || !payload.id || !pending[payload.id]) {{ return; }}
            var entry = pending[payload.id];
            delete pending[payload.id];
            if (payload.error) {{
                entry.reject(payload.error);
            }} else {{
                entry.resolve(payload.result);
            }}
        }} catch (err) {{
            console.error('Wallet deliver failure', err);
        }}
    }};
    function send(method, payload) {{
        return new Promise(function (resolve, reject) {{
            const id = `${{Date.now()}}-${{Math.random().toString(16).slice(2)}}`;
            pending[id] = {{ resolve: resolve, reject: reject }};
            try {{
                window[channel].walletCall(JSON.stringify({{ id: id, method: method, payload: payload }}));
            }} catch (err) {{
                delete pending[id];
                reject(err);
            }}
        }});
    }}
    const providerName = '{PolkadotExtensionWalletBridge.ProviderName}';
    window.injectedWeb3 = window.injectedWeb3 || {{}};
    if (window.injectedWeb3[providerName]) {{
        console.warn('Wallet provider already exists.');
        return;
    }}
    window.injectedWeb3[providerName] = {{
        name: '{AppInfo.Name}',
        version: '{AppInfo.VersionString}',
        enable: function (origin) {{
            return send('enable', {{ origin: origin, tabId: {tabId} }}).then(function () {{
                return {{
                    accounts: {{
                        get: function () {{ return send('accounts.get'); }},
                        subscribe: function (cb) {{
                            var active = true;
                            function emit() {{
                                send('accounts.get').then(function (accounts) {{
                                    if (active) {{ cb(accounts); }}
                                }}).catch(function (error) {{
                                    console.error('Wallet accounts.subscribe error', error);
                                }});
                            }}
                            emit();
                            return function () {{ active = false; }};
                        }}
                    }},
                    signer: {{
                        signRaw: function (raw) {{ return send('signRaw', raw); }},
                        signPayload: function (payloadJson) {{ return send('signPayload', payloadJson); }}
                    }}
                }};
            }});
        }}
    }};
}})();";
    }

    private DAppInfo GetDAppInfo()
    {
        var url = GetCurrentUrl() ?? string.Empty;
        var title = GetCurrentTitle();
        var icon = BuildFaviconSource(url);

        return new DAppInfo
        {
            Icon = icon,
            Name = string.IsNullOrWhiteSpace(title) ? (TryGetHost(url) ?? string.Empty) : title,
            Url = url
        };
    }

    private string? GetCurrentUrl()
    {
#if ANDROID
        if (!string.IsNullOrWhiteSpace(_nativeWebView?.Url))
        {
            return _nativeWebView.Url;
        }
#elif IOS || MACCATALYST
        if (_nativeWebView?.Url is not null)
        {
            return _nativeWebView.Url.ToString();
        }
#endif

        if (Source is UrlWebViewSource urlSource)
        {
            return urlSource.Url;
        }

        return null;
    }

    private string? GetCurrentTitle()
    {
#if ANDROID
        if (!string.IsNullOrWhiteSpace(_nativeWebView?.Title))
        {
            return _nativeWebView.Title;
        }
#elif IOS || MACCATALYST
        if (!string.IsNullOrWhiteSpace(_nativeWebView?.Title))
        {
            return _nativeWebView.Title;
        }
#endif

        return null;
    }

    private static ImageSource BuildFaviconSource(string? url)
    {
        if (Uri.TryCreate(url, UriKind.Absolute, out var uri))
        {
            // Use Google's favicon service to return a PNG image that Glide can decode reliably.
            var host = uri.IsDefaultPort ? uri.Host : $"{uri.Host}:{uri.Port}";
            var faviconUri = new Uri($"https://www.google.com/s2/favicons?domain={Uri.EscapeDataString(host)}&sz=256");
            return ImageSource.FromUri(faviconUri);
        }

        return ImageSource.FromStream(() => Stream.Null);
    }

    private static string? TryGetHost(string? url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out var uri)
            ? uri.Host
            : null;
    }

    partial void InitializePlatformBridge(WebViewHandler handler);

    partial void DisconnectPlatformBridge();

    private partial Task DispatchScriptAsync(string script);

    internal void RaiseScrolled(double x, double y)
    {
        Scrolled?.Invoke(this, new Microsoft.Maui.Controls.ScrolledEventArgs(x, y));
    }
}
