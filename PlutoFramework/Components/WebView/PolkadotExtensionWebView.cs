using Microsoft.Maui.Handlers;
using System.Diagnostics;
using System.Text.Json;

namespace PlutoFramework.Components.WebView;

public partial class PolkadotExtensionWebView : Microsoft.Maui.Controls.WebView
{
    private const string ScriptInterfaceName = "mauiWallet";

    private static readonly string ProviderInjectionScript = BuildProviderInjectionScript();

    private readonly PolkadotExtensionWalletBridge _walletBridge = new();

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
        => DispatchScriptSafeAsync(ProviderInjectionScript);

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

    private static string BuildProviderInjectionScript()
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
            return send('enable', {{ origin: origin }}).then(function () {{
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

    partial void InitializePlatformBridge(WebViewHandler handler);

    partial void DisconnectPlatformBridge();

    private partial Task DispatchScriptAsync(string script);
}
