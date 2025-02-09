using PlutoFramework.View;
using Microsoft.Maui.Controls;

namespace PlutoFramework.Components.Mnemonics;

public partial class MnemonicsExplanationPage : ContentPage
{
    public Command<string> OpenUrlCommand { get; }

    public MnemonicsExplanationPage()
    {
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

#pragma warning disable VSTHRD101 // Avoid unsupported async delegates
        OpenUrlCommand = new Command<string>(async (url) => await Launcher.OpenAsync(url).ConfigureAwait(true));
#pragma warning restore VSTHRD101 // Avoid unsupported async delegates

        InitializeComponent();
        BindingContext = this;
    }
}