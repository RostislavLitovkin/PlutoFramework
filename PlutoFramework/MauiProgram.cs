﻿using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using ZXing.Net.Maui.Controls;

#if ANDROID26_0_OR_GREATER
using PlutoFramework.Platforms.Android;
#endif


namespace PlutoFramework;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseBarcodeReader()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("fontawesome-webfont.ttf", "FontAwesome");
                fonts.AddFont("Exodar-Outline.ttf", "Exodar");
                fonts.AddFont("FontOver.ttf", "FontOver");
                fonts.AddFont("sourcecode.ttf", "SourceCode");
                fonts.AddFont("samsungone700.ttf", "SamsungOne");
            });

        builder.AddAppSettings();

        //builder.Services.AddSingleton<Model.PlutonicationModel>();

        CustomizeWebViewHandler();

        var app = builder.Build();

        Services = app.Services;

        AppContext.SetSwitch("System.Reflection.NullabilityInfoContext.IsSupported", true);

        return app;
    }

    /// <summary>
    /// Source: https://montemagno.com/dotnet-maui-appsettings-json-configuration/
    /// </summary>
    public static IServiceProvider Services { get; private set; }
    private static void AddAppSettings(this MauiAppBuilder builder)
    {
        using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PlutoFramework.appsettings.json");

        if (stream is null)
        {
            return;
        }

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();

        builder.Configuration.AddConfiguration(configuration);
    }

    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/webview?view=net-maui-9.0&pivots=devices-android#handle-permissions-on-android
    /// </summary>
    private static void CustomizeWebViewHandler()
    {
#if ANDROID26_0_OR_GREATER
        Microsoft.Maui.Handlers.WebViewHandler.Mapper.ModifyMapping(
            nameof(Android.Webkit.WebView.WebChromeClient),
            (handler, view, args) => handler.PlatformView.SetWebChromeClient(new WebChromeClientWithPermissions(handler)));
#endif
    }
}
